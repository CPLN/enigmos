using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas.Components
{
    /// <summary>
    /// Class abstraite Boy qui contient les propriétés, les methodes et l'evenement de base pour jouer
    /// </summary>
    public abstract class Boy
    {
        public int X { get; set; }      // Position X de l'objet
        public int Y { get; set; }      // Position Y de l'objet
        public int Width { get; set; }  // Longueur de l'objet
        public int Height { get; set; } // Hauteur de l'objet

        // Retourne un rectangle à partir de l'objet ce qui permet de detecter des intersection plus facilement
        public Rectangle Rectangle
        {
            get { return new Rectangle(X, Y, Width, Height); }
        }

        /// <summary>
        /// Constructeur de la class Boy
        /// </summary>
        /// <param name="X">Postion sur l'axe X de l'objet</param>
        /// <param name="Y">Postion sur l'axe Y de l'objet</param>
        /// <param name="Width">Longueur de l'objet</param>
        /// <param name="Height">Hauteur de l'objet</param>
        protected Boy(int X, int Y, int Width, int Height)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
        }

        // Méthode de test lors d'un mouvement
        public abstract void Move();
    }
}
