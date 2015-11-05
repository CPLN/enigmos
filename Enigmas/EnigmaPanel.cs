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
    }
}
