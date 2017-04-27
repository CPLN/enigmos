using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cpln.Enigmos.Enigmas.Components;

namespace Cpln.Enigmos.Enigmas
{
    class UnderKeyboardEnigmaPanel : EnigmaPanel
    {
        private List<Touche> LesTouches;

        public UnderKeyboardEnigmaPanel()
        {
            LesTouches = new List<Touche>();
            LesTouches.Add(new Touche("", 0, 0));
        }
    }
}
