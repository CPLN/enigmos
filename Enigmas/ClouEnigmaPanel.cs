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
        EnergyBar bar = new EnergyBar();
        Nail nail = new Nail();
        IA ia = new IA();
        Label test = new Label();

        public ClouEnigmaPanel()
        {
            test.Location = new Point(150, 150);
            //test.
            nail.Location = new Point(44, 0);
            Controls.Add(bar);
            Controls.Add(nail);
            Controls.Add(test);
        }

        public override void PressKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
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
