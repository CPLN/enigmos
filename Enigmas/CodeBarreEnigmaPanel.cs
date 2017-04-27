using Cpln.Enigmos.Enigmas.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    class CodeBarreEnigmaPanel : EnigmaPanel
    {
        Panel pBarreE = new Panel();
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public CodeBarreEnigmaPanel()
        {
            pBarreE.Left = 121;
            pBarreE.Top = 11;
            pBarreE.Size = new Size(10, 200);
            pBarreE.Location = new Point(100, 200);
            pBarreE.BackColor = Color.Black;
            pBarreE.MouseMove += new MouseEventHandler(DeplacerBarre);
            this.Controls.Add(pBarreE);
        }
        private void DeplacerBarre(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
