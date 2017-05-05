using System;
using System.Collections.Generic;
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
            PanelCouche = new List<Panel>();

            Panel p1 = new Panel();
            AjoutPanelEtPos(p1,100,100, 50, 50);

            Panel p2 = new Panel();
            AjoutPanelEtPos(p2, 100, 100, 50, 50);

            Panel p3 = new Panel();
            AjoutPanelEtPos(p3, 100, 100, 50, 50);

            Panel p4 = new Panel();
            AjoutPanelEtPos(p4, 100, 100, 50, 50);

            Panel p5 = new Panel();
            AjoutPanelEtPos(p5, 100, 100, 50, 50);

            Panel p6 = new Panel();
            AjoutPanelEtPos(p6, 100, 100, 50, 50);

            Panel p7 = new Panel();
            AjoutPanelEtPos(p7, 100, 100, 50, 50);

        }
        /// <summary>
        /// Ajoute le panel dans la liste et ajoute une position
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="iPosLeft"></param>
        /// <param name="iPosTop"></param>
        public void AjoutPanelEtPos(Panel panel, int iPosLeft, int iPosTop,int dblHeight,int dblWidht)
        {
            panel.Left = iPosLeft;
            panel.Location = new System.Drawing.Point(iPosLeft, iPosTop);
            panel.Size = new System.Drawing.Size(dblHeight, dblWidht);
            panel.BackColor = System.Drawing.Color.Green;
            PanelCouche.Add(panel);

        }
         
    }
}
