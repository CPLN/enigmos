using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas.Component
{
    class PuzzlePiece : Panel
    {
        private Control element;
        private Point start;

        public PuzzlePiece(Control element, Point start)
        {
            this.element = element;
            this.start = start;
            element.Location = start;
            Label l = (Label)element;
            Controls.Add(element);
        }

        public static List<PuzzlePiece> GeneratePieces(string text, int xCuts, int yCuts)
        {
            Label reference = new Label();
            reference.Text = text;
            reference.Font = new Font(FontFamily.GenericMonospace, 72);
            reference.AutoSize = false;

            List<PuzzlePiece> pieces = new List<PuzzlePiece>();

            Size referenceRealSize = TextRenderer.MeasureText(reference.Text, reference.Font);
            int width = referenceRealSize.Width / xCuts;
            int height = referenceRealSize.Height / yCuts;

            for (int j = 0; j < referenceRealSize.Height; j += height)
            {
                for (int i = 0; i < referenceRealSize.Width; i += width)
                {
                    Label label = new Label();
                    label.Text = text;
                    label.Font = new Font(FontFamily.GenericMonospace, 72);
                    label.AutoSize = true;
                    PuzzlePiece piece = new PuzzlePiece(label, new Point(-i, -j));
                    piece.Size = new Size(width, height);
                    pieces.Add(piece);
                }
            }
            return pieces;
        }
    }
}
