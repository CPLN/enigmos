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
        PictureBox table = new PictureBox { BackgroundImage = Properties.Resources.tableCorrect, Size = new Size(960, 480) };
        EnergyBar bar = new EnergyBar();
        Nail nail = new Nail();
        IA ia = new IA();
        Player player = new Player();

        public ClouEnigmaPanel()
        {
            bar.Location = new Point(700, 25);
            nail.Location = new Point(300, 43);
            table.Location = new Point(0, 400); 

            Controls.Add(bar);
            Controls.Add(nail);
            Controls.Add(table);
        }

        public override void PressKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                table.BringToFront();

                //player
                nail.Down(bar.CaptureCursorPower());

                if (nail.Location.Y >= 356)
                {
                    MessageBox.Show("tu a gagné !");
                }

                System.Threading.Thread.Sleep(1000);

                //ia
                nail.Down(ia.CalculateBlowPower(nail));


                //qui a gagne ?
                if (nail.Location.Y >= 356)
                {
                    MessageBox.Show("l'ia a gagné !");
                }

                bar.StartCursor();
            }
        }
    }
}
