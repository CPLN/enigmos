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
        Timer Timer1 = new Timer();

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
            Timer1.Interval = 300; // 1 milliseconde
            Timer1.Tick += new EventHandler(Timer_Tick);
            Timer1.Enabled = true;

            Triangle triangle = new Triangle(100, 50); // Création du panel qui sera un triangle, avec une base de 100 et un sommet à 50 (en haut milieu du panel)
            triangle.Location = new Point(350, 350);
            AjoutDansListe(triangle);
            
            ellipse1.Location = new Point(350, 350);
            ellipse1.Size = new Size(200, 200);
            AjoutDansListe(ellipse1);

            Controls.Add(btnDifferent);
            btnDifferent.Location = new Point(421, 111);
            btnDifferent.Text = "Différent";
            btnDifferent.Click += new EventHandler(ClicSurBouton);
            
            Controls.Add(btnIdentique);
            btnIdentique.Location = new Point(321, 111);
            btnIdentique.Text = "Identique";
            btnIdentique.Click += new EventHandler(ClicSurBouton);

            Carre1 = AjoutPanelCarre(100, 250, 250, Carre1);
            Carre1.BackColor = Color.Blue;

            Carre2 = AjoutPanelCarre(100, 350, 350, Carre2);
            Carre2.BackColor = Color.Black;

            Rectangle1 = AjoutPanelRectangle(100, 200, 350, 350, Rectangle1);
            Rectangle1.BackColor = Color.Beige;

            Rectangle2 = AjoutPanelRectangle(100, 200, 350, 350, Rectangle2);
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
                //Incrémente le compteur 
                Compteur++;
                //Arrête le timer après avoir afficher les 2 premières formes
                Timer1.Stop();
            }

        }

        //Evènement lorsqu'il y a un clic sur un bouton
        private void ClicSurBouton(object sender, EventArgs e)
        {
            //Donner à Actuel (forme actuellement afficher sur l'appli) la valeur de lstForme à la position du Compteur
            Panel Actuel = lstForme[Compteur -1];
            //Panel précédent va prendre la valeur de la forme précédemment afficher
            Panel Precedent = lstForme[Compteur - 2];
            //Prochain va prendre la valeur du prochain élément qui va s'afficher
            Panel Prochain = lstForme[Compteur];

            Compteur++;

            //Est-ce que c'est bien btnDifferent qui à été cliqué
            if (Convert.ToString(sender) == "Différent")
            {
                //Supprime la forme actuelle
                Controls.Remove(Actuel);
                if (Compteur > 1)
                {
                    //Regarde si la couleur de la forme actuelle est la même que la précédente, si elle est pareille il a perdu et recommence
                    if (Precedent.BackColor == Actuel.BackColor)
                    {
                        //Supprime la forme actuelle
                        Controls.Remove(Actuel);
                        //Remet le compteur à zéro
                        Compteur = 0;
                        //Relance le timer ce qui fait tout recommencer
                        Timer1.Start();
                    }
                    else
                    {
                        //Sinon il supprime l'actuelle et ajoute la prochaine forme
                        Controls.Remove(Actuel);
                        Controls.Add(Prochain);
                    }
                }
            }
            else
            {
                if (Compteur > 1)
                {
                    if (Actuel.BackColor == Precedent.BackColor)
                    {
                        Controls.Add(Prochain);
                        Controls.Remove(Actuel);
                    }
                    else
                    {
                        //Supprime la forme actuelle
                        Controls.Remove(Actuel);
                        //Remet le compteur à zéro
                        Compteur = 0;
                        //Relance le timer ce qui fait tout recommencer
                        Timer1.Start();
                    }
                }
            }
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
