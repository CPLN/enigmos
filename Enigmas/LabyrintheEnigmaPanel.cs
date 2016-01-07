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
        int iDepart, iNombreZone = 0, iNombreMur = 0, iSeconde, iSense, iColonne, iLigne;
        bool bGeneration = true, bColonne = false;
        private Timer tJeu = new Timer();

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
            Graph<Label> lab = new Graph<Label>(new Label());
            Zonelaby = new List<Panel>();
            Mur = new List<Panel>();

            tJeu.Interval = 1;
            tJeu.Tick += new EventHandler(timer_tJeu);
        }

        public override void Load()
        {
            Label nbMur = new Label();
            nbMur.Location = new Point(250, 250);
            nbMur.Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);
            nbMur.ForeColor = Color.Black;
            nbMur.AutoSize = true;
            Controls.Add(nbMur);

            //déclaration et utilisation du random
            Random random = new Random();
            iDepart = random.Next(1, 5);

            /*
            //création du premir panel
            Panel zone = new Panel();
            zone.Name = "zone" + iNombreZone;
            zone.Size = new Size(50, 50);
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

             */

            //création du personnage
            Panel personnage = new Panel();
            personnage.Size = new Size(25, 50);
            personnage.BackColor = Color.Black;
            Controls.Add(personnage);
        }

        private void CréationMurs (List<Panel> Zonelaby)
        {/*
            for (int i = 1; i < 5; i++)
            {               
                Panel mur = new Panel();
                mur.Name = "mur" + iNombreMur;
                Mur.Add(mur);
                mur.BackColor = Color.Blue;
                if (i < 3 && i > 0)
                {
                    mur.Size = new Size(100, 20);
                    if (i == 1)
                    {
                        Mur[iNombreMur].Top = Zonelaby[iNombreZone].Top;
                        Mur[iNombreMur].Left = Zonelaby[iNombreZone].Left;
                        Mur[iNombreMur].Top -= Mur[iNombreMur].Height / 2;
                    }
                    else if (i == 2)
                    {
                        Mur[iNombreMur].Left = Zonelaby[iNombreZone].Left;
                        Mur[iNombreMur].Top = Zonelaby[iNombreZone].Bottom;
                        Mur[iNombreMur].Top -= Mur[iNombreMur].Height / 2;
                    }
                }
                else if (i < 5 && i > 2)
                {
                    mur.Size = new Size(20, 100);
                    if (i == 3)
                    {
                        Mur[iNombreMur].Top = Zonelaby[iNombreZone].Top;
                        Mur[iNombreMur].Left = Zonelaby[iNombreZone].Left;
                        Mur[iNombreMur].Left -= Mur[iNombreMur].Width / 2; 
                    } 
                    else if (i == 4)
                    {
                        Mur[iNombreMur].Top = Zonelaby[iNombreZone].Top;
                        Mur[iNombreMur].Left = Zonelaby[iNombreZone].Right;
                        Mur[iNombreMur].Left -= Mur[iNombreMur].Width / 2;
                    }
                }
                Zonelaby[iNombreZone].SendToBack();
                Controls.Add(mur);
                iNombreMur += 1;

                
            }*/           
        }

        private void timer_tJeu(object sender, EventArgs e)
        {
            iSeconde += 1;
            if (iSeconde == 1000)
            {
                iSeconde = 0;

                Random random = new Random();
                iSense = random.Next(1, 5);


            }

           // nbMur.Text = Convert.ToString(iSeconde);
            
            if (bGeneration == true)
            {
                if (bColonne == false)
                {
                    Panel zone = new Panel();
                    zone.Name = "zone" + iNombreZone;
                    zone.Location = new Point(0 + iLigne, 0 + iColonne);
                    zone.Size = new Size(50, 50);
                    zone.BackColor = Color.Red;
                    Zonelaby.Add(zone);
                    Controls.Add(zone);
                    iNombreZone += 1;
                    iLigne += 50;

                    if (iLigne >= Width)
                    {
                        bColonne = true;
                    }
                }
                else
                {
                    iLigne = 0;
                    iColonne += 50;
                    bColonne = false;
                    if (iColonne >= Height)
                    {
                        bGeneration = false;
                    }
                }
            }
        }
    }
}
