using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    class SeptDifferencesEnigmaPanel : EnigmaPanel
    {
        PictureBox pbx1 = new PictureBox();
        PictureBox pbx2 = new PictureBox();
        PictureBox pbx3 = new PictureBox();
        PictureBox pbx4 = new PictureBox();
        PictureBox pbx5 = new PictureBox();
        PictureBox pbx6 = new PictureBox();
        PictureBox pbx7 = new PictureBox();
        public SeptDifferencesEnigmaPanel()
        { 
            //Elargissement de la form
            this.Width = 900;

            //Création de la première PictureBox contenant la première image
            PictureBox Img1 = new PictureBox();
            Img1.BackgroundImage = Properties.Resources.SeptDifference1;
            Img1.Width = Properties.Resources.SeptDifference1.Width;
            Img1.Height = Properties.Resources.SeptDifference1.Height;
            Img1.Location = new Point(20,200);
            Controls.Add(Img1);

            //Création de la 2ème PictureBox contenant la 2ème image
            PictureBox Img2 = new PictureBox();
            Img2.BackgroundImage = Properties.Resources.SeptDifference2;
            Img2.Width = Properties.Resources.SeptDifference2.Width;
            Img2.Height = Properties.Resources.SeptDifference2.Height;
            Img2.Location = new Point(485,200);
            Controls.Add(Img2);

            #region différences
            //Première différence
            int iX1 = 195, iY1 = 6;
            PictureBox(pbx1, Img2, iX1, iY1);
            pbx1.Click += new EventHandler(ClickOnDiff1);

            //Deuxième différence
            int iX2 = 27, iY2 = 38;
            PictureBox(pbx2, Img2, iX2, iY2);
            pbx2.Click += new EventHandler(ClickOnDiff2);

            //Troisième différence
            int iX3 = 218, iY3 = 38;
            PictureBox(pbx3, Img2, iX3, iY3);
            pbx3.Click += new EventHandler(ClickOnDiff3);

            //Quatrième différence
            int iX4 = 88, iY4 = 71;
            PictureBox(pbx4, Img2, iX4, iY4);
            pbx4.Click += new EventHandler(ClickOnDiff4);

            //Cinquième différence
            int iX5 = 121, iY5 = 104;
            PictureBox(pbx5, Img2, iX5, iY5);
            pbx5.Click += new EventHandler(ClickOnDiff5);

            //Sixième différence
            int iX6 = 309, iY6 = 104;
            PictureBox(pbx6, Img2, iX6, iY6);
            pbx6.Click += new EventHandler(ClickOnDiff6);

            //Septième différence
            int iX7 = 122, iY7 = 201;
            PictureBox(pbx7, Img2, iX7, iY7);
            pbx7.Click += new EventHandler(ClickOnDiff7);
            #endregion
        }
        public void PictureBox(PictureBox pbx, PictureBox img, int iX, int iY)
        {
            CreatePbx(pbx);
            pbx.Location = new Point(iX, iY);
            img.Controls.Add(pbx);
            
        }
        public void CreatePbx(PictureBox Pbx)
        {
            Pbx.Size = new Size(17,20);
            Pbx.BackColor = Color.Transparent;
        }

        #region Clic sur différences
        private void ClickOnDiff1(object sender, EventArgs e)
        {
            pbx1.BackColor = Color.FromArgb(100, Color.Red);
        }
        private void ClickOnDiff2(object sender, EventArgs e)
        {
            pbx2.BackColor = Color.FromArgb(100, Color.Red);
        }
        private void ClickOnDiff3(object sender, EventArgs e)
        {
            pbx3.BackColor = Color.FromArgb(100, Color.Red);
        }
        private void ClickOnDiff4(object sender, EventArgs e)
        {
            pbx4.BackColor = Color.FromArgb(100, Color.Red);
        }
        private void ClickOnDiff5(object sender, EventArgs e)
        {
            pbx5.BackColor = Color.FromArgb(100, Color.Red);
        }
        private void ClickOnDiff6(object sender, EventArgs e)
        {
            pbx6.BackColor = Color.FromArgb(100, Color.Red);
        }
        private void ClickOnDiff7(object sender, EventArgs e)
        {
            pbx7.BackColor = Color.FromArgb(100, Color.Red);
        }
#endregion
    }
}
