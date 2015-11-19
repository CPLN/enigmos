using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    /// <summary>
    /// Exemple d'énigme très simple. Seul un texte est affiché.
    /// </summary>
    public class CharadeEnigmaPanel : EnigmaPanel
    {
        /// <summary>
        /// Constructeur par défaut, génère un texte et l'affiche dans le Panel.
        /// </summary>
        public CharadeEnigmaPanel()
        {
            Label lblEnigme = new Label();

            lblEnigme.Text = "Mon premier est un matériau précieux. \n" +
            "Mon second est la maison des oiseaux. \n" + 
            "Mon troisième est un Avenger. \n" +
            "Mon quatrième est la fin de la fin. \n" +
            "Mon cinquième est la 11ème lettre de l'alphabet. \n\n" +
            "Mon tout est un mammifère.";
            lblEnigme.Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);
            lblEnigme.Dock = DockStyle.Fill;
            lblEnigme.TextAlign = ContentAlignment.MiddleCenter;

            Controls.Add(lblEnigme);
        }
    }
}
