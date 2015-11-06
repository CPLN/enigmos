using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpln.Enigmos
{
    class NoAnswerException : Exception
    {
        private string resourceId;

        override public string Message
        {
            get
            {
                return "Erreur : vous n'avez pas ajouté la réponse à \"" + resourceId + "\" dans Reponses.resx.";
            }
        }

        public NoAnswerException(string resourceId)
        {
            this.resourceId = resourceId;
        }
    }
}
