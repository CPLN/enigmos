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
        public Zombie(EnigmaPanel parent)
        {
            this.Image = CreerImage(); //on définit l'image de l'objet  
            this.Size = Properties.Resources.Zombie.Size; //on définit la taille de l'image
            this.Location = new Point(parent.Width - this.Width, parent.Height - this.Height);
        }

        public void AvancerGauche()
        {
            this.Left -= 1;//on fais avancer l'objet
        }

        private Image CreerImage()
        {
            return Properties.Resources.Zombie;
        }
    }
}
