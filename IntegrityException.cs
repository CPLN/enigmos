using System;

namespace Cpln.Enigmos
{
    class IntegrityException : Exception
    {
        private string title;

        override public string Message
        {
            get
            {
                return "Erreur : deux enigmes ou plus ont l'identifiant \"" + title + "\".";
            }
        }

        public IntegrityException(string title)
        {
            this.title = title;
        }
    }
}
