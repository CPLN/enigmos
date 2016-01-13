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
            

            string[] strArray = new string[4];
            
            

            strArray[0] = "Tour Eiffel";
            strArray[1] = "World Trade Center";
            strArray[2] = "Tour de Pise";
            strArray[3] = "Burj Kalifha";

            char[] charArray0 = strArray[0].ToCharArray();
            char[] charArray1 = strArray[1].ToCharArray();
            char[] charArray2 = strArray[2].ToCharArray();
            char[] charArray3 = strArray[3].ToCharArray();

            Label[] lblArray0 = new Label[charArray0.Length];
            Label[] lblArray1 = new Label[charArray1.Length];
            Label[] lblArray2 = new Label[charArray2.Length];
            Label[] lblArray3 = new Label[charArray3.Length];

            //Création des labels 

            CreateEdifice(lblArray0, charArray0, 50, 200);
            CreateEdifice(lblArray1, charArray1, 150, 400);
            CreateEdifice(lblArray2, charArray2, 150, 550);
            CreateEdifice(lblArray3, charArray3, 450, 250);

        }

        private void CreateEdifice(Label[] lbl, char[] chr, int x, int y)
        {
            for (int i = 0, iX = x, iY = y; i < lbl.Length; i++)
            {

                lbl[i] = new Label();
                lbl[i].Text = chr[i].ToString();
                lbl[i].AutoSize = true;
                lbl[i].Font = new Font("Arial", 16);
                lbl[i].Location = new Point(iX, iY);

                iX += 20;
                iY -= 20;

                Controls.Add(lbl[i]);
            }
        }
    }
}
