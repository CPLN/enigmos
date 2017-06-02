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
        int Compteur = 0;
        int CompteurForme = 0;
        int CompteurCouleur = 1;
        Timer Timer1 = new Timer();

        Label lblForme = new Label();
        Label lblCouleur = new Label();

        List<Panel> lstForme = new List<Panel>(); // Création d'une liste qui contiendra tous les panels (formes)

        Button btnDifferent = new Button(); // Création du bouton différent
        Button btnIdentique = new Button(); // Création du bouton identique

        Panel Carre1 = new Panel(); // Création du panel qui sera carré
        Panel Carre2 = new Panel(); // Création d'un deuxième panel qui sera carré

        Panel Rectangle1 = new Panel();
        Panel Rectangle2 = new Panel();

        Ellipse ellipse1 = new Ellipse();
        Ellipse ellipse2 = new Ellipse();

        public FormesEnFoliesEnigmaPanel()
        {
            lblCouleur.Text = "COULEUR";
            lblCouleur.Location = new Point(371, 100);

            lblForme.Text = "FORME";
            lblForme.Location = new Point(371, 100);

            Timer1.Interval = 300; // 1 milliseconde
            Timer1.Tick += new EventHandler(Timer_Tick);
            Timer1.Enabled = true;

            Triangle triangle = new Triangle(100, 50); // Création du panel qui sera un triangle, avec une base de 100 et un sommet à 50 (en haut milieu du panel)
            triangle.Location = new Point(350, 350);
            AjoutDansListe(triangle);
            
            ellipse1.Location = new Point(350, 350);
            ellipse1.Size = new Size(400, 400);
            AjoutDansListe(ellipse1);

            Controls.Add(btnDifferent);
            btnDifferent.Location = new Point(421, 111);
            btnDifferent.Text = "Différent";
            btnDifferent.Width = 100;
            btnDifferent.Click += new EventHandler(ClicSurBouton);
            
            Controls.Add(btnIdentique);
            btnIdentique.Location = new Point(321, 111);
            btnIdentique.Text = "Identique";
            btnIdentique.Width = 100;
            btnIdentique.Click += new EventHandler(ClicSurBouton);

            Carre1 = AjoutPanelCarre(100, 250, 250, Carre1);
            Carre1.BackColor = Color.Blue;

            Carre2 = AjoutPanelCarre(100, 350, 350, Carre2);
            Carre2.BackColor = Color.Black;

            Rectangle1 = AjoutPanelRectangle(120, 210, 350, 350, Rectangle1);
            Rectangle1.BackColor = Color.Beige;

            Rectangle2 = AjoutPanelRectangle(120, 210, 350, 350, Rectangle2);
            Rectangle2.BackColor = Color.Chartreuse;
        }

        //Timer qui va afficher les 2 premières formes automatiquement
        private void Timer_Tick(object sender, EventArgs e)
        {
            if(Compteur <= 0)
            {
                //Affiche la première forme
                Controls.Add(lstForme[Compteur]);
                //Incrémente le compteur
                Compteur++;
            }
            else
            {
                //Ajoute la 2ème forme
                Controls.Add(lstForme[Compteur]);
                //Supprime la 1ère forme
                Controls.Remove(lstForme[Compteur -1]);
                //Ajoute le label forme en dessus des boutons
                Controls.Add(lblForme);
                //Incrémente le compteur 
                Compteur++;
                //Arrête le timer après avoir afficher les 2 premières formes
                Timer1.Stop();
            }

        }

        //Evènement lorsqu'il y a un clic sur un bouton
        private void ClicSurBouton(object sender, EventArgs e)
        {
            //On regarde si le CompteurForme est plus grand que le CompteurCouleur
            if(CompteurForme < CompteurCouleur)
            {
                //On test si le bouton qui à été appuyé est le bouton "différent"
                if(sender==btnDifferent)
                {
                    //Enlève le label Couleur qui doit être sur l'énigme
                    Controls.Remove(lblCouleur);
                    //Ajoute le label Forme
                    Controls.Add(lblForme);
                    //Si la largeur de la forme précédente et celle actuellement identique alors le test est réussi
                    if (lstForme[Compteur - 1].Width == lstForme[Compteur - 2].Width)
                    {
                        //Si ils sont égaux alors on va enlever la forme actuelle
                        Controls.Remove(lstForme[Compteur - 1]);
                        //On remet le compteur à zéro de la liste des formes
                        Compteur = 0;
                        //On remet le compteur Forme à zéro
                        CompteurForme = 0;
                        //On remet le compteur couleur à 1
                        CompteurCouleur = 1;
                        //On relance le timer1
                        Timer1.Start();
                    }
                    else //Si le test est faut on va faire tout ce qu'il y a en dessous
                    {
                        //On ajoute la prochaine forme de la liste
                        Controls.Add(lstForme[Compteur]);
                        //On supprime celle qu'il y a actuellement
                        Controls.Remove(lstForme[Compteur - 1]);
                        //On augment le compteur forme de 2
                        CompteurForme += 2;
                    }
                }
                else //Si le bouton qui à été cliqué n'est pas le bouton "différent" on va faire tout ce qu'il y a dans le "else"
                {
                    //On test si la largeur de la forme précédente est égale à la forme actuelle
                    if(lstForme[Compteur - 1].Width == lstForme[Compteur - 2].Width)
                    {
                        Controls.Add(lstForme[Compteur]);
                        Controls.Remove(lstForme[Compteur - 1]);
                    }
                    else
                    {
                        Controls.Remove(lstForme[Compteur - 1]);
                        Compteur = 0;
                        Timer1.Start();
                    }
                }
                        
            }
            else
            {
                
                if(sender==btnDifferent)
                {
                    Controls.Remove(lblForme);
                }
            }

            Compteur++;
        }

        public Panel AjoutPanelCarre(int cote, int positionX, int positionY, Panel p)
        {
            p.Size = new Size(cote, cote);
            p.Location = new Point(positionX, positionY);
            AjoutDansListe(p);
            
            return p;
        }

        public Panel AjoutPanelRectangle(int hauteur, int largeur, int positionX, int positionY, Panel p)
        {
            p.Size = new Size(largeur, hauteur);
            p.Location = new Point(positionX, positionY);
            AjoutDansListe(p);

            return p;
        }

        public Panel AjoutDansListe(Panel p)
        {
            lstForme.Add(p);
            return p;
        }

    }
}
