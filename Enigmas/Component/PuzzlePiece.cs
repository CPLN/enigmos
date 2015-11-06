using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas.Component
{
    class PuzzlePiece : Panel
    {
        private Control element;
        private Point start;
        private bool bMoving = false;
        private Point moveStart;

        public PuzzlePiece(Control element, Point start)
        {
            this.element = element;
            this.start = start;
            element.Location = start;
            Label l = (Label)element;
            BackColor = Color.Turquoise;

            Controls.Add(element);

            element.MouseDown += new MouseEventHandler(MoveStart);
            element.MouseMove += new MouseEventHandler(MoveMove);
            element.MouseUp += new MouseEventHandler(MoveStop);
        }

        public static ShuffleList<PuzzlePiece> GeneratePieces(string text, int xCuts, int yCuts)
        {
            Label reference = new Label();
            reference.Text = text;
            reference.Font = new Font(FontFamily.GenericMonospace, 72);
            reference.AutoSize = false;

            ShuffleList<PuzzlePiece> pieces = new ShuffleList<PuzzlePiece>();

            Size referenceRealSize = TextRenderer.MeasureText(reference.Text, reference.Font);
            int width = referenceRealSize.Width / xCuts;
            int height = referenceRealSize.Height / yCuts;

            for (int j = 0; j <= referenceRealSize.Height - height; j += height)
            {
                for (int i = 0; i <= referenceRealSize.Width - width; i += width)
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
            pieces.Shuffle();
            return pieces;
        }

        private void MoveStart(object sender, MouseEventArgs e)
        {
            bMoving = true;
            moveStart = e.Location;
        }

        private void MoveMove(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.NoMove2D;
            if (bMoving)
            {
                int newX = Left + e.X - moveStart.X;
                int newY = Top + e.Y - moveStart.Y;

                Left = Math.Max(Math.Min(newX, Parent.Width - Width), 0);
                Top = Math.Max(Math.Min(newY, Parent.Height - Height), 0);
            }
        }

        private void MoveStop(object sender, MouseEventArgs e)
        {
            bMoving = false;
        }
    }
}
