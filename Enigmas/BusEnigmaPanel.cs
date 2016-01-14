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
    public class BusEnigmaPanel : EnigmaPanel
    {
        // Version : 1.4
        // Initialisation des divers objets et variables

        Timer t1 = new Timer();

        Random r = new Random();

        Label lblEnigme = new Label();
        
        PictureBox pbxImage = new PictureBox();
        PictureBox pbxReponse1 = new PictureBox();
        PictureBox pbxReponse2 = new PictureBox();
        PictureBox pbxReponse3 = new PictureBox();

        TableLayoutPanel centerQuestion = new TableLayoutPanel();

        /// <summary>
        /// Constructeur par défaut, génère un texte et l'affiche dans le Panel.
        /// </summary>
        public BusEnigmaPanel()
        {
            lblEnigme.Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);          
            lblEnigme.AutoSize = true;
            centerQuestion.Dock = DockStyle.Fill;
            Controls.Add(centerQuestion);
            pbxReponse1.Click += new EventHandler(ClickVrai);
            pbxReponse2.Click += new EventHandler(ClickFaux);
            pbxReponse3.Click += new EventHandler(ClickFaux);

            Start();
        }

        private void Start()
        {
            // Activation des pictureBox des réponses
            pbxReponse1.Enabled = true;
            pbxReponse2.Enabled = true;
            pbxReponse3.Enabled = true;

            lblEnigme.Text = "De quel côté se dirige le bus ?";
            pbxImage.BackgroundImage = Properties.Resources.bus;
            
            // Suppression de la mise en page des réponses
            centerQuestion.Controls.Clear();

            // Création de la mise en page de la question
            centerQuestion.ColumnCount = 5;
            centerQuestion.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.5f));
            centerQuestion.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            centerQuestion.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            centerQuestion.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            centerQuestion.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.5f));
            centerQuestion.RowCount = 4;
            centerQuestion.RowStyles.Add(new RowStyle(SizeType.Percent, 0.5f));
            centerQuestion.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            centerQuestion.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            centerQuestion.RowStyles.Add(new RowStyle(SizeType.Percent, 0.5f));

            // Largeur du label "lblEnigme"
            centerQuestion.SetColumnSpan(lblEnigme, 3);

            // Coordonnées des objets
            centerQuestion.Controls.Add(lblEnigme, 1, 1);
            centerQuestion.Controls.Add(pbxImage, 2, 2);

            pbxImage.Size = new Size(550, 240);
        }

        public override void ReleaseKey (object sender, KeyEventArgs e)
        {
            // Switch pour la direction du bus
            switch (e.KeyCode)
            {
                case Keys.Left:
                    Ok();
                    break;

                case Keys.Right:
                    Error();
                    break;

                case Keys.Up:
                    Error();
                    break;

                case Keys.Down:
                    Error();
                    break;
            }
        }

        private void Error()
        {
            // Méthode si l'utilisateur se trompe
            DialogResult dlgError = MessageBox.Show("Non, ce n'est pas la bonne direction.", "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Ok()
        {
            // Méthode si l'utilisateur trouve la bonne réponse

            // Dimension des pictureBox pour les réponses
            pbxReponse1.Size = new Size(200, 200);
            pbxReponse2.Size = new Size(200, 200);
            pbxReponse3.Size = new Size(200, 200);

            // Insertion d'une image dans les pictureBox de réponse
            pbxReponse1.BackgroundImage = Properties.Resources.Bus_Reponse1;
            pbxReponse2.BackgroundImage = Properties.Resources.Bus_Reponse2;
            pbxReponse3.BackgroundImage = Properties.Resources.Bus_Reponse3;

            // Suppression de la mise en page de la question
            centerQuestion.Controls.Clear();

            // Listage des réponses
            ShuffleList<PictureBox> lstPics = new ShuffleList<PictureBox>() {pbxReponse1, pbxReponse2, pbxReponse3};
            lstPics.Shuffle();

            // Coordonées des objets
            centerQuestion.Controls.Add(pbxReponse1, 1, 2);
            centerQuestion.Controls.Add(pbxReponse2, 2, 2);
            centerQuestion.Controls.Add(pbxReponse3, 3, 2);

            lblEnigme.Text = "Bravo, mais moi je veux savoir pourquoi.";
            centerQuestion.Controls.Add(lblEnigme, 1, 1);

            t1.Tick += new EventHandler(Timer_Tick);

            // Démarrage du Timer pour écrire la réponse finale

            t1.Enabled = true;
            t1.Interval = 30000;
        }

        private void ClickFaux(object sender, EventArgs e)
        {
            // Méthode si l'utilisateur se trompe
            DialogResult dlgError = MessageBox.Show("Faux !\nCe n'est pas la bonne réponse !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Start();
        }

        private void ClickVrai(object sender, EventArgs e)
        {
            // Méthode si l'utilisateur trouve la bonne réponse
            pbxReponse1.Enabled = false;
            pbxReponse2.Enabled = false;
            pbxReponse3.Enabled = false;

            DialogResult dlgSuccess = MessageBox.Show("Bravo !\nVeuillez entrer la couleur du bus pour continuer !\n\nVous avez 30 secondes pour écrire votre réponse...", "Correct", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Méthode si le Tîmer arrive au bout
            
            pbxReponse1.Enabled = false;
            pbxReponse2.Enabled = false;
            pbxReponse3.Enabled = false;

            t1.Enabled = false;
            Start();
        }
    }
}