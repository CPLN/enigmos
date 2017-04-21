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
        Panel pCouche1;
        Panel pCouchep2;
        Panel pCouche3;
        Panel pCouche4;
        Panel pCouche5;
        Panel pCouche6;
        Panel pCouche7;
        /// <summary>
        /// Constructeur pas défaut
        /// </summary>
        public CoucheCouleurEnigmaPanel()
        {
            PanelCouche = new List<Panel>();

            pCouche1 = new Panel();
            AjoutPanelEtPos(pCouche1,100,100, 50, 50,"Orange");

            pCouchep2 = new Panel();
            AjoutPanelEtPos(pCouchep2, 100, 100, 50, 50,"Grey");

            pCouche3 = new Panel();
            AjoutPanelEtPos(pCouche3, 100, 100, 50, 50,"Blue");

            pCouche4 = new Panel();
            AjoutPanelEtPos(pCouche4, 100, 100, 50, 50, "Green");

            pCouche5 = new Panel();
            AjoutPanelEtPos(pCouche5, 100, 100, 50, 50,"Pink");

            pCouche6 = new Panel();
            AjoutPanelEtPos(pCouche6, 100, 100, 500, 50,"Red");

            pCouche7 = new Panel();
            AjoutPanelEtPos(pCouche7, 100, 100,50,100, "White");


             PanelCouche.ForEach(this.Controls.Add);
             
        }

        /// <summary>
        /// Ajoute le panel dans la liste, une position, une taille et une couleur
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="iPosLeft"></param>
        /// <param name="iPosTop"></param>
        /// <param name="dblHeight"></param>
        /// <param name="dblWidht"></param>
        /// <param name="strCouleur"></param>
        public void AjoutPanelEtPos(Panel panel, int iPosLeft, int iPosTop,int dblHeight,int dblWidht,string strCouleur)
        {
            panel.Left = iPosLeft;
            panel.Location = new System.Drawing.Point(iPosLeft, iPosTop);
            panel.Size = new System.Drawing.Size(dblHeight, dblWidht);
            panel.BackColor = System.Drawing.Color.FromName(strCouleur);
            PanelCouche.Add(panel);
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'g')
            {
                pCouche1.Visible = false;
            }
        }
    }
}
