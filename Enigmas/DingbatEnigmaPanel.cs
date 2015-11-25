using Cpln.Enigmos.Enigmas.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    /// <summary>
    /// Panel affichant une énigme.
    /// </summary>
    public class DingbatEnigmaPanel : EnigmaPanel
    {
        /// <summary>
        /// Constructeur par défaut, fixe la taille du Panel à 800x600 et la couleur de fond à blanc.
        /// </summary>
        public DingbatEnigmaPanel()
        {
            Label lblCitronVert = new Label();

            lblCitronVert.Text = "Tronc";
        }
    }
}
