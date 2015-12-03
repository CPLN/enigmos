using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    /// <summary>
    /// Exemple d'énigme très simple. Seul un texte est affiché.
    /// </summary>
    public class PenduEnigmaPanel : EnigmaPanel
    {
        /// <summary>
        /// Génération des boutons avec les lettres de l'alphabet.
        /// </summary>
        List<Button> boutons = new List<Button>(); 
        string strMot = "OXYGENE";
        int iFautes = 0, k = 200, j = 65, iCompteur = 0, iAscii = 65;
        Label guess = new Label();
        PictureBox pbx = new PictureBox();

        public PenduEnigmaPanel()
        {
            pbx.BackgroundImage = Properties.Resources.imageA;
            pbx.Size = Properties.Resources.imageA.Size;
            ImagePendu();

            for (int i = 0; i <= 25; i++)
            {
                j += 35;
                Button bouton = new Button();
                bouton.Size = new Size(30, 30);
                if (j >= 310)
                {
                    j = 100;
                    k += 35;
                    iCompteur++;
                    if(iCompteur >= 4)
                    {
                        j=170;
                    }
                }
                bouton.Location = new Point(j, k);
                Controls.Add(bouton);
                boutons.Add(bouton);
            }

            foreach(Button bouton in boutons)
            {
                bouton.Text = Convert.ToString(Convert.ToChar(iAscii));
                iAscii++;
            }

            Label lblEnigme = new Label();

            lblEnigme.Text = "Jeu du pendu";
            lblEnigme.Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);
            lblEnigme.Dock = DockStyle.Fill;
            lblEnigme.TextAlign = ContentAlignment.TopCenter;

            Controls.Add(lblEnigme);
        }

         private void test_lettre(char Lettre)
         {
            string text = null;
            bool test = true;
            for (int i = 0; i < strMot.Length; i++)
            {
                if (strMot[i] == Lettre)
                {
                    text += Lettre;
                    test = false;
                }
                else
                {
                    if (guess.Text[i] != '*')
                        text += guess.Text[i];
                    else
                        text += "*";
                }
            }
            if (test)
            {
                iFautes++;
                switch (iFautes)
                {
                case 1:
                    pbx.BackgroundImage = Properties.Resources.imageB;
                    pbx.Size = Properties.Resources.imageB.Size;
                    ImagePendu();
                    break;
                case 2:
                        
                    break;
                case 3:
                        
                    break;
                case 4:
                        
                    break;
                case 5:
                        
                    break;
                case 6:
                        
                    break;
                case 7:
                        
                    MessageBox.Show("Dommage, vous n'avez pas réussis cete enigme,\n il vous faut donc la passer", "Fin");
                    break;
                }   
                guess.Text = text;
            }
        }
        private void ImagePendu()
         {
             pbx.Location = new Point(450,200);
             Controls.Add(pbx);
         }

    }
}
