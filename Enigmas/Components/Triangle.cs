using Cpln.Enigmos.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas.Components
{
    class Triangle : Panel
    {
        public int Cote { get; set; }
        public int Sommet { get; set; }

        public Triangle(int cote, int sommet)
        {
            Cote = cote;
            Sommet = sommet;
            Paint += new PaintEventHandler(Draw);
        }

        private void Draw(object sender, PaintEventArgs e)
        {
            PointF[] points = new PointF[3];
            points[0].X = Sommet;
            points[0].Y = 0;
            points[1].X = 0;
            points[1].Y = Cote;
            points[2].X = Cote;
            points[2].Y = Cote;
            e.Graphics.FillPolygon(Brushes.Red, points);
        }

        public void drawTriangle(PaintEventArgs e, int x, int y, int distance)
        {
            float angle = 0;
            SolidBrush brs = new SolidBrush(Color.Green);
            PointF[] p = new PointF[3];
            p[0].X = x;
            p[0].Y = y;
            p[1].X = (float)(x + distance * Math.Cos(angle));
            p[1].Y = (float)(y + distance * Math.Sin(angle));
            p[2].X = (float)(x + distance * Math.Cos(angle + Math.PI / 3));
            p[2].Y = (float)(y + distance * Math.Sin(angle + Math.PI / 3));
            e.Graphics.FillPolygon(brs, p);
        }
    }
}
