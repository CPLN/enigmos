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
        Panel pnlPictureSolution = new Panel();

        Label lblResult = new Label();

        bool bFin = false;

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
            if (bFin == false)
            {
                pnlPictureFlowers.Location = new Point(550, 80);
                TestResult(OpenDoorImage.FLOWER);
                Timer_OpenDoor();
                bFin = true;
            }
        }
        private void pnlPictureLandscape_Click(object sender, EventArgs e)
        {
            if (bFin == false)
            {
                pnlPictureLandscape.Location = new Point(250, 20);
                TestResult(OpenDoorImage.LANDSCAPE);
                Timer_OpenDoor();
                bFin = true;
            }
        }
        private void Timer_OpenDoor()
        {
            Timer.Interval = 3000; // 3 secondes
            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            Timer.Stop();

            // Ajout de la porte avec la réponse
            pnlPictureSolution.BackgroundImage = Properties.Resources.OpenDoor_Solution;
            pnlPictureSolution.Width = Properties.Resources.OpenDoor_Solution.Width;
            pnlPictureSolution.Height = Properties.Resources.OpenDoor_Solution.Height;
            Controls.Add(pnlPictureSolution);
            pnlPictureSolution.Location = new Point(222, 160);
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