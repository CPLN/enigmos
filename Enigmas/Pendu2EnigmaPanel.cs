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
        ImagePendu pbxImagePendu = new ImagePendu();
        TextBox tbxPropositionLettre = new TextBox();
        Button btnProposerLettre = new Button();
        Label lblMotCache = new Label();
        Label lblFausseLettre = new Label();
        public Pendu2EnigmaPanel()
        {

            #region Image pendu

            pbxImagePendu.SetImage(1);
            pbxImagePendu.Size = new Size(350, 350);
            pbxImagePendu.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxImagePendu.Location = new Point(400, 55);
            Controls.Add(pbxImagePendu);
            #endregion
            #region Textbox proposition lettre
            
            tbxPropositionLettre.Font = new Font(tbxPropositionLettre.Font.FontFamily, 25.0F);
            tbxPropositionLettre.MaxLength = 1;
            tbxPropositionLettre.Width = 60;
            tbxPropositionLettre.Location = new Point(50, 400);
            Controls.Add(tbxPropositionLettre);
            #endregion
            #region Bouton proposition lettrer
            
            btnProposerLettre.Text = "Proposer lettre";
            btnProposerLettre.Font = new Font(tbxPropositionLettre.Font.FontFamily, 20.0F);
            btnProposerLettre.Size = new Size(240, 46);
            btnProposerLettre.Location = new Point(120, 400);
            btnProposerLettre.Click += new EventHandler(btnProposerLettre_Click);
            Controls.Add(btnProposerLettre);
            #endregion
            #region Label mot
            
            lblMotCache.Font = new Font(lblMotCache.Font.FontFamily, 25.0F);
            lblMotCache.Text = "Label";
            lblMotCache.Height = 40;
            lblMotCache.Width = 250;
            lblMotCache.Location = new Point(120, 200);
            Controls.Add(lblMotCache);
            #endregion
            #region Label fausse lettre
            
            lblFausseLettre.Font = new Font(lblMotCache.Font.FontFamily, 17.0F);
            lblFausseLettre.Text = "Label";
            lblFausseLettre.Height = 40;
            lblFausseLettre.Width = 250;

            lblFausseLettre.Location = new Point(120, 350);
            Controls.Add(lblFausseLettre);
            #endregion
            
        }
        public override void Load()
        {
            NouvellePartie();
        }
        string Mot;
        string MotCache;
        int cptErreur = 0;
        List<string> lettreProposee = new List<string>();
        
        public void NouvellePartie()
        {
            lettreProposee.Clear();
            lblFausseLettre.Text = null;

            cptErreur = 0;
            pbxImagePendu.SetImage(cptErreur);
            
            string resource_data = Properties.Resources.listeMotPendu; //Lecture fichier dans une liste
            List<string> lMot = resource_data.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            Random rdm = new Random();
            
            Mot = lMot[rdm.Next(0, lMot.Count)];



            MotCache = "";
            for (int i = 0; i < Mot.Length; i++)
            {
                MotCache += "*";
            }
            lblMotCache.Text = MotCache;
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            NouvellePartie();
        }

        private void btnProposerLettre_Click(object sender, EventArgs e)
        {
            if (tbxPropositionLettre.Text != "" && !lettreProposee.Contains(tbxPropositionLettre.Text.ToString()))
            {
                bool Erreur = true;
                string NouveauMotCache = "";
                string Proposition = tbxPropositionLettre.Text.ToString();
                for (int i = 0; i < Mot.Length; i++)
                {
                    string lettre = Mot[i].ToString();
                    if (Proposition == lettre && MotCache[i].ToString() == "*")
                    {
                        NouveauMotCache += Proposition;
                        Erreur = false;
                    }
                    else if (MotCache[i].ToString() == "*")
                    {
                        NouveauMotCache += "*";

                    }
                    else
                    {
                        NouveauMotCache += MotCache[i];
                    }
                }
                if (Erreur)
                {
                    cptErreur++;
                    pbxImagePendu.SetImage(cptErreur);
                    lblFausseLettre.Text += Proposition + "  ";
                    
                }
                lettreProposee.Add(Proposition);
                MotCache = NouveauMotCache;
                lblMotCache.Text = MotCache;
                tbxPropositionLettre.Text = "";
                tbxPropositionLettre.Focus();
                if (MotCache == Mot)
                {
                    Gagner();
                }
                if (cptErreur == 8)
                {
                    Perdu();
                }
            }
            tbxPropositionLettre.Text = null;
        }

        
        private void Gagner()
        {
            MessageBox.Show("Vous avez gagné\nLa réponse est marsupilami", "Bravo", MessageBoxButtons.OK);
            btnProposerLettre.Enabled = false;


        }
        private void Perdu()
        {
            MessageBox.Show("Vous avez perdu, le vrai mot étai " + Mot + "\nRecommencez !", "Mince", MessageBoxButtons.OK);
            NouvellePartie();


        }


    }
}
