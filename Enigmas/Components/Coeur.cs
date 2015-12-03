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
        public Coeur(Point position)
        {
            this.Image = Properties.Resources.CoeurRouge;
            this.Location = position;
        }

        public void EnleverCoeur()
        {
            this.Image = Properties.Resources.CoeurBlanc;
        }
    }
}
