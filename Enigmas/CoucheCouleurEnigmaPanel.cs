using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
   public class CoucheCouleurEnigmaPanel : EnigmaPanel
    {
        //Déclaration des Attributs

        private List<Panel> PanelCouche;
        private string[] tabCouleur;
        private char[] tabReponse;
        private int iCpt;
        private const int iLongeurReponse = 7;
        private Label lblReponse;
        private PictureBox ptbTrolle;
        private Label lblReset;


        /// <summary>
        /// Constructeur
        /// </summary>
        public CoucheCouleurEnigmaPanel()
        {
            //le compteur sert à passer dans les différentes cases des tableaux.
            iCpt = 0;
            tabCouleur = new string[iLongeurReponse] { "Purple", "Orange", "Blue", "Green", "Pink", "Red", "Yellow" };
            tabReponse = new char[iLongeurReponse] { 'T', 'R', 'O', 'L', 'L', 'E', 'R' };
            PanelCouche = new List<Panel>();

            //Propriétés du label lblReset
            lblReset = new Label();
            lblReset.Text = "Recommencer";
            lblReset.Click += new EventHandler(lbl_Reset_Click);
            
            //création de tous les panels en fonction de la longueur de la Réponse avec juste la couleur qui change
            for (int i = 0;i<tabCouleur.Length; i++)
            {
                Panel panel = new Panel();
                panel.Location = new Point(0, 0);
                panel.Size = new Size(800, 600);
                panel.BackColor = Color.FromName(tabCouleur[i]);
                PanelCouche.Add(panel);
            }

            //Propriétés du label lblReponse
            lblReponse = new Label();
            lblReponse.Location = new Point(100, 50);
            lblReponse.Text = "La réponse est la suite de caractères que vous venez d'entrer.";
            lblReponse.Width = 350;

            //Propriétés de la PictureBox ptbTrolle
            ptbTrolle = new PictureBox();
            ptbTrolle.Location = new Point(200, 100);
            ptbTrolle.Size = new Size(1000, 1000);
            ptbTrolle.Image = Properties.Resources.TrollFace;
            
            //Ajoute des objets aux controls
            Controls.Add(lblReset);
            PanelCouche.ForEach(this.Controls.Add);
            Controls.Add(lblReponse);
            Controls.Add(ptbTrolle);
        }
        /// <summary>
        /// Cette méthode est appelé quand l'utilisateur presse une touche du clavier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void PressKey(object sender, KeyEventArgs e)
        {
            //regarde si le caractère entré est égale à la case du tableau tabReponse
            if (e.KeyValue == tabReponse[iCpt])
                {
                    //Rend le panel invisible
                    PanelCouche[iCpt].Visible = false;
                if(iCpt<6)
                    iCpt++;
                } 
        }
        /// <summary>
        /// Appellé quand l'utlisateur clique sur le label lblReset
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_Reset_Click(object sender, EventArgs e)
        {
            Reset();
        }
        /// <summary>
        /// Appelé quand l'éngime s'affiche à l'écran
        /// </summary>
        public override void Load()
        {
            Reset();
        }
        private void Reset()
        {
            //Rend visible tous les panels de la liste PanelCouche et met le conteur à zéro
            foreach (Panel panel in PanelCouche)
            {
                panel.Visible = true;
            }
            iCpt = 0;
        }
    }

}
