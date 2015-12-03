using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas.Components
{
    class Coeur : PictureBox
    {
        public Coeur()
        {
            this.Image = Properties.Resources.CoeurRouge;
        }

        public void EnleverCoeur()
        {
            this.Image = Properties.Resources.CoeurBlanc;
        }
    }
}
