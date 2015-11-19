using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    public class HazardEnigmaPanel : EnigmaPanel
    {
        public HazardEnigmaPanel()
        {
            Button[] btnReponse = new Button[4];
            for (int i = 0; i < 4; i++)
            {
                btnReponse[i] = new Button();
            }


            btnReponse[0].Location = new Point(0, 0);
            btnReponse[1].Location = new Point(410, 0);
            btnReponse[2].Location = new Point(0, 310);
            btnReponse[3].Location = new Point(410, 310);
            for (int i = 0; i < 4; i++)
            {
                btnReponse[i].Width = 390;
                btnReponse[i].Height = 290;
                btnReponse[i].Text = "Bonne réponse?";
                btnReponse[i].FlatStyle = FlatStyle.System;
                Controls.Add(btnReponse[i]);
            }
        }
    }
}
