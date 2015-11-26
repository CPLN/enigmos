using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{

    /// <summary>
    /// 
    /// </summary>
    public class BeatThemAllEnigmaPanel : EnigmaPanel
    {
        private Timer Timer = new Timer();

        private PictureBox pbxPlayer = new PictureBox();
        private PictureBox pbxGround = new PictureBox();

        List<PictureBox> listEnnemi;

        bool bIsRight = true, bSpawnEnnemiRight = true;

        int iTimer, iNbrEnnemi;

        /// <summary>
        /// Constructeur par défaut, génère les picturesBox de base (le sol, le personnage du joueur).
        /// </summary>
        public BeatThemAllEnigmaPanel()
        {
            //Modification des paramêtre du panel de base
            Screen myScreen = Screen.PrimaryScreen;
            this.Width = (myScreen.WorkingArea.Width);
            this.Height = (myScreen.WorkingArea.Height)/2;

            //Mise en place du sol
            pbxGround.Size = new Size(this.Width, this.Height/7);
            pbxGround.Location = new Point(this.Width / 2 - pbxGround.Width / 2, this.Bottom - pbxGround.Height);
            pbxGround.BackColor = Color.Red;
            Controls.Add(pbxGround);

            //Mise en place du personnage joueur
            pbxPlayer.Size = new Size(80, 100);
            pbxPlayer.Location = new Point(pbxGround.Width / 2 - pbxPlayer.Width / 2, pbxGround.Top - pbxPlayer.Height);
            pbxPlayer.BackColor = Color.Green;
            Controls.Add(pbxPlayer);
 
           //Mise en place d'un timer
            Timer.Interval = 1; // 1 milliseconde
            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Start();

            //Affecte la liste "listEnnemi"
            listEnnemi = new List<PictureBox>();

            this.Focus();
        }

        //Fonction permettant de gèrer les déplacments 
        public override void PressKey(object sender, KeyEventArgs e) 
        {
            if (e.KeyCode == Keys.D)
            {
                if (pbxPlayer.Left >= this.Left)
                {
                    bIsRight = false;
                    pbxPlayer.Left += 10;
                }
            }
            if (e.KeyCode == Keys.A)
            {
                if (pbxPlayer.Right <= this.Right)
                {
                    bIsRight = true;
                    pbxPlayer.Left -= 10;
                }
            }
            if (e.KeyCode == Keys.Space)
            {
                Punch();
            }
        }

        //Fonction permettant d'ocasionner une frappe 
        private void Punch()
        {
            //punch a droit
            if(bIsRight==true)
            {
                pbxPlayer.Left -= 90;
                pbxPlayer.Width += 90;
                //changer image
            }
            //punch a gauche
            else
            {
                pbxPlayer.Width += 90;
                //changer image
            }
        }

        //Timer gérant les spawns 
        private void Timer_Tick(object sender, EventArgs e)
        {
            iTimer++;
            if (iTimer == 140)
            {
                //inverse le point de spawn
                bSpawnEnnemiRight = !bSpawnEnnemiRight;

                PictureBox pbxEnnemi = new PictureBox();
                pbxEnnemi.Size = new Size(60, 60);
                if (bSpawnEnnemiRight == true)
                {
                    pbxEnnemi.Location = new Point(pbxGround.Left - pbxEnnemi.Width, pbxGround.Top - pbxEnnemi.Height);
                }
                else
                {
                    pbxEnnemi.Location = new Point(pbxGround.Right, pbxGround.Top - pbxEnnemi.Height);
                }
                pbxEnnemi.BackColor = Color.DarkRed;
                this.Controls.Add(pbxEnnemi);

                listEnnemi.Add(pbxEnnemi);
                iTimer = 0;
            }
            for (int i = 0; i < listEnnemi.Count; i++)
            {
                if (i % 2 == 0)
                {
                    listEnnemi[i].Left -= 2;
                }
                else
                {
                    listEnnemi[i].Left += 2;
                }
            }
        }
    }
}