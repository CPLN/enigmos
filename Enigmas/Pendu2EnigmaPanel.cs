using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace Cpln.Enigmos.Enigmas
{
    public class Pendu2EnigmaPanel : EnigmaPanel
    {
        public Pendu2EnigmaPanel()
        {
            #region Ajout image pendu
            PictureBox imagePendu = new PictureBox();
            imagePendu.Image = Properties.Resources.pendu1;
            imagePendu.Size = new Size(350, 350);
            imagePendu.SizeMode = PictureBoxSizeMode.StretchImage;
            imagePendu.Location = new Point(400, 55);
            Controls.Add(imagePendu);
            #endregion
            #region Ajout textbox proposition lettre
            TextBox propositionLettre = new TextBox();
            propositionLettre.Font = new Font(propositionLettre.Font.FontFamily, 25.0F);
            propositionLettre.MaxLength=1;
            propositionLettre.Width = 60;
            propositionLettre.Location = new Point(50, 400);
            Controls.Add(propositionLettre);
            #endregion
            #region Ajout bouton proposition lettrer
            Button proposerLettre = new Button();
            proposerLettre.Text = "Proposer lettre";
            proposerLettre.Font = new Font(propositionLettre.Font.FontFamily, 20.0F);
            proposerLettre.Size = new Size(240, 46);
            proposerLettre.Location = new Point(120, 400);
            Controls.Add(proposerLettre);
            #endregion
        }


    }
}
