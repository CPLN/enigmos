using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{

    /// <summary>
    /// Exemple d'énigme très simple. Seul un texte est affiché.
    /// </summary>
    public class MorpionEnigmaPanel : EnigmaPanel
    {
        /*Label lblEnigme = new Label();

            lblEnigme.Text = "la solution est simple";
            lblEnigme.Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);
            lblEnigme.Dock = DockStyle.Fill;
            lblEnigme.TextAlign = ContentAlignment.MiddleCenter;

            Controls.Add(lblEnigme);*/

            // Création des PictureBox
            PictureBox pbxCase1 = new PictureBox();
            PictureBox pbxCase2 = new PictureBox();
            PictureBox pbxCase3 = new PictureBox();
            PictureBox pbxCase4 = new PictureBox();
            PictureBox pbxCase5 = new PictureBox();
            PictureBox pbxCase6 = new PictureBox();
            PictureBox pbxCase7 = new PictureBox();
            PictureBox pbxCase8 = new PictureBox();
            PictureBox pbxCase9 = new PictureBox();

        /// <summary>
        /// Constructeur par défaut, génère un texte et l'affiche dans le Panel.
        /// </summary>
        public MorpionEnigmaPanel()
        {
            
        }

        // Démarrage / Redémarrage du jeu
        public void Satrt()
        {
            PictureBox[] tCases = new PictureBox[] {pbxCase1, pbxCase2, pbxCase3, pbxCase4, pbxCase5, pbxCase6, pbxCase7, pbxCase8, pbxCase9};
        }
    }
}
