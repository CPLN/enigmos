using Cpln.Enigmos.Enigmas.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    class CodeBarreEnigmaPanel : EnigmaPanel
    {
        Panel pBarreE = new Panel();
        public CodeBarreEnigmaPanel()
        {
            pBarreE.Left = 121;
            pBarreE.Top = 11;
            pBarreE.Size = new Size(10, 200);
            pBarreE.Location = new Point(100, 200);
            pBarreE.BackColor = Color.Black;
            this.Controls.Add(pBarreE);
        }
    }
}
