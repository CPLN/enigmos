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
        private Label lblPoint = new Label();
        private int iPoint = 0;
        private bool bGauche = false, bDroite = false;
        private Random RandomX = new Random();
        private Timer timer = new Timer();

        public PhoqueEnigmaPanel()
        {
            //Changement de l'image de fond
            this.BackgroundImage = Properties.Resources.Montagne;

            //Création du Phoque
            pbxPhoque.Size = new Size(85, 129);
            pbxPhoque.Image = Properties.Resources.Phoque1;
            pbxPhoque.Location = new Point(400 - (pbxPhoque.Width / 2), 550 - pbxPhoque.Height); 
            Controls.Add(pbxPhoque);

            //Création des poissons
            for (int i = 0; i < tblPoissons.Length; i++)
            {
                PictureBox pbxPoisson = new PictureBox();
                pbxPoisson.Size = new Size(34, 55);
                pbxPoisson.Image = Properties.Resources.Poisson;
                pbxPoisson.Location = new Point(RandomX.Next(0, 800), (i + 1) * -200 - pbxPoisson.Height);
                tblPoissons[i] = pbxPoisson;
                tblObjet[i] = pbxPoisson;
                Controls.Add(pbxPoisson);
            }

            //Création du Harpon
            pbxHarpon.Size = new Size(34, 55);
            pbxHarpon.BackColor = Color.Red;
            pbxHarpon.Location = new Point(RandomX.Next(0, 800 + pbxHarpon.Width), 0 - pbxHarpon.Height);
            tblObjet[tblPoissons.Length] = pbxHarpon;
            Controls.Add(pbxHarpon);

            //Création label des point
            lblPoint.Location = new Point(0, 0);
            lblPoint.Size = new Size(110, 15);
            lblPoint.Text = "Points : 0";
            Controls.Add(lblPoint);

            //Timer
            timer.Interval = 1;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < tblPoissons.Length; i++)
            {
                //Ajout d'un point lorsque le Phoque attrape un Poissons
                if (tblPoissons[i].Top == 450 && tblPoissons[i].Visible == false)
                {
                    iPoint += 1;
                    lblPoint.Text = "Points : " + iPoint;
                }
            }

            //Penalisation lorsque le Phoque attrape le Harpon
            if (pbxHarpon.Top == 450 && pbxHarpon.Visible == false && iPoint >= 2)
            {
                iPoint -= 2;
                lblPoint.Text = "Points : " + iPoint;
            }

            //if ()

            for (int i = 0; i < tblObjet.Length; i++)
            {
                //Déplacement des Poissons et du Harpon
                tblObjet[i].Top += 5;

                //Reinitialisation des Poissons et du Harpon lorsqu'il est en dehors de la form
                if (tblObjet[i].Top >= 600)
                {
                    tblObjet[i].Location = new Point(RandomX.Next(0, 800) - tblObjet[i].Width, 0 - tblObjet[i].Height);
                    tblObjet[i].Visible = true;
                }

                //Disparition des Poissons et du Harpon lorsqu'ils sont dans la zone du phoque
                if (tblObjet[i].Bottom >= pbxPhoque.Top && tblObjet[i].Right >= pbxPhoque.Left && tblObjet[i].Left <= pbxPhoque.Right && tblObjet[i].Bottom <= pbxPhoque.Top + (pbxPhoque.Height / 2))
                {
                    tblObjet[i].Visible = false;
                }
            }

            if (bGauche == true && pbxPhoque.Left >= 0)
            {
                pbxPhoque.Left -= 10;
            }

            if (bDroite == true && pbxPhoque.Right <= 800)
            {
                pbxPhoque.Left += 10;
            }

            if(iPoint == 10)
            {
                timer.Stop();
                MessageBox.Show("Bravo, vous avez attrapé 10 poissons !\nLa réponse est Dru !", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lblPoint.Text = "La réponse est Dru";
            }
        }

        public override void PressKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                bDroite = true;   
            }

            if (e.KeyCode == Keys.A)
            {
                bGauche = true;
            }
        }
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
