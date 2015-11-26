using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    /// <summary>
    /// Exemple d'énigme très simple. Seul un texte est affiché.
    /// </summary>
    public class AppuieReponseEnigmaPanel : EnigmaPanel
    {
        /// <summary>
        /// Constructeur par défaut, génère un texte et l'affiche dans le Panel.
        /// </summary>
        public AppuieReponseEnigmaPanel()
        {
            Label lblEnigme = new Label();
            Label lblRep = new Label();

            lblRep.Text = "réponse";
            lblEnigme.Text = "Appuie  sur  la";
            lblRep.Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);

            lblEnigme.Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);

            lblRep.Size = TextRenderer.MeasureText(lblRep.Text, lblRep.Font);
            lblEnigme.Size = TextRenderer.MeasureText(lblEnigme.Text, lblEnigme.Font);

            lblRep.Click += new EventHandler(ClickOnReponse);

            TableLayoutPanel centerLayout = new TableLayoutPanel();
            centerLayout.ColumnCount = 2;
            centerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            centerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            centerLayout.RowCount = 3;
            centerLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            centerLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            centerLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            centerLayout.Dock = DockStyle.Fill;

            Controls.Add(centerLayout);
            centerLayout.Controls.Add(lblRep, 1, 1);
            centerLayout.Controls.Add(lblEnigme, 0, 1);

            lblEnigme.Dock = DockStyle.Right;
            lblEnigme.Margin = new Padding(0, 0, 0, 0);
            lblRep.Margin = new Padding(0, 0, 0, 0);
        }

        private void ClickOnReponse(object sender, EventArgs e)
        {
            MessageBox.Show("Branche d'arbre");
        }
        
    }
}
