using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    class PhoqueEnigmaPanel : EnigmaPanel
    {
        //Déclaration des variables et tableaux
        PictureBox pbxPhoque = new PictureBox();
        PictureBox[] tblPoissons = new PictureBox[3];
        Label lblPoint = new Label();
        int iPoint = 0;
        Random RandomX = new Random();
        private Timer timer = new Timer();

        public PhoqueEnigmaPanel()
        {

            //Création du Phoque
            pbxPhoque.Size = new Size(85, 129);
            pbxPhoque.BackColor = Color.Blue;
            pbxPhoque.Location = new Point(400 - (pbxPhoque.Width / 2), 550 - (pbxPhoque.Height)); 
            Controls.Add(pbxPhoque);

            //Création des poissons
            for (int i = 0; i < tblPoissons.Length; i++)
            {
                PictureBox pbxPoisson = new PictureBox();
                pbxPoisson.Size = new Size(34, 55);
                pbxPoisson.BackColor = Color.Gray;
                pbxPoisson.Location = new Point(RandomX.Next(0, 800 + pbxPoisson.Width), i * -200 - pbxPoisson.Height);
                pbxPoisson.Name = "Poisson_" + i;
                tblPoissons[i] = pbxPoisson;
                Controls.Add(pbxPoisson);
            }

            //Création label des point
            lblPoint.Location = new Point(0, 0);
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
                tblPoissons[i].Top += 5;

                if(tblPoissons[i].Top >= 600)
                {
                     tblPoissons[i].Location = new Point(RandomX.Next(0, 800) - tblPoissons[i].Width, 0 - tblPoissons[i].Height);
                     tblPoissons[i].Visible = true;
                }

                if (tblPoissons[i].Bottom >= pbxPhoque.Top && tblPoissons[i].Right >= pbxPhoque.Left && tblPoissons[i].Left <= pbxPhoque.Right && tblPoissons[i].Bottom <= pbxPhoque.Top + (pbxPhoque.Height / 2))
                {
                    iPoint = iPoint + 1;
                    tblPoissons[i].Visible = false;
                }
            }
            lblPoint.Text = "Points : " + iPoint;
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
