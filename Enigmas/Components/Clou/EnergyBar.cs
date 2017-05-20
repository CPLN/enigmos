using System;
using System.Collections.Generic;
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
        /// <summary>
        /// Constructeur : Définition/instanciation des valeurs par défaut.
        /// </summary>
        public EnergyBar()
        {
            //Définition de l'image source
            BackgroundImage = Properties.Resources.bar;
        }
    }
}
