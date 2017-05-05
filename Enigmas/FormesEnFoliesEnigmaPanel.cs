using Cpln.Enigmos.Enigmas.Components;
using Cpln.Enigmos.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    public class FormesEnFoliesEnigmaPanel : EnigmaPanel 
    {
        List<Panel> lstForme = new List<Panel>(); // Création d'une liste qui contiendra tous les panels (formes)

        Button btnDifferent = new Button(); // Création du bouton différent
        Button btnIdentique = new Button(); // Création du bouton identique

        Panel Carre1 = new Panel(); // Création du panel qui sera carré
        Panel Carre2 = new Panel(); // Création d'un deuxième panel qui sera carré

        public FormesEnFoliesEnigmaPanel()
        {
            Triangle triangle = new Triangle(100, 50); // Création du panel qui sera un triangle, avec une base de 100 et un sommet à 50 (en haut milieu du panel)
            Controls.Add(triangle);

            Rond rond = new Rond();
            rond.Location = new Point(250, 250);
            Controls.Add(rond);

            Controls.Add(btnDifferent);
            btnDifferent.Location = new Point(421, 111);
            btnDifferent.Text = "Différent";

            Controls.Add(btnIdentique);
            btnIdentique.Location = new Point(321, 111);
            btnIdentique.Text = "Identique";

            Carre1 = AjoutPanelCarre(50, 250, 250, Carre1);
            Carre1.BackColor = Color.Blue;

            Carre2 = AjoutPanelCarre(50, 350, 350, Carre2);
            Carre2.BackColor = Color.Black;
        }

        public Panel AjoutPanelCarre(int cote, int positionX, int positionY, Panel p)
        {
            p.Size = new Size(cote, cote);
            p.Location = new Point(positionX, positionY);
            lstForme.Add(p);
            
            return p;
        }

        public Panel AjoutPanelRectangle(int hauteur, int largeur, int positionX, int positionY, Panel p)
        {
            p.Size = new Size(largeur, hauteur);
            p.Location = new Point(positionX, positionY);
            lstForme.Add(p);

            return p;
        }


    }
}
