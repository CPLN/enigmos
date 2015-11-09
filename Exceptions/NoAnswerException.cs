using System;

namespace Cpln.Enigmos.Exceptions
{
    class NoAnswerException : Exception
    {
        private string resourceId;

        override public string Message
        {
            get
            {
                return "Erreur : vous n'avez pas référencé l'énigme \"" + resourceId + "\" dans enigmas.xml.";
            }
        }

        public NoAnswerException(string resourceId)
        {
            this.resourceId = resourceId;
        }
    }
}
