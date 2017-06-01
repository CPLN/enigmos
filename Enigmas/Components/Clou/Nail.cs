using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas.Components.Clou
{
    /// <summary>
    /// Classe représentant un clou
    /// </summary>
    class Nail : PictureBox
    {
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
                break;

                case 10:
                    Top += 33;
                break;

                case 15:
                    Top += 49;
                break;

                case 20:
                    Top += 65;
                break;
            }
        }

        /// <summary>
        /// Restaure la poistion du clou à sa position initiale.
        /// </summary>
        public void ResetPosition()
        {
            Location = new Point(370, 77);
        }
        #endregion
    }
}
