using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    public class CompteurEnigmaPanel:EnigmaPanel
    {
        private Timer tStart = new Timer();
        private Label lblTemps = new Label();
        public CompteurEnigmaPanel()
        {
            Button btnStart = new Button();

            //Mise en place du bouton et du label
            lblTemps.Size = new Size(200, 200);
            lblTemps.Location = new Point(300, 200);
            lblTemps.BackColor = Color.Red;
            lblTemps.Font = new Font("Arial", 30);
            Controls.Add(lblTemps);
            btnStart.Size = new Size(200, 50);
            btnStart.Location = new Point(300, 400);
            btnStart.Font = new Font("Arial", 30);
            btnStart.Text = "Start";
            Controls.Add(btnStart);
            btnStart.Click+=new EventHandler(Debut);
            //Paramètre du Timer
            tStart.Interval=1000;
        }

        /// <summary>
        /// Lancement du compteur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Debut(object sender, EventArgs e)
        {
            tStart.Start();
        }


        public override void PressKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                tStart.Stop();
            }
        }
    }
}
