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
    public class TapeTaupeEnigmaPanel : EnigmaPanel
    {       
        //déclaration du timer, de l'image, des deux randoms et de la liste de picturebox
        private Timer tJeuTapeTaupe = new Timer();
        PictureBox pbxTaupe = new PictureBox();
        Random RandoPosition = new Random();
        Random RandoDifficulte = new Random();
        List<PictureBox> Trous;

        //déclaration des varaibles
        private int iCompteur = 0;
        private int iAxeX;
        private int iAxey;
        private int iScore;
        private int iVitesse;
        private int iTemps = 0;
        private string strPerdu = "Dommage, vous avez mis trop de temps ou vous avez cliquez sur un lapin. Appuyer sur OK pour recommencer";
        DialogResult Resultat;

        //Constructeur par défaut
        public TapeTaupeEnigmaPanel()
        {
            //initialisation de la liste
            Trous = new List<PictureBox>();

            //Création du timer et lancement
            tJeuTapeTaupe.Interval = 1;
            tJeuTapeTaupe.Tick += new EventHandler(timer_tJeuTapeTaupe);
            tJeuTapeTaupe.Start();
            
            //Création de la picturebox qui contient l'image
            pbxTaupe.Width = 50;
            pbxTaupe.Height = 50;
            pbxTaupe.Location = new Point(0, 0);
            pbxTaupe.Enabled = false;
            pbxTaupe.Visible = false;
            //pbxTaupe.Image = 
            pbxTaupe.BackColor = Color.Aqua;
            Controls.Add(pbxTaupe);
            pbxTaupe.BringToFront();

            //Création de l'événement du clic sur l'image
            pbxTaupe.MouseClick += new MouseEventHandler(pbxTaupe_Click);

            //Affectation de la difficulter (vitesse d'apparition de l'image)
            iVitesse = RandoDifficulte.Next(200, 250); // ~4-5 secondes
            /*
            this.Cursor = new Cursor(Properties.Resources.gifessai.GetHicon());
            Graphics graphics = this.CreateGraphics();
            Rectangle rectangle = new Rectangle( new Point(10,10), new Size(pbxTaupe.Width, pbxTaupe.Height));
            Cursor.DrawStretched(graphics, rectangle);
            this.Cursor.Size = new Size(2, 2);*/

        }

        //Evenement du clic sur la picturebox
        private void pbxTaupe_Click(object sender, MouseEventArgs e)
        {
            //si taupe, augmentation du score et désactivation du panel
            iScore++;
            pbxTaupe.Enabled = false;
            pbxTaupe.Visible = false;

            //si lapin, appel de la fonction perdu()

        }

        private void Perdu()
        {
            //Arret du timer, réinitialisation des variables et désctivation de la picturebox
            tJeuTapeTaupe.Stop();
            iScore = 0;
            iCompteur = 0;
            iTemps = 0;
            pbxTaupe.Enabled = false;
            pbxTaupe.Visible = false;

            //Affichage de la message box et atribuation dans une variable
            Resultat = MessageBox.Show(strPerdu, "Perdu", MessageBoxButtons.OK);

            //test pour savoir si le bouton OK de la message box à été pressé
            if (Resultat == DialogResult.OK)
            {
                tJeuTapeTaupe.Start();
            } 
        }

        //Evenement du timer
        private void timer_tJeuTapeTaupe(object sender, EventArgs e)
        {
            //Incrémentaion de compteurs de temps
            iCompteur++;
            iTemps++;

            //Si le joueur à fais plus de ~ 17 secondes, on le fais recommencer
            if (iTemps == 850)
            {
                //Appele de la fonction perdu
                Perdu();
            }

            /*Si le compteur est à 150, il va afficher la picturebox à un endroit
              aléatoire grace au random et l'activer. Sinon si le compteur est égal
              avec la vitesse, il va le remettre juste avant la première condition.
              Grace à cela, au prochain passsage dans l'évenement du timer, il va
              remettre le panel à un autre endroit*/
            if (iCompteur == 150) //~3 secondes
            {
                //Affectation de la position calculer à l'aide de la largeur et de la hauteur de "l'ecran" de jeu
                iAxeX = RandoPosition.Next(0, Width - pbxTaupe.Width);
                iAxey = RandoPosition.Next(0, Height - pbxTaupe.Height);
                pbxTaupe.Location = new Point(iAxeX, iAxey);

                //Activation du panel
                pbxTaupe.Enabled = true;
                pbxTaupe.Visible = true;
            } 
            else if (iCompteur == iVitesse)
            {
                iCompteur = 149;
            }

            /*Si le score est à 10 (si le joueur à cliquer 10 fois sur une image, 
              on arrete le timer et on affiche la réponse à l'aide d'un pop-up*/
            if (iScore == 10)
            {
                tJeuTapeTaupe.Stop();
                MessageBox.Show("La réponse est \"taupe\"", "Réponse", MessageBoxButtons.OK);
            }
        }
    }
}
