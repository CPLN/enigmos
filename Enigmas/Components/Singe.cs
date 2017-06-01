using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas.Components
{
    class Singe : PictureBox
    {
        const int POSITION_Y = 500;

        //Attributs
        public bool bEtat { get;set;}

        //Constructeur
        public Singe(int PositionX)
        {
            bEtat = false;

            Image = Properties.Resources.SingeBleuCymbalesFermees;
            Size = Image.Size;
            BackColor = Color.Transparent;
            Location = new Point(PositionX, POSITION_Y);
        }

        //Méthodes

        /// <summary>
        /// Permet d'activer un singe
        /// </summary>
        public void Activer()
        {
            bEtat = true;
        }
        /// <summary>
        /// Permet d'arrêter le mouvement d'un singe
        /// </summary>
        private void Desactiver()
        {
            bEtat = false;
        }
        /// <summary>
        /// Inverse l'état d'un singe
        /// </summary>
        private void Inverser()
        {
            bEtat = !bEtat;
        }
    }
}
