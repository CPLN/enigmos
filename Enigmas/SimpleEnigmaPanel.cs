using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    class SimpleEnigmaPanel : EnigmaPanel
    {
        public SimpleEnigmaPanel()
        {
            Label lblEnigme = new Label();
            lblEnigme.Text = "La solution est simple";
            lblEnigme.AutoSize = true;
            Center(lblEnigme);
            Controls.Add(lblEnigme);
        }
    }
}
