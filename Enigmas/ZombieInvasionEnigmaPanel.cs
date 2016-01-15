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
        int iNombresDeCoeurs = 0;//indique le nombre de coeur restant
        int iChronometre = 2000;//valeur du chronometre en haut a gauche

        //déclaration des pricipaux éléments de l'énigme
        PictureBox pbxBackground = new PictureBox();
        PictureBox pbxBatiment = new PictureBox();
        PictureBox pbxCible = new PictureBox();

        //déclaration des labels
        Label lblChronometre = new Label();

        //création d'un objet Random
        Random random = new Random();

        //permet de faire spawner les zombies à interval différent
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
            Initialisation();
        }

        public override void Unload()
        {
            timer.Stop();
        }

        public ZombieInvasionEnigmaPanel()
        {            
            //modification des parametres du panel de base
            Screen myScreen = Screen.PrimaryScreen;
            this.Width = (myScreen.WorkingArea.Width);
            this.Height = 400;

            //création et ajout des coeurs
            Coeur coeur1 = new Coeur(new Point(this.Right - 50, 0));
            Coeur coeur2 = new Coeur(new Point(this.Right - 100, 0));
            Coeur coeur3 = new Coeur(new Point(this.Right - 150, 0));
            coeurs.Add(coeur1);
            coeurs.Add(coeur2);
            coeurs.Add(coeur3);

            //création du batiment
            pbxBatiment.Size = Properties.Resources.Batiment.Size;
            pbxBatiment.Image = Properties.Resources.Batiment;
            pbxBatiment.Location = new Point(this.Width / 2 - pbxBatiment.Width / 2, this.Bottom - pbxBatiment.Height);

            //déclaration de deux nombres Randoms
            iTickRandomGauche = NextRandom();
            iTickRandomDroite = NextRandom();

            //placement du label
            lblChronometre.Text = "Timer : " + Convert.ToString(iChronometre);
            lblChronometre.Font = new Font("Arial", 24, FontStyle.Bold);
            lblChronometre.Size = new Size(120, 30);
            lblChronometre.Location = new Point(30, 0);

            //mise en place d'un timer
            timer.Interval = 2; // 10 miliseconde
            timer.Tick += new EventHandler(Timer_Tick);

            //changement du curseur
            this.Cursor = new Cursor(Properties.Resources.CibleRouge.GetHicon());//de base on met le curseur en rouge

            //création d'un evenement de click
            MouseClick += new MouseEventHandler(PanelClick);

            //ajout des images dans les controls
            Controls.Add(lblChronometre);
            Controls.Add(pbxCible);
            Controls.Add(pbxBatiment);
            Controls.Add(coeur1);
            Controls.Add(coeur2);
            Controls.Add(coeur3);
        }

        /// <summary>
        /// Detection d'un appuie sur le panel
        /// </summary>
        public void PanelClick(object sender, MouseEventArgs e)
        {
            this.Cursor = new Cursor(Properties.Resources.CibleNoir.GetHicon());//changement de l'image du curseur
            //this.Cursor = null;
            bViseurRouge = false;//on inverse la variable une fois que l'utilisateur à cliqué
            iTimerCible = 0;//on remet la varaible à zero
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            //permet de faire apparaitre des zombies a interval différé
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
            if(!bViseurRouge && iTimerCible > 8)
            {
                this.Cursor = new Cursor(Properties.Resources.CibleRouge.GetHicon());//changement de l'image du curseur
            }


            //fait avancer chaque zombie se trouvant dans la liste de zombie
            foreach (Zombie zombie in zombies)
            {
                try
                {
                    zombie.Avancer();//fait avancer les zombies

                    //si il y a une collision entre le zombie et le batiment
                    if(zombie.Collision())
                    {
                        //si il n'y a plus de coeurs disponibles
                        if(iNombresDeCoeurs < 3)
                        {
                            coeurs[iNombresDeCoeurs].Enabled = false;//on desactive les coeurs
                            iNombresDeCoeurs++;
                        }
                        else
                        {
                            timer.Stop();//on arrete le timer

                            //si l'utilisateur à appuyé sur OK
                            if (MessageBox.Show("t'as perdu") == DialogResult.OK)
                            {
                                Initialisation();//on réinitialise tous les composants
                                timer.Start();//on redémarre le timer
                                return;
                            }
                        }

                    }
                }
                catch (ArreterException)//si le zombie est arreter on lance une exeption 
                {
                    zombiesMort.Add(zombie);//on ajoute le zombie à la liste des zombies morts
                }
            }

            foreach (Zombie zombie in zombiesMort)//on parcours la liste de zombie mort
            {
                TuerZombie(zombie);//on tue le zombie
            }

            foreach(Coeur coeur in coeurs)//on parcours la liste de coeur
            {
                if(coeur.Enabled == false)//si le coeur est desactivé
                {
                    coeur.EnleverCoeur();//on met le coeur en blanc
                }
            }


            iChronometre--;//on decremente le chronometre
            lblChronometre.Text = Convert.ToString(iChronometre);//on met à jour le texte

            if(iChronometre == 0)//si le chronometre a atteint 0
            {
                timer.Stop();//on stoppe le timer
                MessageBox.Show("La réponse est \"Cancun\" !");//on affiche un message
            }

        }

        /// <summary>
        /// Procédure permettant de créer et d'ajouter les zombies dans les 'controls' et dans la liste
        /// </summary>
        private void AjouterZombie(Direction direction)
        {
            Zombie zombie = new Zombie(this, direction, pbxBatiment);//on instancie un zombie
            Controls.Add(zombie);//ajoute les zombies aux controls
            zombies.Add(zombie);//on ajoute le zombie à la liste de zombie
        }

        /// <summary>
        ///  permet de retourner un nombre aléatoire
        /// </summary>
        /// <param name="iMin">Le nombre minimum voulu</param>
        /// <param name="iMax">Le nombre maximun voulu</param>
        /// <returns>Retourne le nombre random en question</returns>
        private int NextRandom()
        {
            return random.Next(70, 170);//retourne un nombre random
        }

        /// <summary>
        /// Permet de tuer un zombie
        /// </summary>
        /// <param name="zombie">Il faut préciser le zombie en question</param>
        public void TuerZombie(Zombie zombie)
        {
            zombies.Remove(zombie);//on enleve le zombie de liste
            Controls.Remove(zombie);//on enleve le zombie des controls
        }

        /// <summary>
        /// Permt d'initialiser le programme
        /// </summary>
        private  void Initialisation()
        {
            bViseurRouge = true;
            iTimerCible = 0;//permet de compter les ticks du viseur
            iNombresDeCoeurs = 0;//indique le nombre de coeur restant
            iChronometre = 2000;//valeur du chronometre en haut a gauche

            lblChronometre.Text = Convert.ToString(iChronometre);

            //remet les coeurs
            foreach(Coeur coeur in coeurs)
            {
                Controls.Remove(coeur);
                coeur.Image = Properties.Resources.CoeurRouge;
                coeur.Enabled = true;
                Controls.Add(coeur);
            }

            //enleve tous les zombies des contols
            foreach(Zombie zombie in zombies)
            {
                Controls.Remove(zombie);
            }

            zombies.Clear();//on enleve tous les elements de la liste
        }
    }
}
