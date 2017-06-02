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
    {  //Attributs
        const int POSITION_Y = 500;

        //Propriétés
        public bool bEtatInstruments { get;set;}
        public bool bEtat { get; set; }
        public Image ImgInactif { get; set; }
        public Image ImgActif { get; set; }


        //Constructeur
        public Singe(int PositionX, Image imgA, Image imgI)
        {
            bEtatInstruments = false;
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
            bEtatInstruments = true;
            bEtat = true;
        }
        /// <summary>
        /// Permet d'arrêter le mouvement d'un singe
        /// </summary>
        public void Desactiver()
        {
            bEtatInstruments = false;
            bEtat = false;
        }
        /// <summary>
        /// Inverse l'état d'un singe
        /// </summary>
        public void Inverser()
        {
            bEtatInstruments = !bEtatInstruments;
            bEtat = !bEtat;
        }

        /// <summary>
        /// Permet d'alterner les images du singe en fournissant la bonne image selon s'il est actif ou non.
        /// </summary>
        public void Alterner()
        {
            if (bEtat)
            {
                if (bEtatInstruments)
                {
                    Image = ImgActif;
                    bEtatInstruments = false;
                }
                else
                {
                    Image = ImgInactif;
                    bEtatInstruments = true;
                }
            }
            else
            {
                Image = Properties.Resources.SingeBleuCymbalesFermees;
            }
        }
    }
}
