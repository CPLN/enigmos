using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas.Components
{
    class Touche : Panel
    {
        //List<Panel> LesTouches = new List<Panel>();
        //Panel pnlCtrl, pnlWindows, pnlAlt, pnlSpace, pnlAltgr, pnlMaj, pnlDash, pnlPoint, pnlComa, pnlCapslock, pnlTab, pnlEnter, pnlDelete, pnlApostrophie, pnl1, pnl2, pnl3, pnl4, pnl5, pnl6, pnl7, pnl8, pnl9, pnl0, pnlQ, pnlW, pnlE, pnlR, pnlT, pnlZ, pnlU, pnlI, pnlO, pnlP, pnlA, pnlS, pnlD, pnlF, pnlG, pnlH, pnlJ, pnlK, pnlL, pnlY, pnlX, pnlC, pnlV, pnlB, pnlN, pnlM;
        //public List<Panel> LesTouches1
        //{
        //    get
        //    {
        //        return LesTouches;
        //    }

        //    set
        //    {
        //        LesTouches1.All(pnlCtrl, pnlWindows, pnlAlt, pnlSpace, pnlAltgr, pnlMaj, pnlDash, pnlPoint, pnlComa, pnlCapslock, pnlTab, pnlEnter, pnlDelete, pnlApostrophie, pnl1, pnl2, pnl3, pnl4, pnl5, pnl6, pnl7, pnl8, pnl9, pnl0, pnlQ, pnlW, pnlE, pnlR, pnlT, pnlZ, pnlU, pnlI, pnlO, pnlP, pnlA, pnlS, pnlD, pnlF, pnlG, pnlH, pnlJ, pnlK, pnlL, pnlY, pnlX, pnlC, pnlV, pnlB, pnlN, pnlM);
        //        LesTouches = value;
        //    }
        //}

        private string strNom;
        public Touche(string nom,int locX,int locY)
        {
            strNom = nom;
            Location = new Point(locX,locY);
            Width = 4;
            Height = 4;
            
        }
        public Touche(string nom, int locX, int locY, int width, int height)
        {
            strNom = nom;
            Location = new Point(locX, locY);
            Width = width;
            Height = height;

        }
    }
}

