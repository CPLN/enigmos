using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas.Components.Clou
{
    /// <summary>
    /// Classe présentant une barre d'énergie.
    /// </summary>
    class EnergyBar : PictureBox
    {
        Timer timer = new Timer();
        Panel cursor = new Panel();
        int iY = 0;

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

        /// <summary>
        /// Reset la position du curseur
        /// </summary>
        public void ResetCursorPosition()
        {
            //Stop le timer
            timer.Stop();

            //Replace le curseur sur la base de la barre
            cursor.Location = new Point(0, 346);

            //Relance le timer
            timer.Start();
        }
    }
}
