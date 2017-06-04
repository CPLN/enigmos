using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    /// <summary>
    /// Classe du jeu "PileOuFace"
    /// </summary>
    public class PileOuFaceEnigmaPanel : EnigmaPanel
    {
        //Déclaration des objets et des variables
        #region Déclaration ..
        private static Random r1 = new Random();
        private PictureBox pbxGif = new PictureBox();
        private Timer t1 = new Timer();
        private ListBox lbxCombi = new ListBox();
        private ListBox lbxCombi2 = new ListBox();
        private List<string> _lstCombi = new List<string>();
        private List<string> _lstCombi2 = new List<string>();
        private Button btnPile = new Button();
        private Button btnFace = new Button();
        private Button btnLanceSuite = new Button();
        private Button btnRepGauche = new Button();
        private Button btnRepDroite = new Button();
        private Button btnRecommencer = new Button();
        private Button btnRepFinal = new Button();
        private Button btnJeu = new Button();
        private Label lblInfo = new Label();
        private Label lblReponsefinal = new Label();
        private Label lblReponseGauche = new Label();
        private Label lblReponseDroite = new Label();
        private Label lblJoueur1 = new Label();
        private Label lblFauxJoueur2 = new Label();
        private Label lblResultat = new Label();
        private System.Drawing.SolidBrush myBrushFaux = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
        private System.Drawing.SolidBrush myBrushVrai = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
        private System.Drawing.Graphics formGraphics;
        private int iLancement = 0;
        private int iNbrReponseJuste = 0;
        private int iFinDuJeu = 0;
        #endregion
        /// <summary>
        /// Constructeur: Instanciation des valeurs par défault et ajout des différents controls
        /// </summary>
        public PileOuFaceEnigmaPanel()
        {
            #region Instanciation des valeurs par défault
            r1 = new Random();
            formGraphics = this.CreateGraphics();

            lbxCombi.Size = new Size(200, 50);
            lbxCombi.Location = new Point(300, 400);
            lbxCombi.Name = "lbxCombi";
            lbxCombi.Font = new Font("Arial", 9);

            lbxCombi2.Size = new Size(200, 50);
            lbxCombi2.Location = new Point(580, 60);
            lbxCombi2.Name = "lbxCombi2";
            lbxCombi2.Font = new Font("Arial", 9);
            lbxCombi2.Visible = false;

            t1.Interval = 1500;
            t1.Enabled = false;
            t1.Tick += new System.EventHandler(t1_tick);

            pbxGif.Image = Properties.Resources.Pileouface;
            pbxGif.Size = pbxGif.Image.Size;
            pbxGif.Location = new Point(350, 200);
            pbxGif.Visible = false;
            pbxGif.Enabled = false;

            lblInfo.Text = "Choisi ta combinaison!";
            lblInfo.Name = "lblinfo";
            lblInfo.Size = new Size(220, 50);
            lblInfo.Font = new Font("Arial", 12);
            lblInfo.Location = new Point(290, 200);
            lblInfo.BackColor = Color.DarkGray;
            lblInfo.TextAlign = ContentAlignment.MiddleCenter;
            lblInfo.BorderStyle = BorderStyle.FixedSingle;

            lblJoueur1.Text = " \" Toi \"";
            lblJoueur1.Name = "lblJoueur1";
            lblJoueur1.Size = new Size(180, 35);
            lblJoueur1.Font = new Font("Arial", 10);
            lblJoueur1.Location = new Point(30, 20);
            lblJoueur1.Visible = false;
            lblJoueur1.TextAlign = ContentAlignment.MiddleCenter;
            lblJoueur1.BackColor = Color.DarkGray;
            lblJoueur1.BorderStyle = BorderStyle.FixedSingle;

            lblFauxJoueur2.Text = "\" Quelqu'un de fort à ce jeu \"";
            lblFauxJoueur2.Name = "lblJoueur1";
            lblFauxJoueur2.Size = new Size(180, 35);
            lblFauxJoueur2.Font = new Font("Arial", 10);
            lblFauxJoueur2.Location = new Point(590, 20);
            lblFauxJoueur2.Visible = false;
            lblFauxJoueur2.TextAlign = ContentAlignment.MiddleCenter;
            lblFauxJoueur2.BackColor = Color.DarkGray;
            lblFauxJoueur2.BorderStyle = BorderStyle.FixedSingle;

            lblResultat.Text = "Résultat:";
            lblResultat.Name = "lblJoueur1";
            lblResultat.Size = new Size(100, 50);
            lblResultat.Font = new Font("Arial", 10);
            lblResultat.Location = new Point(150, 450);
            lblResultat.Visible = false;
            lblResultat.TextAlign = ContentAlignment.MiddleCenter;
            lblResultat.BackColor = Color.DarkGray;
            lblResultat.BorderStyle = BorderStyle.FixedSingle;
            lblResultat.Visible = false;

            lblReponsefinal.Text = "Victoire !\nMais tu as certainement triché...\nVoila la réponse...\"Pile poil\"";
            lblReponsefinal.Name = "lblReponseFinal";
            lblReponsefinal.Size = new Size(350, 200);
            lblReponsefinal.Font = new Font("Arial", 16);
            lblReponsefinal.Location = new Point(230, 200);
            lblReponsefinal.TextAlign = ContentAlignment.MiddleCenter;
            lblReponsefinal.Visible = false;

            lblReponseGauche.Text = "Bien joué \nMais il te manque encore l'autre mot!!!!!\nPremier mot :Pile";
            lblReponseGauche.Name = "lblReponseGauche";
            lblReponseGauche.Size = new Size(350, 200);
            lblReponseGauche.Font = new Font("Arial", 16);
            lblReponseGauche.Location = new Point(230, 200);
            lblReponseGauche.TextAlign = ContentAlignment.MiddleCenter;
            lblReponseGauche.Visible = false;

            lblReponseDroite.Text = "Bien joué \nMais il te manque encore l'autre mot!!!!!\nDeuxième mot :Poil";
            lblReponseDroite.Name = "lblReponseGauche";
            lblReponseDroite.Size = new Size(350, 200);
            lblReponseDroite.Font = new Font("Arial", 16);
            lblReponseDroite.Location = new Point(230, 200);
            lblReponseDroite.TextAlign = ContentAlignment.MiddleCenter;
            lblReponseDroite.Visible = false;

            btnPile.Text = "Pile";
            btnPile.Name = "btnPile";
            btnPile.Font = new Font("Arial", 12);
            btnPile.Size = new Size(100, 50);
            btnPile.Location = new Point(200, 400);
            btnPile.TextAlign = ContentAlignment.MiddleCenter;
            btnPile.Click += new System.EventHandler(btnPile_click);

            btnLanceSuite.Text = "C'est parti!";
            btnLanceSuite.Name = "btnLanceSuite";
            btnLanceSuite.Font = new Font("Arial", 12);
            btnLanceSuite.Size = new Size(100, 50);
            btnLanceSuite.Location = new Point(340, 300);
            btnLanceSuite.BackColor = Color.DarkGray;
            btnLanceSuite.TextAlign = ContentAlignment.MiddleCenter;
            btnLanceSuite.Click += new System.EventHandler(btnLanceSuite_Click);
            btnLanceSuite.Enabled = false;
            btnLanceSuite.Visible = false;

            btnJeu.Text = "Suite";
            btnJeu.Name = "btnJeu";
            btnJeu.Font = new Font("Arial", 12);
            btnJeu.Size = new Size(100, 50);
            btnJeu.Location = new Point(350, 350);
            btnJeu.BackColor = Color.Gray;
            btnJeu.TextAlign = ContentAlignment.MiddleCenter;
            btnJeu.Click += new System.EventHandler(btnJeu_click);
            btnJeu.Enabled = false;
            btnJeu.Visible = false;

            btnRepGauche.Text = "Réponse 1";
            btnRepGauche.Name = "btnRepGauche";
            btnRepGauche.Font = new Font("Arial", 12);
            btnRepGauche.Size = new Size(100, 50);
            btnRepGauche.Location = new Point(200, 500);
            btnRepGauche.TextAlign = ContentAlignment.MiddleCenter;
            btnRepGauche.Click += new System.EventHandler(btnRepGauche_click);
            btnRepGauche.Visible = false;
            btnRepGauche.Enabled = false;

            btnRepDroite.Text = "Réponse 2";
            btnRepDroite.Name = "btnRepDroite";
            btnRepDroite.Font = new Font("Arial", 12);
            btnRepDroite.Size = new Size(100, 50);
            btnRepDroite.Location = new Point(500, 500);
            btnRepDroite.TextAlign = ContentAlignment.MiddleCenter;
            btnRepDroite.Click += new System.EventHandler(btnRepDroite_click);
            btnRepDroite.Visible = false;
            btnRepDroite.Enabled = false;

            btnRecommencer.Text = "Recommencer";
            btnRecommencer.Name = "btnRecommencer";
            btnRecommencer.Font = new Font("Arial", 12);
            btnRecommencer.Size = new Size(150, 50);
            btnRecommencer.Location = new Point(325, 500);
            btnRecommencer.TextAlign = ContentAlignment.MiddleCenter;
            btnRecommencer.Click += new System.EventHandler(btnRecommencer_click);
            btnRecommencer.Enabled = false;
            btnRecommencer.Visible = false;

            btnRepFinal.Text = "Réponse final";
            btnRepFinal.Name = "btnRepFinal";
            btnRepFinal.Font = new Font("Arial", 12);
            btnRepFinal.Size = new Size(150, 50);
            btnRepFinal.Location = new Point(325, 500);
            btnRepFinal.TextAlign = ContentAlignment.MiddleCenter;
            btnRepFinal.Click += new System.EventHandler(btnRepFinal_click);
            btnRepFinal.Enabled = false;
            btnRepFinal.Visible = false;

            btnFace.Text = "Face";
            btnFace.Name = "btnFace";
            btnFace.Font = new Font("Arial", 12);
            btnFace.Size = new Size(100, 50);
            btnFace.Location = new Point(500, 400);
            btnFace.TextAlign = ContentAlignment.MiddleCenter;
            btnFace.Click += new System.EventHandler(btnFace_click);
            #endregion
            #region Ajout des différents controls                   
            Controls.Add(lblReponseGauche);
            Controls.Add(lblReponsefinal);
            Controls.Add(lblReponseDroite);
            Controls.Add(lblJoueur1);
            Controls.Add(lblFauxJoueur2);
            Controls.Add(lblResultat);
            Controls.Add(btnRecommencer);
            Controls.Add(btnRepFinal);
            Controls.Add(btnRepDroite);
            Controls.Add(btnRepGauche);
            Controls.Add(btnPile);
            Controls.Add(btnFace);
            Controls.Add(lblInfo);
            Controls.Add(lbxCombi);
            Controls.Add(lbxCombi2);
            Controls.Add(btnLanceSuite);
            Controls.Add(btnJeu);
            Controls.Add(pbxGif);
            #endregion
        }
        /// <summary>
        /// Lors du chargement, on réinisialise avec les valeurs par défaut.
        /// </summary>
        public override void Load()
        {
            #region Réinitalisation des valeurs
            //Réinitalisation avec les valeurs par défaut
            pbxGif.Visible = false;
            formGraphics.Clear(Color.White);
            _lstCombi.Clear();
            _lstCombi2.Clear();
            iFinDuJeu = 0;
            iLancement = 0;
            iNbrReponseJuste = 0;
            btnFace.Visible = true;
            btnFace.Enabled = true;
            btnPile.Visible = true;
            btnPile.Enabled = true;
            lblReponseDroite.Visible = false;
            lblReponseGauche.Visible = false;
            lblFauxJoueur2.Visible = false;
            lblResultat.Visible = false;
            lblJoueur1.Visible = false;
            lblInfo.Visible = true;
            lblInfo.Text = "Choisi ta combinaison!";
            btnRepGauche.Visible = false;
            btnRepDroite.Visible = false;
            btnRecommencer.Visible = false;
            btnJeu.Visible = false;
            lbxCombi.Visible = true;
            lbxCombi.Location = new Point(300, 400);
            lbxCombi.DataSource = null;
            lbxCombi.DataSource = _lstCombi;
            lbxCombi2.Visible = false;
            lbxCombi2.DataSource = null;
            lbxCombi2.DataSource = _lstCombi2;
            #endregion
        }
        /// <summary>
        /// Cette méthode fait appelle la méthode load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecommencer_click(object sender, EventArgs e)
        {
            Load();
        }
        /// <summary>
        /// Affiche la réponse à l'énigme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRepFinal_click(object sender, EventArgs e)
        {
            lblReponsefinal.Visible = true;
            btnRecommencer.Visible = false;
            btnRecommencer.Enabled = false;
        }
        /// <summary>
        /// Affiche la moitié de la réponse à l'énigme ainsi que le moyen de recommencer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRepDroite_click(object sender, EventArgs e)
        {
            lblReponseDroite.Visible = true;
            btnRecommencer.Visible = true;
            btnRecommencer.Enabled = true;
            btnRepGauche.Enabled = false;
        }
        /// <summary>
        /// Affiche la moitié de la réponse à l'énigme ainsi que le moyen de recommencer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRepGauche_click(object sender, EventArgs e)
        {
            lblReponseGauche.Visible = true;
            btnRecommencer.Visible = true;
            btnRecommencer.Enabled = true;
            btnRepDroite.Enabled = false;
        }
        /// <summary>
        /// Affiche le gif et démarre le timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnJeu_click(object sender, EventArgs e)
        {
            t1.Enabled = true;
            btnJeu.Enabled = false;
            pbxGif.Enabled = true;
        }
        /// <summary>
        /// Mise à jour de l'interface si le combinaison est correcte ou non et s'occupe du gif
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void t1_tick(object sender, EventArgs e)
        {
            iFinDuJeu++;
            pbxGif.Enabled = false;
            t1.Enabled = false;
            lblResultat.Visible = true;
            btnJeu.Enabled = true;
            btnJeu.Visible = true;
            //Génére un string aléatoire
            string strRandomChoix = ChoixRandom();
            //Contrôle si l'élément séléctionné de la combinaison est gagnant ou perdant
            bool bTest = TestChoixRandom(strRandomChoix);
            //Pour chaqu'un des éléments de la combinaison dessine un carrée (vert si juste et rouge si faux)
            #region Dessin des différents carrées en fonction de l'élément de la combinaison
            switch (iFinDuJeu)
            {
                case 1:
                    if (bTest)
                    {
                        formGraphics.FillRectangle(myBrushVrai, new Rectangle(315, 450, 50, 50));
                        iNbrReponseJuste++;
                    }
                    else
                    {
                        formGraphics.FillRectangle(myBrushFaux, new Rectangle(315, 450, 50, 50));
                    }
                    break;
                case 2:
                    if (bTest)
                    {
                        formGraphics.FillRectangle(myBrushVrai, new Rectangle(375, 450, 50, 50));
                        iNbrReponseJuste++;
                    }
                    else
                    {
                        formGraphics.FillRectangle(myBrushFaux, new Rectangle(375, 450, 50, 50));
                    }
                    break;
                case 3:
                    if (bTest)
                    {
                        formGraphics.FillRectangle(myBrushVrai, new Rectangle(435, 450, 50, 50));
                        iNbrReponseJuste++;
                    }
                    else
                    {
                        formGraphics.FillRectangle(myBrushFaux, new Rectangle(435, 450, 50, 50));
                    }
                    break;
                default:
                    break;
                    #endregion
            }
            //Mise à jour des éléments sélectionnés dans les listbox
            SelectChamps();
            /*Contrôle la combinaison a été entièrement tester
             et si c'est le cas , Met à jour les différents boutons de fin*/
            if (TestBonNombre(iFinDuJeu))
            {
                btnJeu.Enabled = false;
                if (iNbrReponseJuste < 2)
                {
                    btnRecommencer.Visible = true;
                    btnRecommencer.Enabled = true;
                }
                else if (iNbrReponseJuste == 2)
                {
                    btnRepDroite.Visible = true;
                    btnRepDroite.Enabled = true;
                    btnRepGauche.Visible = true;
                    btnRepGauche.Enabled = true;
                }
                else
                {
                    btnRepFinal.Visible = true;
                    btnRepFinal.Enabled = true;
                }
            }
        }
        /// <summary>
        /// Mise à jour de l'interface après la fin de la sélection de la combinaison
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnLanceSuite_Click(object sender, EventArgs e)
        {
            btnFace.Visible = false;
            btnPile.Visible = false;
            btnLanceSuite.Enabled = false;
            btnLanceSuite.Visible = false;
            lbxCombi.Location = new Point(20, 60);
            lblInfo.Visible = false;
            lbxCombi.Font = new Font("Arial", 9);
            lbxCombi2.Visible = true;
            lbxCombi2.DataSource = null;
            lbxCombi2.DataSource = _lstCombi2;
            lbxCombi.SelectedIndex = 0;
            lbxCombi2.SelectedIndex = 0;
            pbxGif.Visible = true;
            pbxGif.Enabled = true;
            t1.Enabled = true;
            lbxCombi.SelectedIndex = 0;
            lblFauxJoueur2.Visible = true;
            lblJoueur1.Visible = true;
        }
        /// <summary>
        /// Contrôle si la combinaison est pleine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnPile_click(object sender, EventArgs e)
        {
            //Mise à jour des listes
            DataListbox("Pile");
            iLancement++;
            //Contrôle si la combinaison est pleine
            if (TestBonNombre(iLancement))
            {
                //Mise à jour de l'interface un fois la combinaison pleine
                AfficheBtnLance();
            }
        }
        /// <summary>
        /// Ajoute dans la liste et contrôle si la combinaison est pleine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnFace_click(object sender, EventArgs e)
        {
            //Mise à jour des listes
            DataListbox("Face");
            iLancement++;
            //Contrôle si la combinaison est pleine
            if (TestBonNombre(iLancement))
            {
                //Mise à jour de l'interface un fois la combinaison pleine
                AfficheBtnLance();
            }
        }
        /// <summary>
        /// Mise à jour de l'interface une fois la combinaison rempli
        /// </summary>
        public void AfficheBtnLance()
        {
            btnFace.Enabled = false;
            btnPile.Enabled = false;
            btnLanceSuite.Visible = true;
            btnLanceSuite.Enabled = true;
            lblInfo.Text = "Ta combinaison est validé,\nje prendrai donc l'inverse.\nC'est Parti!";
            lblInfo.Size = new Size(220, 75);
        }
        /// <summary>
        /// Mise à jour des données des listes
        /// </summary>
        /// <param name="strChoix"></param>
        public void DataListbox(string strChoix)
        {
            if (strChoix == "Pile")
            {
                _lstCombi.Add(strChoix);
                _lstCombi2.Add("Face");
            }
            else
            {
                _lstCombi.Add(strChoix);
                _lstCombi2.Add("Pile");
            }

            lbxCombi.DataSource = null;
            lbxCombi.DataSource = _lstCombi;
        }
        /// <summary>
        /// Permet de contrôler si la liste est pleine et si la combinaison a été entièrement tester
        /// </summary>
        /// <param name="iLance"></param>
        /// <returns>bool: retourne true si la combinaison est pleine , dans le cas contraire , retournera false</returns>
        public bool TestBonNombre(int iLance)
        {
            return iLance >= 3;
        }
        /// <summary>
        /// Sélectionne et déselectionne les champs des listbox
        /// </summary>
        public void SelectChamps()
        {
            int iSelect = lbxCombi.SelectedIndex;
            lbxCombi2.SetSelected(iSelect, false);
            lbxCombi.SetSelected(iSelect, false);
            if (iSelect < 2)
            {
                lbxCombi2.SetSelected(iSelect + 1, true);
                lbxCombi.SetSelected(iSelect + 1, true);
            }
            else
            {
                lbxCombi2.SetSelected(iSelect, true);
                lbxCombi.SetSelected(iSelect, true);
            }
        }
        /// <summary>
        /// Génére un string aléatoire
        /// </summary>
        /// <returns>string: retourne un soit "Pile" soit "Face" généré aléatoirement</returns>
        public string ChoixRandom()
        {
            if (r1.Next(0, 2) == 0)
            {
                return "Pile";
            }
            else
            {
                return "Face";
            }
        }
        /// <summary>
        /// Contrôle si l'élément séléctionné de la combinaison est gagnant
        /// </summary>
        /// <param name="strchoix"></param>
        /// <returns>bool: retourne true si l'élément séléctionner correspond au string généré aléatoirement,dans la cas contraire,retournera false</returns>
        public bool TestChoixRandom(string strchoix)
        {
            string strRandom = Convert.ToString(lbxCombi.SelectedItem);
            if (strchoix == strRandom)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
