using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    /// <summary>
    /// Exemple d'énigme très simple. Seul un texte est affiché.
    /// </summary>
    public class CaseVideEnigmaPanel : EnigmaPanel
    {
        /// <summary>
        /// Constructeur par défaut, génère un texte et l'affiche dans le Panel.
        /// </summary>
        public CaseVideEnigmaPanel()
        {
            Label lblEnigme = new Label();

            lblEnigme.Text = "Quand tu ne sais pas quoi répondre, ne répond pas.";
            lblEnigme.Font = new Font(FontFamily.GenericSansSerif, 22, FontStyle.Bold);
            lblEnigme.Dock = DockStyle.Fill;
            lblEnigme.TextAlign = ContentAlignment.MiddleCenter;

            Controls.Add(lblEnigme);
        }
    }
}
