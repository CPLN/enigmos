using Cpln.Enigmos.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    /// <summary>
    /// Exemple d'énigme très simple. Seul un texte est affiché.
    /// </summary>
    public class MorpionEnigmaPanel : EnigmaPanel
    {
        // Version : 1.3

        // Variables pour gestion du jeu

        int iPlayer = 0;

        Random rBegin = new Random();

        // Initialisation des divers objets et variables

        Label lblEnigme = new Label();

        PictureBox pbxImage = new PictureBox();
        PictureBox pbxCase1 = new PictureBox();
        PictureBox pbxCase2 = new PictureBox();
        PictureBox pbxCase3 = new PictureBox();
        PictureBox pbxCase4 = new PictureBox();
        PictureBox pbxCase5 = new PictureBox();
        PictureBox pbxCase6 = new PictureBox();
        PictureBox pbxCase7 = new PictureBox();
        PictureBox pbxCase8 = new PictureBox();
        PictureBox pbxCase9 = new PictureBox();

        TableLayoutPanel casesMorpion = new TableLayoutPanel();

        /// <summary>
        /// Constructeur par défaut, génère un texte et l'affiche dans le Panel.
        /// </summary>
        public MorpionEnigmaPanel()
        {
            this.Width = 620;
            lblEnigme.Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);
            lblEnigme.AutoSize = true;
            casesMorpion.Dock = DockStyle.Fill;
            Controls.Add(casesMorpion);

            Start();
        }

        private void Start()
        {
            PictureBox[] tCase = new PictureBox[] { pbxCase1, pbxCase2, pbxCase3, pbxCase4, pbxCase5, pbxCase6, pbxCase7, pbxCase8, pbxCase9 };

            // Activation des cases pictureBox
            for (int iCpt = 0; iCpt < tCase.Length; iCpt++)
            {
                tCase[iCpt].Enabled = true;
            }

            // Création de la mise en page du tableau du jeu
            casesMorpion.ColumnCount = 5;
            casesMorpion.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.5f));
            casesMorpion.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            casesMorpion.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            casesMorpion.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            casesMorpion.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.5f));
            casesMorpion.RowCount = 4;
            casesMorpion.RowStyles.Add(new RowStyle(SizeType.Percent, 0.2f));
            casesMorpion.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            casesMorpion.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            casesMorpion.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            casesMorpion.RowStyles.Add(new RowStyle(SizeType.Percent, 0.2f));

            // Création des événements click
            pbxCase1.Click += new EventHandler(ClickOnCase1);
            pbxCase2.Click += new EventHandler(ClickOnCase2);
            pbxCase3.Click += new EventHandler(ClickOnCase3);
            pbxCase4.Click += new EventHandler(ClickOnCase4);
            pbxCase5.Click += new EventHandler(ClickOnCase5);
            pbxCase6.Click += new EventHandler(ClickOnCase6);
            pbxCase7.Click += new EventHandler(ClickOnCase7);
            pbxCase8.Click += new EventHandler(ClickOnCase8);
            pbxCase9.Click += new EventHandler(ClickOnCase9);

            // Configuration des pictureBox
            for (int iCpt = 0; iCpt < tCase.Length; iCpt++)
            {
                tCase[iCpt].BorderStyle = BorderStyle.FixedSingle;
                tCase[iCpt].Size = new Size(200, 200);
                tCase[iCpt].BackColor = Color.White;
            }

            // Coordonées des objets
            casesMorpion.Controls.Add(pbxCase1, 1, 0);
            casesMorpion.Controls.Add(pbxCase2, 2, 0);
            casesMorpion.Controls.Add(pbxCase3, 3, 0);
            casesMorpion.Controls.Add(pbxCase4, 1, 1);
            casesMorpion.Controls.Add(pbxCase5, 2, 1);
            casesMorpion.Controls.Add(pbxCase6, 3, 1);
            casesMorpion.Controls.Add(pbxCase7, 1, 2);
            casesMorpion.Controls.Add(pbxCase8, 2, 2);
            casesMorpion.Controls.Add(pbxCase9, 3, 2);

            // Joueur qui commence
            //iPlayer = Convert.ToInt32(rBegin.Next(1, 3));
            iPlayer = 1;

            if (iPlayer == 2)
            {
                IA();
            }

            /* Si iPlayer = 1 : Joueur commence et aller à la fonction Player()
             * Joueur à les croix
             *
             * Si iPlayer = 2 : IA commence et aller à la fonction IA()
             * IA à les ronds */
        }

        private void IA_Winning(PictureBox pbx1, PictureBox pbx2, PictureBox pbx3)
        {
            if (iPlayer == 2 && ((pbx1.BackColor == Color.Blue && pbx2.BackColor == Color.Blue) || (pbx2.BackColor == Color.Blue && pbx3.BackColor == Color.Blue) || (pbx1.BackColor == Color.Blue && pbx3.BackColor == Color.Blue)))
            {
                PictureBox[] tPbx = new PictureBox[] { pbx1, pbx2, pbx3 };

                for (int iCpt = 1; iCpt < tPbx.Length; iCpt++)
                {
                    if (tPbx[iCpt].BackColor == Color.White)
                    {
                        tPbx[iCpt].BackColor = Color.Blue;
                        tPbx[iCpt].Enabled = false;
                        Verification();

                        // Changement de joueur
                        iPlayer = 1;
                    }
                }

                //MessageBox.Show("Vérification :\n\nCase 1 = " + Convert.ToString(pbxCase1.BackColor) + "\nCase 2 = " + Convert.ToString(pbxCase2.BackColor) + "\nCase 3 = " + Convert.ToString(pbxCase3.BackColor) + "\nCase 4 = " + Convert.ToString(pbxCase4.BackColor) + "\nCase 5 = " + Convert.ToString(pbxCase5.BackColor) + "\nCase 6 = " + Convert.ToString(pbxCase6.BackColor) + "\nCase 7 = " + Convert.ToString(pbxCase7.BackColor) + "\nCase 8 = " + Convert.ToString(pbxCase8.BackColor) + "\nCase 9 = " + Convert.ToString(pbxCase9.BackColor));
            }
        }

        private void Player_Winning(PictureBox pbx1, PictureBox pbx2, PictureBox pbx3)
        {
            if (iPlayer == 2 && ((pbx1.BackColor == Color.Red && pbx2.BackColor == Color.Red) || (pbx2.BackColor == Color.Red && pbx3.BackColor == Color.Red) || (pbx1.BackColor == Color.Red && pbx3.BackColor == Color.Red)))
            {
                PictureBox[] tPbx = new PictureBox[] { pbx1, pbx2, pbx3 };

                for (int iCpt = 0; iCpt < tPbx.Length; iCpt++)
                {
                    if (tPbx[iCpt].BackColor == Color.White)
                    {
                        tPbx[iCpt].BackColor = Color.Blue;
                        tPbx[iCpt].Enabled = false;
                        Verification();

                        // Changement de joueur
                        iPlayer = 1;
                    }
                }

                //MessageBox.Show("Vérification :\n\nCase 1 = " + Convert.ToString(pbxCase1.BackColor) + "\nCase 2 = " + Convert.ToString(pbxCase2.BackColor) + "\nCase 3 = " + Convert.ToString(pbxCase3.BackColor) + "\nCase 4 = " + Convert.ToString(pbxCase4.BackColor) + "\nCase 5 = " + Convert.ToString(pbxCase5.BackColor) + "\nCase 6 = " + Convert.ToString(pbxCase6.BackColor) + "\nCase 7 = " + Convert.ToString(pbxCase7.BackColor) + "\nCase 8 = " + Convert.ToString(pbxCase8.BackColor) + "\nCase 9 = " + Convert.ToString(pbxCase9.BackColor));
            }
        }

        private void IA()
        {
            // Intelligence artificielle
            // Test si l'ordinateur peut gagner
            IA_Winning(pbxCase1, pbxCase2, pbxCase3);
            IA_Winning(pbxCase4, pbxCase5, pbxCase6);
            IA_Winning(pbxCase7, pbxCase8, pbxCase9);
            IA_Winning(pbxCase1, pbxCase4, pbxCase7);
            IA_Winning(pbxCase2, pbxCase5, pbxCase8);
            IA_Winning(pbxCase3, pbxCase6, pbxCase9);
            IA_Winning(pbxCase1, pbxCase5, pbxCase9);
            IA_Winning(pbxCase3, pbxCase5, pbxCase7);

            // Test si le joueur peut gagner
            Player_Winning(pbxCase1, pbxCase2, pbxCase3);
            Player_Winning(pbxCase4, pbxCase5, pbxCase6);
            Player_Winning(pbxCase7, pbxCase8, pbxCase9);
            Player_Winning(pbxCase1, pbxCase4, pbxCase7);
            Player_Winning(pbxCase2, pbxCase5, pbxCase8);
            Player_Winning(pbxCase3, pbxCase6, pbxCase9);
            Player_Winning(pbxCase1, pbxCase5, pbxCase9);
            Player_Winning(pbxCase3, pbxCase5, pbxCase7);


            if (iPlayer == 2)
            {
                PictureBox[] tBase = new PictureBox[] { pbxCase1, pbxCase2, pbxCase3, pbxCase4, pbxCase5, pbxCase6, pbxCase7, pbxCase8, pbxCase9 };
                List<PictureBox> List_Libre = new List<PictureBox>();

                for (int iCpt = 0; iCpt < tBase.Length; iCpt++)
                {
                    if (tBase[iCpt].BackColor != Color.Blue && tBase[iCpt].BackColor != Color.Red)
                    {
                        List_Libre.Add(tBase[iCpt]);
                    }
                }

                int iNbCaseLibre;
                Random rCaseLibre = new Random();

                iNbCaseLibre = rCaseLibre.Next(0, List_Libre.Count);

                for (int iCpt = 0; iCpt < List_Libre.Count; iCpt++)
                {
                    if (iCpt == iNbCaseLibre)
                    {
                        List_Libre[iCpt].BackColor = Color.Blue;
                        List_Libre[iCpt].Enabled = false;
                        Verification();
                        iPlayer = 1;
                    }
                }

                //MessageBox.Show("Vérification :\n\nCase 1 = " + Convert.ToString(pbxCase1.BackColor) + "\nCase 2 = " + Convert.ToString(pbxCase2.BackColor) + "\nCase 3 = " + Convert.ToString(pbxCase3.BackColor) + "\nCase 4 = " + Convert.ToString(pbxCase4.BackColor) + "\nCase 5 = " + Convert.ToString(pbxCase5.BackColor) + "\nCase 6 = " + Convert.ToString(pbxCase6.BackColor) + "\nCase 7 = " + Convert.ToString(pbxCase7.BackColor) + "\nCase 8 = " + Convert.ToString(pbxCase8.BackColor) + "\nCase 9 = " + Convert.ToString(pbxCase9.BackColor));
            }
        }

        private void ClickOnCase1(object sender, EventArgs e)
        {
            if (pbxCase1.Enabled == true)
            {
                if (iPlayer == 1)
                {
                    pbxCase1.BackColor = Color.Red;

                    pbxCase1.Enabled = false;

                    // Vérifie si la partie est terminée
                    Verification();

                    //Changement de joueur
                    iPlayer = 2;
                    IA();
                }
            }
        }

        private void ClickOnCase2(object sender, EventArgs e)
        {
            if (pbxCase2.Enabled == true)
            {
                if (iPlayer == 1)
                {
                    pbxCase2.BackColor = Color.Red;

                    pbxCase2.Enabled = false;

                    // Vérifie si la partie est terminée
                    Verification();

                    //Changement de joueur
                    iPlayer = 2;
                    IA();
                }
            }
        }

        private void ClickOnCase3(object sender, EventArgs e)
        {
            if (pbxCase3.Enabled == true)
            {
                if (iPlayer == 1)
                {
                    pbxCase3.BackColor = Color.Red;

                    pbxCase3.Enabled = false;

                    // Vérifie si la partie est terminée
                    Verification();

                    //Changement de joueur
                    iPlayer = 2;
                    IA();
                }
            }
        }

        private void ClickOnCase4(object sender, EventArgs e)
        {
            if (pbxCase4.Enabled == true)
            {
                if (iPlayer == 1)
                {
                    pbxCase4.BackColor = Color.Red;

                    pbxCase4.Enabled = false;

                    // Vérifie si la partie est terminée
                    Verification();

                    //Changement de joueur
                    iPlayer = 2;
                    IA();
                }
            }
        }

        private void ClickOnCase5(object sender, EventArgs e)
        {
            if (pbxCase5.Enabled == true)
            {
                if (iPlayer == 1)
                {
                    pbxCase5.BackColor = Color.Red;

                    pbxCase5.Enabled = false;

                    // Vérifie si la partie est terminée
                    Verification();

                    //Changement de joueur
                    iPlayer = 2;
                    IA();
                }
            }
        }

        private void ClickOnCase6(object sender, EventArgs e)
        {
            if (pbxCase6.Enabled == true)
            {
                if (iPlayer == 1)
                {
                    pbxCase6.BackColor = Color.Red;

                    pbxCase6.Enabled = false;

                    // Vérifie si la partie est terminée
                    Verification();

                    //Changement de joueur
                    iPlayer = 2;
                    IA();
                }
            }
        }

        private void ClickOnCase7(object sender, EventArgs e)
        {
            if (pbxCase7.Enabled == true)
            {
                if (iPlayer == 1)
                {
                    pbxCase7.BackColor = Color.Red;

                    pbxCase7.Enabled = false;

                    // Vérifie si la partie est terminée
                    Verification();

                    //Changement de joueur
                    iPlayer = 2;
                    IA();
                }
            }
        }

        private void ClickOnCase8(object sender, EventArgs e)
        {
            if (pbxCase8.Enabled == true)
            {
                if (iPlayer == 1)
                {
                    pbxCase8.BackColor = Color.Red;

                    pbxCase8.Enabled = false;

                    // Vérifie si la partie est terminée
                    Verification();

                    //Changement de joueur
                    iPlayer = 2;
                    IA();
                }
            }
        }

        private void ClickOnCase9(object sender, EventArgs e)
        {
            if (pbxCase9.Enabled == true)
            {
                if (iPlayer == 1)
                {
                    pbxCase9.BackColor = Color.Red;

                    pbxCase9.Enabled = false;

                    // Vérifie si la partie est terminée
                    Verification();

                    //Changement de joueur
                    iPlayer = 2;
                    IA();
                }
            }
        }

        private void End(PictureBox pbx1, PictureBox pbx2, PictureBox pbx3)
        {
            if(iPlayer == 1)
            {
                if(pbx1.BackColor == Color.Red && pbx2.BackColor == Color.Red && pbx3.BackColor == Color.Red)
                {
                    MessageBox.Show("Vous avez gagné !");
                    iPlayer = 1;

                    Start();
                }
                else
                {

                }
            }
            else if (iPlayer == 2)
            {
                if (pbx1.BackColor == Color.Blue && pbx2.BackColor == Color.Blue && pbx3.BackColor == Color.Blue)
                {
                    MessageBox.Show("Vous avez perdu !");
                    iPlayer = 1;

                    Start();
                }
                else
                {
                    
                }
            }

        }

        private void Verification()
        {
            End(pbxCase1, pbxCase2, pbxCase3);
            End(pbxCase4, pbxCase5, pbxCase6);
            End(pbxCase7, pbxCase8, pbxCase9);
            End(pbxCase1, pbxCase4, pbxCase7);
            End(pbxCase2, pbxCase5, pbxCase8);
            End(pbxCase3, pbxCase6, pbxCase9);
            End(pbxCase1, pbxCase5, pbxCase9);
            End(pbxCase3, pbxCase5, pbxCase7);
        }
    }

    enum Couleur
    {
        VIDE, ROUGE, BLEU
    }
}