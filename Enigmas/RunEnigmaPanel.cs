using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    class RunEnigmaPanel : EnigmaPanel
    {
        //Déclaration de variable
        private Timer timer= new Timer();
        private PictureBox[] tblObstacle = new PictureBox[2];
        private int iCompteur = 0;
        private Random random = new Random();
        private PictureBox pbxHomme = new PictureBox();
        private PictureBox pbxCaillou = new PictureBox();
        private PictureBox pbxTronc = new PictureBox();
        private bool bInversion = false;

        public RunEnigmaPanel()
        {
            //Création du joueur
            pbxHomme.Size = new Size(57, 56);
            pbxHomme.BackgroundImage = Properties.Resources.kirby2;
            pbxHomme.BackColor = Color.Transparent;
            pbxHomme.Location = new Point(400 - pbxHomme.Width / 2,575 - pbxHomme.Height);

            //Appel de l'image de fond
            this.BackgroundImage = Properties.Resources.Fond;

            //timer
            timer.Interval = 1;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();

            //Création des obstacles
            pbxCaillou.Size = new Size(116, 65);
            pbxCaillou.BackgroundImage = Properties.Resources.Caillou;
            pbxCaillou.BackColor = Color.Transparent;
            tblObstacle[0] = pbxCaillou;
            
            pbxTronc.Size = new Size(100, 112);
            pbxTronc.BackgroundImage = Properties.Resources.Arbre;
            pbxTronc.BackColor = Color.Transparent;
            tblObstacle[1] = pbxTronc;

            //Appel de la fonction pour le placement de l'obstacle
            PlacementObstacle(pbxTronc);
            PlacementObstacle(pbxCaillou);
                   
            //Ajout des éléments
            Controls.Add(pbxHomme);
            Controls.Add(pbxCaillou);
            Controls.Add(pbxTronc);

        }

        //Ceci inverse mon programme avec mon deuxième
        public RunEnigmaPanel(bool bInversion)
            : this()
        {
            this.bInversion = bInversion;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            iCompteur += 1;
            tblObstacle[0].Top += 20;
            tblObstacle[1].Top += 20;

            //Condition pour que les obstacles tombent en boucle
            if(tblObstacle[0].Top >= 600 && tblObstacle[1].Top >= 600)
            {
                PlacementObstacle(tblObstacle[0]);
                PlacementObstacle(tblObstacle[1]);
            }

            //Vérifie si le joueur ne touche pas un obstacle
            if(pbxHomme.Top <= pbxCaillou.Bottom && pbxHomme.Bottom >= pbxCaillou.Top && pbxHomme.Left >= pbxCaillou.Left && pbxHomme.Right <= pbxCaillou.Right)
            {
                iCompteur = 0;
            }

            else if (pbxHomme.Top <= pbxTronc.Bottom && pbxHomme.Bottom >= pbxTronc.Top && pbxHomme.Left >= pbxTronc.Left && pbxHomme.Right <= pbxTronc.Right)
            {
                iCompteur = 0;
            }
            
            // Condition qui vérifie quand est-ce que le joueur gagne la partie
            if(iCompteur==500)
            {
                DialogResult coucou = MessageBox.Show("Réponse : C'est pas trop tôt","Gagner",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                iCompteur = 0;
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
                        pbxObstacle.Left = 145;
                        pbxObstacle.Top = 0 - pbxObstacle.Height;
                    }
                    break;
                case 1:
                    {
                        pbxObstacle.Left = 345;
                        pbxObstacle.Top = 0 - pbxObstacle.Height;
                    }
                    break;
                case 2:
                    {
                        pbxObstacle.Left = 545;
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

        //Déplacement du personnage
        public override void PressKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                if (bInversion == false)
                {
                    //Condition qui empêche le joueur de sortir des pistes
                    pbxHomme.BackgroundImage = Properties.Resources.kirby2;
                    if (pbxHomme.Left + pbxHomme.Width / 2 < 600)
                    {
                        pbxHomme.Left += 200;
                    }
                }
                else if (bInversion)
                {
                    pbxHomme.BackgroundImage = Properties.Resources.kirby3;
                    if (pbxHomme.Left + pbxHomme.Width / 2 > 200)
                    {
                        pbxHomme.Left -= 200;
                    }
                }
            }
            else if (e.KeyCode == Keys.A)
            {
                if (bInversion == false)
                {
                    pbxHomme.BackgroundImage = Properties.Resources.kirby3;
                    if (pbxHomme.Left + pbxHomme.Width / 2 > 200)
                    {
                        pbxHomme.Left -= 200;
                    }
                }
                else if (bInversion)
                {
                    pbxHomme.BackgroundImage = Properties.Resources.kirby2;
                    if (pbxHomme.Left + pbxHomme.Width / 2 < 600)
                    {
                        pbxHomme.Left += 200;
                    }
                }
            }
        }

    }
}
