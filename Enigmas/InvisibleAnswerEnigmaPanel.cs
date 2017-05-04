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
        MovablePanel pHaut = new MovablePanel();
        MovablePanel pBas = new MovablePanel();
        Label lblAnswer = new Label();


        /// <summary>
        /// Constructeur par défaut (initialisation des panels)
        /// </summary>
        public InvisibleAnwerEnigmaPanel()
        {
            pHaut.Size = new Size(798, 270);
            pHaut.Location = new Point(1, 1);
            pHaut.BackColor = Color.White;
            pHaut.Cursor = Cursors.Arrow;       
            this.Controls.Add(pHaut);

            pBas.Size = new Size(798, 299);
            pBas.Location = new Point(1, 300);
            pBas.BackColor = Color.White;
            pBas.Cursor = Cursors.Arrow;
            this.Controls.Add(pBas);

            this.Controls.Add(lblAnswer);
            this.lblAnswer.Text = "Blanc c'est blanc";
            lblAnswer.Location = new Point(400, 250);
        }
    }
}