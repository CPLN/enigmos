using Cpln.Enigmos.Enigmas.Component;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    class SimplePuzzleEnigmaPanel : EnigmaPanel
    {
        private ShuffleList<PuzzlePiece> pieces = new ShuffleList<PuzzlePiece>();

        public SimplePuzzleEnigmaPanel()
        {
            pieces = PuzzlePiece.GeneratePieces("JONGLEUR", 4, 2);

            Size size = pieces[0].Size;
            Random random = new Random();
            foreach (PuzzlePiece piece in pieces)
            {
                piece.Location = new Point(random.Next(Width - size.Width), random.Next(Height - size.Height));
                Controls.Add(piece);
            }
        }
    }
}
