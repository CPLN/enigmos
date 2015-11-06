using Cpln.Enigmos.Enigmas.Component;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    class SimplePuzzleEnigmaPanel : EnigmaPanel
    {
        private List<PuzzlePiece> pieces = new List<PuzzlePiece>();

        public SimplePuzzleEnigmaPanel()
        {
            pieces = PuzzlePiece.GeneratePieces("JONGLEUR", 4, 1);

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
