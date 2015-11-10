using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    /// <summary>
    /// Panel affichant une énigme.
    /// </summary>
    public abstract class EnigmaPanel : Panel
    {
        /// <summary>
        /// Constructeur par défaut, fixe la taille du Panel à 800x600 et la couleur de fond à blanc.
        /// </summary>
        public EnigmaPanel()
        {
            BackColor = Color.White;
            Size = new Size(800, 600);
        }
    }
}
