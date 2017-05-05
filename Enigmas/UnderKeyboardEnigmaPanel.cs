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
        
        private ShuffleList<Touche> touches;
        private ShuffleList<int> placement;
        private List<string> caractere;

        private int iWidth = 60;
        private int iHeight = 60;
        private int iLocalisationX = 190;
        private int iLocalisationY = 150;
        private int iLocY;
        private int iLocX;
        private int place = 0;
        private string strNom;

        public void CreerClavier (List<Touche>touches)
        {
            iLocX = iLocalisationX;
            iLocY = iLocalisationY;
            for (int i = 0; i < 26; i++)
            {
                iLocX += iWidth;
                if (i % 7 == 0)
                {
                    iLocX = iLocalisationX;
                    iLocY += iHeight;
                }
                if (i == 21)
                {
                    iLocX += iWidth;
                }

                Touche touche = touches[i];
                touche.Location = new Point(iLocX, iLocY);

            }
        }

        public UnderKeyboardEnigmaPanel()
        {
            placement = new ShuffleList<int>();
            caractere = new List<string>();
            placement.Add(3);
            placement.Add(17);
            placement.Add(21);
            placement.Add(25);
            caractere.Add("p");
            caractere.Add("r");
            caractere.Add("e");
            caractere.Add("s");

            touches = new ShuffleList<Touche>();

            Button reset = new Button();
            Controls.Add(reset);
            reset.Text = "Réinitialiser le clavier";
            reset.Size = new Size(140, 30);
            reset.Click += new EventHandler(Reset);

            for (char i = 'a'; i <= 'z'; i++)
            {
                Touche touche = new Touche("" + i, iWidth, iHeight);

                    Controls.Add(touche);
                    touches.Add(touche);
            }
            placement.Shuffle();
            touches.Shuffle();
            CreerClavier(touches);

            //3 17 21 25
            for (int i = 0; i < 26; i++)
            {
                
               
                if ("p" == touches[i].LabelLettre.Text | "r" == touches[i].LabelLettre.Text | "e" == touches[i].LabelLettre.Text| "s" == touches[i].LabelLettre.Text && place < 4)
                {
                    strNom = touches[placement[place]].LabelLettre.Text;
                    touches[place].LabelLettre.Text = caractere[place] ;
                    touches[i].LabelLettre.Text = strNom;
                    place++;
                    ;
                }
            }

        }
        private void Reset(object sender, EventArgs e)
        {
            CreerClavier(touches);
        }
    }
}
