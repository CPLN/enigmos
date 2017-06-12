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
        int iDecompteTimer = 10;
        int iCompteur = 0;
        int iTimer2 = 0;

        Timer Timer1 = new Timer();
        Timer Timer2 = new Timer();

        Label lblFormeCouleur = new Label();
        Label lblTime = new Label();
        Label lblReponse = new Label();

        List<Panel> lstForme = new List<Panel>(); // Création d'une liste qui contiendra tous les panels (formes)

        Button btnDifferent = new Button(); // Création du bouton différent
        Button btnIdentique = new Button(); // Création du bouton identique

        Panel pnlCarre1 = new Panel(); // Création du panel qui sera carré
        Panel pnlCarre2 = new Panel(); // Création d'un deuxième panel qui sera carré
        Panel pnlCarre3 = new Panel();

        Panel pnlRectangle1 = new Panel();
        Panel pnlRectangle2 = new Panel();
        Panel pnlRectangle3 = new Panel();

        Ellipse ellipse1 = new Ellipse();
        Ellipse ellipse2 = new Ellipse();

        public FormesEnFoliesEnigmaPanel()
        {
            lblFormeCouleur.Location = new Point(371, 100);
            lblTime.Location = new Point(380, 200);
            lblTime.Size = new Size(100, 100);
            lblTime.Font = new Font("Arial", 30 , FontStyle.Bold);

            lblReponse.Text = "réponse est la couleur qui revient le plus souvent sur les formes";
            lblTime.Size = new Size(6000,50);
            lblReponse.Font = new Font("Arial", 14, FontStyle.Bold);
            lblReponse.Location = new Point(100, 200);
            lblReponse.BackColor = Color.Blue;

            Timer1.Interval = 1000; // 1000 millisecondes = 1 seconde
            Timer1.Tick += new EventHandler(Timer_Tick);
            Timer1.Enabled = true;

            Timer2.Interval = 1000;
            Timer2.Tick += new EventHandler(Timer2_Tick);
            

            Triangle triangle = new Triangle(100, 50); // Création du panel qui sera un triangle, avec une base de 100 et un sommet à 50 (en haut milieu du panel)
            triangle.Location = new Point(350, 350);
            AjoutDansListe(triangle);
            
            ellipse1.Location = new Point(300, 300);
            ellipse1.Size = new Size(220, 220);
            AjoutDansListe(ellipse1);

            Controls.Add(btnDifferent);
            btnDifferent.Location = new Point(421, 111);
            btnDifferent.Text = "Différent";
            btnDifferent.Width = 100;
            btnDifferent.Click += new EventHandler(ClicSurBoutonDifferent);
            
            Controls.Add(btnIdentique);
            btnIdentique.Location = new Point(321, 111);
            btnIdentique.Text = "Identique";
            btnIdentique.Width = 100;
            btnIdentique.Click += new EventHandler(ClicSurBoutonIdentique);

            AjoutPanelCarre(100, 350, 350, Color.Green, pnlCarre1);
            AjoutPanelRectangle(120, 210, 350, 350, Color.Blue, pnlRectangle3);
            AjoutPanelCarre(100, 350, 350, Color.Blue, pnlCarre2);
            AjoutPanelRectangle(120, 210, 350, 350, Color.Yellow,pnlRectangle1);
            AjoutPanelCarre(100, 350, 350, Color.Blue,pnlCarre3);
            AjoutPanelRectangle(120, 210, 350, 350, Color.Green, pnlRectangle2);
        }

        /// <summary>
        /// Timer qui va faire défiler les 2 premières formes.
        /// Il va être relancé à chaque erreur.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            if(iCompteur <= 0)
            {
                //Affiche la première forme
                Controls.Add(lstForme[iCompteur]);
                //Incrémente le compteur
                iCompteur++;
            }
            else
            {
                //Ajoute la 2ème forme
                Controls.Add(lstForme[iCompteur]);
                //Supprime la 1ère forme
                Controls.Remove(lstForme[iCompteur -1]);
                //Ajoute le label forme en dessus des boutons
                Controls.Add(lblFormeCouleur);
                lblFormeCouleur.Text = "Forme ?";
                //Incrémente le compteur 
                iCompteur++;
                Timer2.Enabled = true;
                //Arrête le timer après avoir afficher les 2 premières formes
                Timer1.Stop();    
            }

        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            if(iDecompteTimer >= 1)
            {
                if (iTimer2 <= 10)
                {
                    Controls.Add(lblTime);
                    lblTime.Text = Convert.ToString(iDecompteTimer);
                }
                else
                {
                    Timer2.Stop();
                    iTimer2 = 0;

                }

                iDecompteTimer--;
                iTimer2++;
            }
            else
            {
                iDecompteTimer = 10;
                iCompteur = 0;
                Timer1.Start();
            }
            
        }

        //Evènement lorsqu'il y a un clic sur un bouton
        private void ClicSurBoutonDifferent(object sender, EventArgs e)
        {
            int iTailleListe = lstForme.Capacity;
            if (iCompteur < iTailleListe)
            {
                if (lblFormeCouleur.Text == "Forme ?" || iCompteur == 2)
                {
                    lblFormeCouleur.Text = "Couleur ?";

                    if (lstForme[iCompteur - 2].Width == lstForme[iCompteur - 1].Width)
                    {
                        Controls.Remove(lstForme[iCompteur - 1]);
                        iCompteur = 0;
                        iDecompteTimer = 10;
                        Timer1.Start();
                    }
                    else
                    {
                        Controls.Add(lstForme[iCompteur]);
                        Controls.Remove(lstForme[iCompteur - 1]);
                        iCompteur++;
                    }
                }
                else
                {
                    lblFormeCouleur.Text = "Forme ?";

                    if (lstForme[iCompteur - 2].BackColor == lstForme[iCompteur - 1].BackColor)
                    {
                        Controls.Remove(lstForme[iCompteur - 1]);
                        iCompteur = 0;
                        iDecompteTimer = 10;
                        Timer1.Start();
                    }
                    else
                    {
                        Controls.Add(lstForme[iCompteur]);
                        Controls.Remove(lstForme[iCompteur - 1]);
                        iCompteur++;
                    }
                }

            }
            else
            {
                Controls.Remove(lstForme[iCompteur - 1]);
                Controls.Remove(lblFormeCouleur);
                Controls.Remove(lblTime);
                //Timer1.Enabled = false;
                Timer2.Enabled = false;
                Controls.Add(lblReponse);
            }
               
        }

        private void ClicSurBoutonIdentique(object sender, EventArgs e)
        {
            if (lblFormeCouleur.Text == "Forme ?" || iCompteur == 2)
            {
                lblFormeCouleur.Text = "Couleur ?";

                if (lstForme[iCompteur - 2].Width == lstForme[iCompteur - 1].Width)
                {

                    Controls.Add(lstForme[iCompteur]);
                    Controls.Remove(lstForme[iCompteur - 1]);
                    iCompteur++;
                }
                else
                {
                    Controls.Remove(lstForme[iCompteur - 1]);
                    iCompteur = 0;
                    iDecompteTimer = 10;
                    Timer1.Start();
                }
            }
            else
            {
                lblFormeCouleur.Text = "Forme ?";

                if (lstForme[iCompteur - 2].BackColor == lstForme[iCompteur - 1].BackColor)
                {
                    Controls.Add(lstForme[iCompteur]);
                    Controls.Remove(lstForme[iCompteur - 1]);
                    iCompteur++;
                }
                else
                {
                    Controls.Remove(lstForme[iCompteur - 1]);
                    iCompteur = 0;
                    iDecompteTimer = 10;
                    Timer1.Start();
                }
            }
        }

        /// <summary>
        /// Permet de choisir la taille carée d'un panel
        /// </summary>
        /// <param name="cote">Détermine la taille du côté du panel</param>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <param name="p">Contient le panel qui va être modifié</param>
        /// <returns>p</returns>
        public Panel AjoutPanelCarre(int cote, int positionX, int positionY, Color couleur, Panel p)
        {
            p.BackColor = couleur;
            p.Size = new Size(cote, cote);
            p.Location = new Point(positionX, positionY);
            AjoutDansListe(p);
            
            return p;
        }

        /// <summary>
        /// Permet de donner une forme rectangulaire à un panel
        /// </summary>
        /// <param name="hauteur">Détermine la hauteur qu'aura le rectangle</param>
        /// <param name="largeur">Détermine la largeur qu'aura le rectangle</param>
        /// <param name="positionX">Détermine la position qu'aura le panel sur l'axe X</param>
        /// <param name="positionY">Détermine la position qu'aura le panel sur l'axe Y</param>
        /// <param name="p">Contient le panel qui va devenir rectangulaire</param>
        /// <returns>p</returns>
        public Panel AjoutPanelRectangle(int hauteur, int largeur, int positionX, int positionY, Color couleur, Panel p)
        {
            p.BackColor = couleur;
            p.Size = new Size(largeur, hauteur);
            p.Location = new Point(positionX, positionY);
            AjoutDansListe(p);

            return p;
        }

        /// <summary>
        /// Permet d'ajouter un panel dans la liste de panel "lstForme", pour ceux qui ne sont ni rectangle ni carré
        /// </summary>
        /// <param name="p">Contient le panel à ajouter dans la liste</param>
        /// <returns>p</returns>
        public Panel AjoutDansListe(Panel p)
        {
            lstForme.Add(p);
            return p;
        }

    }
}
