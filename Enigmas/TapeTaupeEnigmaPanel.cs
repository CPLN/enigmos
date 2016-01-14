using Cpln.Enigmos.Enigmas.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    public class TapeTaupeEnigmaPanel : EnigmaPanel
    {       
        private Timer tJeu = new Timer();

        public TapeTaupeEnigmaPanel()
        {
            tJeu.Interval = 1;
            tJeu.Tick += new EventHandler(timer_tJeu);

            PictureBox pbxTaupe = new PictureBox();
            pbxTaupe.Width = 50;
            pbxTaupe.Height = 50;
            //pbxTaupe.Image = 
            Controls.Add(pbxTaupe);
            pbxTaupe.BringToFront();
            pbxTaupe.MouseClick += new MouseEventHandler(pbxTaupe_Click);
            asdas
        }

        public override void Load()
        {

        }

        private void pbxTaupe_Click(object sender, MouseEventArgs e)
        {

        }

        private void timer_tJeu(object sender, EventArgs e)
        {

        }
    }
}
