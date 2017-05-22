using Cpln.Enigmos.Enigmas.Components;
using Cpln.Enigmos.Properties;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    class PlateformerEnigmaPanel : EnigmaPanel {
        Hero _hero = new Hero(0, 300, 50, 50); // Le hero que le joueur incarne
        Rectangle _rWin; // La piece qui permet de gagner
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
            foreach(Badboy _bb in _tBadboys) { _bb.Moved += _bb_Moved; } // Assigne à tous les Badboys l'evenement _bb_Moved
			
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
                if (_hero.Rectangle.Bottom == _r.Top && (_hero.Rectangle.Right > _r.Left && _hero.Rectangle.Left < _r.Right) && _hero.JumpFinish) { // Saut avec intersection sur une plateforme
                    _hero.IsJumping = false;
                    break;
                } else if (_hero.Rectangle.Bottom == _r.Top && !(_hero.Rectangle.Right > _r.Left && _hero.Rectangle.Left < _r.Right) && !_hero.IsJumping) { // Gravité
                    _hero.JumpFinish = true;
                    _hero.IsJumping = true;
                } else if (_hero.Y >= Width) {  // Tombe en bas
                    _hero.SetPosition(0, 0);
                }
            }
            Invalidate();
			
			// Si le hero gagne en touchant la piece, il recommence et le mot de passe s'affiche
            if (_hero.Rectangle.IntersectsWith(_rWin)) {
                _hero.Dead();
                MessageBox.Show("Pass1234");
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
}
