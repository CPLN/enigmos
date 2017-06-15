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
        private List<Touche> listeTouche; // Contient la liste de Touche définitive
        private List<int> placement; // Contient les numéros des emplacement qu'il faut réservé pour certaine lettre
        private ShuffleList<char> caractere; // Liste qu'on mélange et qui contient les lettres avec un emplacement réserver dans la liste listeTouche
        private ShuffleList<char> toutestouches; // Liste qu'on mélage et qui contient les lettres
        private Button btnReset; // Bouton pour remettre la localistation des touches au même endroit que au début de l'énigme
        private Label lblPresser; //Label qui indique la clé de l'énigme
        private int iWidth = 70; // Largeur des touches
        private int iHeight = 70; // Hauteur des touches
        private int iLocalisationX = 150; // Localistation de débart des touches en X
        private int iLocalisationY = 150; // Localistation de débart des touches en Y
        private int iLocY; // Localisation tampon pour calculer l'emplacement des touches en X
        private int iLocX; // Localisation tampon pour calculer l'emplacement des touches en Y

        /// <summary>
        /// Place les 26 touches 
        /// </summary>
        public void PlaceTouche()
        {
            iLocX = iLocalisationX;
            iLocY = iLocalisationY;
            for (int i = 0; i <= 25; i++)
            {
                iLocX += iWidth;
                if (i % 7 == 0)
                {
                    // Ces deux commandes nous permettes de faire un "Retour à la ligne" avec les touches
                    iLocX = iLocalisationX;
                    iLocY += iHeight;
                }
                if (i == 21)
                {
                    iLocX += iWidth;
                }
                Touche touche = listeTouche[i];
                touche.Location = new Point(iLocX, iLocY);
            }
        }
        /// <summary>
        /// Constructeur de UnderKeyboard
        /// </summary>
        public UnderKeyboardEnigmaPanel()
        {
            btnReset = new Button() { Text = "Réinitialiser le clavier", Size = new Size(140, 30) }; // instanciation du bouton btnReset
            Controls.Add(btnReset);
            btnReset.Click += new EventHandler(Reset);

            Bitmap BackImage = new Bitmap(Properties.Resources.UnderImage, 50, 50);
            BackgroundImage = BackImage;
            // UnderImage crée une PictureBox avec l'image qui est sous le clavier 
            PictureBox UnderImage = new PictureBox() { Size = new Size(490, 280), Image = Properties.Resources.UnderImage, SizeMode = PictureBoxSizeMode.StretchImage, Location = new Point(150, 220) };
            // CoinG et CoinD crée une PictureBoxx qui iPlace une image dans les coin du clavier où il n'y a pas de touche pour combler les trous
            PictureBox CoinG = new PictureBox() { Size = new Size(50, 50), Image = Properties.Resources.UnderImage, SizeMode = PictureBoxSizeMode.StretchImage, Location = new Point(160, 440) };
            PictureBox CoinD = new PictureBox() { Size = new Size(50, 50), Image = Properties.Resources.UnderImage, SizeMode = PictureBoxSizeMode.StretchImage, Location = new Point(580, 440) };
            Controls.Add(CoinG);
            Controls.Add(CoinD);
            Controls.Add(UnderImage);
        }
        /// <summary>
        /// Cette methode sert à remettre toute les touches à leur places
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Reset(object sender, EventArgs e)
        {
            PlaceTouche();
        }
        public override void Load()
        {
            placement = new List<int>();
            caractere = new ShuffleList<char>();
            toutestouches = new ShuffleList<char>();
            listeTouche = new List<Touche>();

            placement.Add(3);
            placement.Add(17);
            placement.Add(21);
            placement.Add(25);

            caractere.Add('P');
            caractere.Add('R');
            caractere.Add('E');
            caractere.Add('S');

            lblPresser = new Label() { Text = "PRESSER", Location = new Point(315, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Arial", 22), Width = 160, Height = 45 };
            Controls.Add(lblPresser);

            // boucle qui va ajouter dans le tableau toutetouches toute les lettre de l'alphabet
            for (char i = 'A'; i <= 'Z'; i++)
            {
                if (i == 'P' | i == 'R' | i == 'E' | i == 'S') // on exclue les touches avec un emplacement reservé
                {
                    continue;
                }
                toutestouches.Add(i);
            }
            toutestouches.Shuffle();
            caractere.Shuffle();

            //Place les lettres avec un emplacement réservé au bon endroit dans la liste toutestouches
            while (placement.Count > 0)
            {
                int iPlace = placement[0];
                placement.RemoveAt(0);

                char clettre = caractere[0];
                caractere.RemoveAt(0);
                toutestouches.Insert(iPlace, clettre);
            }

            for (int i = 0; i <= 25; i++)
            {
                Touche touche = new Touche("" + toutestouches[i], iWidth, iHeight);
                Controls.Add(touche);
                listeTouche.Add(touche);
                touche.BringToFront(); // Fait passer le contrôle au premier rang dans l'ordre de plan.
            }
            PlaceTouche();
        }
        /// <summary>
        /// Supprime ce que contient la liste touche quand on change d'énigme
        /// </summary>
        public override void Unload()
        {
            foreach (Touche touche in listeTouche)
            {
                Controls.Remove(touche);
            }
        }
    }
}
