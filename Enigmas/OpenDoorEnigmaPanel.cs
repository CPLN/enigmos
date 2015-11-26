using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    class OpenDoorEnigmaPanel : EnigmaPanel
    {
        private Timer Timer = new Timer();

        Panel pnlPictureLandscape = new Panel();
        Panel pnlPictureFlowers = new Panel();

        bool bResult = false;

        public OpenDoorEnigmaPanel()
        {
            // Ajout d'une image et redimension
            this.BackgroundImage = Properties.Resources.OpenDoor;
            this.Width = Properties.Resources.OpenDoor.Width;
            this.Height = Properties.Resources.OpenDoor.Height;

            // Ajout d'un panel avec image des fleurs et redimension
            pnlPictureFlowers.BackgroundImage = Properties.Resources.OpenDoor_Flowers;
            pnlPictureFlowers.Width = Properties.Resources.OpenDoor_Flowers.Width;
            pnlPictureFlowers.Height = Properties.Resources.OpenDoor_Flowers.Height;
            Controls.Add(pnlPictureFlowers);
            pnlPictureFlowers.Location = new Point(550, 175);
            pnlPictureFlowers.Click += new EventHandler(pnlPictureFlowers_Click); // on crée un événement click 

            // Ajout d'un panel avec image paysage et redimension
            pnlPictureLandscape.BackgroundImage = Properties.Resources.OpenDoor_Landscape;
            pnlPictureLandscape.Width = Properties.Resources.OpenDoor_Landscape.Width;
            pnlPictureLandscape.Height = Properties.Resources.OpenDoor_Landscape.Height;
            Controls.Add(pnlPictureLandscape);
            pnlPictureLandscape.Location = new Point(90, 20);
            pnlPictureLandscape.Click += new EventHandler(pnlPictureLandscape_Click); // on crée un événement click 
        }
        private void pnlPictureFlowers_Click(object sender, EventArgs e)
        {
            pnlPictureFlowers.Location = new Point(550, 80);
            TestResult();
            Timer_OpenDoor();
        }
        private void pnlPictureLandscape_Click(object sender, EventArgs e)
        {
            pnlPictureLandscape.Location = new Point(250, 20);
            TestResult();
            Timer_OpenDoor();
        }
        private void Timer_OpenDoor()
        {
            //Mise en place d'un timer
            Timer.Interval = 5000; // 1 milisecondes
            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // replacement initial des différents panels
            pnlPictureLandscape.Location = new Point(90, 20);
            pnlPictureFlowers.Location = new Point(550, 175);
        }
        private void TestResult()
        {
            if (bResult == true)
            {
                /*pnlPictureLandscape.BackgroundImage = Properties.Resources.OpenDoor_Landscape;
                pnlPictureLandscape.Width = Properties.Resources.OpenDoor_Landscape.Width;
                pnlPictureLandscape.Height = Properties.Resources.OpenDoor_Landscape.Height;
                Controls.Add(pnlPictureLandscape);
                pnlPictureLandscape.Location = new Point(90, 20);*/
            }
            else if ()
            {
                Label lblError = new Label();
                lblError.Text = "Bien essayé, dommage :)";
                lblError.Font = new Font(FontFamily.GenericSansSerif, 10);
                Controls.Add(lblError);
                lblError.Location = new Point(550, 175);
                bResult = false;
            }
            else
            {
                Label lblError = new Label();
                lblError.Text = "Bien essayé, dommage :)";
                lblError.Font = new Font(FontFamily.GenericSansSerif, 10);
                Controls.Add(lblError);
                lblError.Location = new Point(550, 175);
                bResult = false;
            }
        }
    }
}
