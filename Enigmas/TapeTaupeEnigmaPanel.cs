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
        //déclaration du timer, de l'image, des trois randoms
        private Timer tJeuTapeTaupe = new Timer();
        PictureBox pbxTaupe = new PictureBox();
        Random RandoPosition = new Random();
        Random RandoDifficulte = new Random();
        Random RandoAnimal = new Random();

        //déclaration des variables
        private int iCompteur = 0;
        private int iAxeX;
        private int iAxeY;
        private int iScore;
        private int iVitesse;
        private int iTemps = 0;
        private int iAnimal;
        private bool bAnimal = false;
        private string strPerdu = "Dommage, vous avez mis trop de temps ou vous avez cliquez sur un chat.";

        //Constructeur par défaut
        public TapeTaupeEnigmaPanel()
        {
            //Création du timer et lancement
            tJeuTapeTaupe.Interval = 1;
            tJeuTapeTaupe.Tick += new EventHandler(timer_tJeuTapeTaupe);
            
            //Création de la picturebox qui contient l'image
            pbxTaupe.Width = 100;
            pbxTaupe.Height = 100;
            pbxTaupe.Location = new Point(0, 0);
            pbxTaupe.Enabled = false;
            pbxTaupe.Visible = false;
            Controls.Add(pbxTaupe);
            pbxTaupe.BringToFront();

            //Création de l'événement du clic sur l'image
            pbxTaupe.MouseClick += new MouseEventHandler(pbxTaupe_Click);

            //Affectation de la difficulter (vitesse d'apparition de l'image)
            iVitesse = RandoDifficulte.Next(50, 100); // ~1-2 secondes      
        }

        private void Initialiser()
        {
            iTemps = 0;
            iCompteur = 0;
            iScore = 0;
            tJeuTapeTaupe.Start();
        }

        public override void Load()
        {
            Initialiser();
        }

        public override void Unload()
        {
            tJeuTapeTaupe.Stop();
        }

        //Evenement du clic sur la picturebox
        private void pbxTaupe_Click(object sender, MouseEventArgs e)
        {
            //Si c'est une souris, augmentation du score et désactivation du panel, sinon on appel de la méthode perdu()
            if (bAnimal == false)
            {
                iScore++;
                pbxTaupe.Enabled = false;
                pbxTaupe.Visible = false;
            }
            else
            {
                Perdu();
            }

        }

        private void Perdu()
        {

            //Arret du timer, réinitialisation des variables et désactivation de la picturebox
            tJeuTapeTaupe.Stop();
            iScore = 0;
            iCompteur = 0;
            iTemps = 0;
            pbxTaupe.Enabled = false;
            pbxTaupe.Visible = false;

            DialogResult resultat = MessageBox.Show(strPerdu, "Perdu");            

            //test pour savoir si le bouton OK de la messagebox à été pressé
            if (resultat == DialogResult.OK)
            {
                Initialiser();
            }
        }

        //Evenement du timer de jeu
        private void timer_tJeuTapeTaupe(object sender, EventArgs e)
        {
            //Incrémentaion des compteurs
            iCompteur++;
            iTemps++;

            //Si le joueur à fais plus de ~ 17 secondes, on le fais recommencer
            if (iTemps == 1000)
            {
                //Appel de la méthode perdu()
                Perdu();
            }          

            /*Si le compteur est égal à la vitesse, on determine le type de
             l'animal et le positionnement de la picturebox. Ensuite, on l'active*/
            if (iCompteur == iVitesse)
            {
                iAnimal = RandoAnimal.Next(0, 8);
                iAxeX = RandoPosition.Next(0, Width - pbxTaupe.Width);
                iAxeY = RandoPosition.Next(0, Height - pbxTaupe.Height);

                //si iAnimal est égal à 2, c'est un chat, sinon c'est une souris. On ajoute l'image voulu ensuite
                if (iAnimal == 2)
                {
                    bAnimal = true;
                    pbxTaupe.BackgroundImage = Properties.Resources.chat;
                } else {
                    pbxTaupe.BackgroundImage = Properties.Resources.souris;
                    bAnimal = false;
                }
               
                this.pbxTaupe.Location = new Point(iAxeX, iAxeY);
                this.pbxTaupe.BringToFront();

                pbxTaupe.Visible = true;
                pbxTaupe.Enabled = true;
                iCompteur = 0;
            }

            /*Si le score est à 8 (si le joueur à cliquer 8 fois sur une image, 
              on arrete le timer et on affiche la réponse à l'aide d'un pop-up*/
            if (iScore == 8)
            {
                tJeuTapeTaupe.Stop();
                if (MessageBox.Show("La réponse est \"Souris\"", "Réponse", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    Initialiser();
                }
            }
        }
    }
}
