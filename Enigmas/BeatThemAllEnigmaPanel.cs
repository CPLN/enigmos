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
        /// <summary>
        /// Constructeur par défaut, génère un texte et l'affiche dans le Panel.
        /// </summary>
        public BeatThemAllEnigmaPanel()
        {
            //Modification des paramêtre du panel de base
            Screen myScreen = Screen.PrimaryScreen;
            this.Width = (myScreen.WorkingArea.Width);
            this.Height = (myScreen.WorkingArea.Height)/2;

            //Mise en place du sol
            PictureBox pbxGround = new PictureBox();
            pbxGround.Size = new Size(this.Width, this.Height/7);
            pbxGround.Location = new Point(this.Width / 2 - pbxGround.Width / 2, this.Bottom - pbxGround.Height);
            pbxGround.BackColor = Color.Red;
            Controls.Add(pbxGround);
 
      /*      //Mise en place d'un timer
            Timer Timer = new Timer();
            Timer.Interval = 1; // 1 milisecondes
            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Start();

            private void Timer_Tick(object sender, EventArgs e)
            {
 
            }*/
        }
    }
}
