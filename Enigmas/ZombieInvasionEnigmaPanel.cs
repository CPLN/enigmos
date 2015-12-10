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
        int iTimerZombie = 0;//permet de faire spwaner les zombies a interval régulier
        int iNombresDeCoeurs = 0;//indique le nombre de coeur restant

        //déclaration des pricipaux éléments de l'énigme
        PictureBox pbxBackground = new PictureBox();
        PictureBox pbxBatiment = new PictureBox();
        PictureBox pbxCible = new PictureBox();

        //Création d'un objet Random
        Random random = new Random();

        int iTickRandomGauche;
        int iTickRandomDroite;

        //création d'un timer
        private Timer Timer = new Timer();

        //création d'une liste
        List<Zombie> zombies = new List<Zombie>();//Liste de zombies
        List<Zombie> zombiesMort = new List<Zombie>();//Liste des zombies morts
        List<Coeur> coeurs = new List<Coeur>();//Liste des coeurs

        public ZombieInvasionEnigmaPanel()
        {            
            //Modification des parametre du panel de base
            Screen myScreen = Screen.PrimaryScreen;
            this.Width = (myScreen.WorkingArea.Width);
            this.Height = (myScreen.WorkingArea.Height) - 100;

            //création des coeurs
            Coeur coeur1 = new Coeur(new Point(this.Right - 50, 0));
            Coeur coeur2 = new Coeur(new Point(this.Right - 100, 0));
            Coeur coeur3 = new Coeur(new Point(this.Right - 150, 0));
            coeurs.Add(coeur1);
            coeurs.Add(coeur2);
            coeurs.Add(coeur3);

            //Création du batiment
            pbxBatiment.Size = Properties.Resources.Batiment.Size;
            pbxBatiment.Image = Properties.Resources.Batiment;
            pbxBatiment.Location = new Point(this.Width / 2 - pbxBatiment.Width / 2, this.Bottom - pbxBatiment.Height);

            //déclaration de deux nombres Random
            iTickRandomGauche = NextRandom();
            iTickRandomDroite = NextRandom();

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
            Controls.Add(coeur1);
            Controls.Add(coeur2);
            Controls.Add(coeur3);
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
            //permet d'ajouter un zombie si 100 tick se sont écoulés
            if (iTimerZombie %  iTickRandomGauche == 0)
            {
                //ajout les zombies de gauche sur le panel
                AjouterZombie(Direction.GAUCHE);
                iTickRandomGauche = NextRandom();
            }

            if (iTimerZombie % iTickRandomDroite == 0)
            {
                //ajout les zombies de droite sur le panel
                AjouterZombie(Direction.DROITE);
                iTickRandomGauche = NextRandom();
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

                try
                {
                    zombie.Avancer();//fait avancer le zombie contre la gauche
                    if(zombie.Collision())
                    {
                        if(iNombresDeCoeurs < 3)
                        {
                            coeurs[iNombresDeCoeurs].Enabled = false;
                            iNombresDeCoeurs++;
                        }
                        else
                        {
                            Timer.Stop();//on stoppe le timer
                            MessageBox.Show("Vous avez perdu !");//on affiche un message
                        }

                    }
                }
                catch (ArreterException exception)//si le zombie est arreter on lance une exeption 
                {
                    zombiesMort.Add(zombie);//quand le zombie est tué
                }
            }

            foreach (Zombie zombie in zombiesMort)//on parcours la liste de zombie mort
            {
                zombies.Remove(zombie);//on enleve le zombie de liste de base de zombie
                Controls.Remove(zombie);//on l'enleve de l'interface graphique
            }

            foreach(Coeur coeur in coeurs)//on parcours la liste de coeur
            {
                if(coeur.Enabled == false)//si le coeur est desactivé
                {
                    coeur.EnleverCoeur();//on met le coeur en blanc
                }
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

        /// <summary>
        /// Permet de retourner un nombre aléatoire
        /// </summary>
        /// <returns>Retourne un nombre aléatoire entre 60 et 120</returns>
        private int NextRandom()
        {
            return random.Next(60, 120);
        }
    }
}
