using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    class ZombieInvasionEnigmaPanel : EnigmaPanel
    {
        public ZombieInvasionEnigmaPanel()
        {
            Label lblEnigme = new Label();

            lblEnigme.Text = "Test";
            lblEnigme.Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);
            lblEnigme.Dock = DockStyle.Fill;
            lblEnigme.TextAlign = ContentAlignment.MiddleCenter;

            Controls.Add(lblEnigme);

        }
    }
}
