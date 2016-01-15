using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas.Components
{
    class Beer : Panel
    {
        private Image beer;
        private bool bCroix;

        public Beer(bool bCroix)
        {
            this.bCroix = bCroix;
            this.Location = new Point(100, 100);

            if (bCroix)
            {
                beer = Properties.Resources.BeerShot_Croix;
            }
            else
            {
                beer = Properties.Resources.BeerShot_SansCroix;
            }

            // Panel de la bière avec croix
            this.BackgroundImage = beer;
            this.Width = beer.Width;
            this.Height = beer.Height;
        }
    }
}
