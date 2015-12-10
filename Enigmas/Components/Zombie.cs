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
        private Direction direction;//définit la direction du zombie
        private PictureBox pbxBatiment;//image du batiment

        /// <summary>
        /// C'est le constructeur par défaut de la classe zombie
        /// </summary>
        /// <param name="parent">on doit lui envoyer le panel en parametre</param>
        public Zombie(EnigmaPanel parent, Direction direction, PictureBox pbxBatiment)
        {
            this.Size = Properties.Resources.ZombieDroite.Size; //on définit la taille de l'image
            this.direction = direction;
            this.pbxBatiment = pbxBatiment;

            //on affecte différent paramétre selon la position du zombie
            if (direction == Direction.GAUCHE)
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
        public void Avancer()
        {
            //teste s'il n'y a pas de collison
            if (Collision())
            {
                Arreter();//s'il y a collision on arrete le zombie
            }

            //teste que le zombie ne soit pas stopper
            if (!bZombieStop)
            {
                if(direction == Direction.GAUCHE)
                {
                    this.Left -= 2;//on fais avancer l'objet
                }
                else
                {
                    this.Left += 2;//on fais avancer l'objet
                }
            }
        }

        /// <summary>
        /// permet de stopper le zombie
        /// </summary>
        private void Arreter()
        {
            bZombieStop = true;
        }


        /// <summary>
        /// permet de tester s'il y a une collision entre le zombie et le batiment
        /// </summary>
        /// <returns>retorune 'false' s'il n'y a pas de collision retourne 'true' dans le cas contraire</returns>
        public bool Collision()
        {
            if(this.Right < pbxBatiment.Left)
            {
                return false;
            }
            
            if(this.Left > pbxBatiment.Right)
            {
                return false;
            }

            if(this.Bottom < pbxBatiment.Top)
            {
                return false;
            }

            if(this.Top > pbxBatiment.Bottom)
            {
                return false;
            }

            return true;
        }

        
    }
}
