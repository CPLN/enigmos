using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    /// <summary>
    /// Exemple d'énigme très simple. Seul un texte est affiché.
    /// </summary>
    public class BusEnigmaPanel : EnigmaPanel
    {
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
            lblEnigme.Text = "De quel côté se dirige le bus ?";
            pbxImage.BackgroundImage = Properties.Resources.bus;

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

            centerQuestion.SetColumnSpan(lblEnigme, 3);

            lblEnigme.Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);
            
            pbxImage.Size = new Size(550, 240);
            lblEnigme.AutoSize = true;

            centerQuestion.Controls.Add(lblEnigme, 1, 1);
            centerQuestion.Controls.Add(pbxImage, 2, 2);

            centerQuestion.Dock = DockStyle.Fill;

            Controls.Add(centerQuestion);
        }

        public override void PressKey (object sender, KeyEventArgs e)
        {
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
            DialogResult dlgError = MessageBox.Show("Non, ce n'est pas la bonne direction.", "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Ok()
        {
            pbxImage.Visible = false;

            lblEnigme.Text = "Bravo, mais moi je veux savoir pourquoi.";

            pbxReponse1.Size = new Size(200, 200);
            pbxReponse2.Size = new Size(200, 200);
            pbxReponse3.Size = new Size(200, 200);

            pbxReponse1.BackgroundImage = Properties.Resources.Bus_Reponse1;
            pbxReponse2.BackgroundImage = Properties.Resources.Bus_Reponse2;
            pbxReponse3.BackgroundImage = Properties.Resources.Bus_Reponse3;

            centerQuestion.Controls.Add(pbxReponse1, 1, 2);
            centerQuestion.Controls.Add(pbxReponse2, 2, 2);
            centerQuestion.Controls.Add(pbxReponse3, 3, 2);

            pbxReponse1.Click += new EventHandler(ClickVrai);
            pbxReponse2.Click += new EventHandler(ClickFaux);
            pbxReponse3.Click += new EventHandler(ClickFaux);
        }

        private void ClickFaux(object sender, EventArgs e)
        {
            MessageBox.Show("Faux !\nCe n'est pas la bonne réponse !");
        }

        private void ClickVrai(object sender, EventArgs e)
        {
            MessageBox.Show("Bravo !\nVeuillez entrer la couleur du bus pour continuer !");
        }

        
    }
}
