using Cpln.Enigmos.Enigmas.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    /// <summary>
    /// Panel affichant une énigme.
    /// </summary>
    public class LabyrintheEnigmaPanel : EnigmaPanel
    {
        /* test
        List<Panel> Case;

        private void test()
        {
            Panel test = new Panel();
            test.Name = "test1";
            Case.Add(test);
            test.Width = 50;
            test.Height = 50;
            test.BackColor = Color.Red;
            this.Controls.Add(test);
        }*/
        
        //déclaration des listes
        List<Panel> zonelaby;
        List<Panel> Mur;

        //déclaration des variables
        int iDepart, iNombreZone;

        public LabyrintheEnigmaPanel()
        {
            /* test
            Case = new List<Panel>();
            test();
            graph.Root.Element = Case[0];
            graph.Root.FindNeighbor(Case[0]);
            graph.Root.AddNeighbor(Case[0]);
            if (graph.Root.Distance(graph.Contains(Case[0])) == -1)
            {
                
            }
            graph.Contains(Case[0]).AddNeighbor(Case[1]);*/

            //initialisation des listes et du graph
            Graph<Panel> graph = new Graph<Panel>(new Panel());
            zonelaby = new List<Panel>();
            Mur = new List<Panel>();            
        }

        public override void Load()
        {
            //déclaration et utilisation du random
            Random random = new Random();
            iDepart = random.Next(1, 4);

            //création du premir panel
            iNombreZone += 1;
            Panel mur = new Panel();
            mur.Name = "mur" + iNombreZone;
            mur.Size = new Size(100, 100);
            mur.BackColor = Color.Red;
            Mur.Add(mur);
            Controls.Add(mur);
            if (iDepart == 1)
            {
                mur.Location = new Point(0, 0);
            }
            else if (iDepart == 2)
            {
                mur.Location = new Point(700, 500);
            }
            else if (iDepart == 3)
            {
                mur.Location = new Point(700, 0);
            }
            else if (iDepart == 4)
            {
                mur.Location = new Point(0, 500);
            }
        }
    }
}
