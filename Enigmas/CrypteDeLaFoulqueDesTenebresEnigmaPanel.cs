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
        private List<Rectangle> ListeDeMurs = new List<Rectangle>();
        private Rectangle RectPlayer;
        private bool bUnlocked = false;
        private Rectangle RectTeleporterInput;
        private Rectangle RectTeleporterOutput;
        private bool bTeleportMessage;
        private Rectangle RectSalleCache;
        private int iTailleDeLaSalleCacheX = 120;
        private int iTailleDeLaSalleCacheY = 80;
        private Rectangle RectFoulque;
        private bool bMessageFoulque = false;
        private bool bSalleSecreteDevrouille = false;
        private Image imgPlayer = Properties.Resources.player_right;
        private int iCoffreWidth=100, iCoffreHeight=100;
        private Rectangle rectCoffre;
        private bool bColision;
        private Rectangle RectClone;

        //Commence quand on affiche le jeu
        /// <summary>
        /// Fonction qui charge tous les elèment decris à l'appel du paneux
        /// </summary>
        public override void Load()
        {
            bUnlocked = false;
            PlayerPositionX = 45;
            bTeleportMessage = false;
            PlayerPositionY = 45;
            bMessageFoulque = false;
            bSalleSecreteDevrouille = false;
            iCoffreWidth = 100;
            iCoffreHeight = 100;
            iTailleDeLaSalleCacheX = 120;
            iTailleDeLaSalleCacheY = 80;

            timer.Start();

            imgPlayer = Properties.Resources.player_left;
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
            Rectangle M14_1 = new Rectangle(600, 180, 60, 160); ListeDeMurs.Add(M14_1);
            Rectangle M14_2 = new Rectangle(660, 180, 80, 120); ListeDeMurs.Add(M14_2);
            Rectangle M14_3 = new Rectangle(740, 180, 60, 120); ListeDeMurs.Add(M14_3);
            Rectangle M14_4 = new Rectangle(780, 300, 20, 40); ListeDeMurs.Add(M14_4);
            Rectangle M15 = new Rectangle(40, 260, 100, 80); ListeDeMurs.Add(M15);
            Rectangle M16 = new Rectangle(60, 360, 100, 80); ListeDeMurs.Add(M16);
            Rectangle M17 = new Rectangle(360, 260, 80, 200); ListeDeMurs.Add(M17);
            Rectangle M18 = new Rectangle(460, 360, 200, 80); ListeDeMurs.Add(M18);
            Rectangle M19_1 = new Rectangle(780, 340, 20, 40); ListeDeMurs.Add(M19_1);
            Rectangle M19_2 = new Rectangle(660, 380, 140, 20); ListeDeMurs.Add(M19_2);
            Rectangle M20 = new Rectangle(40, 460, 660, 40); ListeDeMurs.Add(M20);
            Rectangle M21 = new Rectangle(500, 100, 40, 40); ListeDeMurs.Add(M21);
            Rectangle M22 = new Rectangle(660, 400, 40, 40); ListeDeMurs.Add(M22);
        }
        //Evenement qui se passe quand on passe au prochain paneau ou on finis cet enigme
        public override void Unload()
        {
            timer.Stop();
        }
        /// <summary>
        /// Constructeur du pannel
        /// </summary>
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

        /// <summary>
        /// Teste si le rectangle du joueur a intersecté un rectanglemur et si oui elle definie bColision à true
        /// </summary>
        private void TesteDeColision()
        {
            ListeDeMurs.ForEach(delegate (Rectangle RectangleTeste)
            {
                if (RectClone.IntersectsWith(RectangleTeste))
                {
                    bColision = true;
                }
            });
        }
        /// <summary>
        /// Teste la colision entre le joueur et la case de teleporte
        /// </summary>
        /// <param name="b">nom de variable</param>
        private void testedecolisionTP(string b)
        {
            if (RectPlayer.IntersectsWith(RectTeleporterInput) && bTeleportMessage == false)
            {
                switch(b)
                {
                    case "bToucheW":
                        bToucheW = false;
                        break;
                    case "bToucheS":
                        bToucheS = false;
                        break;
                    case "bToucheA":
                        bToucheA = false;
                        break;
                    case "bToucheD":
                        bToucheD = false;
                        break;
                }
                
                bTeleportMessage = true;
                MessageBox.Show("Vous n'êtes toujours pas béni par la foulque des ténèbres, trouvez où la foulque se cache!", "Teleportation interdite");
            }
        }
        /// <summary>
        /// Timer qui se update chaque 16ms~
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tick(object sender, EventArgs e)
        {
            if (RectPlayer.IntersectsWith(rectCoffre) && bUnlocked == true)
            {
                iCoffreHeight = 0; iCoffreWidth = 0;
            }
            bColision = false;
            if (bToucheD)
            {
                imgPlayer = Properties.Resources.player_right;                
                if (RectPlayer.IntersectsWith(RectFoulque) && bMessageFoulque == false && bTeleportMessage == true)
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
                RectClone = new Rectangle(PlayerPositionX+VitesseDeDeplacement, PlayerPositionY, 10, 10);
                if(RectPlayer.IntersectsWith(RectSalleCache))
                {
                    iTailleDeLaSalleCacheX = 0;
                    iTailleDeLaSalleCacheY = 0;
                    bSalleSecreteDevrouille = true;
                }
                testedecolisionTP("bToucheD");
                TesteDeColision();
                if (bColision==false)
                {
                    PlayerPositionX += VitesseDeDeplacement;
                }           
            }
            if (bToucheA)
            {
                imgPlayer = Properties.Resources.player_left;
                RectClone = new Rectangle(PlayerPositionX-VitesseDeDeplacement, PlayerPositionY, 10, 10);
                testedecolisionTP("bToucheA");
                TesteDeColision();
                if (bColision == false)
                {
                    PlayerPositionX -= VitesseDeDeplacement;
                }
            }
            if (bToucheS)
            {
                imgPlayer = Properties.Resources.player_bot;
                RectClone = new Rectangle(PlayerPositionX, PlayerPositionY+VitesseDeDeplacement, 10, 10);
                testedecolisionTP("bToucheS");
                TesteDeColision();
                if (bColision == false)
                {
                    PlayerPositionY += VitesseDeDeplacement;
                }
            }
            if (bToucheW)
            {
                imgPlayer = Properties.Resources.player_top;
                RectClone = new Rectangle(PlayerPositionX, PlayerPositionY - VitesseDeDeplacement, 10, 10);
                //PlayerPositionY -= VitesseDeDeplacement;
                testedecolisionTP("bToucheW");
                TesteDeColision();
                if (bColision == false)
                {
                    PlayerPositionY -= VitesseDeDeplacement;
                }
            }
            Invalidate();
        }
        /// <summary>
        /// Fonction qui dessine les formes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dessiner(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //Salle caché
            RectSalleCache = new Rectangle(660, 300, iTailleDeLaSalleCacheX, iTailleDeLaSalleCacheY);
            g.FillRectangle(Brushes.Black, RectSalleCache);
            //background
            Image imgDonjon = Properties.Resources.donjon1;            
            if(bSalleSecreteDevrouille==false)
            {
                g.DrawImage(imgDonjon, 0, 0, Width, Height);
            }
            else
            {
                imgDonjon = Properties.Resources.donjon2;
                g.DrawImage(imgDonjon, 0, 0, Width, Height);
                //FOULQUE DES TENEBRES
                RectFoulque = new Rectangle(720, 300, 60, 80);
                Image imgFoulque = Properties.Resources.Coot_transp;
                g.DrawImage(imgFoulque, RectFoulque);
            }
            // Set up string.
            string measureString = "Foulquage";
            Font stringFont = new Font("Arial", 15);
            // Measure string.
            SizeF stringSize = new SizeF();
            stringSize = e.Graphics.MeasureString(measureString, stringFont);
            // Draw string to screen.
            e.Graphics.DrawString(measureString, stringFont, Brushes.White, new PointF(700, 100));
            //coffre
            Image imgCoffre = Properties.Resources.coffre;
            rectCoffre = new Rectangle(700, 80, iCoffreWidth, iCoffreHeight);
            g.DrawImage(imgCoffre, rectCoffre);
            //Position du joueur            
            RectPlayer =new Rectangle(PlayerPositionX, PlayerPositionY, 12, 12);
            g.DrawImage(imgPlayer, RectPlayer);
            //Création de tous les murs
            ListeDeMurs.ForEach(delegate (Rectangle OneWall)
            {
                Image imgsprt = Properties.Resources.mur;
            });
            //Case de teleport
            Image imgTeleporter = Properties.Resources.teleport_transp;
            RectTeleporterInput = new Rectangle(720, 420, 60, 60);
            RectTeleporterOutput = new Rectangle(640, 20, 60, 60);
            g.DrawImage(imgTeleporter, RectTeleporterInput);
            g.DrawImage(imgTeleporter, RectTeleporterOutput);            
        }
        /// <summary>
        /// Event qui se passe quand on presse une touche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void PressKey(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    bToucheD = true;
                    break;
                case Keys.A:
                    bToucheA = true;
                    break;
                case Keys.W:
                    bToucheW = true;
                    break;
                case Keys.S:
                    bToucheS = true;
                    break;
            }
        }
        /// <summary>
        /// Event qui se passe quand on lâche touche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
