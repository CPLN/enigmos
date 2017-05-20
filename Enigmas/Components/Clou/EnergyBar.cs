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
            #endregion

            #region Timer propriétés
            //Définition de l'évènement du timer
            timer.Tick += timer_Tick;

            //Définition de l'interval (ms) de rafraichissement
            timer.Interval = 10;
            #endregion
        }

        /// <summary>
        /// Mouvement du curseur le long de la barre d'énergie
        /// </summary>
        void timer_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
