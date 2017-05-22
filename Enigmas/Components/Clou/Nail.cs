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
                    Top += 18;
                    pixelsRemaining -= 18;
                break;

                case 10:
                    Top += 36;
                    pixelsRemaining -= 36;
                break;

                case 15:
                    Top += 54;
                    pixelsRemaining -= 54;
                break;

                case 20:
                    Top += 72;
                    pixelsRemaining -= 72;
                break;
            }
        }
        #endregion
    }
}
