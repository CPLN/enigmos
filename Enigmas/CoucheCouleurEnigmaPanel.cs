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
        private Label lblReponse;
        /// <summary>
        /// Constructeur pas défaut
        /// </summary>
        public CoucheCouleurEnigmaPanel()
        {
            iCpt = 0;
            tabCouleur = new string[7] { "Purple", "Orange", "Blue", "Green", "Pink", "Red", "Yellow" };
            tabReponse = new char[7] { 'T', 'R', 'O', 'L', 'L', 'E', 'R' };
            PanelCouche = new List<Panel>();
            for (int i = 0;i<tabCouleur.Length; i++)
            {
                Panel panel = new Panel();
                panel.Location = new System.Drawing.Point(0, 0);
                panel.Size = new System.Drawing.Size(800, 600);
                panel.BackColor = System.Drawing.Color.FromName(tabCouleur[i]);
                PanelCouche.Add(panel);
            }     
            PanelCouche.ForEach(this.Controls.Add);

            lblReponse = new Label();
            lblReponse.Location = new Point(100, 100);
            lblReponse.Text = "La réponse est la suite de caractère que vous venez d'entrer";
            Controls.Add(lblReponse);
        }

        public override void PressKey(object sender, KeyEventArgs e)
        {
                if(Convert.ToChar(e.KeyValue) == tabReponse[iCpt])
                {
                    PanelCouche[iCpt].Visible = false;
                if(iCpt<6)
                    iCpt++;
                } 
        }
    }
}
