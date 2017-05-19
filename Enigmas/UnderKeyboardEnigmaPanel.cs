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
        private ShuffleList<string> caractere;
        private Button reset;
        private Label lblPresser;
        private ShuffleList<char> toutestouches;
        private int iWidth = 70;
        private int iHeight = 70;
        private int iLocalisationX = 190;
        private int iLocalisationY = 150;
        private int iLocY;
        private int iLocX;
        private int place = 0;
        private string strNom;

        public void CreerClavier(List<Touche> touches)
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
            caractere = new ShuffleList<string>();
            toutestouches = new ShuffleList<char>();
            placement.Add(3);
            placement.Add(17);
            placement.Add(21);
            placement.Add(25);
            caractere.Add("P");
            caractere.Add("R");
            caractere.Add("E");
            caractere.Add("S");

            lblPresser = new Label();
            lblPresser.Text = "PRESSER";
            Controls.Add(lblPresser);
            lblPresser.Location = new Point(375, 60);
            touches = new ShuffleList<Touche>();

            reset = new Button();
            Controls.Add(reset);
            reset.Text = "Réinitialiser le clavier";
            reset.Size = new Size(140, 30);
            reset.Click += new EventHandler(Reset);

            for (char i = 'A'; i <= 'Z'; i++)
            {
                if (i == 'S' || i == 'R' || i == 'E' || i == 'P')
                {
                    continue;
                }
                toutestouches.Add(i);
                //Touche touche = new Touche("" + i, iWidth, iHeight);
                //Controls.Add(touche);
                //touches.Add(touche);
            }
            toutestouches.Shuffle();
            caractere.Shuffle();
            touches.Shuffle();
            CreerClavier(touches);
            for (int i = 0; i <= toutestouches.Count; i++)
            {
                Touche touche = new Touche("" + toutestouches[i], iWidth, iHeight);
                Controls.Add(touche);
                touches.Add(touche);
            }
            //3 17 21 25
            //for (int i = 0; i < 26; i++)
            //{
            //   if (placement.Contains(i)) // vérifie si la boucle est sur un emplacement réserver pour une lettre
            //    {
            //        continue; // recommence la boucle
            //    }

            //    if ("P" == touches[i].Nom | "R" == touches[i].Nom | "E" == touches[i].Nom| "S" == touches[i].Nom) // verifie si à la position ou il est il y a la lettre P,R,E ou S
            //    {
            //        strNom = touches[placement[place]].Nom; // on récupère la lettre de la touche à la place de la liste placement
            //        touches[placement[place]].Nom = caractere[place] ; // on met dans touche une lettre de la liste caractere
            //        touches[i].Nom = strNom; // on met dans l'emplacement i la lettre que on avais récuperer
            //        place++; // on incrémente place pour le prochain tour de bloucle

            //    }
            //}

        }
        private void Reset(object sender, EventArgs e)
        {
            CreerClavier(touches);
        }
    }
}
