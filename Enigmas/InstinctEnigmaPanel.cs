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
        private int iNumeroImage;
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
           pnlImage.BackgroundImage = CliqueRandom();
           
       }
       private void Random2_Click(object sender, EventArgs e)
       {
           pnlImage.BackgroundImage = CliqueRandom();
       }
       private void Random3_Click(object sender, EventArgs e)
       {
           pnlImage.BackgroundImage = CliqueRandom();
       }
       
        //Constructeur par défaut qui initiliase les proprieté de la première fenêtre.
        public InstinctEnigmaPanel()
        {
           
         
            bool bFindeJeu = false;
            lblTexte.Text = "Vous êtes retrouvez dans une maison inconnue en vous réveillant";
            lblTexte.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
            lblTexte.Size = new Size(800, 30);
            lblTexte.Location = new Point(100, 0);
            
            Controls.Add(lblReponse);
            Controls.Add(lblTexte);
            Controls.Add(btnChoix1);
            Controls.Add(btnChoix2);
            Controls.Add(btnChoix3);
            pnlImage.Width = 800;
            pnlImage.Height = 600;
            //pnlImage.BackColor = Color.BlueViolet;
            pnlImage.BackgroundImageLayout = ImageLayout.Center;
            pnlImage.BackgroundImageLayout = ImageLayout.Zoom;
            pnlImage.BackgroundImage = Properties.Resources.salle_de_bain;
            Controls.Add(pnlImage);
            Image imageDepart1 = Properties.Resources.cuisine;
            Image imageDepart2 = Properties.Resources.salon;
            Image imageDepart3 = Properties.Resources.toilette;
            Image[] aImageDeBase = new Image []{imageDepart1, imageDepart2, imageDepart3};
            btnChoix1.FlatStyle = FlatStyle.Flat;
            btnChoix2.FlatStyle = FlatStyle.Flat;
            btnChoix3.FlatStyle = FlatStyle.Flat;
            btnChoix1.FlatAppearance.BorderColor = Color.White;

            btnChoix1.Location = new Point(200, 200);
            btnChoix2.Location = new Point(320, 100);
            btnChoix3.Location = new Point(400, 200);





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

            
            Controls.Add(pnlImage);

            // Image[] images = new Image[2]{Properties.Resources.depart, Properties.Resources.depart, Properties.Resources.depart };



           






        }
        void btnChoix1rouge_MouseHover(object sender, EventArgs e)
        {
            btnChoix1.BackColor = Color.Red;
        }
        void btnChoix1jaune_MouseHover(object sender, EventArgs e)
        {
            btnChoix1.BackColor = Color.Yellow;
        }
        void btnChoix1vert_MouseHover(object sender, EventArgs e)
        {
            btnChoix1.BackColor = Color.Green;
        }
        void btnChoix1_MouseLeave(object sender, EventArgs e)
        {
            this.btnChoix1.BackColor = Color.White;
        }

        void btnChoix2rouge_MouseHover(object sender, EventArgs e)
        {
            btnChoix2.BackColor = Color.Red;
        }
        void btnChoix2jaune_MouseHover(object sender, EventArgs e)
        {
            btnChoix2.BackColor = Color.Yellow;
        }
        void btnChoix2vert_MouseHover(object sender, EventArgs e)
        {
            btnChoix2.BackColor = Color.Green;
        }
        void btnChoix2_MouseLeave(object sender, EventArgs e)
        {
            this.btnChoix2.BackColor = Color.White;
        }

        void btnChoix3rouge_MouseHover(object sender, EventArgs e)
        {
            btnChoix3.BackColor = Color.Red;
        }
        void btnChoix3jaune_MouseHover(object sender, EventArgs e)
        {
            btnChoix3.BackColor = Color.Yellow;
        }
        void btnChoix3vert_MouseHover(object sender, EventArgs e)
        {
            btnChoix3.BackColor = Color.Green;
        }
        void btnChoix3_MouseLeave(object sender, EventArgs e)
        {
            this.btnChoix3.BackColor = Color.White;
        }


        //fonction qui permet de générer alétoirement une image du tableau d'image.
        private Image CliqueRandom()
        {
            
            
            Image depart = Properties.Resources.salle_de_bain;
            Image imageDefaite = Properties.Resources.bluescreen;
            Image imageDepart1 = Properties.Resources.cuisine;
            Image imageDepart2 = Properties.Resources.chambre;
            Image imageDepart3 = Properties.Resources.Etage_2;
            Image imageMilieu4 = Properties.Resources.étage;
            Image imageMilieu5 = Properties.Resources.cave;
            Image imageMilieu6 = Properties.Resources.escalier;
            Image imageFin = Properties.Resources.sortie;
            //Image imageDepart4 = Properties.Resources.assassinat;
            //Image imageDepart5 = Properties.Resources.buanderie;
            //Image imageDepart6 = Properties.Resources.grenier;
            //Image imageDepart7 = Properties.Resources.maxresdefault;
            //Image imageDepart8 = Properties.Resources.piscine;
            //Image imageDepart9 = Properties.Resources.sortie;

            Image[] aImageDeBase = new Image[] {depart, imageDefaite,imageDepart1, imageDepart2, imageDepart3, imageMilieu4, imageMilieu5, imageMilieu6, imageFin};
            Image imgFinaleDepart;
            // on test si le premier affichage a été fait.
            if (iEtape == 0)
            {
                
                iEtape = 1;
                random = randomNombre.Next(1, 4);
                if (random == 1)
                {
                    GenerationButton(iEtape);
                    btnChoix1.Location = new Point(10, 200);
                    btnChoix2.Location = new Point(100, 100);
                    btnChoix3.Location = new Point(400, 200);
                    lblTexte.Text = "Vous arrivez dans la cuisine";
                    iNumeroImage = 1;
                    return imgFinaleDepart = aImageDeBase[2];
                    

                }
                if (random == 2)
                {
                    GenerationButton(iEtape);
                    btnChoix1.Location = new Point(150, 200);
                    btnChoix2.Location = new Point(100, 100);
                    btnChoix3.Location = new Point(400, 200);
                    lblTexte.Text = "Vous arrivez dans le salon";
                     iNumeroImage = 2;
                    return imgFinaleDepart = aImageDeBase[3];
         
                }
                if (random == 3)
                {
                    GenerationButton(iEtape);
                    btnChoix1.Location = new Point(100, 200);
                    btnChoix2.Location = new Point(10, 100);
                    btnChoix3.Location = new Point(40, 200);
                    lblTexte.Text = "Vous sentez une flatulence : vous êtes au WC !";
                     iNumeroImage = 3;
                    return imgFinaleDepart = aImageDeBase[4];
         
                }
            }
            if(iEtape == 1)
            {
               
                switch(iNumeroImage)
                {
                    case 1 :
                        iNumeroImage = 4;
                        random = randomNombre.Next(1, 4);
                            if (random == 1)
                                 {
                                iEtape = 0;
                                return imgFinaleDepart = aImageDeBase[0];

                                 }
                            if (random == 2)
                                {
                                    iEtape = 2;
                                 return imgFinaleDepart = aImageDeBase[5];
                                }
                            if (random == 3)
                                {
                                    
                               
                                DialogResult perdu = MessageBox.Show("Vous avez perdu", "Yo", MessageBoxButtons.OK);
                                {
                                    Application.Exit();
                                }
                                return imgFinaleDepart = aImageDeBase[1];
                                }
                     break;
                    case 2:
                     iNumeroImage = 5;
                               random = randomNombre.Next(1, 4);
                            if (random == 1)
                                 {
                                iEtape = 0;
                                return imgFinaleDepart = aImageDeBase[0];

                                 }
                            if (random == 2)
                                {
                                    iEtape = 2;
                                 return imgFinaleDepart = aImageDeBase[6];
                                }
                            if (random == 3)
                                {
                                    DialogResult perdu = MessageBox.Show("Vous avez perdu", "Yo", MessageBoxButtons.OK);
                                    if (perdu == DialogResult.OK)
                                    {
                                        
                                        Application.Exit();
                                    }
                                return imgFinaleDepart = aImageDeBase[1];
                                }
                     break;
                    case 3:
                     iNumeroImage = 6;
                               random = randomNombre.Next(1, 4);
                            if (random == 1)
                                 {
                                iEtape = 0;
                                return imgFinaleDepart = aImageDeBase[0];

                                 }
                            if (random == 2)
                                {
                                    iEtape = 2;
                                 return imgFinaleDepart = aImageDeBase[7];
                                }
                            if (random == 3)
                                {
                                    DialogResult perdu = MessageBox.Show("Vous avez perdu", "Yo", MessageBoxButtons.OK);

                                  if(perdu == DialogResult.OK)
                                  {
                                      Application.Exit();
                                  }
                                return imgFinaleDepart = aImageDeBase[1];
                                }
                     break;

                }
            }
            if(iEtape == 2)
            {
                
                random = randomNombre.Next(1, 4);
                if (random == 1)
                {
                    lblTexte.Text = "Vous avez gagné !";
                    return imgFinaleDepart = aImageDeBase[8];

                }
                if (random == 2)
                {
                    lblTexte.Text = "Vous arrivez dans le salon";
                    iNumeroImage = 2;
                    return imgFinaleDepart = aImageDeBase[3];
                }
                if (random == 3)
                {
                    DialogResult perdu = MessageBox.Show("Vous avez perdu", "Yo", MessageBoxButtons.OK);

                    if (perdu == DialogResult.OK)
                    {
                        Application.Exit();
                    }
                    return imgFinaleDepart = aImageDeBase[1];
                }
            }

            return null;

            
        }

        // Fonction permettant de générer une couleur de fond pour chaque aléatoirement à chaque affichage
        private void GenerationButton(int etape)
        {
            int i;
            int randomCouleur;
            int iButton1 = 0;
            int iButton2 = 0;
            int iButton3 = 0;
           
            if(etape == 1)
            {
                
                for(i = 0; i < 3; i++)
                {
                  if(i == 0)
                    {
                        randomCouleur = randomNombre.Next(0, 3);
                        iButton1 = randomCouleur;
                        switch(iButton1)
                        {
                                case 0:
                                btnChoix1.BackColor = Color.Red;
                                break;
                                case 1:
                                btnChoix1.BackColor = Color.Yellow;
                                break;
                                case 2:
                                btnChoix1.BackColor = Color.Green;
                                break;
                        }
                        
                    }
                  if(i == 1)
                    {
                        randomCouleur = randomNombre.Next(0, 3);
                        iButton2 = randomCouleur;
                        while (iButton2 == iButton1)
                        {
                            randomCouleur = randomNombre.Next(0, 3);
                            iButton2 = randomCouleur;
                        }
                        switch (iButton2)
                        {
                            case 0:
                                btnChoix2.BackColor = Color.Red;
                                break;
                            case 1:
                                btnChoix2.BackColor = Color.Yellow;
                                break;
                            case 2:
                                btnChoix2.BackColor = Color.Green;
                                break;
                        }
                        
                    }
                  if(i == 2)
                    {
                        randomCouleur = randomNombre.Next(0, 3);
                        iButton3 = randomCouleur;
                        while(iButton3 == iButton1 || iButton3 == iButton2)
                        {
                            randomCouleur = randomNombre.Next(0, 3);
                            iButton3 = randomCouleur;
                        }
                        switch (iButton3)
                        {
                            case 0:
                                btnChoix3.BackColor = Color.Red;
                                break;
                            case 1:
                                btnChoix3.BackColor = Color.Yellow;
                                break;
                            case 2:
                                btnChoix3.BackColor = Color.Green;
                                break;
                        }
                        
                    }

                }
               
                if (btnChoix1.BackColor == Color.Red)
                {
                    btnChoix1.MouseHover += new EventHandler(btnChoix1rouge_MouseHover);
                    btnChoix1.MouseLeave += new EventHandler(btnChoix1_MouseLeave);
                }
               
                if (btnChoix1.BackColor == Color.Yellow)
                {
                    btnChoix1.MouseHover += new EventHandler(btnChoix1jaune_MouseHover);
                    btnChoix1.MouseLeave += new EventHandler(btnChoix1_MouseLeave);
                }
               
                if (btnChoix1.BackColor == Color.Green)
                {
                    btnChoix1.MouseHover += new EventHandler(btnChoix1vert_MouseHover);
                    btnChoix1.MouseLeave += new EventHandler(btnChoix1_MouseLeave);
                }
            

                if (btnChoix2.BackColor == Color.Red)
                {
                    btnChoix2.MouseHover += new EventHandler(btnChoix2rouge_MouseHover);
                    btnChoix2.MouseLeave += new EventHandler(btnChoix2_MouseLeave);
                }
                if (btnChoix2.BackColor == Color.Yellow)
                {
                    btnChoix2.MouseHover += new EventHandler(btnChoix2jaune_MouseHover);
                    btnChoix2.MouseLeave += new EventHandler(btnChoix2_MouseLeave);
                }
              
                if (btnChoix2.BackColor == Color.Green)
                {
                    btnChoix2.MouseHover += new EventHandler(btnChoix2vert_MouseHover);
                    btnChoix2.MouseLeave += new EventHandler(btnChoix2_MouseLeave);
                }
               
                

                if (btnChoix3.BackColor == Color.Red)
                {
                    btnChoix3.MouseHover += new EventHandler(btnChoix3rouge_MouseHover);
                    btnChoix3.MouseLeave += new EventHandler(btnChoix3_MouseLeave);
                }
                if (btnChoix3.BackColor == Color.Yellow)
                {
                    btnChoix3.MouseHover += new EventHandler(btnChoix3jaune_MouseHover);
                    btnChoix3.MouseLeave += new EventHandler(btnChoix3_MouseLeave);
                }
                if (btnChoix3.BackColor == Color.Green)
                {
                    btnChoix3.MouseHover += new EventHandler(btnChoix3vert_MouseHover);
                    btnChoix3.MouseLeave += new EventHandler(btnChoix3_MouseLeave);
                }
                
            }
          

            
            


        }
        
           
        
    }
}
