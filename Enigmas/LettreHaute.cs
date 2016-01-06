using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    public class LettreHaute : EnigmaPanel
    {
        public LettreHaute()
        {
            Label[] lblArray = new Label[4];

            string[] strArray = new string[4];

            strArray[0] = "Tour Eiffel";
            strArray[1] = "World Trade Center";
            strArray[2] = "Tour de Pise";
            strArray[3] = "Empire State building";

            for (int i = 0; i < strArray.Length; i++)
            {
                lblArray[i] = new Label();
                lblArray[i].Text = strArray[i];
                lblArray[i].Size = 300;
                lblArray[i].Font = new Font("Arial", 16);
                lblArray[i].Top = i * 100 + 150;
                lblArray[i].Left = 350;
                Controls.Add(lblArray[i]);

            }
            
        }
    }
}
