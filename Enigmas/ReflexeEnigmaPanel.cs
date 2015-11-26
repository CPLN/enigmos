using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    public class ReflexeEnigmaPanel : EnigmaPanel
    {
        private Panel pnlTonneaux = new Panel();
        private Button btnStart = new Button();
        public ReflexeEnigmaPanel()
        {
            Controls.Add(btnStart);
            btnStart.Width = 150;
            btnStart.Height = 40;
            btnStart.Location = new Point(650, 560);
            btnStart.Text = "Commencer";
            btnStart.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
            btnStart.FlatStyle = FlatStyle.System;

            Controls.Add(pnlTonneaux);
            pnlTonneaux.Width = 60;
            pnlTonneaux.Height = 60;
            pnlTonneaux.BackColor = Color.Brown;
            pnlTonneaux.Left = 370;
        }
    }
}
