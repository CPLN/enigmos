using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    public class NinePointsEnigmaPanel : EnigmaPanel
    {
        /// <summary>
        /// Charge l'énigme des 9 points.
        /// </summary>
        public NinePointsEnigmaPanel()
        {


        }
        /// <summary>
        /// 
        /// </summary>
        private void Affiche9Points()
        {
            TableLayoutPanel TlpCase9Points = new TableLayoutPanel();
            TlpCase9Points.ColumnCount = 5;
            for (int i = 0; i < 5;i++)
                TlpCase9Points.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.2f));
            TlpCase9Points.RowCount = 5;
            for (int i = 0; i < 5; i++)
                TlpCase9Points.RowStyles.Add(new RowStyle(SizeType.Percent, 0.2f));
            TlpCase9Points.Dock = DockStyle.Fill;
        }
        

    }
}
