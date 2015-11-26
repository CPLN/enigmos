using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas.Components
{
    class Zombie : PictureBox
    {
        Image ImageZombie;
        Point PositionZombie = new Point(100, 100);

        Zombie(Image image)
        {
            ImageZombie = image;
        }

        public void Avancer()
        {
            this.Left -= 20;
        }

        public void Mourir()
        {
        }
    }
}
