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
        int iChronometre = 2000;//valeur du chronometre en haut a gauche

        //déclaration des pricipaux éléments de l'énigme
        PictureBox pbxBackground = new PictureBox();
        PictureBox pbxBatiment = new PictureBox();
        PictureBox pbxCible = new PictureBox();

        //déclaration des labels
        Label lblChronometre = new Label();

        //Création d'un objet Random
        Random random = new Random();

        //permet de faire spawner les zombies a interval différent
        int iTickRandomGauche;
        int iTickRandomDroite;

        //création d'un timer
        private Timer timer = new Timer();

        //création d'une liste
        List<Zombie> zombies = new List<Zombie>();//Liste de zombies
        List<Zombie> zombiesMort = new List<Zombie>();//Liste des zombies morts
        List<Coeur> coeurs = new List<Coeur>();//Liste des coeurs

        public override void Load()
        {
            timer.Start();
        }

        public override void Unload()
        {
            timer.Stop();
        }

        public ZombieInvasionEnigmaPanel()
        {            
            //Modification des parametre du panel de base
            Screen myScreen = Screen.PrimaryScreen;
            this.Width = (myScreen.WorkingArea.Width);
            this.Height = 400;

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

            //placement du label
            lblChronometre.Text = Convert.ToString(iChronometre);
            lblChronometre.Font = new Font("Arial", 24, FontStyle.Bold);
            lblChronometre.Size = new Size(120, 30);
            lblChronometre.Location = new Point(30, 0);

            //Mise en place d'un timer
            timer.Interval = 2; // 10 miliseconde
            timer.Tick += new EventHandler(Timer_Tick);

            //changement du curseur
            this.Cursor = new Cursor(Properties.Resources.CibleRouge.GetHicon());//de base on met le curseur en rouge

            //création d'un evenement de click
            MouseClick += new MouseEventHandler(PanelClick);

            //ajout de l'image
            Controls.Add(lblChronometre);
            Controls.Add(pbxCible);
            Controls.Add(pbxBatiment);
            Controls.Add(coeur1);
            Controls.Add(coeur2);
            Controls.Add(coeur3);
        }

        //evenements
        public void PanelClick(object sender, MouseEventArgs e)//quand on click sur le panel
        {
            this.Cursor = new Cursor(Properties.Resources.CibleNoir.GetHicon());//changement de l'image du curseur
            bViseurRouge = false;//on inverse la variable une fois que l'utilisateur à cliquer
            iTimerCible = 0;//on remet la varaible à zero
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //permet d'ajouter un zombie si 100 tick se sont écoulés
            if (iTickRandomGauche == 0)
            {
                //ajout les zombies de gauche sur le panel
                AjouterZombie(Direction.GAUCHE);
                iTickRandomGauche = NextRandom();
            }

            if (iTickRandomDroite == 0)
            {
                //ajout les zombies de droite sur le panel
                AjouterZombie(Direction.DROITE);
                iTickRandomDroite = NextRandom();
            }

            //incrementation et decrementaion de certains variables de timer
            iTimerCible++;

            iTickRandomGauche--;
            iTickRandomDroite--;

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
                            timer.Stop();
                            if (MessageBox.Show("t'as perdu") == DialogResult.OK)
                            {
                                Initialisation();
                                timer.Start();
                                return;
                            }
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
                TuerZombie(zombie);
            }

            foreach(Coeur coeur in coeurs)//on parcours la liste de coeur
            {
                if(coeur.Enabled == false)//si le coeur est desactivé
                {
                    coeur.EnleverCoeur();//on met le coeur en blanc
                }
            }

            //gestion du chronometre
            iChronometre--;
            lblChronometre.Text = Convert.ToString(iChronometre);

            if(iChronometre == 0)
            {
                timer.Stop();
                MessageBox.Show("La réponse est \"Cancun\" !");
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
            return random.Next(80, 150);
        }

        /// <summary>
        /// Permet de tuer un zombie
        /// </summary>
        /// <param name="zombie">Il faut préciser le zombie en question</param>
        public void TuerZombie(Zombie zombie)
        {
            zombies.Remove(zombie);
            Controls.Remove(zombie);
        }

        private  void Initialisation()
        {
            bViseurRouge = true;
            iTimerCible = 0;//permet de compter les ticks du viseur
            iTimerZombie = 0;//permet de faire spwaner les zombies a interval régulier
            iNombresDeCoeurs = 0;//indique le nombre de coeur restant
            iChronometre = 2000;//valeur du chronometre en haut a gauche

            lblChronometre.Text = Convert.ToString(iChronometre);

            foreach(Coeur coeur in coeurs)
            {
                Controls.Remove(coeur);
                coeur.Image = Properties.Resources.CoeurRouge;
                coeur.Enabled = true;
                Controls.Add(coeur);
            }

            foreach(Zombie zombie in zombies)
            {
                Controls.Remove(zombie);
            }

            zombies.Clear();
        }
    }
}
