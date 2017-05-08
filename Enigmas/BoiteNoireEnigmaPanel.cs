using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    public class BoiteNoireEnigmaPanel : EnigmaPanel
    {
        public void RemplirTableauChiffreAfficher(ref Label[] tChiffreAfficher, double[] tChiffre)
        {
            for (int icpt = 0; icpt < tChiffreAfficher.Length; icpt++)
            {
                tChiffreAfficher[icpt] = new Label();
                tChiffreAfficher[icpt].Text = Convert.ToString(tChiffre[icpt]);
            }
            
        }
        public void AfficherLesChiffres(ref Label[] tChiffreAfficher)
        {
            int iX = 50;
            int iY = 135;

            foreach(Label lblChiffre in tChiffreAfficher)
            {
                lblChiffre.Location = new Point(iX, iY);
                lblChiffre.Size = new Size(50, 50);
                lblChiffre.Font = new Font("Arial", 40);
                Controls.Add(lblChiffre);
                iY = iY + 70;
            }


        }
        public BoiteNoireEnigmaPanel()
        {
            Label[] tChiffreAfficher = new Label[5];
            Label[] tChiffreATrouver = new Label[5];
            double[] tChiffre = new double[] { 9, 2, 5, 9.5, 0 };

            RemplirTableauChiffreAfficher(ref tChiffreAfficher, tChiffre);
            AfficherLesChiffres(ref tChiffreAfficher);
            
            
        }
        
    }
}
