using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    public class PileOuFaceEnigmaPanel : EnigmaPanel
    {
       public PileOuFaceEnigmaPanel()
            {
                
                Label lblinfo = new Label();
                lblinfo.Text = "Choisi ta combinaison!";           
                lblinfo.Size = new Size(200, 50);
                lblinfo.Font = new Font("Arial", 12);
                lblinfo.Location = new Point(300, 200);
                lblinfo.BackColor = Color.Red;
                lblinfo.TextAlign = ContentAlignment.MiddleCenter;
                    
                

                
                Controls.Add(lblinfo);
            }
    }
}
