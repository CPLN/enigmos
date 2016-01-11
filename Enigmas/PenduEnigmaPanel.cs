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
        Label Reponse = new Label();
        PictureBox pbx = new PictureBox();
        Label lblEnigme = new Label();
        string text = "*******";

        public PenduEnigmaPanel()
        {
            //Image de base
            pbx.BackgroundImage = Properties.Resources.imageA;
            pbx.Size = Properties.Resources.imageA.Size;
            ImagePendu();

            for (int i = 0; i < strMot.Length; i++)
            {
                Reponse.Text += "*";
            }
            Reponse.Font = new Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold);
            Reponse.Dock = DockStyle.Bottom;
            Reponse.TextAlign = ContentAlignment.BottomCenter;
            Controls.Add(Reponse);

            //Génération du titre
            lblEnigme.Text = "Jeu du pendu";
            lblEnigme.Font = new Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold);
            lblEnigme.Dock = DockStyle.Top;
            lblEnigme.TextAlign = ContentAlignment.TopCenter;

            this.Controls.Add(lblEnigme);
            
            //Boucle qui crée les boutons pour chaque lettre de l'alphabet
            for (int i = 0; i <= 25; i++)
            {
                j += 35;
                Button bouton = new Button();
                bouton.Size = new Size(30, 30); 
                bouton.Click += new EventHandler(bouton_Click);
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
                this.Controls.Add(bouton);
                boutons.Add(bouton);
            }

            //Foreach qui ajoute toutes les lettres de l'alphabet sur les boutons créés précédemment
            foreach(Button bouton in boutons)
            {
                bouton.Text = Convert.ToString(Convert.ToChar(iAscii));
                iAscii++;
            }
        }

        public override void Unload()
        {
            foreach (Button bouton in boutons)
            {
                bouton.Enabled = true;
            }

            pbx.BackgroundImage = Properties.Resources.imageA;

            Reponse.Text = "";
            text = "";
            for (int i = 0; i < strMot.Length; i++)
            {
                Reponse.Text += "*";
                text += "*";
            }

            iFautes = 0;
        }

        void bouton_Click(Object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;
            test_lettre(Convert.ToChar(((Button)sender).Text));
        }

         private void test_lettre(char Lettre)
         {
            bool faute = true;
            for (int i = 0; i < strMot.Length; i++)
            {
                if (strMot[i] == Lettre)
                {
                    string Partie1 = text.Substring(0, i);
                    string Partie2 = text.Substring(i + 1);
                    text = Partie1 + Lettre + Partie2;
                    faute = false;
                }
            }
            if (faute)
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
                    pbx.BackgroundImage = Properties.Resources.imageC;
                    pbx.Size = Properties.Resources.imageC.Size;
                    ImagePendu();
                    break;
                case 3:
                    pbx.BackgroundImage = Properties.Resources.imageD;
                    pbx.Size = Properties.Resources.imageD.Size;
                    ImagePendu();
                    break;
                case 4:
                    pbx.BackgroundImage = Properties.Resources.imageE;
                    pbx.Size = Properties.Resources.imageE.Size;
                    ImagePendu();
                    break;
                case 5:
                    pbx.BackgroundImage = Properties.Resources.imageF;
                    pbx.Size = Properties.Resources.imageF.Size;
                    ImagePendu();
                    break;
                case 6:
                    pbx.BackgroundImage = Properties.Resources.imageG;
                    pbx.Size = Properties.Resources.imageG.Size;
                    ImagePendu();
                    MessageBox.Show("Dommage, vous n'avez pas réussis cette enigme,\nil vous faut donc la passer", "Fin");
                    break;
                }   

            }
            Reponse.Text = text;
            if (text == "OXYGENE")
            {
                MessageBox.Show("Bravo !\nVous avez découvert le mot -oxygene-","Pendu");
            }
        }
        private void ImagePendu()
         {
             pbx.Location = new Point(450,200);
             Controls.Add(pbx);
         }

    }
}
