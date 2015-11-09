using System;

namespace Cpln.Enigmos.Exceptions
{
    /// <summary>
    /// Exception soulevée lorsque plusieurs énigmes possèdent le même titre.
    /// </summary>
    class IntegrityException : Exception
    {
        /// <summary>
        /// Le titre en doublon
        /// </summary>
        private string title;

        /// <summary>
        /// Renvoie le message "Erreur : deux énigmes ou plus ont le titre "XXX"."
        /// </summary>
        override public string Message
        {
            get
            {
                return "Erreur : deux énigmes ou plus ont le titre \"" + title + "\".";
            }
        }

        /// <summary>
        /// Constructeur permettant l'appel à une nouvelle exception.
        /// </summary>
        /// <param name="title">Le titre des énigmes en double</param>
        public IntegrityException(string title)
        {
            this.title = title;
        }
    }
}
