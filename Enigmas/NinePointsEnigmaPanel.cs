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
        /*Variables & constantes*/
        private PictureBox pcbCase9Points = new PictureBox();
        private Point[] tSaveMouseClickPosition = new Point[5];
        private Point[] tCentrePoint = new Point[9];
        private bool[] tPointTrace = new bool[9];
        private Point cursorPosition = new Point();
        const int RAYON_POINT = 78;

        /// <summary>
        /// Affichage de l'énigme 9 points
        /// </summary>
        public NinePointsEnigmaPanel()
        {
            this.Height = 800; //change la taille du panel "parent"

            /*Initialise la PictureBox*/
            pcbCase9Points.Size = this.Size;
            pcbCase9Points.BackgroundImage = Properties.Resources.NinePoints;
            pcbCase9Points.Click += new System.EventHandler(MouseClick_Affiche9Points);
            pcbCase9Points.MouseMove += new MouseEventHandler(MouseMove_Afficher9Points);
            pcbCase9Points.Paint += new PaintEventHandler(Paint_pcbCase9Points);
            Controls.Add(pcbCase9Points);

            /*Initialise bouton recommencer*/
            Button btnRecommencer = new Button();
            btnRecommencer.Font = new Font("Microsoft Sans Serif", 19);
            btnRecommencer.Text = "Recommencer";
            btnRecommencer.AutoSize = true;
            btnRecommencer.Click += new EventHandler(MouseClick_btnRecommencer);
            btnRecommencer.Location = new Point(this.Left + 10, this.Top + 750);
            Controls.Add(btnRecommencer);
            btnRecommencer.BringToFront();

            /*Initialise les positions du centre des points*/
            for (int i = 0, iX = 200, iY = 200; i < tCentrePoint.Length; i++, iX += 200)
            {
                if (i % 3 == 0 && i != 0) //permet de changer de ligne dans un axe x, y
                {
                    iY += 200;
                    iX = 200;
                }
                tCentrePoint[i] = new Point(iX, iY);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseClick_btnRecommencer(object sender, EventArgs e)
        {
            RedemarrerEnigme();
        }

        /// <summary>
        /// Dessine les traits dans la PictureBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Paint_pcbCase9Points(object sender, PaintEventArgs e)
        {
            /*Pinceau*/
            Pen pen = new Pen(Color.Blue, 20);
            int i = 1;
            /*Dessine les traits un par un, si leurs positions sont connues*/
            for (i = 1; i < tSaveMouseClickPosition.Length; i++)
            {
                if (tSaveMouseClickPosition[i].IsEmpty)
                {
                    break;
                }
                e.Graphics.DrawLine(pen, tSaveMouseClickPosition[i - 1], tSaveMouseClickPosition[i]);
            }
            if (cursorPosition != new Point())
            {
                e.Graphics.DrawLine(pen, tSaveMouseClickPosition[i - 1], cursorPosition);
            }
        }

        /// <summary>
        /// Sauvegarde les positions des clicks de souris, met à jour la PictureBox 
        /// et détecte si les traits sont sur les points
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

            /*Détecte si tous les points sont tracés*/
            if(iFirstCaseEmpty == 4)
            {
                /*Vérifie que chaque point à été tracé*/
                for (int iPoint = 0; iPoint < tCentrePoint.Length; iPoint++)
                {
                    for (int iTrait = 1; iTrait < tSaveMouseClickPosition.Length; iTrait++)
                    {
                        if (RAYON_POINT > Distance(tSaveMouseClickPosition[iTrait - 1], tSaveMouseClickPosition[iTrait], tCentrePoint[iPoint]))
                        {
                            tPointTrace[iPoint] = true;
                        }
                    }
                }
                /*Vérifie si l'un des points n'a pas été tracé*/
                bool bOk = true;
                for(int i = 0; i < tPointTrace.Length; i++)
                {
                    if (tPointTrace[i] != true)
                    {
                        bOk = false;
                    }
                }

                /*Message de fin - victoire/ défaite?*/
                if (bOk)
                {
                    MessageBox.Show("La réponse est \" 9.\"");
                    pcbCase9Points.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Perdu! Vous n'avez pas réussi à tracer touts les points!");
                    RedemarrerEnigme();
                }
            }
        }
        /// <summary>
        /// Affiche le prochain trait de façon dynamique
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseMove_Afficher9Points(object sender, MouseEventArgs e)
        {
            /**/
            if (tSaveMouseClickPosition[0] != new Point())
            {
                cursorPosition = e.Location;
                pcbCase9Points.Invalidate();
            }
        }

        /// <summary>
        /// Formule qui calcule la distance d'un point à une droite
        /// </summary>
        /// <param name="p1">Premier point de la droite</param>
        /// <param name="p2">Deuxième point de la droite</param>
        /// <param name="p">Point externe à la droite dont on souhaite connaitre la distance par rapport à la droite</param>
        /// <returns></returns>
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

        /// <summary>
        /// Relance l'énigme
        /// </summary>
        private void RedemarrerEnigme()
        {
            tSaveMouseClickPosition = new Point[5];
            tPointTrace = new bool[9];
            pcbCase9Points.Image = null;
            cursorPosition = new Point();
        }
    }
}