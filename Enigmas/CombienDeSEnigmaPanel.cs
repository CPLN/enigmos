using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    public class CombienDeSEnigmaPanel : EnigmaPanel
    {
        public CombienDeSEnigmaPanel()
        {
            Label lblEnigmeS = new Label();
            lblEnigmeS.Text = "Quand j'ai deux S on peut me manger quand on en retire un, on ne le peux plus. \nQui suis-je ?";
            lblEnigmeS.TextAlign = ContentAlignment.MiddleCenter;
        } 
    }
}
