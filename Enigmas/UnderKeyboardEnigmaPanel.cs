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
        private int iLocalisationX = 150;
        private int iLocalisationY = 150;
        private int iLocY;
        private int iLocX;
        //private int place = 0;
        //private string strNom;
        /// <summary>
        /// place les touches avec 26 touches
        /// </summary>
        public void PlaceTouche()
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
                Touche touche = ListeTouche[i];
                touche.Location = new Point(iLocX, iLocY);
            }
        }
        /// <summary>
        /// Constructeur de UnderKeyboard
        /// </summary>
        public UnderKeyboardEnigmaPanel()
        {
            reset = new Button() { Text = "Réinitialiser le clavier", Size = new Size(140, 30) };
            Controls.Add(reset);
            reset.Click += new EventHandler(Reset);

            // le background de mon énigme
            Bitmap BackImage = new Bitmap(Properties.Resources.UnderImage, 50, 50);
            BackgroundImage = BackImage;
            // - UnderImage crée une PictureBox avec l'image qui est sous le clavier 
            PictureBox UnderImage = new PictureBox() {Size = new Size(490, 280), Image = Properties.Resources.UnderImage,SizeMode = PictureBoxSizeMode.StretchImage, Location = new Point(150, 220) };
            PictureBox CoinG = new PictureBox() { Size = new Size(50,50), Image = Properties.Resources.UnderImage, SizeMode = PictureBoxSizeMode.StretchImage, Location = new Point(160, 440) };
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
                        /* 
             * instanciation des listes qui sont nécessaire pour le code :
            - placement est une liste qui va savoir à quelle place il faut mettre les lettres que l'on aura reservées
            - caractere est une liste qui se mélange et qui va contenir les caractères a ne pas utiliser car on veut leurs donner des emplacements reservées
            - toutestouches est une liste qui se mélange et qui contient tout les lettres de l'alphabet hors-mis les celles qui sont dans la liste caractère
            - Listetouche sera la liste final ou on introduira dans l'ordre toute les lettres pour pouvoir en faire une Touche
             */
            placement = new List<int>();
            caractere = new ShuffleList<char>();
            toutestouches = new ShuffleList<char>();
            ListeTouche = new List<Touche>();
            // Ajout des emplacements reservées dans la liste placement
            placement.Add(3);
            placement.Add(17);
            placement.Add(21);
            placement.Add(25);
            // Ajout des lettres reservées dans la liste caractere
            caractere.Add('S');
            caractere.Add('P');
            caractere.Add('R');
            caractere.Add('E');

            lblPresser = new Label() { Text = "PRESSER", Location = new Point(335, 60), TextAlign = ContentAlignment.MiddleCenter, Font = new Font(arial,10) };
            Controls.Add(lblPresser);

            // boucle qui va ajouter dans le tableau toutetouches toute les lettre de l'alphabet
            for (char i = 'A'; i <= 'Z'; i++)
            {
                if (placement.Contains(i)) // on exclue les touches avec un emplacement reservé
                {
                    continue;
                }
                toutestouches.Add(i);
            }
            toutestouches.Shuffle(); // Mélange la liste des lettres toutetouches
            caractere.Shuffle(); // Mélange la liste des lettres reservées caractere

            while (placement.Count > 0)
            {
                int place = placement[0];
                placement.RemoveAt(0);

                char lettre = caractere[0];
                caractere.RemoveAt(0);
                toutestouches.Insert(place, lettre);
            }

            for (int i = 0; i <= 25; i++)
            {
                Touche touche = new Touche("" + toutestouches[i], iWidth, iHeight);
                Controls.Add(touche);
                ListeTouche.Add(touche);
                touche.BringToFront();
            }
            PlaceTouche();
        }

        public override void Unload()
        {
            foreach(Touche touche in ListeTouche)
            {
                Controls.Remove(touche);
            }
        }
    }
}
