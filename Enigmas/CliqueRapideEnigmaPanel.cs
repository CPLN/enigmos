using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    class CliqueRapideEnigmaPanel : EnigmaPanel
    {
        private Button btnACliquer = new Button();
        
        public CliqueRapideEnigmaPanel()
        {
            btnACliquer.Size = new Size(200, 200);
            btnACliquer.Location = new Point(400 - btnACliquer.Width / 2, 300 - btnACliquer.Height / 2);
            ChangementPourRouge();
            Controls.Add(btnACliquer);
        }
        private void ChangementPourRouge()
        {
            btnACliquer.BackColor = Color.Red;
            btnACliquer.Text = "Attention ...";
        }

        private void ChangementPourVert()
        {
            btnACliquer.BackColor = Color.Green;
            btnACliquer.Text = "Appuie !!!";
        }
    }
}
