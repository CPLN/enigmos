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
        public CompteurEnigmaPanel()
        {
            Button btnStart = new Button();
            Label lblTemps = new Label();

            //Mise en place du boutton et du label
            lblTemps.Size = new Size(200, 200);
            lblTemps.Location = new Point(300, 200);
            lblTemps.BackColor = Color.Red;
            Controls.Add(lblTemps);
            btnStart.Size = new Size(200, 50);
            btnStart.Location = new Point(300, 400);
            btnStart.Font = new Font("Arial", 30);
            btnStart.Text = "Start";
            Controls.Add(btnStart);
        }
    }
}
