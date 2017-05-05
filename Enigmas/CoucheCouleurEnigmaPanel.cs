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
            iCpt = 0;
            tabCouleur = new string[iLongeurReponse] { "Purple", "Orange", "Blue", "Green", "Pink", "Red", "Yellow" };
            tabReponse = new char[iLongeurReponse] { 'T', 'R', 'O', 'L', 'L', 'E', 'R' };
            PanelCouche = new List<Panel>();

            lblReset = new Label();
            lblReset.Text = "Recommencer";
            lblReset.Click += new EventHandler(Reset);
            Controls.Add(lblReset);

            //création de tous les panels en fonction de la longueur de la Réponse avec juste la couleur qui change
            for (int i = 0;i<tabCouleur.Length; i++)
            {
                Panel panel = new Panel();
                panel.Location = new Point(0, 0);
                panel.Size = new Size(800, 600);
                panel.BackColor = Color.FromName(tabCouleur[i]);
                PanelCouche.Add(panel);
            }     
            PanelCouche.ForEach(this.Controls.Add);

            lblReponse = new Label();
            lblReponse.Location = new Point(100, 50);
            lblReponse.Text = "La réponse est la suite de caractères que vous venez d'entrer.";
            lblReponse.Width = 300;
            Controls.Add(lblReponse);

            ptbTrolle = new PictureBox();
            ptbTrolle.Location = new Point(200, 100);
            ptbTrolle.Size = new Size(1000, 1000);
            ptbTrolle.Image = Properties.Resources.TrollFace;
            Controls.Add(ptbTrolle);
        }

        public override void PressKey(object sender, KeyEventArgs e)
        {
            //regarde si le caractère entré est égale à la case du tableau
                if(e.KeyValue == tabReponse[iCpt])
                {
                    PanelCouche[iCpt].Visible = false;
                if(iCpt<6)
                    iCpt++;
                } 
        }
        private void Reset(object sender, EventArgs e)
        {
            iCpt = 0;
            foreach(Panel panel in PanelCouche)
            {
                panel.Visible = true;
            }
        }
    }

}
