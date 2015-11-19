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


        public ZombieInvasionEnigmaPanel()
        {
            //Modification des paramêtre du panel de base
            Screen myScreen = Screen.PrimaryScreen;
            this.Width = (myScreen.WorkingArea.Width);
            this.Height = (myScreen.WorkingArea.Height) - 100;


            //Test
            pbxCible.Image = Properties.Resources.Cible;
            pbxCible.Width = Properties.Resources.Cible.Width;
            pbxCible.Height = Properties.Resources.Cible.Height;

            Controls.Add(pbxCible);

        }
    }
}
