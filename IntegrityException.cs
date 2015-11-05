using System;

namespace Cpln.Enigmos
{
    class IntegrityException : Exception
    {
        private string id;

        override public string Message
        {
            get
            {
                return "Erreur : deux enigmes ou plus ont le nom \"" + id + "\".";
            }
        }

        public IntegrityException(string id)
        {
            this.id = id;
        }
    }
}
