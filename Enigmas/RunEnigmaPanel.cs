using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    class RunEnigmaPanel : EnigmaPanel
    {
        private Timer timer= new Timer();
        //Déclaration de variable
        PictureBox[] tblObstacle = new PictureBox[2];
        int iCompteur = 0;
        Random random = new Random();
        public RunEnigmaPanel()
        {
            //Création du joueur
            PictureBox pbxHomme = new PictureBox();
            pbxHomme.Size = new Size(25, 50);
            pbxHomme.BackColor = Color.Red;
            pbxHomme.Location = new Point(400 - pbxHomme.Width,575 - pbxHomme.Height);

            //timer
            timer.Interval = 1;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();

            //Création des obstacles
            PictureBox pbxCaillou = new PictureBox();
            pbxCaillou.Size = new Size(50, 50);
            pbxCaillou.BackColor = Color.Gray;
            tblObstacle[0] = pbxCaillou;
            PictureBox pbxTronc = new PictureBox();
            pbxTronc.Size = new Size(75, 50);
            pbxTronc.BackColor = Color.Green;
            tblObstacle[1] = pbxTronc;

            //Appel de la fonction pour le placement de l'obstacle
            PlacementObstacle(pbxTronc);
            PlacementObstacle(pbxCaillou);
       
            //Ajout des éléments
            Controls.Add(pbxHomme);
            Controls.Add(pbxCaillou);
            Controls.Add(pbxTronc);

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            iCompteur += 1;
            tblObstacle[0].Top += 5;
            tblObstacle[1].Top += 5;

            //Condition pour que les obstacles tombent en boucle
            if(tblObstacle[0].Top >= 600 && tblObstacle[1].Top >= 600)
            {
                PlacementObstacle(tblObstacle[0]);
                PlacementObstacle(tblObstacle[1]);
            }
        }

        //Fonction pour placer les obstacles sur les différents chemin 
        private void PlacementObstacle(PictureBox pbxObstacle)
        {
            //random pour qu'il choisisse le chemin aléatoirement
            switch (random.Next(3))
            {
                case 0:
                    {
                        pbxObstacle.Left = 150;
                        pbxObstacle.Top = 0 - pbxObstacle.Height;
                    }
                    break;
                case 1:
                    {
                        pbxObstacle.Left = 300;
                        pbxObstacle.Top = 0 - pbxObstacle.Height;
                    }
                    break;
                case 2:
                    {
                        pbxObstacle.Left = 450;
                        pbxObstacle.Top = 0 - pbxObstacle.Height;
                    }
                    break;
            }
            //Condition pour que les obstacles ne soient jamais à la même place
            if(tblObstacle[0].Left == tblObstacle[1].Left)
            {
                PlacementObstacle(pbxObstacle);
            }
        }
    }
}
