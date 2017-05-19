using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas.Components
{
    /// <summary>
    /// Class représentant une lampe (une case lumineuse) qui peut être allumée ou éteinte
    /// </summary>
    class Light : Panel
    {
        private LightController controller;
        private List<Light> voisins;

        /// <summary>
        /// État de la lampe, allumée ou éteinte
        /// </summary>
        public bool Allume { get; private set; }

        /// <summary>
        /// Constructeur de la lampe
        /// </summary>
        /// <param name="controller">Controlleur qui vérifie si toutes les lampes sont allumées</param>
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

        /// <summary>
        /// Permet d'ajouter un voisin à cette lampe
        /// </summary>
        /// <param name="voisin">Une autre lampe située à proximité</param>
        public void AjouterVoisin(Light voisin)
        {
            voisins.Add(voisin);
        }

        /// <summary>
        /// Évènement déclanché par la clic sur cette lampe.
        /// 
        /// Cette lampe et toutes les lampes voisines changent d'état.
        /// </summary>
        /// <param name="sender">Cette lampe</param>
        /// <param name="e">Les arguments de l'évènement</param>
        public void Cliquer(object sender, EventArgs e)
        {
            CliquerVoisins();
        }

        /// <summary>
        /// Évènement de dessin de cette lampe.
        /// </summary>
        /// <param name="sender">Cette lampe</param>
        /// <param name="e">Les arguments de l'évènenement</param>
        public void Dessiner(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Allume ? Brushes.Blue : Brushes.Gray, 0, 0, Width, Height);
        }

        /// <summary>
        /// Change l'état de cette lampe et celui de toutes les lampes voisines.
        /// </summary>
        public void CliquerVoisins()
        {
            Cliquer();
            foreach (Light voisin in voisins)
            {
                voisin.Cliquer();
            }
            controller.Check();
        }

        /// <summary>
        /// Change l'état de cette lampe uniquement.
        /// </summary>
        private void Cliquer()
        {
            Allume = !Allume;
            Invalidate();
        }
    }
}
