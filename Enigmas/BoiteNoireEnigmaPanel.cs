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
        //Attributs
        private TextBox[] tTbxChiffreATrouver;
        /// <summary>
        /// Remplis les Labels avec les chiffres de départ et les affiche
        /// </summary>
        /// <param name="tLblChiffreAfficher">Tableau de Labels</param>
        /// <param name="tDblChiffre">Tableau contenant les chiffres de départ</param>
        public void RemplirTableauChiffreEtAfficher(ref Label[] tLblChiffreAfficher, double[] tDblChiffre)
        {
            //Taille des Textbox
            int iX = 125;
            int iY = 135;

            //Création et mise en place des Labels
            for (int icpt = 0; icpt < tLblChiffreAfficher.Length; icpt++)
            {
                tLblChiffreAfficher[icpt] = new Label();
                tLblChiffreAfficher[icpt].Text = Convert.ToString(tDblChiffre[icpt]);
                tLblChiffreAfficher[icpt].Location = new Point(iX, iY);
                tLblChiffreAfficher[icpt].Size = new Size(150, 50);
                tLblChiffreAfficher[icpt].Font = new Font("Arial", 40);
                Controls.Add(tLblChiffreAfficher[icpt]);
                iY = iY + 70;
            }
        }
        /// <summary>
        /// Afficher les Textbox permettant d'écrire les réponses de la boîte noire et remplir les deux premières
        /// </summary>
        /// <param name="tTbxChiffreATrouver">Tableau contenant les chiffres à afficher</param>
        public void AfficherCaseARemplir()
        {
            //Taille des Textbox
            int iX = 610;
            int iY = 135;

            //Création et mise en place des TextBox
            for (int icpt = 0; icpt < tTbxChiffreATrouver.Length; icpt++)
            {
                tTbxChiffreATrouver[icpt] = new TextBox();
                tTbxChiffreATrouver[icpt].Location = new Point(iX, iY);
                tTbxChiffreATrouver[icpt].Size = new Size(100, 50);
                tTbxChiffreATrouver[icpt].Font = new Font("Arial", 40);
                Controls.Add(tTbxChiffreATrouver[icpt]);
                iY = iY + 70;
            }
            //Chiffres préremplis
            tTbxChiffreATrouver[0].Text = "19";
            tTbxChiffreATrouver[1].Text = "5";
            tTbxChiffreATrouver[0].Enabled = false;
            tTbxChiffreATrouver[1].Enabled = false;
        }
        public BoiteNoireEnigmaPanel()
        {
            Label[] tLblChiffreAfficher = new Label[5];
            tTbxChiffreATrouver = new TextBox[5];
            double[] tDblChiffre = new double[] { 9, 2, 5, 9.5, 0 };

            //Paramètres de la boîte noire
            Panel pnlBoiteNoire = new Panel();
            pnlBoiteNoire.Size = new Size(300, 400);
            pnlBoiteNoire.Location = new Point(250, 100);
            pnlBoiteNoire.BackColor = Color.Black;
            Controls.Add(pnlBoiteNoire);

            //Appel des méthodes
            RemplirTableauChiffreEtAfficher(ref tLblChiffreAfficher, tDblChiffre);
            AfficherCaseARemplir();
        }
        public override void Load()
        { 
            for (int icpt = 2; icpt < tTbxChiffreATrouver.Length; icpt++)
            {
                tTbxChiffreATrouver[icpt].Text = "";
            }
        }
    }
}
