using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cpln.Enigmos.Enigmas.Components;
using System.Drawing;
using Cpln.Enigmos.Utils;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    class UnderKeyboardEnigmaPanel : EnigmaPanel
    {
        private List<Touche> touches;
        private ShuffleList<Label> lettres ;
       // private Label;
        private int iWidth = 60;
        private int iHeight = 60;
        private int iLocalisationX = 50;
        private int iLocalisationY = 50;
        private int iLocY;
        private int iLocX;

        public UnderKeyboardEnigmaPanel()
        {
            touches = new List<Touche>();
            lettres = new ShuffleList<Label>();
            iLocX = iLocalisationX;
            iLocY = iLocalisationY;
            for (char i = 'a'; i <= 'z'; i++)
            {
                Label label = new Label();
                label.Text = Convert.ToString(i);
            }
            for (int i = 0; i < 26; i++)
            {
                iLocX += iWidth;
                if (i%7 == 0)
                {
                    iLocX = iLocalisationX;
                    iLocY += iHeight;
                }
                if (i == 21)
                {
                    iLocX += iWidth; 
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
