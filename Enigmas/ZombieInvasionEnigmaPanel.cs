using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cpln.Enigmos.Enigmas.Components;

namespace Cpln.Enigmos.Enigmas
{

    class ZombieInvasionEnigmaPanel : EnigmaPanel
    {
        //déclaration des variables
        bool bViseurRouge = true;
        int iTimerCible = 0;//permet de compter les ticks du viseur
        int iTimerZombie = 0;//permt de faire spwaner les zombies a interval régulier

        //déclaration des pricipaux éléments de l'énigme
        PictureBox pbxBackground = new PictureBox();
        PictureBox pbxBatiment = new PictureBox();
        PictureBox pbxCible = new PictureBox();

        //création d'un timer
        private Timer Timer = new Timer();

        //création des coeurs
        Coeur coeur1 = new Coeur();

        //création d'une liste
        List<Zombie> zombies = new List<Zombie>();

        public ZombieInvasionEnigmaPanel()
        {
            

            //Modification des parametre du panel de base
            Screen myScreen = Screen.PrimaryScreen;
            this.Width = (myScreen.WorkingArea.Width);
            this.Height = (myScreen.WorkingArea.Height) - 100;

            //Création du batiment
            pbxBatiment.Size = Properties.Resources.Batiment.Size;
            pbxBatiment.Image = Properties.Resources.Batiment;
            pbxBatiment.Location = new Point(this.Width / 2 - pbxBatiment.Width / 2, this.Bottom - pbxBatiment.Height);

            //Mise en place d'un timer
            Timer.Interval = 100; // 10 millisecondes
            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Start();

            //changement du curseur
            this.Cursor = new Cursor(Properties.Resources.CibleRouge.GetHicon());//de base on met le curseur en rouge

            //création d'un evenement de click
            MouseClick += new MouseEventHandler(PanelClick);

            //ajout de l'image
            Controls.Add(pbxCible);
            Controls.Add(pbxBatiment);
        }

        //evenements
        private void PanelClick(object sender, MouseEventArgs e)//quand on click sur le panel
        {
            this.Cursor = new Cursor(Properties.Resources.CibleNoir.GetHicon());//changement de l'image du curseur
            bViseurRouge = false;//on inverse la variable une fois que l'utilisateur à cliquer
            iTimerCible = 0;//on remet la varaible à zero
        }
 
        private void Timer_Tick(object sender, EventArgs e)
        {
            //permt d'ajouter un zombie si 100 tick se sont écoulés
            if (iTimerZombie % 100 == 0)
            {
                //ajout des zombies sur le panel
                AjouterZombie(Direction.GAUCHE);
                AjouterZombie(Direction.DROITE);
            }

            //incrementation les variables de timer
            iTimerZombie++;
            iTimerCible++;

            //si le curseur n'est pas en rouge et que 10 seconde ce sont écoulées
            if(!bViseurRouge && iTimerCible > 2)
            {
                this.Cursor = new Cursor(Properties.Resources.CibleRouge.GetHicon());//changement de l'image du curseur
            }

            //fait avancer chaque zombie se trouvant dans la liste de zombie
            foreach (Zombie zombie in zombies)
            {
                zombie.Avancer();//fait avancer le zombie contre la gauche
            }
        }

        /// <summary>
        /// Procédure permettant de créer et d'ajouter les zombies dans les 'controls' et dans la liste
        /// </summary>
        private void AjouterZombie(Direction direction)
        {
            Zombie zombie = new Zombie(this, direction, pbxBatiment);
            Controls.Add(zombie);
            zombies.Add(zombie);
        }
    }
}
