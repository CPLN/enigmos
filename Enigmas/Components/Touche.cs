using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Cpln.Enigmos.Enigmas.Components
{
    class Touche : MovablePanel
    {
        private Color couleurPanel;
        private Color couleurPolice;

        public string Nom { get; set; }

        public Touche(string nom,int Width, int Height)
        {
            this.Nom = nom;            
            this.Width = Width ;
            this.Height = Height ;

            this.Cursor = Cursors.Arrow;
            this.couleurPanel = Color.Black;
            this.couleurPolice = Color.White;

            this.Paint += new PaintEventHandler(Dessin);
            this.MouseEnter += new EventHandler(SourisEntre);
            this.MouseLeave += new EventHandler(SourisSort);
            this.MouseDown += new MouseEventHandler(SourisDown);
            this.MouseUp += new MouseEventHandler(SourisUp);

            DoubleBuffered = true;
        }


        private void Dessin(object sender, PaintEventArgs e)
        {
            Brush brushPanel = new SolidBrush(couleurPanel);
            Brush brushPolice = new SolidBrush(couleurPolice);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillRectangle(brushPanel, 10, 0, Width -20, Height);
            e.Graphics.FillRectangle(brushPanel, 0, 10, Width, Height -20);

            e.Graphics.FillEllipse(brushPanel, 0, 0, 20, 20);
            e.Graphics.FillEllipse(brushPanel, 0,Height-20, 20, 20);
            e.Graphics.FillEllipse(brushPanel, Width-20, 0, 20, 20);
            e.Graphics.FillEllipse(brushPanel, Width-20, Height-20, 20, 20);
            e.Graphics.DrawString(Nom, new Font("Arial", 12), brushPolice, 2, 2);
        }
        private void SourisEntre(object sender, EventArgs e)
        {
            this.couleurPanel = Color.Gray;
            Invalidate();
        }

        private void SourisSort(object sender, EventArgs e)
        {
            this.couleurPanel = Color.Black;
            Invalidate();
        }
        private void SourisDown(object sender, MouseEventArgs e)
        {
            this.couleurPolice = Color.Black;
            this.couleurPanel = Color.LightGray;
            Invalidate();
        }
        private void SourisUp(object sender, MouseEventArgs e)
        {
            this.couleurPolice = Color.White;
            this.couleurPanel = Color.Gray;
            Invalidate();
        }
    }
}

