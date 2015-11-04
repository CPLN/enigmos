using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    abstract class EnigmaPanel : Panel
    {
        public EnigmaPanel()
        {
            BackColor = Color.White;
        }
        protected void Center(Control element)
        {
            element.Location = new Point((Width - element.Width) / 2, (Height - element.Height) / 2);
        }
    }
}
