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
        /// <summary>
        /// Constructeur pas défaut
        /// </summary>
        public CoucheCouleurEnigmaPanel()
        {
            string[] tabCouleur = new string[7] { "Orange", "Grey", "Blue", "Green", "Pink", "Red", "White" };

            PanelCouche = new List<Panel>();
            for (int i = 0;i<tabCouleur.Length; i++)
            {
                Panel panel = new Panel();
                panel.Location = new System.Drawing.Point(100, 100);
                panel.Size = new System.Drawing.Size(50, 50);
                panel.BackColor = System.Drawing.Color.FromName(tabCouleur[i]);
                PanelCouche.Add(panel);
            }       
             PanelCouche.ForEach(this.Controls.Add);   
        }

        public override void PressKey(object sender, KeyEventArgs e)
        {
            
        }
    }
}
