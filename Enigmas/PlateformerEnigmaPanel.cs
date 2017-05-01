using Cpln.Enigmos.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas {
    class PlateformerEnigmaPanel : EnigmaPanel {
        
        Hero _hero = new Hero(0, 300, 50, 50);
        Badboy _badboy;
        Rectangle _rWin;
        Rectangle[] _tPlateformes;

        public PlateformerEnigmaPanel() {
            _hero.Moved += new EventHandler(_hero_Moved);
            Paint += PlateformerEnigmaPanel_Paint;

            _tPlateformes = new Rectangle[] {
                new Rectangle(0, Height - 50, 200, 50),
                new Rectangle(250, Height - 200, 200, 50),
                new Rectangle(270, Height - 400, 200, 50),
                new Rectangle(600, Height - 500, 200, 50)
            };

            _badboy = new Badboy(_tPlateformes[_tPlateformes.Length - 2].X, _tPlateformes[_tPlateformes.Length - 2].Y - 40, 40, 40, _tPlateformes[_tPlateformes.Length - 2].Right - 40);
            _badboy.Moved += delegate {
                if (_hero.Rectangle.IntersectsWith(_badboy.Rectangle)) {
                    _hero.Dead();
                }
                Invalidate();
            };

            _rWin = new Rectangle(_tPlateformes.Last().X + _tPlateformes.Last().Width - 30, _tPlateformes.Last().Y - 30, 30, 30);

            _hero.Jump(true);
        }

        private void _hero_Moved(object sender, EventArgs e) {
            foreach (Rectangle _r in _tPlateformes) {
                if (_hero.Rectangle.Bottom == _r.Top && (_hero.Rectangle.Right >= _r.Left && _hero.Rectangle.Left <= _r.Right) && _hero.JumpFinish) {
                    _hero.IsJumping = false;
                    break;
                } else if (_hero.Rectangle.Bottom == _r.Top && !(_hero.Rectangle.Right >= _r.Left && _hero.Rectangle.Left <= _r.Right) && !_hero.IsJumping) {
                    _hero.JumpFinish = true;
                    _hero.IsJumping = true;
                } else if (_hero.Y >= Width) {
                    _hero.SetPosition(0, 0);
                }
            }
            Invalidate();

            if (_hero.Rectangle.IntersectsWith(_rWin)) {
                _hero.Dead();
                MessageBox.Show("Ugwemuhwem");
            }
        }

        private void PlateformerEnigmaPanel_Paint(object sender, PaintEventArgs e) {
            e.Graphics.FillRectangles(Brushes.ForestGreen, _tPlateformes);
            e.Graphics.FillRectangle(Brushes.LightGray, _hero.Rectangle);
            e.Graphics.DrawImage(_hero.Texture, _hero.Rectangle);
            e.Graphics.FillRectangle(Brushes.Black, _badboy.Rectangle);
            e.Graphics.DrawImage(new Bitmap(Resources.Coin), _rWin);
        }

        public override void PressKey(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.D:
                _hero.MoveX(1);
                break;

                case Keys.A:
                _hero.MoveX(-1);
                break;

                case Keys.W:
                _hero.Jump(false);
                break;
            }
        }

        public override void ReleaseKey(object sender, KeyEventArgs e) {
            _hero.MoveX(0);
        }
    }

    public abstract class Boy {
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public int Width { get; protected set; }
        public int Height { get; protected set; }
        public abstract event EventHandler Moved;

        public Rectangle Rectangle {
            get { return new Rectangle(X, Y, Width, Height); }
        }
        protected Timer Timer { get; set; } = new Timer() { Enabled = true, Interval = 1 };

        protected Boy(int X, int Y, int Width, int Height) {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;

            Timer.Tick += Timer_Tick;
        }

        protected abstract void Timer_Tick(object sender, EventArgs e);
    }

    public class Badboy : Boy {
        public override event EventHandler Moved;
        private int iXMin;
        private int iXMax;
        private bool bMax = false;

        public Badboy(int X, int Y, int Width, int Height, int XMax) : base(X, Y, Width, Height) {
            iXMin = X;
            iXMax = XMax;
        }

        protected override void Timer_Tick(object sender, EventArgs e) {
            if (X < iXMax && !bMax) {
                X++;
                bMax = X >= iXMax;
            } if (bMax) {
                X--;
                bMax = X >= iXMin;
            }
            Moved?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Hero : Boy {
        public bool IsJumping { get; set; }
        public bool JumpFinish { get; set; }
        public Bitmap Texture { get; set; }
        public override event EventHandler Moved;

        private Bitmap[] Textures = new Bitmap[6];
        private int iJump;
        private int iTexture = 0;
        private int iIntervalTexture = 0;
        private int iDirection;

        public Hero(int X, int Y, int Width, int Height) : base (X, Y, Width, Height) {
            int tX = 0;
            Bitmap _OriginalTexture = new Bitmap(Resources.Player);
            for (int i = 0; i < 6; i++) {
                Textures[i] = _OriginalTexture.Clone(new Rectangle(tX, 0, 45, 45), _OriginalTexture.PixelFormat);
                tX += 60;
            }
            Texture = Textures[0];
        }

        private void ChangeTexture(int TextureMin, int TextureMax) {
            if (!IsJumping) {
                if (iIntervalTexture >= 3) {
                    Texture = Textures[iTexture];
                    if (iTexture < TextureMax) {
                        iTexture++;
                    } else {
                        iTexture = TextureMin;
                    }
                    iIntervalTexture = 0;
                }
                iIntervalTexture++;
            }
        }

        public void Jump(bool JumpFinish) {
            if (!IsJumping) {
                iJump = Y - 300;
                this.JumpFinish = JumpFinish;
                IsJumping = true;
            }
        }

        public void Move(int X, int Y) {
            base.X += X;
            base.Y += Y;

            Moved?.Invoke(this, EventArgs.Empty);
        }

        public void SetPosition(int X, int Y) {
            base.X = X;
            base.Y = Y;

            Moved?.Invoke(this, EventArgs.Empty);
        }

        public void MoveX(int iDirection) {
            this.iDirection = iDirection;
        }

        protected override void Timer_Tick(object sender, EventArgs e) {
            if (IsJumping) {
                if (Y > iJump && !JumpFinish) {
                    Move(0, -10);
                    JumpFinish = Y <= iJump;
                }

                if (JumpFinish) {
                    Move(0, 10);
                }
            }

            switch (iDirection) {
                case 1:
                Move(5, 0);
                ChangeTexture(0, 2);
                break;

                case -1:
                Move(-5, 0);
                ChangeTexture(3, Textures.Length - 1);
                break;
            }
        }

        public void Dead() {
            SetPosition(0, 0);
            IsJumping = true;
            JumpFinish = true;
        }
    }
}
