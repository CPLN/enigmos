using Cpln.Enigmos.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace Cpln.Enigmos.Enigmas
{
    /// <summary>
    /// Exemple d'énigme très simple. Seul un texte est affiché.
    /// </summary>
    public class NfsEnigmaPanel : EnigmaPanel
    {
        // Initialisation des divers objets et variables

        int iX;
        PictureBox pbxVoiture = new PictureBox();
        

        /// <summary>
        /// Constructeur par défaut, génère un texte et l'affiche dans le Panel.
        /// </summary>
        public NfsEnigmaPanel()
        {

            pbxVoiture.BackgroundImage = Properties.Resources.car;
            pbxVoiture.Size = new Size(230, 60);
            pbxVoiture.Location = new Point(1,300);
            iX = pbxVoiture.Left;
            pbxVoiture.Click += new EventHandler(ClickOnCar);
            Controls.Add(pbxVoiture);
      
        }
        private void ClickOnCar(object sender, EventArgs e)
        {
            pbxVoiture.Location = new Point(iX+=10,300);
            Stream str = Properties.Resources._2jzCarSound;
            SoundPlayer snd = new SoundPlayer(str);           
            if(iX >=570)
            {
                snd.Stop();
                MessageBox.Show("eucalyptus");
                pbxVoiture.Enabled = false;
            }
            if(iX==11)
            {
                snd.Play();
            }
                   
        }




 
    }
}