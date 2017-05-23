using Cpln.Enigmos.Enigmas.Components.Clou;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    /// <summary>
    /// Classe du jeu du clou
    /// </summary>
    class ClouEnigmaPanel : EnigmaPanel
    {
        //Définition/instanciation des valeurs par défaut.
        private Label status = new Label { Location = new Point(15, 15), Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold), Text = "Manche: 1/3 - Gagné: 0/3", Height = 36, Width=300 };
        private PictureBox table = new PictureBox { BackgroundImage = Properties.Resources.tableCorrect, Size = new Size(960, 480), Location = new Point(0, 400) };
        private EnergyBar bar = new EnergyBar { Location = new Point(700, 25) };
        private Nail nail = new Nail { Location = new Point(370, 77) };
        private IA ia = new IA();
        private Player player = new Player();

        /// <summary>
        /// Constructeur: ajout des contrôles sur l'affichage
        /// </summary>
        public ClouEnigmaPanel()
        {
            Controls.Add(bar);
            Controls.Add(nail);
            Controls.Add(table);
            Controls.Add(status);
        }

        #region Evènements
        public override void PressKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                table.BringToFront();

                //player
                player.Blow(nail, bar.CaptureCursorPower());

                if (nail.Location.Y >= 399)
                {
                    MessageBox.Show("tu a gagné !");
                }

                System.Threading.Thread.Sleep(1000);

                //ia
                ia.Blow(nail, ia.CalculateBlowPower(nail, player));
                //nail.Down(ia.CalculateBlowPower(nail, player));

                //qui a gagne ?
                if (nail.Location.Y >= 399)
                {
                    MessageBox.Show("l'ia a gagné !");
                }

                bar.StartCursor();
            }
        }
        #endregion
    }
}
