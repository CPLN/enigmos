using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    public class PenduEnigmaPanel : EnigmaPanel
    {
        List<Button> boutons = new List<Button>(); //Liste pour les boutons.
        string strMot = "OXYGENE"; //Réponse de l'énigme.
        int iFautes = 0, k = 200, j = 65, iCompteur = 0, iAscii = 65;
        Label Reponse = new Label();
        PictureBox pbx = new PictureBox();
        Label lblEnigme = new Label();
        string text = "*******";

        public PenduEnigmaPanel()
        {
            //Image de base du pendu.
            pbx.BackgroundImage = Properties.Resources.imageA;
            pbx.Size = Properties.Resources.imageA.Size;
            ImagePendu();

            //Créaion du mot qui s'affiche en bas de l'écran, des astérisques en l'occurence.
            for (int i = 0; i < strMot.Length; i++)
            {
                Reponse.Text += "*";
            }
            Reponse.Font = new Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold);
            Reponse.Dock = DockStyle.Bottom;
            Reponse.TextAlign = ContentAlignment.BottomCenter;
            this.Controls.Add(Reponse);

            //Génération du titre.
            lblEnigme.Text = "Jeu du pendu";
            lblEnigme.Font = new Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold);
            lblEnigme.Dock = DockStyle.Top;
            lblEnigme.TextAlign = ContentAlignment.TopCenter;

            this.Controls.Add(lblEnigme);
            
            //Boucle qui crée les boutons pour chaque lettre de l'alphabet.
            for (int i = 0; i <= 25; i++)
            {
                j += 35;
                Button bouton = new Button();
                bouton.Size = new Size(30, 30); 
                bouton.Click += new EventHandler(bouton_Click); //Création d'un évenement pour chaque clic sur un bouton.
                //Place 6 boutons par ligne.
                if (j >= 310)
                {
                    j = 100;
                    k += 35;
                    iCompteur++;
                    //Il y a 6 boutons par ligne, il en reste donc 2 sur la dernière ligne(26 lettres dans l'alphabet), C'est pourquoi avec le code ci-dessous, on centre les deux derniers boutons.
                    if(iCompteur >= 4)
                    {
                        j=170;
                    }
                }
                bouton.Location = new Point(j, k);
                this.Controls.Add(bouton);
                boutons.Add(bouton); //Ajoute le bouton dans la liste des boutons.
            }

            //Foreach qui ajoute toutes les lettres de l'alphabet sur les boutons créés précédemment.
            foreach(Button bouton in boutons)
            {
                bouton.Text = Convert.ToString(Convert.ToChar(iAscii));
                iAscii++;
            }
        }

        public override void Unload()
        {
            //Activation des boutons.
            foreach (Button bouton in boutons)
            {
                bouton.Enabled = true;
            }
        }

        //Evenement sur le clic sur un bouton, utilisation de la méthode "test_lettre" avec comme paramètre la lettre se trouvant sur le bouton.
        void bouton_Click(Object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;
            test_lettre(Convert.ToChar(((Button)sender).Text));
        }

        //Méthode qui vérifie si la lettre choisie se trouve dans le mot.
        private void test_lettre(char Lettre)
        {
            bool faute = true;
            //Vérification de chaque lettre du mot.
            for (int i = 0; i < strMot.Length; i++)
            {
                //Ce if permet de vérifier si la lettre est dans le mot, et d'insérer la lettre trouvée, en coupant le mot en deux.
                if (strMot[i] == Lettre)
                {
                    string Partie1 = text.Substring(0, i);
                    string Partie2 = text.Substring(i + 1);
                    text = Partie1 + Lettre + Partie2;
                    faute = false;
                }
            }
            //Lorsqe la lettre choisie n'est pas dans le mot on entre ici.
            if (faute)
            {
                //Permet de gérer le nombre de faute (max: 7), change l'image du pendu pour chaque erreur.
                iFautes++;
                #region Switch fautes
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
                #endregion
            }
            Reponse.Text = text; //Affiche le mot en bas de l'écran, lorsqu'on trouve une lettre, elle s'affiche.
            //Lorsqu'on trouve la réponse entière, un message s'affiche en nous répétant la réponse à écrire.
            if (text == "OXYGENE")
            {
                MessageBox.Show("Bravo !\nVous avez découvert le mot -oxygene-","Pendu");
            }
        }
        //Méthode qui donne les mêmes paramètres pour toutes les images du pendu.
        private void ImagePendu()
         {
             pbx.Location = new Point(450,200);
             Controls.Add(pbx);
         }

    }
}
