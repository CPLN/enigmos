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
        /// <summary>
        /// Remplis les labels avec les chiffres de départ et les affiche
        /// </summary>
        /// <param name="tChiffreAfficher">Tableau de labels</param>
        /// <param name="tChiffre">Tableau contenant les chiffres de départ</param>
        public void RemplirTableauChiffreEtAfficher(ref Label[] tChiffreAfficher, double[] tChiffre)
        {
            int iX = 125;
            int iY = 135;
            for (int icpt = 0; icpt < tChiffreAfficher.Length; icpt++)
            {
                tChiffreAfficher[icpt] = new Label();
                tChiffreAfficher[icpt].Text = Convert.ToString(tChiffre[icpt]);
                tChiffreAfficher[icpt].Location = new Point(iX, iY);
                tChiffreAfficher[icpt].Size = new Size(100, 50);
                tChiffreAfficher[icpt].Font = new Font("Arial", 40);
                Controls.Add(tChiffreAfficher[icpt]);
                iY = iY + 70;
            }
        }

        public void AfficherCaseARemplir(ref TextBox[] tChiffreATrouver)
        {
            int iX = 610;
            int iY = 135;
            
            for (int icpt = 0; icpt < tChiffreATrouver.Length; icpt++)
            {
                tChiffreATrouver[icpt] = new TextBox();
                tChiffreATrouver[icpt].Location = new Point(iX, iY);
                tChiffreATrouver[icpt].Size = new Size(80, 50);
                tChiffreATrouver[icpt].Font = new Font("Arial", 40);
                Controls.Add(tChiffreATrouver[icpt]);
                iY = iY + 70;
            }
            tChiffreATrouver[0].Text = "19";
            tChiffreATrouver[1].Text = "5";
            tChiffreATrouver[0].Enabled = false;
            tChiffreATrouver[1].Enabled = false;
        }

        public BoiteNoireEnigmaPanel()
        {
            Label[] tChiffreAfficher = new Label[5];
            TextBox[] tChiffreATrouver = new TextBox[5];    
            double[] tChiffre = new double[] { 9, 2, 5, 9.5, 0 };
            Panel pnlBoiteNoire = new Panel();
            pnlBoiteNoire.Size = new Size(300, 400);
            pnlBoiteNoire.Location = new Point(250, 100);
            pnlBoiteNoire.BackColor = Color.Black;
            Controls.Add(pnlBoiteNoire);

            RemplirTableauChiffreEtAfficher(ref tChiffreAfficher, tChiffre);
            AfficherCaseARemplir(ref tChiffreATrouver);
        }
        
    }
}
