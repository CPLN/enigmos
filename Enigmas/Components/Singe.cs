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
        protected const int POSITION_Y = 450;

        //Propriétés
        public bool bEtat { get; set; }
        protected bool bEtatInstruments { get;set;}
        protected Image ImgInactif { get; set; }
        protected Image ImgActif { get; set; }
        protected Image ImgReponse { get; set; }


        //Constructeur
        public Singe(int PositionX, Image imgA, Image imgI, Image imgR)
        {
            bEtatInstruments = false;
            bEtat = false;

            ImgInactif = imgI;
            ImgActif = imgA;
            ImgReponse = imgR;

            Image = ImgInactif;
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
        /// Permet d'afficher la réponse de l'énigme.
        /// </summary>
        public void AfficherReponse()
        {
            Image = ImgReponse;
        }

        /// <summary>
        /// Permet d'alterner les images du singe en fournissant la bonne image selon si il est actif ou non.
        /// </summary>
        public void Animer()
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
                Image = ImgInactif;
            }

        }
    }
}
