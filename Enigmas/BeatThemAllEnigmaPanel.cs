using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Cpln.Enigmos.Enigmas.Components;

namespace Cpln.Enigmos.Enigmas
{
    public class BeatThemAllEnigmaPanel : EnigmaPanel
    {
        ///constante permettant de gérer les caractéristiques fondamentales qui influront rapidement sur le gameplay
        const int WIDTH_PUNCH = 65, CARACTER_SPEED = 10, TIME_FRAME_PUNCH = 20, TIME_JUMP = 25, STRENGTH_JUMP = 8;

        private Timer Timer = new Timer();
        private PictureBox pbxPlayer = new PictureBox();
        public PictureBox pbxGround = new PictureBox();
        private PictureBox pbxTutoriel = new PictureBox();
        public List<Ennemi> listEnnemi;

        //bool gérant les délpacements
        private bool bIsRight = false, bIsLeft = false, bFaceRight = true, bJump = false;

        private bool bPunch = false, bGodMod = false;
        private int iTimer = 0, iTimerPunch = 0, iTimerJump = 0, iNbrEnnemiDead;

        public BeatThemAllEnigmaPanel()
        {
            //Modification des paramêtre du panel de base
            Screen myScreen = Screen.PrimaryScreen;
            this.Width = (myScreen.WorkingArea.Width);
            this.Height = (myScreen.WorkingArea.Height) / 2;
            this.BackColor = Color.Black;

            //Mise en place du sol
            pbxGround.Size = new Size(this.Width, this.Height / 7);
            pbxGround.Location = new Point(this.Width / 2 - pbxGround.Width / 2, this.Bottom - pbxGround.Height);
            pbxGround.BackColor = Color.Black;
            Controls.Add(pbxGround);

            //Mise en place du personnage joueur
            pbxPlayer.Size = Properties.Resources.pj1.Size; ;
            pbxPlayer.Location = new Point(pbxGround.Width / 2 - pbxPlayer.Width / 2, pbxGround.Top - pbxPlayer.Height);
            pbxPlayer.BackColor = Color.Transparent;
            Controls.Add(pbxPlayer);

            //Mise en place du Bouton "tutoriel" qui servira également à "game over" 
            pbxTutoriel.Size = Properties.Resources.tutorial.Size;
            pbxTutoriel.Image = Properties.Resources.tutorial;
            pbxTutoriel.Location = new Point(this.Width/5, this.Top);
            pbxTutoriel.BackColor = Color.Transparent;
            Controls.Add(pbxTutoriel);
            Controls.SetChildIndex(pbxTutoriel, 0);

            //Mise en place d'un timer (gérants les déplacements ennemie)
            Timer.Interval = 1; // 1 milliseconde
            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Stop();

            //Affecte la liste "listEnnemi"
            listEnnemi = new List<Ennemi>();

            pbxTutoriel.Click += new EventHandler(OnButtonClick);

            this.Focus();
        }

        public override void Load()//au chargement de l'énigme
        {
            pbxTutoriel.Enabled = true;//remet le tuto en cliquable
            pbxTutoriel.Show();
            pbxTutoriel.Size = Properties.Resources.tutorial.Size;
            pbxTutoriel.Image = Properties.Resources.tutorial;
            pbxTutoriel.BackColor = Color.Transparent;
            pbxPlayer.Location = new Point(pbxGround.Width / 2 - pbxPlayer.Width / 2, pbxGround.Top - pbxPlayer.Height);
            pbxPlayer.BackColor = Color.Transparent;
            pbxPlayer.Width = Properties.Resources.pj1.Width;//btnReset la taille du player

        }

        public override void Unload()//quand on quitte l'énigme
        {
            pbxGround.BackColor = Color.Black;
            Timer.Stop();
            pbxPlayer.Width = Properties.Resources.pj1.Width;//btnReset la taille du player
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            pbxTutoriel.Hide();
            Timer.Start();
            pbxGround.BackColor = Color.White;
        }

        //Fonction permettant de gèrer les input du joueur (déplacement, punch, saut)
        public override void PressKey(object sender, KeyEventArgs e)
        {
            if (iTimerPunch == 0)//test si un punch est en cours, si non les actions peuvent se lancer corréctement
            {
                //fais avancer le personnage à droite
                if (e.KeyCode == Keys.D && pbxPlayer.Right < this.Right)
                {
                    bIsRight = true;
                    bFaceRight = true;
                }
                //fais avancer le personnage à gauche
                if (e.KeyCode == Keys.A && pbxPlayer.Left > this.Left)
                {
                    bIsLeft = true;
                    bFaceRight = false;
                }
                //fais sauter le personnage
                if (e.KeyCode == Keys.W)
                {
                    Jump();
                }
                //fais attaquer le personnage
                if (e.KeyCode == Keys.Space)
                {
                    Punch();
                }
            }
        }
        public override void ReleaseKey(object sender, KeyEventArgs e)
        {
            //permet de stopper l'avancement du personnage sur la droite
            if (e.KeyCode == Keys.D)
            {
                bIsRight = false;
            }
            //permet de stopper l'avancement du personnage sur la gauche
            if (e.KeyCode == Keys.A)
            {
                bIsLeft = false;
            }
        }

        //Permet au personnage d'attaquer
        private void Punch()
        {
            if (iTimerPunch == 0)//test si un punch est en cours, si non, l'actions peut se lancer corréctement
            {
                //attaque à droit
                if (bFaceRight == true)
                {
                    pbxPlayer.Image = Properties.Resources.pj2;
                }
                //attaque à gauche
                else
                {
                    pbxPlayer.Image = Properties.Resources.pj4;
                }
                pbxPlayer.Width = pbxPlayer.Image.Width; // mise à jour de la taille
                bPunch = true;//lance une fonction dans le timer permettant de "retracter" le poing
            }
        }

        //Permet au joueur de sauter
        private void Jump()
        {
            if (pbxPlayer.Bottom == pbxGround.Top)//test si le joueur est au sol, si oui l'action peut se lancer
            {
                bJump = true;//lance une fonction dans le timer permettant de retomber sur le "sol"
            }
        }

        //Timer gérant les spawns 
        private void Timer_Tick(object sender, EventArgs e)
        {
            //Gére les images
            if (bFaceRight == true)
            {
                pbxPlayer.Image = Properties.Resources.pj1;
            }
            else
            {
                pbxPlayer.Image = Properties.Resources.pj3;
            }
            pbxPlayer.Width = pbxPlayer.Image.Width; // mise à jour de la taille

            #region Left Right input
            //Gére les déplacement
            if (bIsRight == true && pbxPlayer.Right < this.Right)//test si le joueur appui sur la touche permettant d'aller à droite et si il est dans la limite de déplacement 
            {
                pbxPlayer.Left += CARACTER_SPEED;//si oui le fait se déplacer à droite, sur un certain temps
            }
            if (bIsLeft == true && pbxPlayer.Left > this.Left)//test si le joueur appui sur la touche permettant d'aller à gauche et si il est dans la limite de déplacement 
            {
                pbxPlayer.Left -= CARACTER_SPEED;//si oui le fait se déplacer à gauche, sur un certain temps
            }
            #endregion

            #region Punch
            //Gére les coups de poingt
            if (bPunch == true)
            {
                bGodMod = true;//permet au joueur d'être insensible pendant qu'il attaque
                iTimerPunch++;//sert à gérer les millisecondes dans le timer
                if (bFaceRight)//test si le personnage est en direction de la droite
                {
                    pbxPlayer.Image = Properties.Resources.pj2; //modifi son sprite
                }
                else
                {
                    pbxPlayer.Image = Properties.Resources.pj4; //modifi son sprite
                }

                if (iTimerPunch == TIME_FRAME_PUNCH)//si le temps du coups de poing est fini
                {
                    if (bFaceRight == false)//test si le personnage est en direction de la gauche
                    {
                        pbxPlayer.Left += WIDTH_PUNCH;//modifi sa hitbox (problème winForm)
                    }
                    pbxPlayer.Width = Properties.Resources.pj1.Width;//btnReset la taille du player
                    bGodMod = false;// remet le joueur en mode vulnérable
                    iTimerPunch = 0;
                    bPunch = false;//permet de ne plus rentrer dans cette boucle
                }
            }
            #endregion

            #region Jump
            //Gére les sauts
            if (bJump == true)//si le saut est activé
            {
                iTimerJump++;//sert à gérer les millisecondes dans le timer

                pbxPlayer.Top -= STRENGTH_JUMP;

                if (iTimerJump == TIME_JUMP)
                {
                    iTimerJump = 0;
                    bJump = false;
                }
            }
            if (pbxPlayer.Bottom < pbxGround.Top && bJump == false)
            {
                pbxPlayer.Top += 10;//9.81 gravité arrondie
            }
            #endregion

            #region Ennemies
            iTimer++;//sert à gérer les millisecondes dans le timer
            //Crée un ennemie toutes les 0.7s
            Ennemi ennemi = null;
            if (iTimer == 70)
            {
                ennemi = Ennemi.CreateEnnemi(this, pbxGround, listEnnemi);
                iTimer = 0;
            }

            //fais avancer les ennemies
            for (int i = 0; i < listEnnemi.Count; i++)
            {
                if (listEnnemi[i].getDirection() == Direction.GAUCHE)
                {
                    listEnnemi[i].Left -= 6;
                }
                else if (listEnnemi[i].getDirection() == Direction.DROITE)
                {
                    listEnnemi[i].Left += 6;
                }

                //HitBox des ennemies
                if (listEnnemi[i].Right >= pbxPlayer.Left && listEnnemi[i].Top <= pbxPlayer.Bottom && listEnnemi[i].Left <= pbxPlayer.Right)
                {
                    //si le joueur est entrer en colision avec un ennemi pendant qu'il frappait
                    if (bGodMod == true)
                    {
                        //"tue" l'ennemi
                        Controls.Remove(listEnnemi[i]);
                        listEnnemi.Remove(listEnnemi[i]);
                        iNbrEnnemiDead++;//incrémente les nombre d'ennemi tués
                    }
                    //si le joueur est entrer en colision avec un ennemi pendant qu'il était vulnérable
                    else
                    {
                        //"tue" l'ennemi
                        Controls.Remove(listEnnemi[i]);
                        listEnnemi.Remove(listEnnemi[i]);

                        pbxTutoriel.Size = Properties.Resources.game_over.Size;
                        pbxTutoriel.Image = Properties.Resources.game_over; //modifi en écran game over
                        pbxTutoriel.Show();//montre l'écran game over

                        iNbrEnnemiDead = 0;//remet à zero le nombre d'ennemi tués

                        Timer.Stop();//stop le timer
                    }
                }
            }
            #endregion

            #region test si gagne
            //test si le joueur à gagné
            if (iNbrEnnemiDead >= 10)
            {
                Timer.Stop();//stop le timer
                pbxTutoriel.Enabled = false;
                pbxTutoriel.Size = Properties.Resources.GG.Size;
                pbxTutoriel.Image = Properties.Resources.GG; //modifi en écran de fin
                pbxTutoriel.Show();//montre de fin
            }
            #endregion
        }
    }
}