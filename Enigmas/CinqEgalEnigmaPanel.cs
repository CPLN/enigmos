using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    /// <summary>
    /// Exemple d'énigme très simple. Seul un texte est affiché.
    /// </summary>
    public class CinqEgalEnigmaPanel : EnigmaPanel
    {
        /// <summary>
        /// Constructeur par défaut, génère un texte et l'affiche dans le Panel.
        /// </summary>
        public CinqEgalEnigmaPanel()
        {
            //Crée des labels
            Label lblDonnee1 = new Label();
            Label lblDonnee2 = new Label();
            Label lblDonnee3 = new Label();
            Label lblDonnee4 = new Label();
            Label lblDonnee5 = new Label();

            //ajoute du texte dans les labels
            lblDonnee1.Text = "1 = 5";
            lblDonnee2.Text = "2 = 25";
            lblDonnee3.Text = "3 = 235";
            lblDonnee4.Text = "4 = 4325";
            lblDonnee5.Text = "5 = ?";

            //permet de paramètrer les labels au niveau de la taille, du texte, de la couleur et de la position
            lblDonnee1.Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);
            lblDonnee1.ForeColor = Color.Green;
            lblDonnee1.Location = new Point(200, 100);
            lblDonnee1.AutoSize = false;
            lblDonnee1.Size = TextRenderer.MeasureText(lblDonnee1.Text, lblDonnee1.Font);



            lblDonnee2.Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);
            lblDonnee2.ForeColor = Color.Blue;
            lblDonnee2.Location = new Point(200, 150);
            lblDonnee2.AutoSize = false;
            lblDonnee2.Size = TextRenderer.MeasureText(lblDonnee2.Text, lblDonnee2.Font);



            lblDonnee3.Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);
            lblDonnee3.ForeColor = Color.Red;
            lblDonnee3.Location = new Point(200, 200);
            lblDonnee3.AutoSize = false;
            lblDonnee3.Size = TextRenderer.MeasureText(lblDonnee3.Text, lblDonnee3.Font);


            lblDonnee4.Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);
            lblDonnee4.ForeColor = Color.Black;
            lblDonnee4.Location = new Point(200, 250);
            lblDonnee4.AutoSize = false;
            lblDonnee4.Size = TextRenderer.MeasureText(lblDonnee4.Text, lblDonnee4.Font);

            lblDonnee5.Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);
            lblDonnee5.ForeColor = Color.Purple;
            lblDonnee5.Location = new Point(200, 300);
            lblDonnee5.AutoSize = false;
            lblDonnee5.Size = TextRenderer.MeasureText(lblDonnee5.Text, lblDonnee5.Font);

            //Affiche les labels 
            Controls.Add(lblDonnee1);
            Controls.Add(lblDonnee2);
            Controls.Add(lblDonnee3);
            Controls.Add(lblDonnee4);
            Controls.Add(lblDonnee5);
        }
    }
}
