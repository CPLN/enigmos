using System.Drawing;
using System.Windows.Forms;
using System;

namespace Cpln.Enigmos.Enigmas
{
    class PhoqueEnigmaPanel : EnigmaPanel
    {
        public PhoqueEnigmaPanel()
        {
            //Déclaration des variables et tableaux
            PictureBox[] tblPoissons = new PictureBox[3];
            Random RandomX = new Random();

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

        }
    }
}
