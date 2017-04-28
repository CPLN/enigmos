using Cpln.Enigmos.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas.Components
{
    class MovablePanel : Panel
    {
        /// <summary>
        /// Élément représentant l'image complète.
        /// </summary>
        private Control element;
        /// <summary>
        /// Coordonnées dans l'image complète où la pièce du puzzle commence.
        /// </summary>
        private Point start;
        /// <summary>
        /// La pièce est-elle en train de suivre le mouvement de la souris ?
        /// </summary>
        private bool bMoving = false;
        /// <summary>
        /// Coordonnées de départ du déplacement.
        /// </summary>
        private Point moveStart;

        /// <summary>
        /// Ce constructeur permet de créer une pièce de puzzle d'après un élément représentant le puzzle terminé.
        /// </summary>
        /// <param name="element">L'élément représentant le puzzle terminé</param>
        /// <param name="start">Les coordonnées de la pièce dans le puzzle terminé</param>
        public MovablePanel(Control element, Point start)
        {
            this.element = element;
            this.start = start;
            element.Location = start;
            Label l = (Label)element;
            BackColor = Color.Turquoise;

            Controls.Add(element);

            element.MouseDown += new MouseEventHandler(MoveStart);
            element.MouseMove += new MouseEventHandler(MoveMove);
            element.MouseUp += new MouseEventHandler(MoveStop);
        }

        /// <summary>
        /// Cette méthode permet de générer une liste de pièces de puzzle d'après un texte.
        /// 
        /// Le texte est d'abord inséré dans un Label avec la police GenericMonospace de taille 72pt avant d'être découpé en plusieurs morceaux.
        /// </summary>
        /// <param name="text">Le texte à afficher</param>
        /// <param name="xCuts">Le nombre de pièces en largeur</param>
        /// <param name="yCuts">Le nombre de pièces en hauteur</param>
        /// <returns>Une liste de pièces contenant chacun une partie de l'image</returns>
        public static List<PuzzlePiece> GeneratePieces(string text, int xCuts, int yCuts)
        {
            ShuffleList<PuzzlePiece> pieces = new ShuffleList<PuzzlePiece>();

            Size referenceRealSize = TextRenderer.MeasureText(text, new Font(FontFamily.GenericMonospace, 72));
            int width = referenceRealSize.Width / xCuts;
            int height = referenceRealSize.Height / yCuts;

            for (int j = 0; j <= referenceRealSize.Height - height; j += height)
            {
                for (int i = 0; i <= referenceRealSize.Width - width; i += width)
                {
                    Label label = new Label();
                    label.Text = text;
                    label.Font = new Font(FontFamily.GenericMonospace, 72);
                    label.AutoSize = true;
                    PuzzlePiece piece = new PuzzlePiece(label, new Point(-i, -j));
                    piece.Size = new Size(width, height);
                    pieces.Add(piece);
                }
            }
            pieces.Shuffle();
            return pieces;
        }

        /// <summary>
        /// Appelé lors du clic sur la pièce.
        /// </summary>
        /// <param name="sender">L'objet appelant</param>
        /// <param name="e">Les données liées à la souris</param>
        private void MoveStart(object sender, MouseEventArgs e)
        {
            bMoving = true;
            moveStart = e.Location;
        }

        /// <summary>
        /// Appelé lors du déplacement de la pièce.
        /// </summary>
        /// <param name="sender">L'objet appelant</param>
        /// <param name="e">Les données liées à la souris</param>
        private void MoveMove(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.NoMove2D;
            if (bMoving)
            {
                int newX = Left + e.X - moveStart.X;
                int newY = Top + e.Y - moveStart.Y;

                Left = Math.Max(Math.Min(newX, Parent.Width - Width), 0);
                Top = Math.Max(Math.Min(newY, Parent.Height - Height), 0);
            }
        }

        /// <summary>
        /// Appelé lors du relachement du bouton sur la pièce.
        /// </summary>
        /// <param name="sender">L'objet appelant</param>
        /// <param name="e">Les données liées à la souris</param>
        private void MoveStop(object sender, MouseEventArgs e)
        {
            bMoving = false;
        }
    }
}
