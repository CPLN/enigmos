using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    class BeerShotEnigmaPanel : EnigmaPanel
    {
        Button boutonStart = new Button();
        private Timer Timer = new Timer();
        Panel panelBeer = new Panel();

        public BeerShotEnigmaPanel()
        {
            // Ajout de l'image de fond
            this.BackgroundImage = Properties.Resources.BeerShot_Bar;
            this.Width = Properties.Resources.BeerShot_Bar.Width;
            this.Height = Properties.Resources.BeerShot_Bar.Height;

            // Placement du bouton start
            boutonStart.Height = 80;
            boutonStart.Width = 300;
            boutonStart.Text = "Commencer en cliquant ici !";
            boutonStart.Location = new Point(400, 200);
            Controls.Add(boutonStart);
            boutonStart.Click += new EventHandler(boutonStart_Click);

            // Panel de la bière
            panelBeer.BackgroundImage = Properties.Resources.BeerShot_Foncé;
            panelBeer.Width = 100;
            panelBeer.Width = 100;
            Controls.Add(panelBeer);
        }

        private void boutonStart_Click(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(Properties.Resources.BeerShot_Curseur.GetHicon()); // initialisation du curseur
            boutonStart.Visible = false;
        }


    }
}
