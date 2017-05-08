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
        Rectangle _rWin;
        Rectangle[] _tPlateformes;
        Badboy[] _tBadboys;

        public PlateformerEnigmaPanel() {
			// Taille du jeu
            Width = 1500;
            Height = 900;
            _hero.Moved += new EventHandler(_hero_Moved);
            Paint += PlateformerEnigmaPanel_Paint;
			
			// Toutes les plateformes du jeu
            _tPlateformes = new Rectangle[] {
                new Rectangle(0, Height - 50, 200, 50),
                new Rectangle(250, Height - 200, 200, 30),
                new Rectangle(350, Height - 400, 40, 10),
                new Rectangle(600, Height - 500, 200, 50),
                new Rectangle(980, Height - 580, 50, 10),
                new Rectangle(850, Height - 800, 125, 50),
                new Rectangle(1200, Height - 820, 100, 10),
                new Rectangle(Width - 70, 50, 70, 10)
            };
			
			// Tout les ennemis du jeu
            _tBadboys = new Badboy[] {
                new Badboy(_tPlateformes[_tPlateformes.Length - 3], 40, 2),
                new Badboy(_tPlateformes[1], 30, 4)
            };
            foreach(Badboy _bb in _tBadboys) { _bb.Moved += _bb_Moved; }
			
			// Piece qui permettera de gagner
            _rWin = new Rectangle(_tPlateformes.Last().X + _tPlateformes.Last().Width - 30, _tPlateformes.Last().Y - 30, 30, 30);

            _hero.Jump(true);
        }
		
		// Evemement qui se déclenche que un des ennemis bouge
        private void _bb_Moved(object sender, EventArgs e) {
            Badboy _bbThis = (Badboy)sender;
			
			// Quand le hero intersect un des ennemis, il meurt
            if (_hero.Rectangle.IntersectsWith(_bbThis.Rectangle))
                _hero.Dead();

            Invalidate();
        }
		
		// Evemement qui se déclanche le joueur bouge
        private void _hero_Moved(object sender, EventArgs e) {
            foreach (Rectangle _r in _tPlateformes) {
                if (_hero.Rectangle.Bottom == _r.Top && (_hero.Rectangle.Right > _r.Left && _hero.Rectangle.Left < _r.Right) && _hero.JumpFinish) {
                    _hero.IsJumping = false;
                    break;
                } else if (_hero.Rectangle.Bottom == _r.Top && !(_hero.Rectangle.Right > _r.Left && _hero.Rectangle.Left < _r.Right) && !_hero.IsJumping) {
                    _hero.JumpFinish = true;
                    _hero.IsJumping = true;
                } else if (_hero.Y >= Width) {
                    _hero.SetPosition(0, 0);
                }
            }
            Invalidate();
			
			// Si le hero gagne en touchant la piece, il recommence et le mot de passe s'affiche
            if (_hero.Rectangle.IntersectsWith(_rWin)) {
                _hero.Dead();
                MessageBox.Show("Ugwemuhwem");
            }
        }
		
		// Dessine tout le jeu
        private void PlateformerEnigmaPanel_Paint(object sender, PaintEventArgs e) {
            e.Graphics.FillRectangles(Brushes.ForestGreen, _tPlateformes);
            e.Graphics.FillRectangle(Brushes.LightGray, _hero.Rectangle);
            e.Graphics.DrawImage(_hero.Texture, _hero.Rectangle);
            e.Graphics.DrawImage(new Bitmap(Resources.Coin), _rWin);
            foreach(Badboy _bb in _tBadboys) { e.Graphics.FillRectangle(Brushes.Black, _bb.Rectangle); }
        }
		
		// Quand une touche est pressée
        public override void PressKey(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
				// Recule
                case Keys.D:
                _hero.MoveX(1);
                break;
				
				// Avance
                case Keys.A:
                _hero.MoveX(-1);
                break;
				
				// Saute
                case Keys.W:
                case Keys.Space:
                _hero.Jump(false);
                break;
            }
        }
		
		// Si une touche du déplacament X est levée, de déplacement s'arrête
        public override void ReleaseKey(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.A:
                case Keys.D:
				_hero.MoveX(0);
				break;
			}
        }
    }

    /// <summary>
    /// Class abstraite Boy qui contient les propriétés, les methodes et l'evenement de base pour jouer
    /// </summary>
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

        /// <summary>
        /// Constructeur de la class Boy
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        protected Boy(int X, int Y, int Width, int Height) {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;

            Timer.Tick += Timer_Tick;
        }

        protected abstract void Timer_Tick(object sender, EventArgs e);
    }

    /// <summary>
    /// Class des ennemis qui hérite de la class abstraite Boy. 
    /// </summary>
    public class Badboy : Boy {
        public override event EventHandler Moved;
        private int iXMin;
        private int iXMax;
        private bool bMax = false;
        private int iSpeed;

        /// <summary>
        /// Constructeur de la class Badboy.
        /// </summary>
        /// <param name="_r">La hitbox de l'objet</param>
        /// <param name="Length">Taille des côté du carré</param>
        /// <param name="Speed">La vitesse de déplacement de l'objet</param>
        public Badboy(Rectangle _r, int Length, int Speed) : base(_r.X, _r.Y - Length, Length, Length) {
            iXMin = X;
            iXMax = _r.Right - Length;
            iSpeed = Speed;
        }

        /// <summary>
        /// Réécriture de l'evenement abstarait du timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Timer_Tick(object sender, EventArgs e) {
            // Bouge de gauche à droite infiniment
            if (X < iXMax && !bMax) {
                X += iSpeed;
                bMax = X >= iXMax;
            } if (bMax) {
                X -= iSpeed;
                bMax = X >= iXMin;
            }
            // Invoque l'évenement Moved
            Moved?.Invoke(this, EventArgs.Empty);
        }
    }

    /// <summary>
    /// L'objet que l'utilisateur jouera, il hérite de la classe abstraite Boy
    /// </summary>
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

        /// <summary>
        /// Constructeur de Hero
        /// </summary>
        /// <param name="X">Position initiale X</param>
        /// <param name="Y">Position initiale Y</param>
        /// <param name="Width">Longueur de l'objet</param>
        /// <param name="Height">Hauteur de l'objet</param>
        public Hero(int X, int Y, int Width, int Height) : base (X, Y, Width, Height) {
            // Remplissage du tableau des images de l'objet
            int tX = 0;
            Bitmap _OriginalTexture = new Bitmap(Resources.Player);
            for (int i = 0; i < 6; i++) {
                Textures[i] = _OriginalTexture.Clone(new Rectangle(tX, 0, 45, 45), _OriginalTexture.PixelFormat);
                tX += 60;
            }
            Texture = Textures[0];
        }

        /// <summary>
        /// Permet de changer la texture de l'objet
        /// </summary>
        /// <param name="TextureMin">L'emplacement du tableau de la texture minimum</param>
        /// <param name="TextureMax">L'emplacement du tableau de la texture maximum</param>
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

        /// <summary>
        /// Permet de faire sauter l'objet
        /// </summary>
        /// <param name="JumpFinish">True = Ne monte pas, False = Descent</param>
        public void Jump(bool JumpFinish) {
            if (!IsJumping) {
                iJump = Y - 300;
                this.JumpFinish = JumpFinish;
                IsJumping = true;
            }
        }

        /// <summary>
        /// Permet de bouger l'element
        /// </summary>
        /// <param name="X">Nombre de pixels à déplacer sur l'axe X</param>
        /// <param name="Y">Nombre de pixels à déplacer sur l'axe Y</param>
        public void Move(int X, int Y) {
            base.X += X;
            base.Y += Y;

            // Invoque l'evenement Moved
            Moved?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Change la position de l'objet
        /// </summary>
        /// <param name="X">Change la postion sur l'axe X par la valeur de ce paramètre</param>
        /// <param name="Y">Change la postion sur l'axe Y par la valeur de ce paramètre</param>
        public void SetPosition(int X, int Y) {
            base.X = X;
            base.Y = Y;

            Moved?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Permet de bouger l'element sur l'axe X grace au Timer
        /// </summary>
        /// <param name="iDirection">-1 Arrière, 1 Avanr, 0 bouge pas</param>
        public void MoveX(int iDirection) {
            this.iDirection = iDirection;
        }

        /// <summary>
        /// Réécriture de l'evenement abstarait du timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Timer_Tick(object sender, EventArgs e) {
            // Permet de faire sauter l'objet
            if (IsJumping) {
                if (Y > iJump && !JumpFinish) {
                    Move(0, -10);
                    JumpFinish = Y <= iJump;
                }

                if (JumpFinish) {
                    Move(0, 10);
                }
            }

            // Permet de faire bouger l'objet sur l'axe X
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

        /// <summary>
        /// Reset l'emplacement du joueur
        /// </summary>
        public void Dead() {
            SetPosition(0, 0);
            IsJumping = true;
            JumpFinish = true;
        }
    }
}
