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
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

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

        public abstract void Move();
    }
}
