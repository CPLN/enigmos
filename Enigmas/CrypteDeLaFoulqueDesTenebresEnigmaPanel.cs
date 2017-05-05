using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    class CrypteDeLaFoulqueDesTenebresEnigmaPanel : EnigmaPanel
    {
        private int PlayerPositionX=45;
        private int PlayerPositionY=45;
        private int VitesseDeDeplacement=3;
        private Timer timer;
        private bool bToucheA, bToucheS, bToucheD, bToucheW;
        List<Rectangle> ListeDeMurs = new List<Rectangle>();
        Rectangle RectPlayer;
        private bool bUnlocked = false;
        Rectangle RectTeleporterInput;
        Rectangle RectTeleporterOutput;
        private bool bTeleportMessage;
        Rectangle RectSalleCache;
        int iTailleDeLaSalleCacheX = 120;
        int iTailleDeLaSalleCacheY = 80;
        Rectangle RectFoulque;
        bool bMessageFoulque = false;
        //Commence quand on affiche le jeu
        public override void Load()
        {            
            timer.Start();
            Rectangle MBase1 = new Rectangle(-20, 0, 20, 100); ListeDeMurs.Add(MBase1);
            Rectangle MBase2 = new Rectangle(0, -20, 100, 20); ListeDeMurs.Add(MBase2);
            Rectangle MBase3 = new Rectangle(500, -20, 100, 20); ListeDeMurs.Add(MBase3);
            Rectangle MBase4 = new Rectangle(600, -20, 200, 20); ListeDeMurs.Add(MBase4);
            Rectangle MBase5 = new Rectangle(800, 0, 20, 200); ListeDeMurs.Add(MBase5);
            Rectangle MBase6 = new Rectangle(800, 400, 20, 100); ListeDeMurs.Add(MBase6);
            Rectangle MBase7 = new Rectangle(700, 500, 100, 20); ListeDeMurs.Add(MBase7);
            Rectangle M1 = new Rectangle(100, 0, 400, 40); ListeDeMurs.Add(M1);
            Rectangle M2 = new Rectangle(600, 0, 20, 180); ListeDeMurs.Add(M2);
            Rectangle M3 = new Rectangle(100, 60, 40, 40); ListeDeMurs.Add(M3);
            Rectangle M4 = new Rectangle(140, 60, 360, 80); ListeDeMurs.Add(M4);
            Rectangle M5 = new Rectangle(0, 100, 40, 400); ListeDeMurs.Add(M5);
            Rectangle M6 = new Rectangle(60, 100, 80, 140); ListeDeMurs.Add(M6);
            Rectangle M7 = new Rectangle(140, 160, 20, 80); ListeDeMurs.Add(M7);
            Rectangle M8 = new Rectangle(160, 160, 60, 280); ListeDeMurs.Add(M8);
            Rectangle M9 = new Rectangle(240, 160, 100, 280); ListeDeMurs.Add(M9);
            Rectangle M10 = new Rectangle(340, 160, 120, 80); ListeDeMurs.Add(M10);
            Rectangle M11 = new Rectangle(460, 160, 80, 180); ListeDeMurs.Add(M11);
            Rectangle M12 = new Rectangle(560, 100, 40, 240); ListeDeMurs.Add(M12);
            //Rectangle M14 = new Rectangle(600, 180, 200, 160); ListeDeMurs.Add(M14);
            Rectangle M14_1 = new Rectangle(600, 180, 60, 160); ListeDeMurs.Add(M14_1);
            Rectangle M14_2 = new Rectangle(660, 180, 80, 120); ListeDeMurs.Add(M14_2);
            Rectangle M14_3 = new Rectangle(740, 180, 60, 120); ListeDeMurs.Add(M14_3);
            Rectangle M14_4 = new Rectangle(780, 300, 20, 40); ListeDeMurs.Add(M14_4);
            Rectangle M15 = new Rectangle(40, 260, 100, 80); ListeDeMurs.Add(M15);
            Rectangle M16 = new Rectangle(60, 360, 100, 80); ListeDeMurs.Add(M16);
            Rectangle M17 = new Rectangle(360, 260, 80, 200); ListeDeMurs.Add(M17);
            Rectangle M18 = new Rectangle(460, 360, 200, 80); ListeDeMurs.Add(M18);
            //Rectangle M19 = new Rectangle(660, 340, 140, 60); ListeDeMurs.Add(M19);
            Rectangle M19_1 = new Rectangle(780, 340, 20, 40); ListeDeMurs.Add(M19_1);
            Rectangle M19_2 = new Rectangle(660, 380, 140, 20); ListeDeMurs.Add(M19_2);
            Rectangle M20 = new Rectangle(40, 460, 660, 40); ListeDeMurs.Add(M20);
            Rectangle M21 = new Rectangle(500, 100, 40, 40); ListeDeMurs.Add(M21);
            Rectangle M22 = new Rectangle(660, 400, 40, 40); ListeDeMurs.Add(M22);
        }
        //Arrête le jeu
        public override void Unload()
        {
            timer.Stop();
        }

        public CrypteDeLaFoulqueDesTenebresEnigmaPanel()
        {
            Width = 800;
            Height = 500;            

            Paint += new PaintEventHandler(Dessiner);

            timer = new Timer();
            timer.Tick += new EventHandler(Tick);
            timer.Interval = 1000 / 60;
            DoubleBuffered = true;
        }


        private bool ColisionTest(Rectangle R1, bool b)
        {
            ListeDeMurs.ForEach(delegate (Rectangle RectangleTeste)
            {
                if (R1.IntersectsWith(RectangleTeste))
                {
                    b = true;
                }
            });
            return b;
        }
        private void Tick(object sender, EventArgs e)
        {
            bool bColision = false;
            //bToucheA, bToucheS, bToucheD, bToucheW
            if (bToucheD)
            {
                if(RectPlayer.IntersectsWith(RectFoulque) && bMessageFoulque == false)
                {
                    bMessageFoulque = true;
                    MessageBox.Show("Vous m'avez eu? Mince, quelle foulquage! Bon, je vous benis! Prennez le portail!");
                    bToucheD = false;
                    bUnlocked = true;
                }
                if(RectPlayer.IntersectsWith(RectTeleporterInput) && bUnlocked == true)
                {
                    PlayerPositionX = 640;
                    PlayerPositionY = 20;
                }
                Rectangle RectClone = new Rectangle(PlayerPositionX+VitesseDeDeplacement, PlayerPositionY, 10, 10);
                if(RectPlayer.IntersectsWith(RectSalleCache))
                {
                    iTailleDeLaSalleCacheX = 0;
                    iTailleDeLaSalleCacheY = 0;
                }
                if(RectPlayer.IntersectsWith(RectTeleporterInput) && bTeleportMessage == false)
                {
                    bToucheD = false;
                    bTeleportMessage = true;
                    MessageBox.Show("Vous n'êtes toujours pas béni par la foulque des ténèbres, trouvez où la foulque se cache!", "Teleportation interdite");
                }
                if(ColisionTest(RectClone, bColision) == true)
                {
                    bColision = true;
                }
                if(bColision==false)
                {
                    PlayerPositionX += VitesseDeDeplacement;
                }           
            }
            if (bToucheA)
            {
                Rectangle RectClone = new Rectangle(PlayerPositionX-VitesseDeDeplacement, PlayerPositionY, 10, 10);
                if (RectPlayer.IntersectsWith(RectTeleporterInput) && bTeleportMessage == false)
                {
                    bToucheD = false;
                    bTeleportMessage = true;
                    MessageBox.Show("Vous n'êtes toujours pas béni par la foulque des ténèbres, trouvez où la foulque se cache!", "Teleportation interdite");
                }
                if (ColisionTest(RectClone, bColision) == true)
                {
                    bColision = true;
                }
                if (bColision == false)
                {
                    PlayerPositionX -= VitesseDeDeplacement;
                }
            }
            if (bToucheS)
            {
                //PlayerPositionY += VitesseDeDeplacement;
                Rectangle RectClone = new Rectangle(PlayerPositionX, PlayerPositionY+VitesseDeDeplacement, 10, 10);
                if (RectPlayer.IntersectsWith(RectTeleporterInput) && bTeleportMessage == false)
                {
                    bToucheD = false;
                    bTeleportMessage = true;
                    MessageBox.Show("Vous n'êtes toujours pas béni par la foulque des ténèbres, trouvez où la foulque se cache!", "Teleportation interdite");
                }
                if (ColisionTest(RectClone, bColision) == true)
                {
                    bColision = true;
                }
                if (bColision == false)
                {
                    PlayerPositionY += VitesseDeDeplacement;
                }
            }
            if (bToucheW)
            {
                Rectangle RectClone = new Rectangle(PlayerPositionX, PlayerPositionY - VitesseDeDeplacement, 10, 10);
                //PlayerPositionY -= VitesseDeDeplacement;
                if (RectPlayer.IntersectsWith(RectTeleporterInput) && bTeleportMessage == false)
                {
                    bToucheD = false;
                    bTeleportMessage = true;
                    MessageBox.Show("Vous n'êtes toujours pas béni par la foulque des ténèbres, trouvez où la foulque se cache!", "Teleportation interdite");
                }
                if (ColisionTest(RectClone, bColision) == true)
                {
                    bColision = true;
                }
                if (bColision == false)
                {
                    PlayerPositionY -= VitesseDeDeplacement;
                }
            }
            Invalidate();
        }

        private void Dessiner(object sender, PaintEventArgs e)
        {
            /*Width = 800;
            Height = 500;*/
            Graphics g=e.Graphics;

            //Position du joueur            
            RectPlayer=new Rectangle(PlayerPositionX, PlayerPositionY, 10, 10);
            g.DrawRectangle(Pens.Black, RectPlayer);
            //g.DrawRectangle(Pens.Black, PlayerPositionX, PlayerPositionY, 10, 10);

            //Création de tous les murs
            ListeDeMurs.ForEach(delegate (Rectangle OneWall)
            {
                //sg.DrawRectangle(Pens.Black, OneWall);
                g.FillRectangle(Brushes.Black, OneWall);
            });

            //Case de teleport
            Image imgTeleporter = Properties.Resources.teleporter;
            RectTeleporterInput = new Rectangle(720, 420, 60, 60);
            RectTeleporterOutput = new Rectangle(640, 20, 60, 60);
            g.DrawImage(imgTeleporter, RectTeleporterInput);
            g.DrawImage(imgTeleporter, RectTeleporterOutput);

            //FOULQUE DES TENEBRES
            RectFoulque = new Rectangle(720, 300, 60, 80);
            Image imgFoulque = Properties.Resources.Foulque;
            g.DrawImage(imgFoulque, RectFoulque);

            //Salle caché
            RectSalleCache = new Rectangle(660, 300, iTailleDeLaSalleCacheX, iTailleDeLaSalleCacheY);
            g.FillRectangle(Brushes.Black, RectSalleCache);

            

        }
        public override void PressKey(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    bToucheD = true;
                    //PlayerPositionX+=20;
                    break;
                case Keys.A:
                    bToucheA = true;
                    //PlayerPositionX -=20;
                    break;
                case Keys.W:
                    bToucheW = true;
                    //PlayerPositionY -= 20;
                    break;
                case Keys.S:
                    bToucheS = true;
                    //PlayerPositionY += 20;
                    break;
            }
        }
        public override void ReleaseKey(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    bToucheD = false;
                    break;
                case Keys.A:
                    bToucheA = false;
                    break;
                case Keys.W:
                    bToucheW = false;
                    break;
                case Keys.S:
                    bToucheS = false;
                    break;
            }
        }
    }
}
