using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    public class InvisibleAnswerEnigmaPanel : EnigmaPanel
    {
        //Déclaration des variables et objets
        Panel pHaut = new Panel();
        Panel pBas = new Panel();

        /// <summary>
        /// Constructeur par défaut, génère un texte et l'affiche dans le Panel.
        /// </summary>

        public InvisibleAnswerEnigmaPanel()
        {
            Controls.Add(pHaut);
            Controls.Add(pBas);
            pBas.BackColor = Color.Black;
            pHaut.BackColor = Color.Black;

            pHaut.Width = 798;
            pHaut.Height = 298;

            
        }

        public void Move()
        {

        }
    }
}