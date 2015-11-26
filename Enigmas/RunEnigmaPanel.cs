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
        Label lblCompteur = new Label();
        int iCompteur = 0;
        Random random = new Random();
        PictureBox pbxHomme = new PictureBox();
        PictureBox pbxCaillou = new PictureBox();
        PictureBox pbxTronc = new PictureBox();
        public RunEnigmaPanel()
        {
            
            
            //Création du joueur
            pbxHomme.Size = new Size(25, 50);
            pbxHomme.BackColor = Color.Red;
            pbxHomme.Location = new Point(400 - pbxHomme.Width / 2,575 - pbxHomme.Height);

            //Appel de l'image de fond
            this.BackgroundImage = Properties.Resources.Fond;

            //timer
            timer.Interval = 1;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();

            //Création des obstacles
            
            pbxCaillou.Size = new Size(50, 50);
            pbxCaillou.BackColor = Color.Gray;
            tblObstacle[0] = pbxCaillou;
            
            pbxTronc.Size = new Size(50, 50);
            pbxTronc.BackColor = Color.Green;
            tblObstacle[1] = pbxTronc;

            //Appel de la fonction pour le placement de l'obstacle
            PlacementObstacle(pbxTronc);
            PlacementObstacle(pbxCaillou);
                   
            //Ajout des éléments
            Controls.Add(pbxHomme);
            Controls.Add(pbxCaillou);
            Controls.Add(pbxTronc);
            Controls.Add(lblCompteur);

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            iCompteur += 1;
            tblObstacle[0].Top += 10;
            tblObstacle[1].Top += 10;
            lblCompteur.Text = Convert.ToString(iCompteur);
            //Condition pour que les obstacles tombent en boucle
            if(tblObstacle[0].Top >= 600 && tblObstacle[1].Top >= 600)
            {
                PlacementObstacle(tblObstacle[0]);
                PlacementObstacle(tblObstacle[1]);
            }

            if(pbxHomme.Top == pbxCaillou.Bottom && pbxHomme.Left == pbxCaillou.Left)
            {
                iCompteur = 0;
            }

            else if (pbxHomme.Top == pbxTronc.Bottom && pbxHomme.Left == pbxTronc.Left)
            {
                iCompteur = 0;
            }

            if(iCompteur==500)
            {
                DialogResult coucou = MessageBox.Show("C'est pas trop tôt","Gagner",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                iCompteur = 0;
                timer.Stop();

                if(coucou==DialogResult.OK)
                {
                     timer.Start();
                }
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
                        pbxObstacle.Left = 188;
                        pbxObstacle.Top = 0 - pbxObstacle.Height;
                    }
                    break;
                case 1:
                    {
                        pbxObstacle.Left = 388;
                        pbxObstacle.Top = 0 - pbxObstacle.Height;
                    }
                    break;
                case 2:
                    {
                        pbxObstacle.Left = 588;
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
                if (pbxHomme.Left + pbxHomme.Width / 2 < 600)
                {
                    pbxHomme.Left += 200;
                }
            }
            if (e.KeyCode == Keys.A)
            {
                if (pbxHomme.Left + pbxHomme.Width / 2 > 200)
                {
                    pbxHomme.Left -= 200;
                }
            }
        }

    }
}
