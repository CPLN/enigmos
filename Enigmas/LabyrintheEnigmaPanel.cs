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
        //déclaration des listes
        List<Panel> Zonelaby;
        List<Panel> Mur;

        //déclaration des variables
        int iDepart, iNombreZone = 0, iNombreMur = 0;

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
            Zonelaby = new List<Panel>();
            Mur = new List<Panel>();            
        }

        public override void Load()
        {
            //déclaration et utilisation du random
            Random random = new Random();
            iDepart = random.Next(1, 4);

            //création du premir panel
            Panel zone = new Panel();
            zone.Name = "zone" + iNombreZone;
            zone.Size = new Size(100, 100);
            zone.BackColor = Color.Red;
            Zonelaby.Add(zone);
            Controls.Add(zone);
            if (iDepart == 1)
            {
                zone.Location = new Point(0, 0);
            }
            else if (iDepart == 2)
            {
                zone.Location = new Point(700, 500);
            }
            else if (iDepart == 3)
            {
                zone.Location = new Point(700, 0);
            }
            else if (iDepart == 4)
            {
                zone.Location = new Point(0, 500);
            }
            CréationMurs(Zonelaby);
            iNombreZone += 1;

            //création du personnage
            Panel personnage = new Panel();
            personnage.Size = new Size(25, 50);
            personnage.Left = zone.Left;
            personnage.Top = zone.Top;
            personnage.BackColor = Color.Black;
            Controls.Add(personnage);
        }

        private void CréationMurs (List<Panel> Zonelaby)
        {
            for (int i=0; i < 5; i++)
            {               
                Panel mur = new Panel();
                mur.Name = "mur" + iNombreMur;
                Mur.Add(mur);
                Controls.Add(mur);
                mur.BackColor = Color.Blue;
                if (i < 3 && i > 0)
                {
                    mur.Size = new Size(100, 20);
                    if (i == 1)
                    {
                        mur.Top = Zonelaby[iNombreZone].Top;
                        mur.Left = Zonelaby[iNombreZone].Left;
                    }
                    else if (i == 2)
                    {
                        mur.Left = Zonelaby[iNombreZone].Left;
                        mur.Top = Zonelaby[iNombreZone].Bottom;
                    }
                }
                else if (i < 5 && i > 2)
                {
                    mur.Size = new Size(20, 100);
                    if (i == 3)
                    {
                        mur.Top = Zonelaby[iNombreZone].Top;
                        mur.Left = Zonelaby[iNombreZone].Left;
                    } 
                    else if (i == 4)
                    {
                        mur.Top = Zonelaby[iNombreZone].Top;
                        mur.Left = Zonelaby[iNombreZone].Right;
                    }
                }
                iNombreMur += 1;
            }
        }
    }
}
