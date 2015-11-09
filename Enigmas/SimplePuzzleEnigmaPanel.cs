using Cpln.Enigmos.Enigmas.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    /// <summary>
    /// Exemple d'énigme assez simple. Le Panel contient un puzzle qui, une fois résolu, indique la solution.
    /// </summary>
    class SimplePuzzleEnigmaPanel : EnigmaPanel
    {
        /// <summary>
        /// Liste des pièces de puzzle
        /// </summary>
        private List<PuzzlePiece> pieces = new List<PuzzlePiece>();

        /// <summary>
        /// Constructeur par défaut, génère des pièces et les répartit aléatoirement dans le Panel.
        /// </summary>
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
