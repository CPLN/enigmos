using Cpln.Enigmos.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace Cpln.Enigmos.Enigmas
{
    /// <summary>
    /// enigme ou l'on doit trouver le rectangle parmi plusieurs carrés
    /// </summary>
    public class RectangleEnigmaPanel : EnigmaPanel
    {
        // Initialisation des divers objets et variables

        Panel[] tpnlCarre = new Panel[500];
        

        /// <summary>
        /// Constructeur par défaut, génère plusieurs carrés.
        /// </summary>
        public RectangleEnigmaPanel()
        {
            Random rnd = new Random();
         
            TableLayoutPanel centerLayout = new TableLayoutPanel();
            centerLayout.ColumnCount = 27;
            for (int i = 0; i < 27 ;i++)
            {
                centerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,0.04f));
            }
            centerLayout.RowCount = 21;
            for (int i = 0; i < 21; i++)
            {
                centerLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 0.05f));
            }
            centerLayout.Dock = DockStyle.Fill;
            Controls.Add(centerLayout);

            for (int i = 0; i < tpnlCarre.Length; i++)
            {
                tpnlCarre[i] = new Panel();
                Random randonGen = new Random();
                Color randomColor = Color.FromArgb(randonGen.Next(240), randonGen.Next(240),
                randonGen.Next(255));
                tpnlCarre[i].BackColor = randomColor;             
                tpnlCarre[i].Size = new Size(20, 20);
                int iLocX = rnd.Next(1, 27);
                int iLocY = rnd.Next(0, 21);                 
                centerLayout.Controls.Add(tpnlCarre[i], iLocX, iLocY);
                tpnlCarre[i].Click += new EventHandler(ClickOnCarre);
            }

            centerLayout.Click += new EventHandler(ClickOnPanel);

        }
        private void ClickOnPanel(object sender, EventArgs e)
        {
            MessageBox.Show("Bien ! (⌐■_■)" + "\n" + "La réponse à l'énigme est la couleur du rectangle.");
        }
        private void ClickOnCarre(object sender, EventArgs e)
        {
            MessageBox.Show("NON C'est un carré");
        }

    }
}