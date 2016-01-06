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

            TableLayoutPanel centerQuestion = new TableLayoutPanel();

            centerQuestion.ColumnCount = 7;
            centerQuestion.RowCount = 4;
        }

    }
}
