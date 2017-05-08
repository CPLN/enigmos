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
    /// Class de l'énigme du rébus
    /// </summary>
    public class RebusEnigmaPanel : EnigmaPanel
    {
        #region Attributs & Propriétés
        List<PictureBox> lImg = new List<PictureBox>();
        Label lblTitle = new Label { Text = "Rébus" };
        TextBox tbxAnswer = new TextBox { Text = "Réponse", Width=200 };
        TableLayoutPanel display = new TableLayoutPanel();
        Button bntDone = new Button { Text = "Valider" };
        #endregion

        #region Contructeur class & page
        public RebusEnigmaPanel()
        {
            //Lors de l'instantation, peupler une liste d'image contenant les 5 images possibles.
            //Piocher dans cette liste une image aléatoire qui sera l'image affichée.
            lImg.Add(new PictureBox { BackgroundImage = Properties.Resources.Coccinelle, Size = new Size(512, 261), Tag = "coccinelle" });
            lImg.Add(new PictureBox { BackgroundImage = Properties.Resources.farine, Size = new Size(512, 261), Tag = "farine" });
            lImg.Add(new PictureBox { BackgroundImage = Properties.Resources.mamifere, Size = new Size(512, 261), Tag = "mamifere" });
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
            //Ajoute les évènements sur la texbox
            tbxAnswer.GotFocus += RemoveText;

            // Suppression de la mise en page des réponses
            display.Controls.Clear();

            // Création de la mise en page de la question
            display.ColumnCount = 5;
            display.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.5f));
            display.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            display.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            display.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            display.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.5f));
            display.RowCount = 4;
            display.RowStyles.Add(new RowStyle(SizeType.Percent, 0.5f));
            display.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            display.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            display.RowStyles.Add(new RowStyle(SizeType.Percent, 0.5f));

            // Mise en forme du label de titre
            lblTitle.Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);
            lblTitle.AutoSize = true;
            display.SetColumnSpan(lblTitle, 3);

            // Coordonnées des objets
            display.Controls.Add(lblTitle, 1, 0);
            display.Controls.Add(lImg[RandomIndex()], 1, 1);
            display.Controls.Add(tbxAnswer, 1, 2);
            display.Controls.Add(bntDone, 1, 3);
        }
        #endregion

        #region Méthodes
        public int RandomIndex()
        {
            Random r = new Random();
            return r.Next(0, 4);
        }
        #endregion

        #region Evènements
        public void RemoveText(object sender, EventArgs e)
        {
            tbxAnswer.Text = "";
        }
        #endregion
    }
}
