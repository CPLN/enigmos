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

        /// <summary>
        /// Appelé lorsqu'une touche du clavier est appuyée.
        /// </summary>
        /// <param name="sender">L'envoyeur</param>
        /// <param name="e">L'évènement</param>
        public virtual void PressKey(object sender, KeyEventArgs e)
        {

        }

        /// <summary>
        /// Appelé lorsqu'une touche du clavier est relâchée.
        /// </summary>
        /// <param name="sender">L'envoyeur</param>
        /// <param name="e">L'évènement</param>
        public virtual void ReleaseKey(object sender, KeyEventArgs e)
        {

        }
    }
}
