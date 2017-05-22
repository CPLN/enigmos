using System;
using System.Drawing;

namespace Cpln.Enigmos.Enigmas.Components
{
    /// <summary>
    /// Class des ennemis qui hérite de la class abstraite Boy. 
    /// </summary>
    public class Badboy : Boy
    {
        //public override event EventHandler Moved;
        public int XMin { get; set; }  // Position minimale (Initiale)
        public int XMax { get; set; }  // Position maximale
        public bool Max { get; set; } = false; // True = va à gauche, False = va à droite
        public int Speed { get; set; } // Vitesse de l'objet

        /// <summary>
        /// Constructeur de la class Badboy.
        /// </summary>
        /// <param name="_r">La hitbox de l'objet</param>
        /// <param name="Length">Taille des côté du carré</param>
        /// <param name="Speed">La vitesse de déplacement de l'objet</param>
        public Badboy(Rectangle _r, int Length, int Speed) : base(_r.X, _r.Y - Length, Length, Length)
        {
            XMin = X;
            XMax = _r.Right - Length;
            this.Speed = Speed;
        }

        /// <summary>
        /// Réécriture de l'evenement abstarait du timer
        /// </summary>
        public override void Move() {
            // Bouge de gauche à droite infiniment
            if (X < XMax && !Max)
            {
                X += Speed;
                Max = X >= XMax;
            }
            if (Max)
            {
                X -= Speed;
                Max = X >= XMin;
            }
        }
    }
}
