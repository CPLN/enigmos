using Cpln.Enigmos.Enigmas.Components;
using Cpln.Enigmos.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    class PlateformerEnigmaPanel : EnigmaPanel {
        Hero _hero = new Hero(0, 300, 50, 50);      // Le hero que le joueur incarne
        Rectangle _rWin;                            // La piece qui permet de gagner
        Rectangle[] _tPlateformes;                  // Toute les plateformes du jeu
        Badboy[] _tBadboys;                         // Tout les ennemis
        Timer _tmr = new Timer() { Interval = 1 };  // Timer du jeu

        public PlateformerEnigmaPanel() {
            // Taille du jeu
            Width = 1500;
            Height = 900;
            DoubleBuffered = true;

            // Evenements
            Paint += PlateformerEnigmaPanel_Paint;
            _tmr.Tick += Tmr_Tick;
			
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
			
            // Piece qui permettera de gagner
            _rWin = new Rectangle(_tPlateformes.Last().X + _tPlateformes.Last().Width - 30, _tPlateformes.Last().Y - 30, 30, 30);
        }

        private void Tmr_Tick(object sender, EventArgs e)
        {
            // bouge le joueur en effectuant les test de déplacement
            _hero.Move();
            foreach (Rectangle _r in _tPlateformes)
            {
                if (_hero.Rectangle.Bottom == _r.Top && (_hero.Rectangle.Right > _r.Left && _hero.Rectangle.Left < _r.Right) && _hero.JumpFinish)
                { 
                    // Saut avec intersection sur une plateforme
                    _hero.IsJumping = false;
                    break;
                }
                else if (_hero.Rectangle.Bottom == _r.Top && !(_hero.Rectangle.Right > _r.Left && _hero.Rectangle.Left < _r.Right) && !_hero.IsJumping)
                { 
                    // Gravité
                    _hero.JumpFinish = true;
                    _hero.IsJumping = true;
                }
                else if (_hero.Y >= Width)
                {  
                    // Tombe en bas
                    _hero.SetPosition(0, 0);
                }
            }

            // Bouge les ennemis et test les collisions avec le joueur
            foreach (Badboy _bb in _tBadboys)
            {
                _bb.Move();
                if (_hero.Rectangle.IntersectsWith(_bb.Rectangle))
                    _hero.Dead();
            }

            // Si le hero gagne en touchant la piece, il recommence et le mot de passe s'affiche
            if (_hero.Rectangle.IntersectsWith(_rWin))
            {
                _hero.Dead();
                MessageBox.Show("Pass1234");
            }

            // Redéssine
            Invalidate();
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

        // Active le timer quand le jeu est affiché et remet le joueur au point de départ
        public override void Load()
        {
            _tmr.Start();
            _hero.Dead();
        }

        // Stop le timer quand l'énigme n'est plus affichée
        public override void Unload()
        {
            _tmr.Stop();
        }
    }
}
