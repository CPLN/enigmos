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
        

        //Commence quand on affiche le jeu
        public override void Load()
        {            
            timer.Start();
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
            Rectangle M14 = new Rectangle(600, 180, 200, 160); ListeDeMurs.Add(M14);
            Rectangle M15 = new Rectangle(40, 260, 100, 80); ListeDeMurs.Add(M15);
            Rectangle M16 = new Rectangle(0, 0, 0, 0);
            Rectangle M17 = new Rectangle(0, 0, 0, 0);
            Rectangle M18 = new Rectangle(0, 0, 0, 0);
            Rectangle M19 = new Rectangle(0, 0, 0, 0);
            Rectangle M20 = new Rectangle(0, 0, 0, 0);
            Rectangle M21 = new Rectangle(500, 100, 40, 40); ListeDeMurs.Add(M21);
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



        private void Tick(object sender, EventArgs e)
        {
            //bToucheA, bToucheS, bToucheD, bToucheW
            if (bToucheD)
            {
                PlayerPositionX += VitesseDeDeplacement;
            }
            if (bToucheA)
            {
                PlayerPositionX -= VitesseDeDeplacement;
            }
            if (bToucheS)
            {
                PlayerPositionY += VitesseDeDeplacement;
            }
            if (bToucheW)
            {
                PlayerPositionY -= VitesseDeDeplacement;
            }
            Invalidate();
        }

        private void Dessiner(object sender, PaintEventArgs e)
        {
            /*Width = 800;
            Height = 500;*/
            Graphics g = e.Graphics;

            //Position du joueur
            g.DrawRectangle(Pens.Black, PlayerPositionX, PlayerPositionY, 10, 10);

            //Création de tous les murs
            ListeDeMurs.ForEach(delegate (Rectangle OneWall)
            {
                g.DrawRectangle(Pens.Black, OneWall);
            });
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
