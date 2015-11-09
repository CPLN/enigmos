using System;

namespace Cpln.Enigmos.Exceptions
{
    class IntegrityException : Exception
    {
        private string title;

        override public string Message
        {
            get
            {
                return "Erreur : deux enigmes ou plus ont le titre \"" + title + "\".";
            }
        }

        public IntegrityException(string title)
        {
            this.title = title;
        }
    }
}
