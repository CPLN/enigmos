using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    public class InstinctEnigmaPanel : EnigmaPanel
    {
        public InstinctEnigmaPanel()
        {
            Label lblEnigme = new Label();

            lblEnigme.Text = "Coucou";
            lblEnigme.Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);
            lblEnigme.Dock = DockStyle.Fill;
            lblEnigme.TextAlign = ContentAlignment.MiddleCenter;

            Controls.Add(lblEnigme);
        }
     
    }
}
