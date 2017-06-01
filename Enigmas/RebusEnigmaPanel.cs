using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    /// <summary>
    /// Class de l'énigme du rébus
    /// </summary>
    public class RebusEnigmaPanel : EnigmaPanel
    {
        #region Attributs & Propriétés
        List<PictureBox> lImg = new List<PictureBox>();

        TableLayoutPanel display = new TableLayoutPanel();
        Label lblTitle = new Label { Text = "Rébus" };
        TextBox tbxAnswer = new TextBox { Text = "Réponse", Width=200 };
        Button btnDone = new Button { Text = "Valider" };

        int randomIndex;
        #endregion

        #region Contructeur class & page
        public RebusEnigmaPanel()
        {
            //Lors de l'instantation, peupler une liste d'image contenant les 5 images possibles. Les tags correspondent aux réponses.
            lImg.Add(new PictureBox { BackgroundImage = Properties.Resources.Coccinelle, Size = new Size(512, 261), Tag = "coccinelle" });
            lImg.Add(new PictureBox { BackgroundImage = Properties.Resources.farine, Size = new Size(512, 261), Tag = "farine" });
            lImg.Add(new PictureBox { BackgroundImage = Properties.Resources.mamifere, Size = new Size(512, 261), Tag = "mammifère" });
            lImg.Add(new PictureBox { BackgroundImage = Properties.Resources.parapluie, Size = new Size(512, 261), Tag = "parapluie" });
            lImg.Add(new PictureBox { BackgroundImage = Properties.Resources.piano, Size = new Size(512, 261), Tag = "piano" });

            //Définit la source de l'affichage
            display.Dock = DockStyle.Fill;
            Controls.Add(display);

            //Construit l'affichage
            BuildPage();
        }

        public void BuildPage()
        {
            //Evènement keypress de la ta textbox
            tbxAnswer.KeyDown += PressKey;

            //Permet d'attraper la touche enter dans la textbox
            tbxAnswer.Multiline = true;
            tbxAnswer.AcceptsReturn = true;

            //Evènement du placeholder sur la textbox
            tbxAnswer.GotFocus += RemoveText;

            //Evènement de click sur le bouton
            btnDone.Click += BtnDone_Click;

            // Suppression de la mise en page des réponses
            display.Controls.Clear();

            // Création de la mise en page de la question
            display.ColumnCount = 5;
            display.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.5f));
            display.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            display.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            display.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            display.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.5f));
            display.RowCount = 5;
            display.RowStyles.Add(new RowStyle(SizeType.Percent, 0.3f));
            display.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            display.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            display.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            display.RowStyles.Add(new RowStyle(SizeType.Percent, 0.5f));

            // Mise en forme du label de titre
            lblTitle.Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);
            lblTitle.AutoSize = true;
            display.SetColumnSpan(lblTitle, 3);

            //Génération du nombre aléatoire
            randomIndex = RandomIndex();

            // Coordonnées des objets
            display.Controls.Add(lblTitle, 1, 1);
            display.Controls.Add(lImg[randomIndex], 1, 2);
            display.Controls.Add(tbxAnswer, 1, 3);
            display.Controls.Add(btnDone, 1, 4);
        }

        #endregion

        #region Méthodes
        /// <summary>
        /// Génère un index aléatoire permettant de choisir l'image affichée
        /// </summary>
        public int RandomIndex()
        {
            Random r = new Random();
            return r.Next(0, lImg.Count);
        }

        /// <summary>
        /// Valide la saisie de l'utilisateur
        /// </summary>
        public void ValidateAnswer(string answer)
        {
            //Formater la saisie de l'utilisateur en minuscule
            answer = answer.ToLower();

            //Tester si la réponse est correcte
            if (answer == lImg[randomIndex].Tag.ToString())
            {
                //Bonne réponse
                MessageBox.Show("La réponse est : 42", "Bravo !");
            }
            else
            {
                //Mauvaise réponse
                tbxAnswer.Clear();
                tbxAnswer.Focus();
            }
        }
        #endregion

        #region Evènements
        /// <summary>
        /// Permet de supprimer le texte lors du focus sur la textbox (alternative au placeholder)
        /// </summary>
        public void RemoveText(object sender, EventArgs e)
        {
            tbxAnswer.Text = "";
        }

        /// <summary>
        /// Vérifie que la saisie ainsi que le tag de l'image affichée corresponde
        /// </summary>
        private void BtnDone_Click(object sender, EventArgs e)
        {
            ValidateAnswer(tbxAnswer.Text);
        }

        /// <summary>
        /// Permet de valider la réponse quand l'utilisateur clique sur la touche enter
        /// </summary>
        public override void PressKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                ValidateAnswer(tbxAnswer.Text);
            }
        }
        #endregion
    }
}
