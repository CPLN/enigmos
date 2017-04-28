using Cpln.Enigmos.Enigmas.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    class InvisibleAnwerEnigmaPanel : EnigmaPanel
    {
        // Déclaration et initalisation des objets
        Panel pHaut = new Panel();
        Panel pBas = new Panel();
        Label lblAnswer = new Label();

        /// <summary>
        /// Constructeur par défaut (initialisation des panels)
        /// </summary>
        public InvisibleAnwerEnigmaPanel()
        {
            pHaut.Size = new Size(798, 270);
            pHaut.Location = new Point(1, 1);
            pHaut.BackColor = Color.Black;
            pHaut.MouseMove += new MouseEventHandler(DeplacerBarre);
            this.Controls.Add(pHaut);

            pBas.Size = new Size(798, 299);
            pBas.Location = new Point(1, 300);
            pBas.BackColor = Color.Black;
            pBas.MouseMove += new MouseEventHandler(DeplacerBarre);
            this.Controls.Add(pBas);

            this.Controls.Add(lblAnswer);
            this.lblAnswer.Text = "Blanc c'est blanc";
            lblAnswer.Location = new Point(400, 250);
        }

        /// <summary>
        /// Méthode pour deplacer certain panels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void DeplacerBarre(object sender, MouseEventArgs e)
        {
            Panel panel = sender as Panel;
            if (e.Button == MouseButtons.Left)
            {
                panel.Top += (e.Y - Parent.Location.Y);
                panel.Left += (e.X - Parent.Location.X);

            }
        }

    }
}
