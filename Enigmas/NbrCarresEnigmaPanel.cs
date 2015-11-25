using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    /// <summary>
    /// Exemple d'énigme très simple. Seul un texte est affiché.
    /// </summary>
    public class NbrCarresEnigmaPanel : EnigmaPanel
    {
        /// <summary>
        /// Constructeur par défaut, génère un texte et l'affiche dans le Panel.
        /// </summary>
        public NbrCarresEnigmaPanel()
        {
            Label lblEnigme = new Label();

            PictureBox pbxImage = new PictureBox();

            lblEnigme.Text = "Combien y a-t-il de carrés ?";
            pbxImage.BackgroundImage = Properties.Resources.carre;

            TableLayoutPanel centerQuestion = new TableLayoutPanel();
            centerQuestion.ColumnCount = 5;
            centerQuestion.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.5f));
            centerQuestion.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            centerQuestion.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            centerQuestion.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            centerQuestion.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.5f));
            centerQuestion.RowCount = 4;
            centerQuestion.RowStyles.Add(new RowStyle(SizeType.Percent, 0.5f));
            centerQuestion.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            centerQuestion.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            centerQuestion.RowStyles.Add(new RowStyle(SizeType.Percent, 0.5f));

            centerQuestion.SetColumnSpan(lblEnigme, 3);

            lblEnigme.Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);
            
            pbxImage.Size = new Size(295, 303);
            lblEnigme.AutoSize = true;

            centerQuestion.Controls.Add(lblEnigme, 1, 1);
            centerQuestion.Controls.Add(pbxImage, 2, 2);

            centerQuestion.Dock = DockStyle.Fill;

            Controls.Add(centerQuestion);
        }
    }
}
