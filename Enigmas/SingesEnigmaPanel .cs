using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    public class SingesEnigmaPanel : EnigmaPanel
    {
        private Button[] btnReponse = new Button[5];
        //string strMot = "BANANAS"; //Réponse de l'énigme.
        Label Reponse = new Label();
        //PictureBox pbx = new PictureBox();
        Label lblEnigme = new Label();

        public SingesEnigmaPanel()
        {
            //Génération du titre.
            lblEnigme.Text = "Jeu des 3 Singes";
            lblEnigme.Font = new Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold);
            lblEnigme.Dock = DockStyle.Top;
            lblEnigme.TextAlign = ContentAlignment.TopCenter;

            this.Controls.Add(lblEnigme);

            //Image de base.
            BackgroundImage = Properties.Resources.jungle;
            Size = Properties.Resources.jungle.Size;
            //ImageSinges();

            //Création des boutons
            Button bouton = new Button();
            bouton.Size = new Size(50, 80);
            bouton.Click += new EventHandler(bouton_Click);
            for (int i = 0; i < 5; i++)
            {
                Controls.Remove(btnReponse[i]);
                btnReponse[i] = new Button();
                //btnReponse[i].Image = Image.FromFile("banane");
            }

            btnReponse[0].Location = new Point(450, 800);//Placement des boutons
            btnReponse[1].Location = new Point(600, 850);
            btnReponse[2].Location = new Point(750, 800);
            btnReponse[3].Location = new Point(900, 850);
            btnReponse[4].Location = new Point(1050, 800);

            for (int i = 0; i < 5; i++)
            {
                //attribution d'une taille et d'un texte pour les boutons
                btnReponse[i].Width = 50;
                btnReponse[i].Height = 30;
                //btnReponse[i].Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);
                btnReponse[i].FlatStyle = FlatStyle.System;
                Controls.Add(btnReponse[i]);
            }
        }

            //Evenement sur le clic sur un bouton.
            private void bouton_Click(object sender, EventArgs e)
            {
                ((Button)sender).Enabled = false;
            }

            private void ImageSinges()
            {
                //pbx.Location = new Point(200, 200);
                //Controls.Add(pbx);
            }

        public override void Unload()
        {
        }
    }
}
