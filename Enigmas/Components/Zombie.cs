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
        public Zombie(Image image, EnigmaPanel parent)
        {
            this.Image = image;//on définit l'image de l'objet  
            this.Size = Properties.Resources.Zombie.Size; //on définit la taille de l'image
            this.Location = new Point(parent.Right - this.Width, parent.Bottom - this.Height);
        }

        public void Avancer()
        {
            this.Left -= 1;//on fais avancer l'objet
        }
    }
}
