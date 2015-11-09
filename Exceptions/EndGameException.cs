using System;

namespace Cpln.Enigmos.Exceptions
{
    /// <summary>
    /// Exception soulevée lorsque le jeu est terminé.
    /// </summary>
    class EndGameException : Exception
    {
        /// <summary>
        /// Contient le message "Vous avez résolu toutes les énigmes !"
        /// </summary>
        override public string Message
        {
            get
            {
                return "Vous avez résolu toutes les énigmes !";
            }
        }
    }
}
