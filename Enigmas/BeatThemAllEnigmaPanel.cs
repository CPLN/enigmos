using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    public class BeatThemAllEnigmaPanel : EnigmaPanel
    {
        //constante permettant de gérer les caractéristique rapidement
        const int WIDTH_PUNCH = 70, CARACTER_SPEED = 25;

        private Timer Timer = new Timer();

        private PictureBox pbxPlayer = new PictureBox();
        private PictureBox pbxGround = new PictureBox();

        List<PictureBox> listEnnemi;

        bool bIsLeft = true, bSpawnEnnemiRight = true, bPunch = false, bGodMod = false;

        int iTimer = 0, iNbrEnnemi = 0, iTimerPunch = 0;

        /// <summary>
        /// Constructeur par défaut, génère les picturesBox de base (le sol, le personnage du joueur).
        /// </summary>
        public BeatThemAllEnigmaPanel()
        {
            //Modification des paramêtre du panel de base
            Screen myScreen = Screen.PrimaryScreen;
            this.Width = (myScreen.WorkingArea.Width);
            this.Height = (myScreen.WorkingArea.Height)/2;
            this.BackColor = Color.Black;

            //Mise en place du sol
            pbxGround.Size = new Size(this.Width, this.Height/7);
            pbxGround.Location = new Point(this.Width / 2 - pbxGround.Width / 2, this.Bottom - pbxGround.Height);
            pbxGround.BackColor = Color.White;
            Controls.Add(pbxGround);

            //Mise en place du personnage joueur
            pbxPlayer.Size = Properties.Resources.pj1.Size; ;
            pbxPlayer.Location = new Point(pbxGround.Width / 2 - pbxPlayer.Width / 2, pbxGround.Top - pbxPlayer.Height);
            pbxPlayer.BackColor = Color.Transparent;
            Controls.Add(pbxPlayer);
 
           //Mise en place d'un timer (gérants les déplacements ennemie)
            Timer.Interval = 1; // 1 milliseconde
            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Start();

            //Affecte la liste "listEnnemi"
            listEnnemi = new List<PictureBox>();

            this.Focus();
        }

        //Fonction permettant de gèrer les input du joueur (déplacement, punch, saut)
        public override void PressKey(object sender, KeyEventArgs e) 
        {
            //droite
            if (e.KeyCode == Keys.D)
            {
                    bIsLeft = false;
                    pbxPlayer.Left += CARACTER_SPEED;
            }
            //gauche
            if (e.KeyCode == Keys.A)
            {
                    bIsLeft = true;
                    pbxPlayer.Left -= CARACTER_SPEED;
            }
            //saut
            if (e.KeyCode == Keys.W)
            {
                
            }
            //punch
            if (e.KeyCode == Keys.Space)
            {
                Punch();
            }
        }

        //Fonction permettant d'ocasionner une frappe 
        private void Punch()
        {
            //punch a droit
            if(bIsLeft==true)
            {
                pbxPlayer.Left -= WIDTH_PUNCH;
                pbxPlayer.Width += WIDTH_PUNCH;
            }
            //punch a gauche
            else
            {
                pbxPlayer.Width += WIDTH_PUNCH;
            }
            bPunch = true;
        }

        //Timer gérant les spawns 
        private void Timer_Tick(object sender, EventArgs e)
        {
            iTimer++;

            //Gére les images
            if(bIsLeft==true)
            {
                pbxPlayer.Image = Properties.Resources.pj3;
            }
            else
            {
                pbxPlayer.Image = Properties.Resources.pj1;
            }
            //Crée les ennemies
            if (iTimer == 40)
            {
                //inverse le point de spawn
                bSpawnEnnemiRight = !bSpawnEnnemiRight;

                PictureBox pbxEnnemi = new PictureBox();
                pbxEnnemi.Size = Properties.Resources.ennemi1.Size;
                if (bSpawnEnnemiRight == true)
                {
                    pbxEnnemi.Location = new Point(pbxGround.Left - pbxEnnemi.Width, pbxGround.Top - pbxEnnemi.Height);
                }
                else
                {
                    pbxEnnemi.Location = new Point(pbxGround.Right, pbxGround.Top - pbxEnnemi.Height);
                }
                pbxEnnemi.BackColor = Color.Transparent;
                pbxEnnemi.Image = Properties.Resources.ennemi1;
                this.Controls.Add(pbxEnnemi);

                listEnnemi.Add(pbxEnnemi);
                iTimer = 0;
            }

            //fais avancer les ennemies
            for (int i = 0; i < listEnnemi.Count; i++)
            {
                if (i % 2 == 0)
                {
                    listEnnemi[i].Left -= 6;
                }
                else
                {
                    listEnnemi[i].Left += 6;
                }

                //HitBox des ennemies
                if (listEnnemi[i].Right >= pbxPlayer.Left && listEnnemi[i].Top <= pbxPlayer.Bottom  && listEnnemi[i].Left <= pbxPlayer.Right)
                {
                    if (bGodMod == true)
                    {
                        Controls.Remove(listEnnemi[i]);
                    }
                    else
                    {
                    }
                }
            }

            //Gére les coups de poingt
            if(bPunch==true)
            {
                bGodMod = true;
                iTimerPunch++;
                if (bIsLeft)
                {
                    pbxPlayer.Image = Properties.Resources.pj4;
                }
                else
                {
                    pbxPlayer.Image = Properties.Resources.pj2;
                }

                if (iTimerPunch == 15)
                {
                    if (bIsLeft)
                    {
                        pbxPlayer.Left += WIDTH_PUNCH;
                    }
                    pbxPlayer.Width  = Properties.Resources.pj1.Width;
                    bGodMod = false;
                    iTimerPunch = 0;
                    bPunch = false;
                }
            }
        }
    }
}