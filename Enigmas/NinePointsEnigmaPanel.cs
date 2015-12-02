using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cpln.Enigmos.Enigmas.Components;

namespace Cpln.Enigmos.Enigmas
{
    public class NinePointsEnigmaPanel : EnigmaPanel
    {
        private Jeton[] tJeton = new Jeton[9];
        private CaseVide[] tCaseVide = new CaseVide[16];
        private TableLayoutPanel TlpCase9Points;

        /// <summary>
        /// Charge l'énigme des 9 points.
        /// </summary>
        public NinePointsEnigmaPanel()
        {
            Affiche9Points();

        }

        /// <summary>
        /// Créer la structure de l'énigme et affiche les 9 points
        /// </summary>
        private void Affiche9Points()
        {
            this.Height = 800;
            this.BackColor = Color.Black;

            /*Créer tableau 5x5*/
            TlpCase9Points = new TableLayoutPanel();
            TlpCase9Points.ColumnCount = 5;
            for (int i = 0; i < 5; i++)
                TlpCase9Points.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.2f));
            TlpCase9Points.RowCount = 5;
            for (int i = 0; i < 5; i++)
                TlpCase9Points.RowStyles.Add(new RowStyle(SizeType.Percent, 0.2f));
            TlpCase9Points.Dock = DockStyle.Fill;

            Controls.Add(TlpCase9Points);

            /*Affiche les 9 points de l'énigme*/
            for (int iY = 1, i = 0; iY <= 3; iY++)
                for (int iX = 1; iX <= 3; iX++, i++)
                    tJeton[i] = new Jeton(iX, iY, this, TlpCase9Points);

            /*Créer les cases autour des 9 points*/
            for (int iY = 0, i = 0; iY < 5; iY+= 4)
                for (int iX = 0; iX < 5; iX++, i++)
                    tCaseVide[i] = new CaseVide(iX, iY, this, TlpCase9Points);

            for (int iX = 0, i = 10; iX < 5; iX += 4)
                for (int iY = 1; iY < 4; iY++, i++)
                    tCaseVide[i] = new CaseVide(iX, iY, this, TlpCase9Points);
        }
        

    }
}
