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
        List<Button> boutons = new List<Button>(); //Liste pour les boutons.
        string strMot = "BANANAS"; //Réponse de l'énigme.
        Label Reponse = new Label();
        PictureBox pbx = new PictureBox();
        Label lblEnigme = new Label();

        public SingesEnigmaPanel()
        {
            //Image de base.
            pbx.BackgroundImage = Properties.Resources.SingesBackground;
            pbx.Size = Properties.Resources.SingesBackground.Size;
            ImageSinges();

            //Génération du titre.
            lblEnigme.Text = "Jeu des 3 Singes";
            lblEnigme.Font = new Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold);
            lblEnigme.Dock = DockStyle.Top;
            lblEnigme.TextAlign = ContentAlignment.TopCenter;

            this.Controls.Add(lblEnigme);

            //Création des boutons
                Button bouton = new Button();
                bouton.Size = new Size(30, 30);
                bouton.Click += new EventHandler(bouton_Click); //Création d'un évenement pour chaque clic sur un bouton.
                //bouton.Location = new Point(j, k);
                this.Controls.Add(bouton);
                boutons.Add(bouton); //Ajoute le bouton dans la liste des boutons.
        }

        //Evenement sur le clic sur un bouton.
        private void bouton_Click(object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;
        }

        private void ImageSinges()
        {
            pbx.Location = new Point(200, 200);
            Controls.Add(pbx);
        }

        public override void Unload()
        {
            //Activation des boutons.
            foreach (Button bouton in boutons)
            {
                bouton.Enabled = true;
            }
        }
            /*
            {
                MessageBox.Show("Bravo !\nLe code est -BANANAS-", "Les 3 singes");
            }*/
        }
}
