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
            BackgroundImage = Properties.Resources.nailCorrected;

            //Définition de la taille de l'image
            Size = new Size(100, 322);
            #endregion
        }

        #region Méthodes
        /// <summary>
        /// Descend le clou lorsqu'il est frappé
        /// </summary>
        /// <param name="power">La puissance du coup</param>
        public void Down(int power)
        {
            //Descend le clou en fonction de la puissance et met
            //à jour la propriété PixelsRemaining
            switch(power)
            {
                case 5:
                    Top += 17;
                    pixelsRemaining -= 17;
                break;

                case 10:
                    Top += 33;
                    pixelsRemaining -= 33;
                break;

                case 15:
                    Top += 49;
                    pixelsRemaining -= 49;
                break;

                case 20:
                    Top += 65;
                    pixelsRemaining -= 65;
                break;
            }
        }
        #endregion
    }
}
