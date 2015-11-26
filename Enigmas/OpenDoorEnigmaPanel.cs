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

        Label lblResult = new Label();

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
            TestResult(OpenDoorImage.FLOWER);
            Timer_OpenDoor();
        }
        private void pnlPictureLandscape_Click(object sender, EventArgs e)
        {
            pnlPictureLandscape.Location = new Point(250, 20);
            TestResult(OpenDoorImage.LANDSCAPE);
            Timer_OpenDoor();
        }
        private void Timer_OpenDoor()
        {
            //Mise en place d'un timer
            Timer.Interval = 3000; // 5 secondes
            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            /*pnlPictureLandscape.BackgroundImage = null;
            pnlPictureFlowers.BackgroundImage = null;
            this.BackgroundImage = null;
            lblResult.Text = null;*/
            this.BackgroundImage = Properties.Resources.OpenDoor_Solution;
            this.Width = Properties.Resources.OpenDoor.Width;
            this.Height = Properties.Resources.OpenDoor.Height;
        }
        private void Result()
        {
            lblResult.Text = "Bien Joué";
            lblResult.Font = new Font(FontFamily.GenericSansSerif, 10);
            Controls.Add(lblResult);
            this.BackColor = Color.FromArgb(153, 217, 234);

        }
        private void TestResult(OpenDoorImage image)
        {
            if (image == OpenDoorImage.LANDSCAPE)
            {
                Result();
                lblResult.Location = new Point(150, 40);
            }
            else
            {
                Result();
                lblResult.Location = new Point(570, 370);
            }
        }
    }
    enum OpenDoorImage
    {
        FLOWER, LANDSCAPE
    }
}