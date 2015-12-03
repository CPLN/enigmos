using Cpln.Enigmos.Enigmas.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    /// <summary>
    /// Panel affichant une énigme.
    /// </summary>
    public class DingbatEnigmaPanel : EnigmaPanel
    {
        public DingbatEnigmaPanel()
        {
            Random rnd = new Random();
            for(int i = 0; i < 6; i++)
            {
                int x = rnd.Next(1, 700);
                int y = rnd.Next(1, 550);
                Label lblCitronVert = new Label();

                lblCitronVert.Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);
                lblCitronVert.ForeColor = Color.Green;
                lblCitronVert.Location = new Point(x, y);
                lblCitronVert.Text = "Tronc";
                lblCitronVert.AutoSize = false;

                lblCitronVert.Size = TextRenderer.MeasureText(lblCitronVert.Text, lblCitronVert.Font);
                Controls.Add(lblCitronVert);
            }
        }
    }
}
