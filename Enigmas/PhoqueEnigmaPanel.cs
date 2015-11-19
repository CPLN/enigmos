using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    class PhoqueEnigmaPanel : EnigmaPanel
    {
        //Déclaration des variables et tableaux
        PictureBox[] tblPoissons = new PictureBox[3];
        Random RandomX = new Random();
        private Timer timer = new Timer();

        public PhoqueEnigmaPanel()
        {

            //Création du Phoque
            PictureBox pbxPhoque = new PictureBox();
            pbxPhoque.Size = new Size(20, 40);
            pbxPhoque.BackColor = Color.Blue;
            pbxPhoque.Location = new Point(400 - (pbxPhoque.Width / 2), 550 - (pbxPhoque.Height));
            Controls.Add(pbxPhoque);

            //Création des poissons
            for (int i = 0; i < tblPoissons.Length; i++)
            {
                PictureBox pbxPoisson = new PictureBox();
                pbxPoisson.Size = new Size(20, 40);
                pbxPoisson.BackColor = Color.Gray;
                pbxPoisson.Location = new Point(RandomX.Next(0, 800) - pbxPoisson.Width, 0 - pbxPoisson.Height);
                pbxPoisson.Name = "Poisson_" + i;
                tblPoissons[i] = pbxPoisson;
                Controls.Add(pbxPoisson);
            }

            //Timer
            timer.Interval = 1;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < tblPoissons.Length; i++)
            {
                tblPoissons[i].Top += 1;

                if(tblPoissons[i].Bottom >= 600)
                {
                     tblPoissons[i].Location = new Point(RandomX.Next(0, 800) - tblPoissons[i].Width, 0 - tblPoissons[i].Height); 
                }
            }
        }
    }
}
