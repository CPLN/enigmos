using System;

namespace Cpln.Enigmos.Exceptions
{
    class EndGameException : Exception
    {
        override public string Message
        {
            get
            {
                return "Vous avez résolu toutes les énigmes !";
            }
        }
    }
}
