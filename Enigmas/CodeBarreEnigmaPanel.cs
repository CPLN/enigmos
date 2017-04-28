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

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        List<Panel> list = new List<Panel>();
        int iPosX = 120;
        Random rnd = new Random();
        RotatingLabel cpln = new RotatingLabel();
        /// <summary>
        /// Constructeur par défaut (initialisation le code barre et initialisation du mot caché)
        /// </summary>
        public CodeBarreEnigmaPanel()
        {
            // Initialise le code barre
            for (int i = 0; i < 15; i++)
            {
                Panel Barre = new Panel();
                list.Add(Barre);
                list[0 + i].Size = new Size(rnd.Next(8, 20), 200);
                list[0 + i].Location = new Point(iPosX + iPosX, 200);
                list[0 + i].BackColor = Color.Black;
                list[0 + i].MouseMove += new MouseEventHandler(DeplacerBarre);
                this.Controls.Add(list[0 + i]);
                iPosX += 12;
            }
            // Initialise le mot caché
            cpln.Text = "cpln";
            cpln.Location = new Point(500, 300);
            cpln.Angle = 90;
            this.Controls.Add(cpln);
        }
        /// <summary>
        /// Méthode pour deplacer certain panels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
