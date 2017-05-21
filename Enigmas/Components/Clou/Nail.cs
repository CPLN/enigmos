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
    /// Classe représentant un clou
    /// </summary>
    class Nail : PictureBox
    {
        int pixelsRemaining = 356;

        /// <summary>
        /// Propriété indiquant le nombre de pixels qu'il reste à planter.
        /// </summary>
        public int PixelsRemaining 
        {
            get { return pixelsRemaining; }
        }

        /// <summary>
        /// Constructeur : Définition/instanciation des valeurs par défaut.
        /// </summary>
        public Nail()
        {
            #region Pbx propriétés
            //Définition de l'image source
            BackgroundImage = Properties.Resources.nailResized;

            //Définition de la taille de l'image
            Size = new Size(101, 356);
            #endregion
        }

        #region Méthodes
        /// <summary>
        /// Descend le clou lorsqu'il est frappé
        /// </summary>
        /// <param name="power">La puissance du coup</param>
        public void Blow(int power)
        {

        }
        #endregion
    }
}
