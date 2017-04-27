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
        private int iWidth = 60;
        private int iHeight = 60;
        private int iLocalisationX = 50;
        private int iLocalisationY = 50;

        public UnderKeyboardEnigmaPanel()
        {
            touches = new List<Touche>();
            int iLocX = iLocalisationX;
            int iLocY = iLocalisationY;
            for (int i = 0; i < 26; i++)
            {
                iLocX += iWidth;
                if (i%7 == 0)
                {
                    iLocX = iLocalisationX;
                    iLocY += iLocalisationY + iHeight;
                   
                }
                if (i == 21)
                {
                    iLocX = iLocalisationX;
                    iLocY += iLocalisationY + Height * 2;

                }
                Touche touche = new Touche("", iLocX, iLocY,iWidth,iHeight);
                touche.BackColor = Color.Black;
                touche.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                touches.Add(touche);
                Controls.Add(touche);
            }
        }
    }
}
