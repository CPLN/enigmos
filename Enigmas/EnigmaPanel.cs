using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    abstract class EnigmaPanel : Panel
    {
        public EnigmaPanel()
        {
            BackColor = Color.White;
            Size = new Size(800, 600);
        }

        protected void Center(Control element)
        {
            element.Location = new Point((Width - element.Width) / 2, (Height - element.Height) / 2);
        }
    }
}
