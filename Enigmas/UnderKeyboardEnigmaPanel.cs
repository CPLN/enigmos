using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cpln.Enigmos.Enigmas.Components;
using System.Drawing;

namespace Cpln.Enigmos.Enigmas
{
    class UnderKeyboardEnigmaPanel : EnigmaPanel
    {
        private List<Touche> touches;
        private int width = 20;
        private locX = 50

        public UnderKeyboardEnigmaPanel()
        {
            touches = new List<Touche>();

            for (int i = 0; i < 61; i++)
            {
                
                
                Touche touche = new Touche("", 50, 50,width,20);
                touche.BackColor = Color.Black;
                touches.Add(touche);
                Controls.Add(touche);
            }
        }
    }
}
