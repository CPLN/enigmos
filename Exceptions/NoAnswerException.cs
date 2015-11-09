using System;

namespace Cpln.Enigmos.Exceptions
{
    /// <summary>
    /// Exception soulevée lorsqu'aucune information sur l'énigme n'a été fournie dans le fichier enigmas.xml.
    /// </summary>
    class NoAnswerException : Exception
    {
        /// <summary>
        /// L'identifiant manquant.
        /// </summary>
        private string title;

        /// <summary>
        /// Renvoie le message "Erreur : vous n'avez pas référencé l'énigme "XXX" dans enigma.xml."
        /// </summary>
        override public string Message
        {
            get
            {
                return "Erreur : vous n'avez pas référencé l'énigme \"" + title + "\" dans enigmas.xml.";
            }
        }

        /// <summary>
        /// Constructeur permettant de lancer une exception.
        /// </summary>
        /// <param name="title">Le titre de l'énigme manquante</param>
        public NoAnswerException(string title)
        {
            this.title = title;
        }
    }
}
