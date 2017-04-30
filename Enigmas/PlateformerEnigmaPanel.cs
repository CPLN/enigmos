using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas {
    class PlateformerEnigmaPanel : EnigmaPanel {
        
        Hero _hero = new Hero(0, 300, 20, 20, Brushes.Blue);
        Rectangle _rWin;
        Rectangle[] _tPlateformes;
        bool bEnd = false;

        public PlateformerEnigmaPanel() {
            _hero.Moved += new EventHandler(_hero_Moved);
            Paint += PlateformerEnigmaPanel_Paint;

            _tPlateformes = new Rectangle[] {
                new Rectangle(0, Height - 50, 200, 50),
                new Rectangle(250, Height - 200, 200, 50),
                new Rectangle(270, Height - 400, 200, 50),
                new Rectangle(600, Height - 500, 200, 50)
            };

            _rWin = new Rectangle(_tPlateformes.Last().X + _tPlateformes.Last().Width - 50, _tPlateformes.Last().Y - 50, 50, 50);

            _hero.Jump(true);
        }

        private void _hero_Moved(object sender, EventArgs e) {
            if (!bEnd) {
                foreach (Rectangle _r in _tPlateformes) {
                    if (_hero.Y == _r.Y - _hero.Height && (_hero.X >= _r.X && _hero.X <= _r.X + _r.Width) && _hero.JumpFinish) {
                        _hero.IsJumping = false;
                        break;
                    } else if (_hero.Y == _r.Y - _hero.Height && !(_hero.X >= _r.X && _hero.X <= _r.X + _r.Width) && !_hero.IsJumping) {
                        _hero.JumpFinish = true;
                        _hero.IsJumping = true;
                    } else if (_hero.Y >= Width) {
                        _hero.SetPosition(0, 0);
                    }
                }
                Invalidate();

                if (_hero.Rectangle.IntersectsWith(_rWin)) {
                    bEnd = true;
                    MessageBox.Show("Ugwemuhwem");
                }
            }
        }

        private void PlateformerEnigmaPanel_Paint(object sender, PaintEventArgs e) {
            e.Graphics.FillRectangles(Brushes.Red, _tPlateformes);
            e.Graphics.FillRectangle(_hero.Color, _hero.X, _hero.Y, _hero.Width, _hero.Height);
            e.Graphics.FillRectangle(Brushes.Black, _rWin);
        }

        public override void PressKey(object sender, KeyEventArgs e) {
            if (!bEnd) {
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
        }

        public override void ReleaseKey(object sender, KeyEventArgs e) {
            _hero.MoveX(0);
        }
    }

    public class Hero {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Brush Color { get; private set; }
        public bool IsJumping { get; set; }
        public bool JumpFinish { get; set; }
        public List<Rectangle> Plateformes { get; private set; }
        public event EventHandler Moved;

        private Timer _tmr = new Timer() { Enabled = true, Interval = 1 };
        private int iJump;
        private int iDirection;

        public Rectangle Rectangle {
            get { return new Rectangle(X, Y, Width, Height); }
        }

        public Hero(int X, int Y, int Width, int Height, Brush Color) {
            this.X = X;
            this.Y = Y;
            this.Color = Color;
            this.Width = Width;
            this.Height = Height;

            _tmr.Tick += _tmr_Tick;
        }

        private void _tmr_Tick(object sender, EventArgs e) {
            if (IsJumping) {
                if (Y > iJump && !JumpFinish) {
                    Move(0, -10);
                    JumpFinish = Y <= iJump;
                }

                if (JumpFinish) {
                    Move(0, 10);
                }
            }

            switch(iDirection) {
                case 1:
                    Move(5, 0);
                    break;

                case -1:
                    Move(-5, 0);
                    break;
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
            this.X += X;
            this.Y += Y;
            Moved?.Invoke(this, EventArgs.Empty);
        }

        public void SetPosition(int X, int Y) {
            this.X = X;
            this.Y = Y;
        }

        public void MoveX(int iDirection) {
            this.iDirection = iDirection;
        }
    }
}
