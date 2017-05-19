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
        private LightController controller;
        private List<Light> voisins;
        public bool Allume { get; private set; }

        public Light(LightController controller)
        {
            this.controller = controller;
            voisins = new List<Light>();
            Allume = true;
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
            CliquerVoisins();
        }

        public void Dessiner(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Allume ? Brushes.Blue : Brushes.Gray, 0, 0, Width, Height);
        }

        public void CliquerVoisins()
        {
            Cliquer();
            foreach (Light voisin in voisins)
            {
                voisin.Cliquer();
            }
        }

        private void Cliquer()
        {
            Allume = !Allume;
            Invalidate();
            controller.Check();
        }
    }
}
