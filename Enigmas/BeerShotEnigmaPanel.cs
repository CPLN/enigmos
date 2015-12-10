using Cpln.Enigmos.Enigmas.Components;
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
        private Button boutonStart = new Button();
        private Timer Timer = new Timer();
        private List<Beer> beers = new List<Beer>();

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

            Beer beer = new Beer(true);
            Controls.Add(beer);
        }
        private void boutonStart_Click(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(Properties.Resources.BeerShot_Curseur.GetHicon()); // initialisation du curseur
            boutonStart.Visible = false;
            Timer_BeerShot();
        }
        private void Timer_BeerShot()
        {
            Timer.Interval = 100;
            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (Beer beer in beers)
            {
                beer.Left -= 1;
                beers.Add(beer);
            }
        }
    }
}
