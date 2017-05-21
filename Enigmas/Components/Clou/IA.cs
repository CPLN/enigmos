using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpln.Enigmos.Enigmas.Components.Clou
{
    /// <summary>
    /// Classe représentant l'IA qui va jouer contre le joueur humain.
    /// </summary>
    class IA : Player
    {
        /// <summary>
        /// Constructeur : Définition/instanciation des valeurs par défaut.
        /// </summary>
        public IA()
        {
            //Par défaut, ce n'est pas le tour de l'IA
            base.IsTurn = false;
        }

        #region Méthodes
        /// <summary>
        /// Calcul le coup à porter sur le clou
        /// </summary>
        /// <param name="nail">Le clou de la partie</param>
        /// <returns>La puissance du coup à porter</returns>
        public int CalculateBlowPower(Nail nail)
        {
            
        }
        #endregion
    }
}
