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
        private PictureBox pcbCase9Points = new PictureBox();
        private Point[] tSaveMouseClickPosition = new Point[5];

        /// <summary>
        /// Charge l'énigme des 9 points.
        /// </summary>
        public NinePointsEnigmaPanel()
        {
            Affiche9Point();

        }

        public void Affiche9Point()
        {
            this.Height = 800;
            pcbCase9Points.Size = this.Size;
            pcbCase9Points.Click += new System.EventHandler(MouseClick_Affiche9Points);
            pcbCase9Points.Paint += new PaintEventHandler(Paint_pcbCase9Points);
            Controls.Add(pcbCase9Points);
        }

        private void Paint_pcbCase9Points(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, 10);

            for (int i = 1; i < tSaveMouseClickPosition.Length; i++)
            {
                if (tSaveMouseClickPosition[i].IsEmpty)
                {
                    break;
                }
                e.Graphics.DrawLine(pen, tSaveMouseClickPosition[i - 1].X - this.Left, tSaveMouseClickPosition[i - 1].Y - this.Top, tSaveMouseClickPosition[i].X - this.Left, tSaveMouseClickPosition[i].Y - this.Top);
            }
        }

        private void MouseClick_Affiche9Points(object sender, EventArgs e)
        {
            int iFirstCaseEmpty = 0;

            /*Trouve la première case vide*/
            for (int i = 0; i < tSaveMouseClickPosition.Length; i++)
            {
                if (tSaveMouseClickPosition[i].IsEmpty)
                {
                    iFirstCaseEmpty = i;
                    break;
                }
            }

            /*Ajoute les dernières positions connues*/
            tSaveMouseClickPosition[iFirstCaseEmpty] = Cursor.Position;

            /*Éxecute la suite du code si le numéro de la première case vide est impaire*/
            if (iFirstCaseEmpty != 0)
            {
                pcbCase9Points.Invalidate();
            }

            if(iFirstCaseEmpty == 4)
            {
                //tSaveMouseClickPosition = new int[5, 2];
            }
        }
    }
}
