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
        // Tous les compteurs
        int iDecompteTimer = 10; // Variable qui fera office de chrono 
        int iCompteur = 0; // Compteur pour déterminer si l'on arrive au bout de la liste
        int iCptTimer2 = 0;

        // Tous les Timer
        Timer Timer1 = new Timer();
        Timer Timer2 = new Timer();

        // Les différents labels
        Label lblFormeCouleur = new Label();
        Label lblTime = new Label();
        Label lblReponse = new Label();

        List<Panel> lstForme = new List<Panel>(); // Création d'une liste qui contiendra tous les panels (formes)

        Button btnDifferent = new Button(); // Création du bouton différent
        Button btnIdentique = new Button(); // Création du bouton identique

        // Les panels carré
        Panel pnlCarre1 = new Panel();
        Panel pnlCarre2 = new Panel();
        Panel pnlCarre3 = new Panel();
        Panel pnlCarre4 = new Panel();
        Panel pnlCarre5 = new Panel();

        // Les panels rectangle
        Panel pnlRectangle1 = new Panel();
        Panel pnlRectangle2 = new Panel();
        Panel pnlRectangle3 = new Panel();
        Panel pnlRectangle4 = new Panel();
        Panel pnlRectangle5 = new Panel();

        // Les panels avec dessin d'ellipse 
        Ellipse ellipse1 = new Ellipse();

        public FormesEnFoliesEnigmaPanel()
        {
            CreationLabel(lblFormeCouleur, "", 150, 100, 371, 90);
            lblFormeCouleur.Font = new Font("Arial", 15, FontStyle.Bold);

            CreationLabel(lblTime, "", 100, 100, 380, 200);
            lblTime.Font = new Font("Arial", 30, FontStyle.Bold);

            CreationLabel(lblReponse, "La réponse est la couleur de la dernière forme", 600, 100, 200, 350);
            lblReponse.Font = new Font("Arial", 15, FontStyle.Bold);
            lblReponse.ForeColor = Color.Red;

            Timer1.Interval = 1000; // 1000 millisecondes = 1 seconde
            Timer1.Tick += new EventHandler(Timer_Tick);
            Timer1.Enabled = true;

            Timer2.Interval = 1000;
            Timer2.Tick += new EventHandler(Timer2_Tick);

            Triangle triangle = new Triangle(100, 50); // Création du panel qui sera un triangle, avec une base de 100 et un sommet à 50 (en haut milieu du panel)
            triangle.Location = new Point(360, 350);
            AjoutDansListe(triangle);

            ellipse1.Location = new Point(300, 300);
            ellipse1.Size = new Size(220, 220);
            AjoutDansListe(ellipse1);

            CreationBouton(btnDifferent, "Différent", 100, 420, 125);
            btnDifferent.Click += new EventHandler(ClicSurBoutonDifferent);
            btnDifferent.Font = new Font("Arial", 10);

            CreationBouton(btnIdentique, "Identique", 100, 300, 125);
            btnIdentique.Click += new EventHandler(ClicSurBoutonIdentique);
            btnIdentique.Font = new Font("Arial", 10);

            AjoutPanelCarre(100, 360, 350, Color.Green, pnlCarre1);
            AjoutPanelRectangle(120, 210, 300, 350, Color.Blue, pnlRectangle3);
            AjoutPanelCarre(100, 360, 350, Color.Blue, pnlCarre2);
            AjoutPanelRectangle(120, 210, 300, 350, Color.Yellow, pnlRectangle1);
            AjoutPanelCarre(100, 360, 350, Color.Blue, pnlCarre3);
            AjoutPanelCarre(100, 360, 350, Color.Yellow, pnlCarre4);
            AjoutPanelRectangle(120, 210, 300, 350, Color.Green, pnlRectangle2);
            AjoutPanelCarre(100, 360, 350, Color.Blue, pnlCarre5);
            AjoutPanelRectangle(120, 210, 300, 350, Color.Red, pnlRectangle4);
            AjoutPanelRectangle(120, 210, 300, 350, Color.Blue, pnlRectangle5);
        }

        /// <summary>
        /// Timer qui va faire défiler les 2 premières formes.
        /// Il va être relancé à chaque erreur.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (iCompteur <= 0)
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
                Controls.Remove(lstForme[iCompteur - 1]);
                //Ajoute le label forme en dessus des boutons
                Controls.Add(lblFormeCouleur);
                lblFormeCouleur.Text = "Forme ?";
                //Incrémente le compteur 
                iCompteur++;
                btnDifferent.Enabled = true;
                btnIdentique.Enabled = true;
                Timer2.Enabled = true;
                Timer2.Start();
                //Arrête le timer après avoir afficher les 2 premières formes
                Timer1.Stop();
            }

        }

        /// <summary>
        /// Timer qui va faire office de chrono avec la variable iDecompteTimer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (iDecompteTimer >= 1)
            {
                if (iCptTimer2 <= 10)
                {
                    Controls.Add(lblTime);
                    lblTime.Text = Convert.ToString(iDecompteTimer);
                }
                else
                {
                    Timer2.Stop();
                    iCptTimer2 = 0;
                }

                iCptTimer2++;
                iDecompteTimer--;
            }
            else
            {
                Controls.Remove(lstForme[iCompteur - 1]);
                iDecompteTimer = 10;
                iCompteur = 0;
                iCptTimer2 = 0;
                Timer1.Start();
            }

        }

        /// <summary>
        /// Va permettre de savoir si le bouton pressé est btnDifferent.
        /// Va tester si c'était la forme ou la couleur à identifier.
        /// Va tout redémarrer ou va afficher la prochaine forme.
        /// </summary>
        /// <param name="sender">le paramètre "sender" est btnDifferent</param>
        /// <param name="e"></param>
        private void ClicSurBoutonDifferent(object sender, EventArgs e)
        {
            int iTailleListe = lstForme.Capacity;
            if (iCompteur < iTailleListe - 4)
            {
                if (lblFormeCouleur.Text == "Forme ?" || iCompteur == 2)
                {
                    lblFormeCouleur.Text = "Couleur ?";

                    if (lstForme[iCompteur - 2].Width == lstForme[iCompteur - 1].Width)
                    {
                        Controls.Remove(lstForme[iCompteur - 1]);
                        iCompteur = 0;
                        btnDifferent.Enabled = false;
                        btnIdentique.Enabled = false;
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
                        btnDifferent.Enabled = false;
                        btnIdentique.Enabled = false;
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
                // On va supprimer tout ce qu'il y a sauf les boutons et afficher la réponse
                Controls.Remove(lstForme[iCompteur - 1]);
                Controls.Remove(lblFormeCouleur);
                Controls.Remove(lblTime);
                Timer1.Enabled = false;
                Timer2.Enabled = false;
                btnDifferent.Enabled = false;
                btnIdentique.Enabled = false;
                Controls.Add(lblReponse);
            }

        }

        /// <summary>
        /// Va permettre de savoir si le bouton pressé était le btnIdentique.
        /// Va tester si c'était la forme ou la couleur à identifier.
        /// Va tout redémarrer ou va afficher la prochaine forme. 
        /// </summary>
        /// <param name="sender">le paramètre "sender" est btnIdentique</param>
        /// <param name="e"></param>
        private void ClicSurBoutonIdentique(object sender, EventArgs e)
        {
            int iTailleListe = lstForme.Capacity;
            if (iCompteur < iTailleListe - 4)
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
                        btnDifferent.Enabled = false;
                        btnIdentique.Enabled = false;
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
                        btnDifferent.Enabled = false;
                        btnIdentique.Enabled = false;
                        iCompteur = 0;
                        iDecompteTimer = 10;
                        Timer1.Start();
                    }
                }
            }
            else
            {
                // Supprime tout et ne va afficher que la réponse, seul les boutons seront encore visibles
                Controls.Remove(lstForme[iCompteur - 1]);
                Controls.Remove(lblFormeCouleur);
                Controls.Remove(lblTime);
                Timer1.Enabled = false;
                Timer2.Enabled = false;
                btnDifferent.Enabled = false;
                btnIdentique.Enabled = false;
                Controls.Add(lblReponse);
            }
        }

        /// <summary>
        /// Permet de modifer les paramètres d'un panel carré
        /// </summary>
        /// <param name="cote">Détermine la taille du côté du panel</param>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <param name="panel">Contient le panel qui va être modifié</param>
        /// <returns>panel</returns>
        public Panel AjoutPanelCarre(int cote, int positionX, int positionY, Color couleur, Panel panel)
        {
            panel.BackColor = couleur;
            panel.Size = new Size(cote, cote);
            panel.Location = new Point(positionX, positionY);
            AjoutDansListe(panel);

            return panel;
        }

        /// <summary>
        /// Permet de modifier les paramètres d'un panel rectangulaire
        /// </summary>
        /// <param name="hauteur">Détermine la hauteur qu'aura le rectangle</param>
        /// <param name="largeur">Détermine la largeur qu'aura le rectangle</param>
        /// <param name="positionX">Détermine la position qu'aura le panel sur l'axe X</param>
        /// <param name="positionY">Détermine la position qu'aura le panel sur l'axe Y</param>
        /// <param name="panel">Contient le panel qui va devenir rectangulaire</param>
        /// <returns>panel</returns>
        public Panel AjoutPanelRectangle(int hauteur, int largeur, int positionX, int positionY, Color couleur, Panel panel)
        {
            panel.BackColor = couleur;
            panel.Size = new Size(largeur, hauteur);
            panel.Location = new Point(positionX, positionY);
            AjoutDansListe(panel);

            return panel;
        }

        /// <summary>
        /// Permet d'ajouter un panel dans la liste de panel "lstForme", pour ceux qui ne sont ni rectangle ni carré
        /// </summary>
        /// <param name="panel">Contient le panel à ajouter dans la liste</param>
        /// <returns>panel</returns>
        public Panel AjoutDansListe(Panel panel)
        {
            lstForme.Add(panel);
            return panel;
        }

        /// <summary>
        /// Permet de modifier les propriétés de boutons avec différents paramètres
        /// </summary>
        /// <param name="bouton"> Paramètre qui contiendra le bouton</param>
        /// <param name="texte"> Pramètre qui contiendra le texte du bouton</param>
        /// <param name="largeur"> Paramètre qui contiendra la largeur du bouton</param>
        /// <param name="positionX"> Paramètre qui condra la position sur l'axe X du bouton</param>
        /// <param name="positionY"> Paramètre qui contiendra la position sur l'axe Y du bouton</param>
        /// <returns></returns>
        public Button CreationBouton(Button bouton, string texte, int largeur, int positionX, int positionY)
        {
            bouton.Text = texte;
            bouton.Width = largeur;
            bouton.Location = new Point(positionX, positionY);
            bouton.Enabled = false; // N'active pas le bouton directement après la création
            Controls.Add(bouton);

            return bouton;
        }

        /// <summary>
        /// Permet de modifier les propriétés de Labels avec différents paramètres
        /// </summary>
        /// <param name="label"> C'est le label </param>
        /// <param name="texte"></param>
        /// <param name="largeur"></param>
        /// <param name="hauteur"></param>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <returns></returns>
        public Label CreationLabel(Label label, string texte, int largeur, int hauteur, int positionX, int positionY)
        {
            label.Text = texte;
            label.Size = new Size(largeur, hauteur);
            label.Location = new Point(positionX, positionY);

            return label;
        }
    }
}
