using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpln.Enigmos.Enigmas
{
    public class Singe
    {
        //Attributs
        private bool bEtat;
        private bool bEtatCymbales;

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

        public static Singe CreateSinge(EnigmaPanel panel, List<Singe> listSinge)
        {
            //Formatages des pictures box, insertions de l'image du singe, ajout à la liste de singe
            bEtatSinge = false;
            bEtatCymbales = true;
            pbxSinge.BackColor = Color.Transparent;
            pbxSinge.Image = Properties.Resources.SingeBleuCymbalesOuvertes;
            pbxSinge.Size = Properties.Resources.SingeBleuCymbalesOuvertes.Size;
            panel.Controls.Add(pbxSinge);
            listSinge.Add(pbxSinge);
        }
    }
}
