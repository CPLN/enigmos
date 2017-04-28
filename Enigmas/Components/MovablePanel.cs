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
        private bool bMoving = false;
        /// <summary>
        /// Coordonnées de départ du déplacement.
        /// </summary>
        private Point moveStart;

        /// <summary>
        /// Ce constructeur permet de créer une pièce de puzzle d'après un élément représentant le puzzle terminé.
        /// </summary>
        public MovablePanel()
        {
            this.MouseDown += new MouseEventHandler(MoveStart);
            this.MouseMove += new MouseEventHandler(MoveMove);
            this.MouseUp += new MouseEventHandler(MoveStop);
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
