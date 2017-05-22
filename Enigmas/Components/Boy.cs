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
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public int Width { get; protected set; }
        public int Height { get; protected set; }
        public abstract event EventHandler Moved;

        // Retourne un rectangle à partir de l'objet ce qui permet de detecter des intersection plus facilement
        public Rectangle Rectangle
        {
            get { return new Rectangle(X, Y, Width, Height); }
        }
        protected Timer Timer { get; set; } = new Timer() { Enabled = true, Interval = 1 };

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

            Timer.Tick += Timer_Tick;
        }

        // L'evenement de Tick du timer, à overrider
        protected abstract void Timer_Tick(object sender, EventArgs e);
    }
}
