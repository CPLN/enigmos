using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    class RunEnigmaPanel : EnigmaPanel
    {
        private Timer timer= new Timer();
        public RunEnigmaPanel()
        {
            //Déclaration des variables
            PictureBox[] tblObstacle = new PictureBox[2];
            
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
            pbxCaillou.Location = new Point(400 - pbxCaillou.Width, 75 - pbxCaillou.Height);
            PictureBox pbxTronc = new PictureBox();
            pbxTronc.Size = new Size(75, 50);
            pbxTronc.BackColor = Color.Green;
            pbxTronc.Location = new Point(400 - pbxTronc.Width, 100 - pbxTronc.Height);

            //Tableau
            tblObstacle[0] = pbxCaillou;
            tblObstacle[1] = pbxTronc;
            
            //Ajout des éléments
            Controls.Add(pbxHomme);
            Controls.Add(pbxCaillou);
            Controls.Add(pbxTronc);

        }

        private void Timer_Tick(object sender, EventArgs e)
        {

        }
    }
}
