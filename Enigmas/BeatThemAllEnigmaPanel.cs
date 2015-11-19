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
    /// Exemple d'énigme très simple. Seul un texte est affiché.
    /// </summary>
    public class BeatThemAllEnigmaPanel : EnigmaPanel
    {
        private Timer Timer = new Timer();

        private PictureBox pbxPlayer = new PictureBox();
        private PictureBox pbxGround = new PictureBox();

        bool bIsRight; 

        /// <summary>
        /// Constructeur par défaut, génère un texte et l'affiche dans le Panel.
        /// </summary>
        public BeatThemAllEnigmaPanel()
        {
            //Modification des paramêtre du panel de base
            Screen myScreen = Screen.PrimaryScreen;
            this.Width = (myScreen.WorkingArea.Width);
            this.Height = (myScreen.WorkingArea.Height)/2;

            //Généréation d'un event keyDown
            KeyDown += new KeyEventHandler(OnKeyDown);

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

            this.Focus();
        }

        private void OnKeyDown(object sender, KeyEventArgs e) 
        {
            if (e.KeyCode == Keys.Right)
            {
                bIsRight = true;
                pbxPlayer.Left += 10;
                Frappe("right");
            }
            if (e.KeyCode == Keys.Left)
            {
                bIsRight = false;
                pbxPlayer.Left -= 10;
                Frappe("left");
            }
            if (e.KeyCode == Keys.Space)
            {

            }
        }

        private void Frappe(string strSensDeLaFrappe)
        {

        }

        private void Timer_Tick(object sender, EventArgs e)
        {

        }
    }
}