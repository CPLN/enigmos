using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    /// <summary>
    /// 
    /// </summary>
    public class HiddenCharacterEnigmalPanel : EnigmaPanel
    {
        private GraphicsPath P = new GraphicsPath(), P1 = new GraphicsPath(), P2 = new GraphicsPath(), P3 = new GraphicsPath();
        int iLastX, iLastY;

        /// <summary>
        /// Constructeur par défaut, génère un texte et l'affiche dans le Panel.
        /// </summary>
        public HiddenCharacterEnigmalPanel()
        {
            Label lblHC = new Label();
            lblHC.Text = "CPLN";
            lblHC.Font = new Font(FontFamily.GenericSerif, 30, FontStyle.Bold);
            lblHC.ForeColor = Color.White;
            lblHC.BackColor = Color.Transparent;
            lblHC.Location = new Point(600, 400);
            lblHC.Size = TextRenderer.MeasureText(lblHC.Text, lblHC.Font);
            Controls.Add(lblHC);

            this.MouseMove += new MouseEventHandler(Move);
            this.MouseEnter += new EventHandler(EnterPanel);
            this.Paint += new PaintEventHandler(PaintBlue);

            DoubleBuffered = true;
        }

        private void EnterPanel(object sender, EventArgs e)
        {
            iLastX = MousePosition.X;
            iLastY = MousePosition.Y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Move(object sender, EventArgs e)
        {
            int iX = MousePosition.X;
            int iY = MousePosition.Y;
            int iDiff = 15;
            P.AddLine(iLastX - iDiff, iLastY - iDiff, iX + iDiff, iY + iDiff);
            P1.AddLine(iLastX + iDiff, iLastY + iDiff, iX - iDiff, iY - iDiff);
            P2.AddLine(iLastX - iDiff, iLastY - iDiff, iX - iDiff, iY - iDiff);
            P3.AddLine(iLastX + iDiff, iLastY + iDiff, iX + iDiff, iY + iDiff);

            iLastX = iX;
            iLastY = iY;

            Invalidate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PaintBlue(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.TranslateTransform(-240,-170);
            g.ScaleTransform(1.0f, 1.0f);
            g.DrawPath(new Pen(Color.Blue), P);
            g.DrawPath(new Pen(Color.Blue), P1);
            g.DrawPath(new Pen(Color.Blue), P2);
            g.DrawPath(new Pen(Color.Blue), P3);
            g.Flush();
        }
    }
}