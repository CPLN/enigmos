using Cpln.Enigmos.Enigmas.Components;
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
    class Forme : Panel
    {
        public int Hauteur { get; set; }
        public int Largeur { get; set; }

        public Forme(int hauteur, int largeur)
        {
            Hauteur = hauteur;
            Largeur = largeur;
        }
    }
}
