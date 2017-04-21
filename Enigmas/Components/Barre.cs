using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas.Components
{
    class Barre : Panel
    {
        Panel pBarreE = new Panel();
        public Barre()
        {
            pBarreE.Left = 121;
            pBarreE.Top = 11;
            pBarreE.Size = new Size(10, 200);
            pBarreE.Location = new Point(100, 200);
            pBarreE.BackColor = Color.Black;
            this.Controls.Add(pBarreE);
        }
        Point positionClick; // Suffisamment clair, un point c'est tout !
        protected override void OnMouseDown(MouseEventArgs e) // Surcharge de la méthode OnMouseDown
        {
            positionClick = e.Location; // Où on initialise le point
            base.OnMouseDown(e); // J'imagine que cette ligne va intégrer le reste de la méthode mère
            // (comme une concaténation), mais je suis pas sûr...
        }

        protected override void OnMouseMove(MouseEventArgs e) // Surcharge de la méthode OnMouseMove
        {
            if (e.Button == MouseButtons.Left) // Si on clique (Gauche)
            {
                pBarreE.Location = new Point(Location.X + e.X - positionClick.X, Location.Y + e.Y - positionClick.Y);
                // Ça change l'origine du la DamiBox(j'adore)...
                // Locution = Point d'origine de la DamiBox
                // e.X/e.Y = int de l'abscisse/ordonnée de la souris
            }
        }
    }
}
