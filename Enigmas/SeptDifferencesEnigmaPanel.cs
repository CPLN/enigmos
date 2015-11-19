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
        public SeptDifferencesEnigmaPanel()
        {
            //Elargissement de la form
            this.Width = this.Width + 100;
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
            Label lblEnigme = new Label();

            lblEnigme.Text = "Cherchez les 7 différences dans l'image de droite";
            lblEnigme.Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);
            lblEnigme.Dock = DockStyle.Fill;
            lblEnigme.TextAlign = ContentAlignment.TopCenter;

            Controls.Add(lblEnigme);
        }
    }
}
