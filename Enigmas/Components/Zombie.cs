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
        private bool bZombieStop = false;//definit si le zombie est arreter

        /// <summary>
        /// C'est le constructeur par défaut de la classe zombie
        /// </summary>
        /// <param name="parent">on doit lui envoyer le panel en parametre</param>
        public Zombie(EnigmaPanel parent, string strPositionZombie)
        {
            this.Size = Properties.Resources.ZombieDroite.Size; //on définit la taille de l'image


            //on affecte différent paramétre selon la position du zombie
            if (strPositionZombie == "Droite")
            {
                this.Location = new Point(parent.Width - this.Width, parent.Height - this.Height);//place les zombies sur le panel
                this.Image = Properties.Resources.ZombieDroite;//définit une image
            }
            else
            {
                this.Location = new Point(0, parent.Height - this.Height);//place les zombies sur le panel
                this.Image = Properties.Resources.ZombieGauche;//définit une image
            }
        }

        /// <summary>
        /// permet de faire avancer le zombie de 2 pixels sur la gauche
        /// </summary>
        public void AvancerGauche()
        {
            //teste que le zombie ne soit pas stopper
            if (!bZombieStop)
            {
                this.Left -= 2;//on fais avancer l'objet
            }
        }

        /// <summary>
        /// permet de faire avancer le zombie de 2 pixels sur la droite
        /// </summary>
        public void AvancerDroite()
        {
            //teste que le zombie ne soit pas stopper
            if (!bZombieStop)
            {
                this.Left += 2;//on fais avancer l'objet
            }
        }

        /// <summary>
        /// permet de stopper le zombie
        /// </summary>
        public void Arreter()
        {
            bZombieStop = true;
        }
    }
}
