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
        private Point[] tCentrePoint = new Point[9];

        const int RAYON_POINT = 40;

        /// <summary>
        /// Charge l'énigme des 9 points.
        /// </summary>
        public NinePointsEnigmaPanel()
        {
            Affiche9Point();

        }

        /// <summary>
        /// Affichage des 9 points
        /// </summary>
        public void Affiche9Point()
        {
            this.Height = 800;
            pcbCase9Points.Size = this.Size;
            pcbCase9Points.Click += new System.EventHandler(MouseClick_Affiche9Points);
            pcbCase9Points.Paint += new PaintEventHandler(Paint_pcbCase9Points);
            Controls.Add(pcbCase9Points);

            Panel pnl = new Panel();
            pnl.BackColor = Color.Black; ;
            pnl.Location = new Point(this.Left + 380, this.Top + 380);
            pnl.Size = new Size(40, 40);
            this.Controls.Add(pnl);
            pnl.BringToFront();

            tCentrePoint[0] = new Point(Width / 2, Height / 2);
        }

        /// <summary>
        /// Dessine les traits dans la PictureBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Paint_pcbCase9Points(object sender, PaintEventArgs e)
        {
            /**/
            Pen pen = new Pen(Color.Black, 10);

            /*Dessine les traits un par un, si leurs positions sont connues*/
            for (int i = 1; i < tSaveMouseClickPosition.Length; i++)
            {
                if (tSaveMouseClickPosition[i].IsEmpty)
                {
                    break;
                }
                e.Graphics.DrawLine(pen, tSaveMouseClickPosition[i - 1], tSaveMouseClickPosition[i]);
            }
        }

        /// <summary>
        /// Sauvegarde les positions des clicks de souris & met à jour la PictureBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            tSaveMouseClickPosition[iFirstCaseEmpty] = PointToClient(Cursor.Position);

            /*Éxecute la suite du code si le numéro de la première case vide est impaire*/
            if (iFirstCaseEmpty != 0)
            {
                pcbCase9Points.Invalidate();
            }

            if(iFirstCaseEmpty != 0)
            {
                int iBeta, iA, iB, iC, iH;
                double dblBetaRad;

                int iTest = Distance(new Point(0, 0), new Point(20, 20));

                /*Calcule les distances entre les différents clique et le centre du point*/
                iA = Distance(tSaveMouseClickPosition[iFirstCaseEmpty - 1], tSaveMouseClickPosition[iFirstCaseEmpty]);
                iB = Distance(tSaveMouseClickPosition[iFirstCaseEmpty - 1], tCentrePoint[0]);
                iC = Distance(tCentrePoint[0], tSaveMouseClickPosition[iFirstCaseEmpty]);

                //double dblTest = (iA * iA + iC * iC - iB * iB) / (2 * iA * iC);
                //dblBetaRad = Math.Acos(dblTest);

                //iBeta = (int)Math.Round(dblBetaRad * (180 / Math.PI), MidpointRounding.AwayFromZero);
                
                double dblPartieA = iA * iA + iC * iC - iB * iB;
                double dblPartieB = 2 * iA * iC;
                double dblPartieC = dblPartieA / dblPartieB;

                dblBetaRad = (1.0 * iA * iA + iC * iC - iB * iB) / (2 * iA * iC); //Exemple bug

                double dblTest = Math.Acos((1.0 * iA * iA + iC * iC - iB * iB) / (2 * iA * iC));

                /*Formule pour trouver un angle à l'aide du théorème du Cosinus et de pythagore*/
                iBeta = (int)Math.Round(Math.Acos((1.0 * iA * iA + iC * iC - iB * iB) / (2 * iA * iC)) * (180 / Math.PI), MidpointRounding.AwayFromZero);
                
                iH = (int)Math.Round(iC * Math.Sin(1.0 * iBeta), MidpointRounding.AwayFromZero);
                
                if(RAYON_POINT > Distance(tSaveMouseClickPosition[iFirstCaseEmpty - 1], tSaveMouseClickPosition[iFirstCaseEmpty], new Point(400, 400)))
                {

                }
            }
        }
        /// <summary>
        /// Calcule la distance entre 2 points
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        private int Distance(Point p1, Point p2)
        {
            int dx = p1.X - p2.X;
            int dy = p1.Y - p2.Y;

            double distance = Math.Sqrt(dx * dx + dy * dy);

            return (int)Math.Round(distance, MidpointRounding.AwayFromZero);
        }

        private double Distance(Point p1, Point p2, Point p)
        {
            double pente = (1.0 * p2.Y - p1.Y) / (p2.X - p1.X);
            if (pente == double.NaN || double.IsInfinity(pente))
            {
                return Math.Abs(p2.X - p.X);
            }
            double distance = Math.Abs(pente * p.X - p.Y + (p1.Y - p1.X * pente)) / Math.Sqrt(1.0 + pente * pente);
            return distance;
        }
    }
}
