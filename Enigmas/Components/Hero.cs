using Cpln.Enigmos.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpln.Enigmos.Enigmas.Components
{
    /// <summary>
    /// L'objet que l'utilisateur jouera, il hérite de la classe abstraite Boy
    /// </summary>
    public class Hero : Boy
    {
        public bool IsJumping { get; set; }         // True = Entrain de sauter, False = Saute pas
        public bool JumpFinish { get; set; }        // True = A fini de monter, False = Redescent
        public Bitmap Texture { get; set; }         // Texture actuelle de l'objet

        private Bitmap[] Textures = new Bitmap[6];  // Textures de l'objet
        private int iJump;                          // Haut du daut maximale
        private int iTexture = 0;                   // Index de la texture, fait référence au tableau des texture
        private int iIntervalTexture = 0;           // Interval en ms de chagement de texture
        private int iDirection;                     // La direction du déplacemet du l'objet, 1 = Droite, -1 Gauche, 0 = Bouge pas

        /// <summary>
        /// Constructeur de Hero
        /// </summary>
        /// <param name="X">Position initiale X</param>
        /// <param name="Y">Position initiale Y</param>
        /// <param name="Width">Longueur de l'objet</param>
        /// <param name="Height">Hauteur de l'objet</param>
        public Hero(int X, int Y, int Width, int Height) : base(X, Y, Width, Height)
        {
            // Remplissage du tableau des images de l'objet
            int tX = 0;
            Bitmap _OriginalTexture = new Bitmap(Resources.Player);
            for (int i = 0; i < 6; i++)
            {
                Textures[i] = _OriginalTexture.Clone(new Rectangle(tX, 0, 45, 45), _OriginalTexture.PixelFormat);
                tX += 60;
            }
            Texture = Textures[0];
        }

        /// <summary>
        /// Permet de changer la texture de l'objet
        /// </summary>
        /// <param name="TextureMin">L'emplacement du tableau de la texture minimum</param>
        /// <param name="TextureMax">L'emplacement du tableau de la texture maximum</param>
        private void ChangeTexture(int TextureMin, int TextureMax)
        {
            if (!IsJumping)
            {
                if (iIntervalTexture >= 3)
                {
                    Texture = Textures[iTexture];
                    if (iTexture < TextureMax)
                    {
                        iTexture++;
                    }
                    else
                    {
                        iTexture = TextureMin;
                    }
                    iIntervalTexture = 0;
                }
                iIntervalTexture++;
            }
        }

        /// <summary>
        /// Permet de faire sauter l'objet
        /// </summary>
        /// <param name="JumpFinish">True = Ne monte pas, False = Descent</param>
        public void Jump(bool JumpFinish)
        {
            if (!IsJumping)
            {
                iJump = Y - 300;
                this.JumpFinish = JumpFinish;
                IsJumping = true;
            }
        }

        /// <summary>
        /// Permet de bouger l'element
        /// </summary>
        /// <param name="X">Nombre de pixels à déplacer sur l'axe X</param>
        /// <param name="Y">Nombre de pixels à déplacer sur l'axe Y</param>
        public void Move(int X, int Y)
        {
            base.X += X;
            base.Y += Y;
        }

        /// <summary>
        /// Change la position de l'objet
        /// </summary>
        /// <param name="X">Change la postion sur l'axe X par la valeur de ce paramètre</param>
        /// <param name="Y">Change la postion sur l'axe Y par la valeur de ce paramètre</param>
        public void SetPosition(int X, int Y)
        {
            base.X = X;
            base.Y = Y;
        }

        /// <summary>
        /// Permet de bouger l'element sur l'axe X grace au Timer
        /// </summary>
        /// <param name="iDirection">-1 Arrière, 1 Avanr, 0 bouge pas</param>
        public void MoveX(int iDirection)
        {
            this.iDirection = iDirection;   // Change la direction du déplacement(1, -1) ou l'arrête(0)
        }

        public override void Move()
        {
            // Permet de faire sauter l'objet
            if (IsJumping)
            {
                if (Y > iJump && !JumpFinish)
                {
                    Move(0, -10);
                    JumpFinish = Y <= iJump;
                }

                if (JumpFinish)
                {
                    Move(0, 10);
                }
            }

            // Permet de faire bouger l'objet sur l'axe X
            switch (iDirection)
            {
                case 1:
                    Move(5, 0);
                    ChangeTexture(0, 2);
                    break;

                case -1:
                    Move(-5, 0);
                    ChangeTexture(3, Textures.Length - 1);
                    break;
            }
        }

        /// <summary>
        /// Reset l'emplacement du joueur
        /// </summary>
        public void Dead()
        {
            SetPosition(0, 0);
            IsJumping = true;
            JumpFinish = true;
        }
    }
}
