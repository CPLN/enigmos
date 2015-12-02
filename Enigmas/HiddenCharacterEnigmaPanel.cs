using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    /// <summary>
    /// 
    /// </summary>
    public class HiddenCharacterEnigmalPanel : EnigmaPanel
    {
        /// <summary>
        /// Constructeur par défaut, génère un texte et l'affiche dans le Panel.
        /// </summary>
        public HiddenCharacterEnigmalPanel()
        {
            Label lblHC = new Label();

            lblHC.Text = "CPLN";
            lblHC.Font = new Font(FontFamily.GenericSerif, 30, FontStyle.Bold);
            lblHC.ForeColor = Color.Blue;
            lblHC.Location = new Point(600, 400);
            lblHC.Size = TextRenderer.MeasureText(lblHC.Text, lblHC.Font);
            Controls.Add(lblHC);
            this.MouseHover += new EventHandler(PaintBlue);

        }

        private void PaintBlue(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}