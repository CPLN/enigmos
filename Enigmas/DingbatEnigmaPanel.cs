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
            for(int i = 0; i < 6; i++)
            {
                Label lblCitronVert = new Label();

                lblCitronVert.Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);
                lblCitronVert.ForeColor = Color.Green;
                lblCitronVert.Dock = DockStyle.Fill;
                lblCitronVert.Location = new Point(0, 0);
                lblCitronVert.Text = "Tronc";
                
                Controls.Add(lblCitronVert);
            }
        }
    }
}
