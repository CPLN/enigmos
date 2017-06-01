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
        private List<Touche> ListeTouche;
        private List<int> placement;
        private ShuffleList<char> caractere;
        private ShuffleList<char> toutestouches;
        private Button reset;
        private Label lblPresser;
        private int iWidth = 70;
        private int iHeight = 70;
        private int iLocalisationX = 190;
        private int iLocalisationY = 150;
        private int iLocY;
        private int iLocX;
        private int place = 0;
        private string strNom;
        /// <summary>
        /// crée un clavier avec 26 touches
        /// </summary>
        /// <param name="touches"></param>
        public void CreerClavier(List<Touche> touches)
        {
            iLocX = iLocalisationX; //la localisation de la touche en X
            iLocY = iLocalisationY; //la localisation de la touche en Y
            for (int i = 0; i <= 25; i++) // 
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
            placement = new List<int>(); 
            caractere = new ShuffleList<char>();
            toutestouches = new ShuffleList<char>();
            placement.Add(3);
            placement.Add(17);
            placement.Add(21);
            placement.Add(25);
            caractere.Add('S');
            caractere.Add('P');
            caractere.Add('R');
            caractere.Add('E');

            lblPresser = new Label();
            lblPresser.Text = "PRESSER";
            Controls.Add(lblPresser);
            lblPresser.Location = new Point(375, 60);
            ListeTouche = new List<Touche>();

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

            }

            toutestouches.Shuffle();
            caractere.Shuffle();

            while (placement.Count > 0)
            {
                int place = placement[0];
                placement.RemoveAt(0);

                char lettre = caractere[0];
                caractere.RemoveAt(0);
                toutestouches.Insert(place, lettre);
            }

            for (int i=0; i <= 25;i++)
            {
                Touche touche = new Touche("" + toutestouches[i], iWidth, iHeight);
                Controls.Add(touche);
                ListeTouche.Add(touche);
            }
            CreerClavier(ListeTouche);
        }
        /// <summary>
        /// Cette methode sert à remettre toute les touches à leur places
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Reset(object sender, EventArgs e)
        {
            CreerClavier(ListeTouche);
        }
    }
}
