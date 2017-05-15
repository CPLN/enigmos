using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas.Components
{
    class Light : Panel
    {
        private List<Light> voisins;
        private bool allume;

        public Light()
        {
            voisins = new List<Light>();
            allume = true;
            Width = 100;
            Height = 100;

            Click += new EventHandler(Cliquer);
            Paint += new PaintEventHandler(Dessiner);
            DoubleBuffered = true;
        }

        public void AjouterVoisin(Light voisin)
        {
            voisins.Add(voisin);
        }

        public void Cliquer(object sender, EventArgs e)
        {
            Cliquer();
            foreach(Light voisin in voisins)
            {
                voisin.Cliquer();
            }
        }

        public void Dessiner(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(allume ? Brushes.Blue : Brushes.Gray, 0, 0, Width, Height);
        }

        public void Cliquer()
        {
            allume = !allume;
            Invalidate();
        }
    }
}
