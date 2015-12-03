using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    class PhoqueEnigmaPanel : EnigmaPanel
    {
        //Déclaration des variables et tableaux
        PictureBox pbxPhoque = new PictureBox();
        PictureBox pbxHarpon = new PictureBox();
        PictureBox[] tblObjet = new PictureBox[3];
        PictureBox[] tblPoissons = new PictureBox[2];
        Label lblPoint = new Label();
        int iPoint = 0;
        Random RandomX = new Random();
        private Timer timer = new Timer();

        public PhoqueEnigmaPanel()
        {

            //Création du Phoque
            pbxPhoque.Size = new Size(85, 129);
            pbxPhoque.BackColor = Color.Blue;
            pbxPhoque.Location = new Point(400 - (pbxPhoque.Width / 2), 550 - pbxPhoque.Height); 
            Controls.Add(pbxPhoque);

            //Création des poissons
            for (int i = 0; i < tblPoissons.Length; i++)
            {
                PictureBox pbxPoisson = new PictureBox();
                pbxPoisson.Size = new Size(34, 55);
                pbxPoisson.BackColor = Color.Gray;
                pbxPoisson.Location = new Point(RandomX.Next(0, 800 + pbxPoisson.Width), (i + 1) * -200 - pbxPoisson.Height);
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
        }

        public override void PressKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D && pbxPhoque.Right <= 800)
            {
                    pbxPhoque.Left += 10;
            }
            if (e.KeyCode == Keys.A && pbxPhoque.Left >= 0)
            {
                    pbxPhoque.Left -= 10;
            }
        }

    }
}
