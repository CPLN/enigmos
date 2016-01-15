using Cpln.Enigmos.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    /// <summary>
    /// Enigme du Morpion - version 2.1 (finale)
    /// </summary>
    public class MorpionEnigmaPanel : EnigmaPanel
    {
        // Variables pour gestion du jeu
        int iPlayer = 0;
        int iScore = 0;

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

        List<PictureBox> lCases = new List<PictureBox>();

        public MorpionEnigmaPanel()
        {
            // Paramètresde mise en page de la forme
            this.Width = 620;
            lblEnigme.Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);
            lblEnigme.AutoSize = true;
            casesMorpion.Dock = DockStyle.Fill;
            Controls.Add(casesMorpion);

            // Appelle la méthode pour ajouter les PictureBox dans la liste
            addInList(pbxCase1);
            addInList(pbxCase2);
            addInList(pbxCase3);
            addInList(pbxCase4);
            addInList(pbxCase5);
            addInList(pbxCase6);
            addInList(pbxCase7);
            addInList(pbxCase8);
            addInList(pbxCase9);

            // Appelle la méthode pour démarer l'application
            StartApplication();
        }

        public void addInList(PictureBox pbx)
        {
            // Ajout des PictureBox dans la liste
            lCases.Add(pbx);
        }

        private void StartApplication()
        {
            // Création de la mise en page du tableau du jeu

            // Colonnes :
            casesMorpion.ColumnCount = 5;
            casesMorpion.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.5f));
            casesMorpion.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            casesMorpion.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            casesMorpion.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            casesMorpion.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.5f));

            // Lignes :
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

            // Configuration des PictureBox
            for (int iCpt = 0; iCpt < lCases.Count; iCpt++)
            {
                // Paramètres des cases (PictureBox)
                lCases[iCpt].BorderStyle = BorderStyle.FixedSingle;
                lCases[iCpt].Size = new Size(200, 200);
            }

            // Appelle la méthode pour ajouter les coordonnées des différents PictureBox
            Coordinates(pbxCase1, 1, 0);
            Coordinates(pbxCase2, 2, 0);
            Coordinates(pbxCase3, 3, 0);
            Coordinates(pbxCase4, 1, 1);
            Coordinates(pbxCase5, 2, 1);
            Coordinates(pbxCase6, 3, 1);
            Coordinates(pbxCase7, 1, 2);
            Coordinates(pbxCase8, 2, 2);
            Coordinates(pbxCase9, 3, 2);
        }

        public override void Load()
        {
            // Appelle la méthode pour démarrer le Morpion
            StartGame();
        }

        private void Coordinates(PictureBox pbx, int iC, int iR)
        {
            // Ajout des coordonnées des cases (PicturesBox)
            casesMorpion.Controls.Add(pbx, iC, iR);
        }

        private void StartGame()
        {
            // Activation des cases (PicturesBox)
            for (int iCpt = 0; iCpt < lCases.Count; iCpt++)
            {
                lCases[iCpt].BackColor = Color.White;
                lCases[iCpt].Enabled = true;
            }

            // Défini le joueur qui commence ( 1 = Personne)
            iPlayer = 1;
        }

        private void IA_Winning(PictureBox pbx1, PictureBox pbx2, PictureBox pbx3)
        {
            // Algorythme pour vérifier si l'ordinateur à la possibilité de gagner
            if (iPlayer == 2 && ((pbx1.BackColor == Color.Blue && pbx2.BackColor == Color.Blue) ||
                (pbx2.BackColor == Color.Blue && pbx3.BackColor == Color.Blue) || 
                (pbx1.BackColor == Color.Blue && pbx3.BackColor == Color.Blue)))
            {
                // Création du tableau pour les 3 cases de victoire
                PictureBox[] tPbx = new PictureBox[] { pbx1, pbx2, pbx3 };

                // Le programme cherche quelle case il doit jouer pour gagner
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
            }
        }

        private void Player_Winning(PictureBox pbx1, PictureBox pbx2, PictureBox pbx3)
        {
            // Algorythme pour vérifier si la personne à la possibilité de gagner
            if (iPlayer == 2 && ((pbx1.BackColor == Color.Red && pbx2.BackColor == Color.Red) || 
                (pbx2.BackColor == Color.Red && pbx3.BackColor == Color.Red) || 
                (pbx1.BackColor == Color.Red && pbx3.BackColor == Color.Red)))
            {
                // Création du tableau pour les 3 cases de danger
                PictureBox[] tPbx = new PictureBox[] { pbx1, pbx2, pbx3 };

                // Le programme cherche quelle case il doit jouer pour se défendre
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
            }
        }

        private void IA()
        {
            // Appelle la méthode pour tester si l'ordinateur peut gagner
            IA_Winning(pbxCase1, pbxCase2, pbxCase3);
            IA_Winning(pbxCase4, pbxCase5, pbxCase6);
            IA_Winning(pbxCase7, pbxCase8, pbxCase9);
            IA_Winning(pbxCase1, pbxCase4, pbxCase7);
            IA_Winning(pbxCase2, pbxCase5, pbxCase8);
            IA_Winning(pbxCase3, pbxCase6, pbxCase9);
            IA_Winning(pbxCase1, pbxCase5, pbxCase9);
            IA_Winning(pbxCase3, pbxCase5, pbxCase7);

            // Appelle la méthode pour tester si la personne peut gagner
            Player_Winning(pbxCase1, pbxCase2, pbxCase3);
            Player_Winning(pbxCase4, pbxCase5, pbxCase6);
            Player_Winning(pbxCase7, pbxCase8, pbxCase9);
            Player_Winning(pbxCase1, pbxCase4, pbxCase7);
            Player_Winning(pbxCase2, pbxCase5, pbxCase8);
            Player_Winning(pbxCase3, pbxCase6, pbxCase9);
            Player_Winning(pbxCase1, pbxCase5, pbxCase9);
            Player_Winning(pbxCase3, pbxCase5, pbxCase7);

            // Algorythme pour remplir une case lorsque l'ordinateur n'est pas dans une situation de danger
            if (iPlayer == 2)
            {
                // Création du tableau des cases libres
                List<PictureBox> List_Libre = new List<PictureBox>();

                // Rempli la liste avec les PictureBox des cases vides
                for (int iCpt = 0; iCpt < lCases.Count; iCpt++)
                {
                    if (lCases[iCpt].BackColor != Color.Blue && lCases[iCpt].BackColor != Color.Red)
                    {
                        List_Libre.Add(lCases[iCpt]);
                    }
                }

                int iNbCaseLibre;
                Random rCaseLibre = new Random();

                // Choisi la case à jouer
                iNbCaseLibre = rCaseLibre.Next(0, List_Libre.Count);

                // Algorythme pour remplir la case choisi
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
            }
        }

        private void ClickOnCase1(object sender, EventArgs e)
        {
            // La personne a décidé de jouer la première case
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
            // La personne a décidé de jouer la deuxième case
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
            // La personne a décidé de jouer la troisième case
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
            // La personne a décidé de jouer la quatrième case
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
            // La personne a décidé de jouer la cinquième case
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
            // La personne a décidé de jouer la sixième case
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
            // La personne a décidé de jouer la septième case
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
            // La personne a décidé de jouer la hutième case
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
            // La personne a décidé de jouer la neuvième case
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
            // Algormythme pour tester si quelqu'un va gagner
            if (iPlayer == 1)
            {
                // Le pogramme test si la personne a gagné


                if (pbx1.BackColor == Color.Red && pbx2.BackColor == Color.Red && pbx3.BackColor == Color.Red)
                {
                    MessageBox.Show("Partie terminée\n\nVous avez gagné !");
                    iPlayer = 1;

                    iScore++;

                    DialogResult dlgInfo = MessageBox.Show("Vous avez terminé le jeu\n\nLe mot mystère est : << J'ai gagné >>\n\nVous pouvez passer à l'énigme suivante ou continuer à jouer", "Fin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    // Relance une nouvelle partie
                    StartGame();
                }
                else
                {

                }
            }
            else if(iPlayer == 2)
            {
                // Le programme test si l'ordinateur a gagné
                if (pbx1.BackColor == Color.Blue && pbx2.BackColor == Color.Blue && pbx3.BackColor == Color.Blue)
                {
                    MessageBox.Show("Partie terminée\n\nVous avez perdu !\n\nRevenez plus tard :)");
                    iPlayer = 1;

                    // Relance une nouvelle partie
                    StartGame();
                }
                else
                {

                }
            }

            // Algorythme pour vérifier si toutes les cases ont été utilisées sans que quelqu'un gagne
            int iResultat = 0;

            for (int iCpt = 0; iCpt < 9; iCpt++)
            {
                if (lCases[iCpt].BackColor != Color.White)
                {
                    iResultat++;
                }
            }

            // Message si personne n'a gagné
            if(iResultat == 9)
            {
                MessageBox.Show("Partie terminée\n\nAucun joueur n'a gagné.");

                // Relance le jeu
                StartGame();
            }
        }

        private void Verification()
        {
            // Algorythme pour vérifier si l'ordinateur ne joue qu'une fois s'il commence
            int iIATest = 0;

            for(int iCpt = 0; iCpt < lCases.Count; iCpt++)
            {
                if(lCases[iCpt].BackColor == Color.Blue && 
                    (pbxCase1.BackColor != Color.Red && pbxCase2.BackColor != Color.Red && 
                    pbxCase3.BackColor != Color.Red &&
                    pbxCase4.BackColor != Color.Red && 
                    pbxCase5.BackColor != Color.Red && 
                    pbxCase6.BackColor != Color.Red && 
                    pbxCase7.BackColor != Color.Red &&
                    pbxCase8.BackColor != Color.Red && 
                    pbxCase9.BackColor != Color.Red))
                {
                    iIATest++;
                }
            }

            // Si l'ordinateur a joué plus d'une fois au démarrage, le jeu redémarre
            if(iIATest >= 1)
            {
                // Relance le jeu
                StartGame();
            }
            
            // Appelle la méthode pour vérifier si quelqu'un a gagné
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
}