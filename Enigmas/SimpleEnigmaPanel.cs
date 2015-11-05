using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    class SimpleEnigmaPanel : EnigmaPanel
    {
        public SimpleEnigmaPanel()
        {
            Label lblEnigme = new Label();

            lblEnigme.Text = "La solution est simple.";
            lblEnigme.Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);
            lblEnigme.Dock = DockStyle.Fill;
            lblEnigme.TextAlign = ContentAlignment.MiddleCenter;

            Controls.Add(lblEnigme);
        }
    }
}
