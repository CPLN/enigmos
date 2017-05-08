using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    /// <summary>
    /// 
    /// </summary>
    public class CombienDeSEnigmaPanel : EnigmaPanel
    {
        /// <summary>
        /// Crée un label avec le texte de l'énigme écrit dessus
        /// </summary>
        public CombienDeSEnigmaPanel()
        {
            Label lblEnigmeS = new Label();
            lblEnigmeS.Text = "Quand j'ai deux s on peut me manger quand on en retire un, on ne le peux plus. \n\nQui suis-je ?";
            lblEnigmeS.Dock = DockStyle.Fill;
            lblEnigmeS.TextAlign = ContentAlignment.MiddleCenter;
            lblEnigmeS.Font = new Font("Arial", 16);

            Controls.Add(lblEnigmeS);
        } 
    }
}
