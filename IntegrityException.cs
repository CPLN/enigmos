using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpln.Enigmos
{
    class IntegrityException : Exception
    {
        private string id;

        public string Message
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
