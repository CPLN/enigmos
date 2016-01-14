using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    class CliqueRapideEnigmaPanel : EnigmaPanel
    {
        private Button btnACliquer = new Button();
        private Timer timer = new Timer();
        private Label lblNbClique = new Label();
        FontFamily fontFamily = new FontFamily("Berlin Sans FB");
        const int SEC = 10;
        int iComptSec = 0, iComptClique = 0;
        bool bVert = false;
        
        public CliqueRapideEnigmaPanel()
        {
            //Initialisation du bouton
            btnACliquer.Size = new Size(200, 200);
            btnACliquer.Location = new Point(400 - btnACliquer.Width / 2, 300 - btnACliquer.Height / 2);
            btnACliquer.Font = new Font(fontFamily, 14);
            ChangementPourRouge();
            Controls.Add(btnACliquer);

            //Initialisation du label
            lblNbClique.Size = new Size(200, 20);
            lblNbClique.Location = new Point(20, 20);
            lblNbClique.Font = new Font(fontFamily, 14);
            lblNbClique.Text = "Nombre de clique : " + Convert.ToString(iComptClique);
            Controls.Add(lblNbClique);

            //Initialisation du timer
            timer.Interval = 100;
            timer.Tick += new EventHandler(Timer_Tick);

            //Initialisation de l'evenement clique
            btnACliquer.Click += new EventHandler(btnACliquer_Clique);
        }

        /// <summary>
        /// Change le texte et la couleur du bouton en rouge
        /// </summary>
        private void ChangementPourRouge()
        {
            btnACliquer.BackColor = Color.Red;
            btnACliquer.Text = "Attention ...";
        }

        /// <summary>
        /// Change le texte et la couleur du bouton en vert
        /// </summary>
        private void ChangementPourVert()
        {
            btnACliquer.BackColor = Color.Green;
            btnACliquer.Text = "Appuie !!!";
        }

        /// <summary>
        /// Lance le timer lorsque l'utilisateur arrive sur l'enigme
        /// </summary>
        public override void Load()
        {
            timer.Start();
        }

        /// <summary>
        /// Arrete le timer lorsque l'utilisateur quitte l'enigme
        /// </summary>
        public override void Unload()
        {
            timer.Stop();
        }

        /// <summary>
        /// Evenement timer pour compter les secondes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            if(iComptSec == SEC)
            {
                iComptSec = 0;
                ChangementPourVert();
                bVert = true;
            }
            else
            {
                iComptSec += 1;
                ChangementPourRouge();
                bVert = false;
            }
        }

        /// <summary>
        /// Evenement clique pour vérifier si l'utilisateur a reussi et eventuellement afficher le message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnACliquer_Clique(object sender, EventArgs e)
        {
            iComptClique++;
            lblNbClique.Text = "Nombre de clique : " + Convert.ToString(iComptClique);
            if(bVert == true)
            {
                timer.Stop();
                if(iComptClique == 1)
                {
                    MessageBox.Show("Bravo vous avez gagné !\nAvez-vous triché ou êtes-vous le professeur ?\n\nLa réponse est : Flash", "Bravo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if(iComptClique >= 2 || iComptClique <= 3)
                {
                    MessageBox.Show("Bravo vous avez gagné !\nAvez-vous eu de la chance ou êtes-vous juste bon ?\n\nLa réponse est : Flash", "Bravo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if(iComptClique >= 4 && iComptClique <= 6)
                {
                    MessageBox.Show("Bravo vous avez gagné !\nVous êtes pas si mal\n\nLa réponse est : Flash", "Bravo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if(iComptClique >= 7 && iComptClique <= 10)
                {
                    MessageBox.Show("Bravo vous avez gagné !\nVous êtes dans la moyenne\n\nLa réponse est : Flash", "Bravo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Bravo vous avez gagné !\nDésolé mais vous n'êtes pas très bon...\n\nLa réponse est : Flash", "Bravo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                btnACliquer.Enabled = false;
                btnACliquer.Text = "La réponse est : Flash";
            }
            else
            {
                iComptSec = 0;
            }
        }
    }
}
