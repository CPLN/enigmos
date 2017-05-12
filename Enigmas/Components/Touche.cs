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
        public string Nom { get; set; }

        public Touche(string nom,int Width, int Height)
        {
            this.Nom = nom;
            
            this.Width = Width ;
            this.Height = Height ;
            this.Cursor = Cursors.Arrow;
            this.Paint += new PaintEventHandler(Dessin);
            SourisBouge += new MouseEventHandler(Bouge); // evenement quand la souris est sur le panel
        }


        private void Dessin(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillRectangle(Brushes.Black, 10, 0, Width -20, Height);
            e.Graphics.FillRectangle(Brushes.Black, 0, 10, Width, Height -20);

            e.Graphics.FillEllipse(Brushes.Black , 0, 0, 20, 20);
            e.Graphics.FillEllipse(Brushes.Black, 0,Height-20, 20, 20);
            e.Graphics.FillEllipse(Brushes.Black, Width-20, 0, 20, 20);
            e.Graphics.FillEllipse(Brushes.Black, Width-20, Height-20, 20, 20);
            e.Graphics.DrawString(Nom, new Font("Arial", 12), Brushes.White, 2, 2);
        }
    }
}

