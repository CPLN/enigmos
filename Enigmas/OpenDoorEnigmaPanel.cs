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

        private Panel pnlPictureLandscape = new Panel();
        private Panel pnlPictureFlowers = new Panel();
        private Panel pnlPictureAnswer = new Panel();

        private Label lblResult = new Label();

        private bool bEnd = false;
        private bool bClickPictureLandscape = false;
        private bool bClickPictureFlowers = false;

        public OpenDoorEnigmaPanel()
        {
            // Ajout d'une image de fond et redimension
            this.BackgroundImage = Properties.Resources.OpenDoor;
            this.Width = Properties.Resources.OpenDoor.Width;
            this.Height = Properties.Resources.OpenDoor.Height;

            // Ajout d'un panel avec image de fleurs, redimension et placement
            pnlPictureFlowers.BackgroundImage = Properties.Resources.OpenDoor_Flowers;
            pnlPictureFlowers.Width = Properties.Resources.OpenDoor_Flowers.Width;
            pnlPictureFlowers.Height = Properties.Resources.OpenDoor_Flowers.Height;
            Controls.Add(pnlPictureFlowers);
            pnlPictureFlowers.Location = new Point(550, 175);
            pnlPictureFlowers.Click += new EventHandler(pnlPicture_Click); // Création d'un événement click sur l'image

            // Ajout d'un panel avec image paysage et redimension
            pnlPictureLandscape.BackgroundImage = Properties.Resources.OpenDoor_Landscape;
            pnlPictureLandscape.Width = Properties.Resources.OpenDoor_Landscape.Width;
            pnlPictureLandscape.Height = Properties.Resources.OpenDoor_Landscape.Height;
            Controls.Add(pnlPictureLandscape);
            pnlPictureLandscape.Location = new Point(90, 20);
            pnlPictureLandscape.Click += new EventHandler(pnlPicture_Click); // Création d'un événement click sur l'image
        }
        private void pnlPicture_Click(object sender, EventArgs e)
        {
            Point LocationPicture = new Point(0, 0);
            OpenDoorImage image = 0;

            if ((Panel)sender == pnlPictureFlowers)
            {
                LocationPicture = new Point(550, 80);
                bClickPictureFlowers = true;
                image = OpenDoorImage.FLOWER;
            }
            else if ((Panel)sender == pnlPictureLandscape)
            {
                LocationPicture = new Point(260, 20);
                bClickPictureLandscape = true;
                image = OpenDoorImage.LANDSCAPE;
            }

            if (!bEnd && bClickPictureLandscape && bClickPictureFlowers)
            {
                ((Panel)sender).Location = LocationPicture;
                TestResult(image);
                Timer_OpenDoor();
                bEnd = true;
            }
        }
        private void Timer_OpenDoor()
        {
            Timer.Interval = 1000; // 1 seconde
            Timer.Tick += new EventHandler(Timer_Tick); // Création d'un événement pour le timer
            Timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Ajout de la porte avec la réponse
            pnlPictureAnswer.BackgroundImage = Properties.Resources.OpenDoor_Solution;
            pnlPictureAnswer.Width = Properties.Resources.OpenDoor_Solution.Width;
            pnlPictureAnswer.Height = Properties.Resources.OpenDoor_Solution.Height;
            Controls.Add(pnlPictureAnswer);
            pnlPictureAnswer.Location = new Point(222, 160);
        }
        private void Result()
        {
            lblResult.Text = "Bien Joué";
            lblResult.Font = new Font(FontFamily.GenericSansSerif, 15); // Modification de la police et de la taille
            Controls.Add(lblResult);
            this.BackColor = Color.FromArgb(153, 217, 234);
        }
        private void TestResult(OpenDoorImage image)
        {
            if (image == OpenDoorImage.LANDSCAPE)
            {
                lblResult.Location = new Point(150, 40);
            }
            else
            {
                lblResult.Location = new Point(570, 370);
            }

            Result();
        }
    }
    enum OpenDoorImage
    {
        FLOWER, LANDSCAPE
    }
}