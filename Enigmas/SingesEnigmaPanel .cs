using System;
using System.Drawing;
using System.Windows.Forms;
namespace Cpln.Enigmos.Enigmas
{
    public class SingesEnigmaPanel : EnigmaPanel
    {
        //Déclarations des variables
        Label Reponse = new Label();
        Label lblEnigme = new Label();
        Timer tChrono = new Timer();
        private Button[] btnReponse = new Button[5];
        private PictureBox[] tblPbx = new PictureBox[3];
        Image[] tblImg = new Image[2];
        bool[] tblBool = new bool[3];
        private PictureBox pbxReponse;

        public SingesEnigmaPanel()
        {
            //Remplissage des cases du tableau d'images
            tblImg[0] = Properties.Resources.SingeBleuCymbalesFermees;
            tblImg[1] = Properties.Resources.SingeBleuCymbalesOuvertes;
            //Initialisation des PituresBox
            for (int i = 0; i < tblPbx.Length; i++)
            {
                tblPbx[i] = new PictureBox();
            }
            //Génération du titre.
            lblEnigme.Text = "Jeu des 3 Singes";
            lblEnigme.Font = new Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold);
            lblEnigme.Dock = DockStyle.Top;
            lblEnigme.TextAlign = ContentAlignment.TopCenter;
            Controls.Add(lblEnigme);
            //Image de base.
            BackgroundImage = Properties.Resources.jungle;
            Size = Properties.Resources.jungle.Size;
            //Formatages des pictures box et insertions de l'image du singe
            foreach (PictureBox pbx in tblPbx)
            {
                pbx.Image = Properties.Resources.SingeBleuCymbalesOuvertes;
                pbx.Size = Properties.Resources.SingeBleuCymbalesOuvertes.Size;
                pbx.BackColor = Color.Transparent;
                Controls.Add(pbx);
            }
            //Initialisation des booléans et passage de leur valeur à false
            for (int i = 0; i < tblBool.Length; i++)
            {
                tblBool[i] = new bool();
                tblBool[i] = false;
            }
         
            //Placement des PictureBox
            tblPbx[0].Location = new Point(200, 500);
            tblPbx[1].Location = new Point(600, 500);
            tblPbx[2].Location = new Point(1000, 500);

            //Création des boutons
            Button bouton = new Button();
            bouton.Size = new Size(50, 80);
            bouton.Click += new EventHandler(bouton_Click);
            for (int i = 0; i < 5; i++)
            {
                Controls.Remove(btnReponse[i]);
                btnReponse[i] = new Button();
            }
            //Placement des boutons
            btnReponse[0].Location = new Point(450, 800);
            btnReponse[1].Location = new Point(600, 850);
            btnReponse[2].Location = new Point(750, 800);
            btnReponse[3].Location = new Point(900, 850);
            btnReponse[4].Location = new Point(1050, 800);

            //Attribution d'une taille pour les boutons
            for (int i = 0; i < 5; i++)
            {
                btnReponse[i].Width = 50;
                btnReponse[i].Height = 30;
                //btnReponse[i].Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);
                btnReponse[i].FlatStyle = FlatStyle.System;
                Controls.Add(btnReponse[i]);
            }
            //Réponse à l'énigme
            if (tblBool[0] == true && tblBool[1] == true && tblBool[2] == true)
            {
                pbxReponse = new PictureBox();
                pbxReponse.Image = Properties.Resources.BananesWTF;
                pbxReponse.Size = Properties.Resources.BananesWTF.Size;
                pbxReponse.Location = new Point(500, 100);
                pbxReponse.BackColor = Color.Transparent;
                Controls.Add(pbxReponse);
            }
        }
            //Evènement sur le clic sur un bouton.
            private void bouton_Click(object sender, EventArgs e)
            {
            }

             private void TimerEventProcessor(object sender, EventArgs e)
            {
            }

        /// <summary>
        /// Permet d'activer un singe
        /// </summary>
        /// <param name="i">Correspond au numero de la cellule du tableau ou se trouve la pbx</param>
        public void Activer(int i)
        {
            if (tblPbx[i].Image == Properties.Resources.SingeBleuCymbalesFermees)
            {
                tblPbx[i].Image = Properties.Resources.SingeBleuCymbalesOuvertes;
            }
            if (tblPbx[i].Image == Properties.Resources.SingeBleuCymbalesOuvertes)
            {
                tblPbx[i].Image = Properties.Resources.SingeBleuCymbalesFermees;
            }
        }

        /// <summary>
        /// Permet d'arrêter le mouvement d'un singe
        /// </summary>
        /// <param name="i">Correspond au numero de la cellule du tableau ou se trouve la pbx</param>
        private void Desactiver(int i)
            {
               
            }

        /// <summary>
        /// Inverse l'état d'un singe
        /// </summary>
        ///  /// <param name="i">Correspond au numero de la cellule du tableau ou se trouve la pbx</param>
        private void Inverses(int i)
        {
            
        }

        /// <summary>
        /// Initialise le timer, créer une intervalle d'une demi-seconde, et le démarre
        /// </summary>
        private void Initialiser()
            {
               tChrono.Tick += new EventHandler(TimerEventProcessor);
               tChrono.Interval = 500;
               tChrono.Start();
            }   
         public override void Load()
        {
          Initialiser();
        }
         public override void Unload()
       {
          tChrono.Stop();
       }
    }
}

