using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    public class TrouverEnigmaPanel : EnigmaPanel
    {
        /// <summary>
        /// Constructeur par défaut, génère un texte et l'affiche dans le Panel.
        /// </summary>
        public TrouverEnigmaPanel()
        {
            Label lblEnigme = new Label();
            int i = 0;
            Random random = new Random();
            for (i = 0; i < 100; i++)
            {
                Button b = new Button();
                b.Text = "" + i;
                b.Size = new Size(100, 100);
                b.Location = new Point(random.Next(800), random.Next(600));
                i++;
                Controls.Add(b);
            }
            Button bCristiano = new Button();
            bCristiano.Text = "" + 666;
            bCristiano.Size = new Size(100, 100);
            bCristiano.Location = new Point(random.Next(800), random.Next(600));
            bCristiano.BackColor = Color.Red;
            bCristiano.Click += new EventHandler(bCristiano_Click);
            Controls.Add(bCristiano);
            lblEnigme.Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);
            lblEnigme.Dock = DockStyle.Fill;
            lblEnigme.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(lblEnigme);
            }     
            private void bCristiano_Click(object sender, EventArgs e)
            {
            MessageBox.Show("Le mot à valider est cristiano", "Yo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }



            //lblEnigme.Text = "fesse ?";
            
            
        }
    }

