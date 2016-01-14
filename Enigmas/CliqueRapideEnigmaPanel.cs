using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    class CliqueRapideEnigmaPanel : EnigmaPanel
    {
        private Button btnACliquer = new Button();
        private Timer timer = new Timer();
        const int SEC = 10;
        int iCompteur = 0;
        bool bVert = false;
        
        public CliqueRapideEnigmaPanel()
        {
            //Initialisation du bouton
            btnACliquer.Size = new Size(200, 200);
            btnACliquer.Location = new Point(400 - btnACliquer.Width / 2, 300 - btnACliquer.Height / 2);
            ChangementPourRouge();
            Controls.Add(btnACliquer);

            //Initialisation du timer
            timer.Interval = 100;
            timer.Tick += new EventHandler(Timer_Tick);

            //Initialisation de l'evenement clique
            btnACliquer.Click += new EventHandler(btnACliquer_Clique);
        }

        private void ChangementPourRouge()
        {
            btnACliquer.BackColor = Color.Red;
            btnACliquer.Text = "Attention ...";
        }

        private void ChangementPourVert()
        {
            btnACliquer.BackColor = Color.Green;
            btnACliquer.Text = "Appuie !!!";
        }

        public override void Load()
        {
            timer.Start();
        }

        public override void Unload()
        {
            timer.Stop();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(iCompteur == SEC)
            {
                iCompteur = 0;
                ChangementPourVert();
                bVert = true;
            }
            else
            {
                iCompteur += 1;
                ChangementPourRouge();
                bVert = false;
            }
        }

        private void btnACliquer_Clique(object sender, EventArgs e)
        {
            if(bVert == true)
            {
                timer.Stop();
                MessageBox.Show("Brovo vous avez gagné !\nLa réponse est : Flash", "Bravo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnACliquer.Text = "La réponse est : Flash";
            }
            else
            {
                iCompteur = 0;
            }
        }
    }
}
