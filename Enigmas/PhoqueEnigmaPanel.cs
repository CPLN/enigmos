using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    class PhoqueEnigmaPanel : EnigmaPanel
    {
        //Déclaration des variables et tableaux
        private PictureBox pbxPhoque = new PictureBox();
        private PictureBox pbxHarpon = new PictureBox();
        private PictureBox[] tblObjet = new PictureBox[3];
        private PictureBox[] tblPoissons = new PictureBox[2];
        private Boolean[] tblPointAttribue = new Boolean[2]{true, true};
        private Label lblPoint = new Label();
        private int iPoint = 0;
        private bool bGauche = false, bDroite = false;
        private Random RandomX = new Random();
        private Timer timer = new Timer();

         /// <summary>
         /// Initialisation de tout les objets présent dans le jeu
         /// </summary>
        public PhoqueEnigmaPanel()
        {
            //Initialisation des tableaux

            //Changement de l'image de fond
            this.BackgroundImage = Properties.Resources.Montagne;

            //Initialisation du phoque
            pbxPhoque.Size = new Size(85, 129);
            pbxPhoque.Image = Properties.Resources.Phoque1;
            pbxPhoque.Location = new Point(400 - (pbxPhoque.Width / 2), 550 - pbxPhoque.Height);
            pbxPhoque.BackColor = Color.Transparent;
            Controls.Add(pbxPhoque);

            //Initialisation des poissons
            for (int i = 0; i < tblPoissons.Length; i++)
            {
                PictureBox pbxPoisson = new PictureBox();
                pbxPoisson.Size = new Size(34, 55);
                pbxPoisson.Image = Properties.Resources.Poisson;
                pbxPoisson.Location = new Point(RandomX.Next(0, 800), (i + 1) * -200 - pbxPoisson.Height);
                pbxPoisson.BackColor = Color.Transparent;
                tblPoissons[i] = pbxPoisson;
                tblObjet[i] = pbxPoisson;
                Controls.Add(pbxPoisson);
            }

            //Initialisation du harpon
            pbxHarpon.Size = new Size(7, 45);
            pbxHarpon.Location = new Point(RandomX.Next(0, 800), 0 - pbxHarpon.Height);
            pbxHarpon.Image = Properties.Resources.Harpon;
            pbxHarpon.BackColor = Color.Transparent;
            tblObjet[tblPoissons.Length] = pbxHarpon;
            Controls.Add(pbxHarpon);

            //Création du label compteur de point
            lblPoint.Location = new Point(0, 0);
            lblPoint.Size = new Size(200, 20);
            lblPoint.Text = "Points : 0";
            FontFamily fontFamily = new FontFamily("Arial");
            lblPoint.Font = new Font(fontFamily, 12); 
            Controls.Add(lblPoint);

            //Initialisation du timer
            timer.Interval = 1;
            timer.Tick += new EventHandler(Timer_Tick);

        }

        /// <summary>
        /// Lancement du Timer lorsque l'utilisateur se trouvge sur l'énigme
        /// </summary>
        public override void Load()
        {
            timer.Start();
        }

        /// <summary>
        /// Arret du Timer lorsque l'utilisateur quitte l'enigme
        /// </summary>
        public override void Unload()
        {
            timer.Stop();
        }

        /// <summary>
        /// Timer pour faire bouger les objets
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            //remise à zero du nombre de point lorsque le phoque attrape un harpon
            if (pbxHarpon.Bottom == 450 && pbxHarpon.Visible == false)
            {
                iPoint = 0;
            }

            for (int i = 0; i < tblObjet.Length; i++)
            {
                //Déplacement des Poissons et du Harpon
                tblObjet[i].Top += 10;

                //Reinitialisation des Poissons et du Harpon lorsqu'il est en dehors de la form
                if (tblObjet[i].Top >= 600)
                {
                    tblObjet[i].Location = new Point(RandomX.Next(0, 800 - tblObjet[i].Width) , 0 - tblObjet[i].Height);
                    tblObjet[i].Visible = true;
                    if(i <= 1)
                    {
                        tblPointAttribue[i] = true;
                    }
                }

                //Disparition des Poissons et du Harpon lorsqu'ils sont dans la zone du phoque
                if (tblObjet[i].Bottom >= pbxPhoque.Top && tblObjet[i].Right >= pbxPhoque.Left && tblObjet[i].Left <= pbxPhoque.Right && tblObjet[i].Bottom <= pbxPhoque.Top + (pbxPhoque.Height / 2))
                {
                    tblObjet[i].Visible = false;
                    if (tblObjet[i] != tblObjet[tblPoissons.Length] && tblPointAttribue[i] == true)
                    {
                        iPoint += 1;
                        tblPointAttribue[i] = false;
                    }
                } 
                lblPoint.Text = "Points : " + iPoint;
            }
            
            //Déplacement du Phoque
            if (bGauche == true && pbxPhoque.Left >= 0)
            {
                pbxPhoque.Left -= 10;
            }

            if (bDroite == true && pbxPhoque.Right <= 800)
            {
                pbxPhoque.Left += 10;
            }

            //Affichage du message de fin lorsque le joueur atteint l'objectif
            if(iPoint == 10)
            {
                timer.Stop();
                MessageBox.Show("Bravo, vous avez attrapé 10 poissons !\nLa réponse est Dru !", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblPoint.Text = "La réponse est Dru";
                foreach(PictureBox pbxObjet in tblObjet)
                {
                    Controls.Remove(pbxObjet);
                }
            }
        }

        /// <summary>
        /// Détecte si l'utilisateur appuie sur la touche D ou A
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void PressKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                bDroite = true;   
            }

            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                bGauche = true;
            }
        }

        /// <summary>
        /// Détecte si l'utilisateur relache sur la touche D ou A
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ReleaseKey(object sender, KeyEventArgs e)
        {
            
            if(e.KeyCode == Keys.D)
            {
                bDroite = false;
            }

            if (e.KeyCode == Keys.A)
            {
                bGauche = false;
            }
        }
    }
}
