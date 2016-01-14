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

        // Tableau pour vérification
        int[] tVerification = new int[9] {3, 4, 5, 6, 7, 8, 9, 10, 11};

        /// <summary>
        /// Constructeur par défaut, génère un texte et l'affiche dans le Panel.
        /// </summary>
        public MorpionEnigmaPanel()
        {
            lblEnigme.Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);
            lblEnigme.AutoSize = true;
            casesMorpion.Dock = DockStyle.Fill;
            Controls.Add(casesMorpion);

            Start();
        }

        private void Start()
        {
            PictureBox[] tCase = new PictureBox[] {pbxCase1, pbxCase2, pbxCase3, pbxCase4, pbxCase5, pbxCase6, pbxCase7, pbxCase8, pbxCase9};

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
            iPlayer = 2;

            if(iPlayer == 2)
            {
                IA();
            }

            /* Si iPlayer = 1 : Joueur commence et aller à la fonction Player()
             * Joueur à les croix
             *
             * Si iPlayer = 2 : IA commence et aller à la fonction IA()
             * IA à les ronds */
        }

        private void IA()
        {
            if(iPlayer == 2 && ((tVerification[0] == tVerification[1]) || (tVerification[0] == tVerification[2]) || (tVerification[1] == tVerification[2])))
            {
                int[] tIA1 = new int[] { tVerification[0], tVerification[1], tVerification[2] };
                PictureBox[] tPbx1 = new PictureBox[] { pbxCase1, pbxCase2, pbxCase3 };

                for(int iCpt = 0; iCpt < tIA1.Length; iCpt++)
                {
                    if(tPbx1[iCpt].BackColor == null)
                    {
                        tPbx1[iCpt].BackColor = Color.Blue;
                        tIA1[iCpt] = 2;

                        // Changement de joueur
                        iPlayer = 1;
                    }
                }
            }
            
            if(iPlayer == 2 && ((tVerification[3] == tVerification[4]) || (tVerification[3] == tVerification[5]) || (tVerification[4] == tVerification[5])))
            {
                int[] tIA2 = new int[] { tVerification[3], tVerification[4], tVerification[5] };
                PictureBox[] tPbx2 = new PictureBox[] {pbxCase4, pbxCase5, pbxCase6};

                for(int iCpt = 0; iCpt < tIA2.Length; iCpt++)
                {
                    if(tPbx2[iCpt].BackColor == null)
                    {
                        tPbx2[iCpt].BackColor = Color.Blue;
                        tIA2[iCpt] = 2;

                        // Changement de joueur
                        iPlayer = 1;
                    }
                }
            }

            if(iPlayer == 2 && ((tVerification[6] == tVerification[7]) || (tVerification[6] == tVerification[8]) || (tVerification[7] == tVerification[8])))
            {
                int[] tIA3 = new int[] { tVerification[3], tVerification[4], tVerification[5] };
                PictureBox[] tPbx3 = new PictureBox[] { pbxCase7, pbxCase8, pbxCase9 };

                for(int iCpt = 0; iCpt < tIA3.Length; iCpt++)
                {
                    if(tPbx3[iCpt].BackColor == null)
                    {
                        tPbx3[iCpt].BackColor = Color.Blue;
                        tIA3[iCpt] = 2;

                        // Changement de joueur
                        iPlayer = 1;
                    }
                }
            }

            if(iPlayer == 2 && ((tVerification[0] == tVerification[3]) || (tVerification[0] == tVerification[6]) || (tVerification[3] == tVerification[6])))
            {
                int[] tIA4 = new int[] { tVerification[0], tVerification[3], tVerification[6] };
                PictureBox[] tPbx4 = new PictureBox[] { pbxCase1, pbxCase4, pbxCase7 };

                for(int iCpt = 0; iCpt < tIA4.Length; iCpt++)
                {
                    if(tPbx4[iCpt].BackColor == null)
                    {
                        tPbx4[iCpt].BackColor = Color.Blue;
                        tIA4[iCpt] = 2;

                        // Changement de joueur
                        iPlayer = 1;
                    }
                }
            }

            if (iPlayer == 2 && ((tVerification[1] == tVerification[4]) || (tVerification[1] == tVerification[7]) || (tVerification[4] == tVerification[7])))
            {
                int[] tIA5 = new int[] { tVerification[1], tVerification[4], tVerification[7] };
                PictureBox[] tPbx5 = new PictureBox[] { pbxCase2, pbxCase5, pbxCase8 };

                for(int iCpt = 0; iCpt < tIA5.Length; iCpt++)
                {
                    if(tPbx5[iCpt].BackColor == null)
                    {
                        tPbx5[iCpt].BackColor = Color.Blue;
                        tIA5[iCpt] = 2;

                        // Changement de joueur
                        iPlayer = 1;
                    }
                }
            }

            if(iPlayer == 2 && ((tVerification[2] == tVerification[5]) || (tVerification[2] == tVerification[8]) || (tVerification[5] == tVerification[8])))
            {
                int[] tIA6 = new int[] { tVerification[2], tVerification[5], tVerification[8] };
                PictureBox[] tPbx6 = new PictureBox[] { pbxCase3, pbxCase6, pbxCase9 };

                for (int iCpt = 0; iCpt < tIA6.Length; iCpt++)
                {
                    if(tPbx6[iCpt].BackColor == null)
                    {
                        tPbx6[iCpt].BackColor = Color.Blue;
                        tIA6[iCpt] = 2;

                        // Changement de joueur
                        iPlayer = 1;
                    }
                }
            }

            if(iPlayer == 2 && ((tVerification[0] == tVerification[4]) || (tVerification[0] == tVerification[8]) || (tVerification[4] == tVerification[8])))
            {
                int[] tIA7 = new int[] { tVerification[0], tVerification[4], tVerification[8] };
                PictureBox[] tPbx7 = new PictureBox[] { pbxCase1, pbxCase5, pbxCase9 };

                for(int iCpt = 0; iCpt < tIA7.Length; iCpt++)
                {
                    if(tPbx7[iCpt].BackColor == null)
                    {
                        tPbx7[iCpt].BackColor = Color.Blue;
                        tIA7[iCpt] = 2;

                        // Changement de joueur
                        iPlayer = 1;
                    }
                }
            }

            if (iPlayer == 2 && ((tVerification[2] == tVerification[4]) || (tVerification[2] == tVerification[6]) || (tVerification[4] == tVerification[6])))
            {
                int[] tIA8 = new int[] { tVerification[2], tVerification[4], tVerification[6] };
                PictureBox[] tPbx8 = new PictureBox[] { pbxCase3, pbxCase5, pbxCase7 };

                for(int iCpt = 0; iCpt < tIA8.Length; iCpt++)
                {
                    if(tPbx8[iCpt].BackColor == null)
                    {
                        tPbx8[iCpt].BackColor = Color.Blue;
                        tIA8[iCpt] = 2;

                        // Changement de joueur
                        iPlayer = 1;
                    }
                }
            }

            else if(iPlayer == 2)
            {
                PictureBox[] tPbx2 = new PictureBox[] { pbxCase1, pbxCase2, pbxCase3, pbxCase4, pbxCase5, pbxCase6, pbxCase7, pbxCase8, pbxCase9 };
                Random r = new Random();
                int iRandom = r.Next(0, 9);

                for (int iCpt = 0; iCpt < tPbx2.Length; iCpt++)
                {
                    if((iRandom == iCpt) && (tVerification[iCpt] != 1) && (tVerification[iCpt] != 2))
                    {
                        tPbx2[iCpt].BackColor = Color.Blue;

                        // Changement de joueur
                        iPlayer = 1;
                    }
                }
            }
        }

        private void ClickOnCase1(object sender, EventArgs e)
        {
            if(pbxCase1.Enabled == true)
            {
                if (iPlayer == 1)
                {
                    pbxCase1.BackColor = Color.Red;
                    tVerification[0] = iPlayer;
                    
                    pbxCase1.Enabled = false;

                    // Vérifie si la partie est terminée
                    End();

                    //Changement de joueur
                    iPlayer = 2;
                    IA();
                }
            }
            else if(pbxCase1.Enabled == false)
            {
                Error();
            }
        }

        private void ClickOnCase2(object sender, EventArgs e)
        {
            if (pbxCase2.Enabled == true)
            {
                if (iPlayer == 1)
                {
                    pbxCase2.BackColor = Color.Red;
                    tVerification[1] = iPlayer;

                    pbxCase2.Enabled = false;

                    // Vérifie si la partie est terminée
                    End();

                    //Changement de joueur
                    iPlayer = 2;
                    IA();
                }
            }
            else if (pbxCase2.Enabled == false)
            {
                Error();
            }
        }

        private void ClickOnCase3(object sender, EventArgs e)
        {
            if (pbxCase3.Enabled == true)
            {
                if (iPlayer == 1)
                {
                    pbxCase3.BackColor = Color.Red;
                    tVerification[2] = iPlayer;

                    pbxCase3.Enabled = false;

                    // Vérifie si la partie est terminée
                    End();

                    //Changement de joueur
                    iPlayer = 2;
                    IA();
                }
            }
            else if (pbxCase3.Enabled == false)
            {
                Error();
            }
        }

        private void ClickOnCase4(object sender, EventArgs e)
        {
            if (pbxCase4.Enabled == true)
            {
                if (iPlayer == 1)
                {
                    pbxCase4.BackColor = Color.Red;
                    tVerification[3] = iPlayer;

                    pbxCase4.Enabled = false;

                    // Vérifie si la partie est terminée
                    End();

                    //Changement de joueur
                    iPlayer = 2;
                    IA();
                }
            }
            else if (pbxCase4.Enabled == false)
            {
                Error();
            }
        }

        private void ClickOnCase5(object sender, EventArgs e)
        {
            if (pbxCase5.Enabled == true)
            {
                if (iPlayer == 1)
                {
                    pbxCase5.BackColor = Color.Red;
                    tVerification[4] = iPlayer;

                    pbxCase5.Enabled = false;

                    // Vérifie si la partie est terminée
                    End();

                    //Changement de joueur
                    iPlayer = 2;
                    IA();
                }
            }
            else if (pbxCase5.Enabled == false)
            {
                Error();
            }
        }

        private void ClickOnCase6(object sender, EventArgs e)
        {
            if (pbxCase6.Enabled == true)
            {
                if (iPlayer == 1)
                {
                    pbxCase6.BackColor = Color.Red;
                    tVerification[5] = iPlayer;

                    pbxCase6.Enabled = false;

                    // Vérifie si la partie est terminée
                    End();

                    //Changement de joueur
                    iPlayer = 2;
                    IA();
                }
            }
            else if (pbxCase6.Enabled == false)
            {
                Error();
            }
        }

        private void ClickOnCase7(object sender, EventArgs e)
        {
            if (pbxCase7.Enabled == true)
            {
                if (iPlayer == 1)
                {
                    pbxCase7.BackColor = Color.Red;
                    tVerification[6] = iPlayer;

                    pbxCase7.Enabled = false;

                    // Vérifie si la partie est terminée
                    End();

                    //Changement de joueur
                    iPlayer = 2;
                    IA();
                }
            }
            else if (pbxCase7.Enabled == false)
            {
                Error();
            }
        }

        private void ClickOnCase8(object sender, EventArgs e)
        {
            if (pbxCase8.Enabled == true)
            {
                if (iPlayer == 1)
                {
                    pbxCase8.BackColor = Color.Red;
                    tVerification[7] = iPlayer;

                    pbxCase8.Enabled = false;

                    // Vérifie si la partie est terminée
                    End();

                    //Changement de joueur
                    iPlayer = 2;
                    IA();
                }
            }
            else if (pbxCase8.Enabled == false)
            {
                Error();
            }
        }

        private void ClickOnCase9(object sender, EventArgs e)
        {
            if (pbxCase9.Enabled == true)
            {
                if (iPlayer == 1)
                {
                    pbxCase9.BackColor = Color.Red;
                    tVerification[8] = iPlayer;

                    pbxCase9.Enabled = false;

                    // Vérifie si la partie est terminée
                    End();

                    //Changement de joueur
                    iPlayer = 2;
                    IA();
                }
            }
            else if (pbxCase9.Enabled == false)
            {
                Error();
            }
        }

        private void End()
        {
            if(tVerification[0] == tVerification[3] && tVerification[0] == tVerification[6])
            {
                MessageBox.Show("Partie terminée [PLAYER] gagne");
            }

            if(tVerification[1] == tVerification[4] && tVerification[1] == tVerification[7])
            {
                MessageBox.Show("Partie terminée [PLAYER] gagne");
            }

            if(tVerification[2] == tVerification[5] && tVerification[2] == tVerification[8])
            {
                MessageBox.Show("Partie terminée [PLAYER] gagne");
            }

            if(tVerification[0] == tVerification[1] && tVerification[0] == tVerification[2])
            {
                MessageBox.Show("Partie terminée [PLAYER] gagne");
            }

            if(tVerification[3] == tVerification[4] && tVerification[3] == tVerification[5])
            {
                MessageBox.Show("Partie terminée [PLAYER] gagne");
            }

            if(tVerification[6] == tVerification[7] && tVerification[6] == tVerification[8])
            {
                MessageBox.Show("Partie terminée [PLAYER] gagne");
            }

            if(tVerification[2] == tVerification[4] && tVerification[2] == tVerification[6])
            {
                MessageBox.Show("Partie terminée [PLAYER] gagne");
            }

            if(tVerification[0] == tVerification[4] && tVerification[0] == tVerification[8])
            {
                MessageBox.Show("Partie terminée [PLAYER] gagne");
            }

            if(iPlayer == 2)
            {
                IA();
            }
        }

        private void Error()
        {
            DialogResult dlgError = MessageBox.Show("Cette case a déjà été utilislée.\n\nMerci d'en utiliser une autre.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}