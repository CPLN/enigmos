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

        /// <summary>
        /// C'est le constructeur par défaut de la classe zombie
        /// </summary>
        /// <param name="parent">on doit lui envoyer le panel en parametre</param>
        public Zombie(EnigmaPanel parent)
        {
            this.Image = CreerImage(); //on définit l'image de l'objet  
            this.Size = Properties.Resources.Zombie.Size; //on définit la taille de l'image
            this.Location = new Point(parent.Width - this.Width, parent.Height - this.Height);//palce les zombies sur le panel
        }

        /// <summary>
        /// permet de faire avancer le zombie de 2 pixels sur la gauche
        /// </summary>
        public void AvancerGauche()
        {
            this.Left -= 2;//on fais avancer l'objet
        }

        /// <summary>
        /// permet de faire avancer le zombie de 2 pixels sur la droite
        /// </summary>
        public void AvancerDroite()
        {
            this.Left += 2;//on fais avancer l'objet
        }

        /// <summary>
        /// permet de créer une image afin de l'afficher sur le zombie
        /// </summary>
        /// <returns>retourne l'image qui sera afficher su le zombie</returns>
        private Image CreerImage()
        {
            return Properties.Resources.Zombie;
        }
    }
}
