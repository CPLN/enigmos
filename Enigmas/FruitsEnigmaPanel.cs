using Cpln.Enigmos.Enigmas.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    /// <summary>
    /// Panel affichant une énigme.
    /// </summary>
    public class FruitsEnigmaPanel : EnigmaPanel
    {
        public FruitsEnigmaPanel()
        {
            List<Image> liImages = new List<Image>()
            {
                Image.FromFile(@"..\..\Resources\3bananes.png"),
                Image.FromFile(@"..\..\Resources\banane_enigme.png"),
                Image.FromFile(@"..\..\Resources\pomme.png"),
                Image.FromFile(@"..\..\Resources\raisins.png")
            };

            TableLayoutPanel caseFruit = new TableLayoutPanel();
            caseFruit.Dock = DockStyle.Fill;

            PictureBox pbxImage = new PictureBox();
            PictureBox pbxImage2 = new PictureBox();
            PictureBox pbxImage3 = new PictureBox();
            PictureBox pbxImage4 = new PictureBox();
            PictureBox pbxImage5 = new PictureBox();
            PictureBox pbxImage6 = new PictureBox();
            PictureBox pbxImage7 = new PictureBox();
            PictureBox pbxImage8 = new PictureBox();

            Label lblEnigme = new Label();
            Label lblEnigme2 = new Label();
            Label lblEnigme3 = new Label();
            Label lblEnigme4 = new Label();
            Label lblEnigme5 = new Label();
            Label lblEnigme6 = new Label();
            Label lblEnigme7 = new Label();
            Label lblEnigme8 = new Label();
            Label lblEnigme9 = new Label();
            Label lblEnigme10 = new Label();
            Label lblEnigme11 = new Label();
            Label lblEnigme12 = new Label();

            lblEnigme.Text = "=";
            lblEnigme2.Text = "7";
            lblEnigme3.Text = "=";
            lblEnigme4.Text = "5";
            lblEnigme5.Text = "+";
            lblEnigme6.Text = "=";
            lblEnigme7.Text = "1";
            lblEnigme8.Text = "+";
            lblEnigme9.Text = "+";
            lblEnigme10.Text = "+";
            lblEnigme11.Text = "=";
            lblEnigme12.Text = "?";

            pbxImage.BackgroundImage = liImages[2];
            pbxImage2.BackgroundImage = liImages[2];
            pbxImage3.BackgroundImage = liImages[2];
            pbxImage4.BackgroundImage = liImages[2];
            pbxImage5.BackgroundImage = liImages[3];
            pbxImage6.BackgroundImage = liImages[3];
            pbxImage7.BackgroundImage = liImages[1];
            pbxImage8.BackgroundImage = liImages[0];

            pbxImage.Size = liImages[2].Size;
            pbxImage2.Size = liImages[2].Size;
            pbxImage3.Size = liImages[2].Size;
            pbxImage4.Size = liImages[2].Size;
            pbxImage5.Size = liImages[3].Size;
            pbxImage6.Size = liImages[3].Size;
            pbxImage7.Size = liImages[1].Size;
            pbxImage8.Size = liImages[0].Size;

            caseFruit.ColumnCount = 9;
            caseFruit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.5f));
            caseFruit.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            caseFruit.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            caseFruit.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            caseFruit.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            caseFruit.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            caseFruit.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            caseFruit.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            caseFruit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.5f));
            caseFruit.RowCount = 6;
            caseFruit.RowStyles.Add(new RowStyle(SizeType.Percent, 0.5f));
            caseFruit.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            caseFruit.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            caseFruit.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            caseFruit.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            caseFruit.RowStyles.Add(new RowStyle(SizeType.Percent, 0.5f));

            caseFruit.Controls.Add(pbxImage, 3, 1);
            caseFruit.Controls.Add(pbxImage2, 6, 2);
            caseFruit.Controls.Add(pbxImage3, 2, 3);
            caseFruit.Controls.Add(pbxImage4, 1, 4);
            caseFruit.Controls.Add(pbxImage5, 2, 2);
            caseFruit.Controls.Add(pbxImage6, 3, 4);
            caseFruit.Controls.Add(pbxImage8, 5, 4);
            caseFruit.Controls.Add(pbxImage7, 6, 3);

            caseFruit.Controls.Add(lblEnigme, 4, 1);
            caseFruit.Controls.Add(lblEnigme2, 5, 1);
            caseFruit.Controls.Add(lblEnigme3, 3, 2);
            caseFruit.Controls.Add(lblEnigme4, 4, 2);
            caseFruit.Controls.Add(lblEnigme5, 5, 2);
            caseFruit.Controls.Add(lblEnigme6, 3, 3);
            caseFruit.Controls.Add(lblEnigme7, 4, 3);
            caseFruit.Controls.Add(lblEnigme8, 5, 3);
            caseFruit.Controls.Add(lblEnigme9, 2, 4);
            caseFruit.Controls.Add(lblEnigme10, 4, 4);
            caseFruit.Controls.Add(lblEnigme11, 6, 4);
            caseFruit.Controls.Add(lblEnigme12, 7, 4);
            Controls.Add(caseFruit);
        }

    }
}
