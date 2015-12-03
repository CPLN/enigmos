using System.Drawing;
using System.Windows.Forms;
using System;
using System.Timers;
using Cpln.Enigmos.Exceptions;
using Cpln.Enigmos.Utils;

using System.Collections.Generic;

namespace Cpln.Enigmos.Enigmas
{
       
    public class InstinctEnigmaPanel : EnigmaPanel
    {

        private int random;
        private int iEtape;
        //création des buttons et des panels
        Label lblReponse = new Label();
        Label lblTexte = new Label();
        Panel pnlImage = new Panel();
        Button btnChoix1 = new Button();
        Button btnChoix2 = new Button();
        Button btnChoix3 = new Button();
        Random randomNombre = new Random();
        
        //Evenement des clicks de boutons 
       private void Random_Click(object sender, EventArgs e)
       {
           pnlImage.BackgroundImage = CliqueRandom(random);
           
       }
       private void Random2_Click(object sender, EventArgs e)
       {
           pnlImage.BackgroundImage = CliqueRandom(random);
       }
       private void Random3_Click(object sender, EventArgs e)
       {
           pnlImage.BackgroundImage = CliqueRandom(random);
       }
       
        //Constructeur par défaut qui initiliase les proprieté de la première fenêtre.
        public InstinctEnigmaPanel()
        {
           
         
            bool bFindeJeu = false;
            lblTexte.Text = "Vous vous réveillez dans une baignoire.";
            lblTexte.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
            lblTexte.Size = new Size(400, 30);
            lblTexte.Location = new Point(470, 0);
            btnChoix1.Location = new Point(200, 200);
            btnChoix2.Location = new Point(320, 100);
            btnChoix3.Location = new Point(400, 200);
            Controls.Add(lblReponse);
            Controls.Add(lblTexte);
            Controls.Add(btnChoix1);
            Controls.Add(btnChoix2);
            Controls.Add(btnChoix3);
            pnlImage.Width = 800;
            pnlImage.Height = 600;
            //pnlImage.BackColor = Color.BlueViolet;

            pnlImage.BackgroundImage = Properties.Resources.depart;
            Controls.Add(pnlImage);
            Image imageDepart1 = Properties.Resources.cuisine;
            Image imageDepart2 = Properties.Resources.salon;
            Image imageDepart3 = Properties.Resources.toilette;
            Image[] aImageDeBase = new Image []{imageDepart1, imageDepart2, imageDepart3};
            btnChoix1.FlatStyle = FlatStyle.Flat;
            btnChoix2.FlatStyle = FlatStyle.Flat;
            btnChoix3.FlatStyle = FlatStyle.Flat;
            btnChoix1.FlatAppearance.BorderColor = Color.White;
           
           
        
  
    


            /*lblReponse.Text = "Réponse A : \n" + "Réponse B : \n" + "Réponse C : \n";
            lblReponse.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
            lblReponse.Size = new Size(150, 70);
            lblReponse.Location = new Point(0, 0);*/
           
           /*while (!bFindeJeu)
           {
           



           }*/




            btnChoix1.Click += new EventHandler(Random_Click);
            btnChoix2.Click += new EventHandler(Random2_Click);
            btnChoix3.Click += new EventHandler(Random3_Click);
            
            
           
      
           Controls.Add(lblReponse);
            Controls.Add(lblTexte);

            pnlImage.Width = 800;
            pnlImage.Height = 600;
           //pnlImage.BackColor = Color.BlueViolet;

            pnlImage.BackgroundImage = Properties.Resources.depart;
            Controls.Add(pnlImage);

           // Image[] images = new Image[2]{Properties.Resources.depart, Properties.Resources.depart, Properties.Resources.depart };

         
            
            

            
            



            
        }

        //fonction qui permet de générer alétoirement une image du tableau d'image.
        private Image CliqueRandom(int random)
        {
           
            Image imageDepart1 = Properties.Resources.cuisine;
            Image imageDepart2 = Properties.Resources.salon;
            Image imageDepart3 = Properties.Resources.toilette;
            //Image imageDepart4 = Properties.Resources.assassinat;
            //Image imageDepart5 = Properties.Resources.buanderie;
            //Image imageDepart6 = Properties.Resources.grenier;
            //Image imageDepart7 = Properties.Resources.maxresdefault;
            //Image imageDepart8 = Properties.Resources.piscine;
            //Image imageDepart9 = Properties.Resources.sortie;

            Image[] aImageDeBase = new Image[] { imageDepart1, imageDepart2, imageDepart3};
            Image imgFinaleDepart;
            // on test si le premier affichage a été fait.
            if (iEtape == 0)
            {
                iEtape++;
                random = randomNombre.Next(1, 4);
                if (random == 1)
                {
                    return imgFinaleDepart = aImageDeBase[0];
                }
                if (random == 2)
                {
                    return imgFinaleDepart = aImageDeBase[1];
                }
                if (random == 3)
                {
                    return imgFinaleDepart = aImageDeBase[2];
                }
            }
            else
            {

            }

            return null;

            
        }

        
           
        
    }
}
