using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas.Components.Clou
{
    /// <summary>
    /// Classe présentant une barre d'énergie.
    /// </summary>
    class EnergyBar : PictureBox
    {
        private Timer timer = new Timer();
        private Panel cursor = new Panel();
        private int iY = 0;

        /// <summary>
        /// Constructeur : Définition/instanciation des valeurs par défaut.
        /// </summary>
        public EnergyBar()
        {
            #region Pbx propriétés
            //Définition de l'image source
            BackgroundImage = Properties.Resources.barResized;

            //Définition de la taille de l'image
            Size = new Size(44, 356);
            #endregion

            #region Curseur propriétés
            //Définition de la taille du curseur
            cursor.Size = new Size(44, 10);

            //Définition de la couleur du curseur
            cursor.BackColor = Color.Black;

            //Le curseur se positionne par défaut sur la base de la barre
            cursor.Location = new Point(0, 346);
            #endregion

            #region Timer propriétés
            //Définition de l'évènement du timer
            timer.Tick += timer_Tick;

            //Définition de l'interval (ms) de rafraichissement
            timer.Interval = 1;

            //Le curseur bouge par défaut
            timer.Start();
            #endregion

            //Ajout du curseur dans la forme
            Controls.Add(cursor);
        }

        #region Méthodes
        /// <summary>
        /// Reset la position du curseur
        /// </summary>
        public void ResetCursorPosition()
        {
            //Stop le timer
            timer.Stop();

            //Replace le curseur sur la base de la barre
            cursor.Location = new Point(0, 346);
        }

        /// <summary>
        /// Lance l'animation du curseur
        /// </summary>
        public void StartCursor()
        {
            //Relance le timer
            timer.Start();
        }

        /// <summary>
        /// Stop le curseur et capture sa position
        /// </summary>
        /// <returns>La puissance du coup</returns>
        public int CaptureCursorPower()
        {
            //Stop le timer
            timer.Stop();

            //Capture la position du curseur et définit la puissance du coup en fonction de sa position
            if(cursor.Location.Y < 0 || cursor.Location.Y >= 0 && cursor.Location.Y <= 89)
            {
                ResetCursorPosition();

                //20 de puissance
                return 20;
            }
            else if(cursor.Location.Y >= 90 && cursor.Location.Y <= 179)
            {
                ResetCursorPosition();

                //15 de puissance
                return 15;
            }
            else if(cursor.Location.Y >= 180 && cursor.Location.Y <= 269)
            {
                ResetCursorPosition();

                //10 de puissance
                return 10;
            }
            else if(cursor.Location.Y >= 270 && cursor.Location.Y <= 356 || cursor.Location.Y > 356)
            {
                ResetCursorPosition();

                //5 de puissance
                return 5;
            }
            else
            {
                ResetCursorPosition();
                return 0;
            }
        }
        #endregion

        #region Evènements
        /// <summary>
        /// Mouvement du curseur le long de la barre d'énergie
        /// </summary>
        void timer_Tick(object sender, EventArgs e)
        {
            if(cursor.Location.Y >= 346)
            {
                //Monter
                iY = -7;
            }
            else if (cursor.Location.Y <= 0)
            {
                //Descendre
                iY = 7;
            }

            cursor.Top += iY;
        }
        #endregion
    }
}
