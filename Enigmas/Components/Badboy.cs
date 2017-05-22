using System;
using System.Drawing;

namespace Cpln.Enigmos.Enigmas.Components
{
    /// <summary>
    /// Class des ennemis qui hérite de la class abstraite Boy. 
    /// </summary>
    public class Badboy : Boy
    {
        public override event EventHandler Moved;
        private int iXMin;  // Position minimale (Initiale)
        private int iXMax;  // Position maximale
        private bool bMax = false; // True = va à gauche, False = va à droite
        private int iSpeed; // Vitesse de l'objet

        /// <summary>
        /// Constructeur de la class Badboy.
        /// </summary>
        /// <param name="_r">La hitbox de l'objet</param>
        /// <param name="Length">Taille des côté du carré</param>
        /// <param name="Speed">La vitesse de déplacement de l'objet</param>
        public Badboy(Rectangle _r, int Length, int Speed) : base(_r.X, _r.Y - Length, Length, Length)
        {
            iXMin = X;
            iXMax = _r.Right - Length;
            iSpeed = Speed;
        }

        /// <summary>
        /// Réécriture de l'evenement abstarait du timer
        /// </summary>
        protected override void Timer_Tick(object sender, EventArgs e)
        {
            // Bouge de gauche à droite infiniment
            if (X < iXMax && !bMax)
            {
                X += iSpeed;
                bMax = X >= iXMax;
            }
            if (bMax)
            {
                X -= iSpeed;
                bMax = X >= iXMin;
            }
            // Invoque l'évenement Moved
            Moved?.Invoke(this, EventArgs.Empty);
        }
    }
}
