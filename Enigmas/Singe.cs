using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpln.Enigmos.Enigmas
{
    class Singe
    {
        //Attributs
        private bool bEtat;

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
            if (bEtat == true)
            {
                bEtat = false;
            }
            if (bEtat == false)
            {
                bEtat = true;
            }
        }
    }
}
