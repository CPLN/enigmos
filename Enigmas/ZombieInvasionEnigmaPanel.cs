using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{

    class ZombieInvasionEnigmaPanel : EnigmaPanel
    {
        //déclaration des pricipaux éléments de l'énigme
        PictureBox pbxBackground = new PictureBox();
        PictureBox pbxBatiment = new PictureBox();
        PictureBox pbxCible = new PictureBox();
        PictureBox pbxZombie = new PictureBox();

        //création d'un timer
        private Timer Timer = new Timer();

        public ZombieInvasionEnigmaPanel()
        {
            //Modification des paramêtre du panel de base
            Screen myScreen = Screen.PrimaryScreen;
            this.Width = (myScreen.WorkingArea.Width);
            this.Height = (myScreen.WorkingArea.Height) - 100;

            //Mise en place d'un timer
            Timer.Interval = 1; // 1 milisecondes
            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Start();

            //ajout de l'image
            Controls.Add(pbxCible);

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(Properties.Resources.Cible.GetHicon());//changement de l'iamge du curseur
        }
    }
}
