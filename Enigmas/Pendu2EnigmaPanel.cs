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
            PictureBox pbxImagePendu = new PictureBox();
            pbxImagePendu.Image = Properties.Resources.pendu1;
            pbxImagePendu.Size = new Size(350, 350);
            pbxImagePendu.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxImagePendu.Location = new Point(400, 55);
            Controls.Add(pbxImagePendu);
            #endregion
            #region Ajout textbox proposition lettre
            TextBox tbxPropositionLettre = new TextBox();
            tbxPropositionLettre.Font = new Font(tbxPropositionLettre.Font.FontFamily, 25.0F);
            tbxPropositionLettre.MaxLength=1;
            tbxPropositionLettre.Width = 60;
            tbxPropositionLettre.Location = new Point(50, 400);
            Controls.Add(tbxPropositionLettre);
            #endregion
            #region Ajout bouton proposition lettrer
            Button btnProposerLettre = new Button();
            btnProposerLettre.Text = "Proposer lettre";
            btnProposerLettre.Font = new Font(tbxPropositionLettre.Font.FontFamily, 20.0F);
            btnProposerLettre.Size = new Size(240, 46);
            btnProposerLettre.Location = new Point(120, 400);
            Controls.Add(btnProposerLettre);
            #endregion
            #region Ajout label mot
            Label lblMot = new Label();
            lblMot.Font = new Font(lblMot.Font.FontFamily, 25.0F);
            lblMot.Text = "Label";
            lblMot.Location = new Point(100, 400);
            Controls.Add(lblMot);
            #endregion
        }


    }
}
