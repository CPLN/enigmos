using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas.Components
{
    class CaseVide : Panel
    {
        //Attributs

        private int iX;
        private int iY;
        private TableLayoutPanel TlpTableau;

        //Constructeurs

        public CaseVide(int x, int y, EnigmaPanel parent, TableLayoutPanel tableau)
        {
            
            this.iX = x;
            this.iY = y;
            this.TlpTableau = tableau;

            TlpTableau.Controls.Add(this, x, y);

            this.Width = parent.Width / 5;
            this.Height = parent.Height / 5;

            this.BackColor = Color.LightGreen;
        }

        //Méthodes

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        public void MouseClick_CaseVide(object sender)
        {

        }

        // Accesseurs
        
        /// <summary>
        /// Donne la position dans l'axe X
        /// </summary>
        /// <returns></returns>
        public int getX()
        {
            return iX;
        }

        /// <summary>
        /// Donne la position dans l'axe Y
        /// </summary>
        /// <returns></returns>
        public int getY()
        {
            return iY;
        }
    }
}
