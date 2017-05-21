using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpln.Enigmos.Enigmas.Components.Clou
{
    /// <summary>
    /// Classe représentant un joueur du jeu du clou
    /// </summary>
    class Player
    {
        /// <summary>
        /// Propriété indiquant si c'est le tour du joueur courant ou pas.
        /// </summary>
        public bool IsTurn { get; set; }

        /// <summary>
        /// Constructeur : Définition/instanciation des valeurs par défaut.
        /// </summary>
        public Player()
        {
            //Par défaut, c'est toujours le joueur humain qui commence.
            IsTurn = true;
        }

        #region Méthodes
        /// <summary>
        /// Donne un coup sur le clou
        /// </summary>
        /// <param name="nail">Le clou de la partie</param>
        /// <param name="power">La puissanc du coup</param>
        public void Blow(Nail nail, int power)
        {

        }
        #endregion
    }
}
