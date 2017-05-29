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
        /// Propriété indiquant le nombre de manches gagnés du joueur
        /// </summary>
        public int WinnedRound { get; set; }

        /// <summary>
        /// Propriété indiquant la puissance de frappe du dernier tour.
        /// </summary>
        public int LastTurnPower { get; set; }

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
        /// Donne un coup sur le clou, enregistre dans la propriété LastTurnPower la puissance du coup.
        /// </summary>
        /// <param name="nail">Le clou de la partie</param>
        /// <param name="power">La puissanc du coup</param>
        public void Blow(Nail nail, int power)
        {
            nail.Down(power);
            LastTurnPower = power;
        }
        #endregion
    }
}
