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
        private int iNombreRandom = 0;
        //création des images à l'appel du constructeur
        Image depart = Properties.Resources.salle_de_bain;
        Image imageDefaite = Properties.Resources.bluescreen;
        Image imageDepart1 = Properties.Resources.Etage_2;
        Image imageDepart2 = Properties.Resources.chambre;
        Image imageDepart3 = Properties.Resources.étage;
        Image imageMilieu4 = Properties.Resources.escalier;
        Image imageMilieu5 = Properties.Resources.salon;
        Image imageMilieu6 = Properties.Resources.Salon2;
        Image imageFin = Properties.Resources.cave;

        private bool iLock1 = false;
        private bool iLock2 = false; //Ces variables permettent de ne pas répéter l'action de générer à l'infini un chemin
        private bool iLock3 = false;
        private int iIndice1;
        private int iIndice2;
        private int iIndice3;
        private int iNumeroImage;
        private int random;
        private int iEtape1;
        private int iEtape2;
        private int iEtape3;
        private string strQuestionLocale1;
        private string strQuestionLocale2;
        private string strQuestionLocale3;


        //création des buttons et des panels
        Label lblReponse = new Label();
        Label lblTexte = new Label();
        Label lblCopyright = new Label();
        Panel pnlImage = new Panel();
       
        Random randomNombre = new Random();
        Label lblIndice = new Label();
        PictureBox pbxChoix1 = new PictureBox();
        PictureBox pbxChoix2 = new PictureBox();
        PictureBox pbxChoix3 = new PictureBox();




        ///Evenement des clicks de boutons 
        private void Random_Click(object sender, EventArgs e)
       {
           pnlImage.BackgroundImage = ChoixImage(iIndice1);
            iLock2 = false; //variable permettant de pas générer des indices à l'infini
            iLock1 = false; 
            iLock3 = false;
            TexteImage1();
            iEtape2 = iEtape1;
            iEtape3 = iEtape1;
            
       }
       private void Random2_Click(object sender, EventArgs e)
       {
           pnlImage.BackgroundImage = ChoixImage(iIndice2);
            iLock2 = false;
            iLock1 = false;
            iLock3 = false;
            TexteImage2();
            iEtape3 = iEtape2;
            iEtape1 = iEtape2;
            
        }
       private void Random3_Click(object sender, EventArgs e)
       {
           pnlImage.BackgroundImage = ChoixImage(iIndice3);
            iLock2 = false;
            iLock1 = false;
            iLock3 = false;
            TexteImage3();
           iEtape1 = iEtape3;
            iEtape2 = iEtape3;
           
        }
       
        //Constructeur par défaut qui initiliase les proprieté de la première fenêtre.
        public InstinctEnigmaPanel()
        {

            iEtape1 = 0;
            iEtape2 = 0;
            iEtape3 = 0;
            bool bFindeJeu = false;
            lblTexte.Text = "Vous vous retrouvez dans une maison inconnue en vous réveillant";
            lblIndice.Text = "Cherchez les chemins possibles sur l'image et sortez de la maison. Les chemins sont indiqués par des couleurs en les survolant";
            lblTexte.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
            lblTexte.Size = new Size(800, 30);
            lblTexte.Location = new Point(100, 0);
            lblIndice.Location = new Point(100, 570);
            lblIndice.Size = new Size(800, 30);
            lblCopyright.Location = new Point(680, 550);
            lblCopyright.Size = new Size(130, 30);
            lblCopyright.Text = "Romain Delbarre";

            pbxChoix1.Location = new Point(40, 200);
            pbxChoix2.Location = new Point(680, 300);
            pbxChoix3.Location = new Point(350, 170);
            pbxChoix1.Size = new Size(60, 150);
            pbxChoix2.Size = new Size(40, 200);
            pbxChoix3.Size = new Size(90, 200);

            Controls.Add(lblReponse);
            Controls.Add(lblTexte);
            Controls.Add(pbxChoix1);
            Controls.Add(pbxChoix2);
            Controls.Add(pbxChoix3);
            Controls.Add(lblCopyright);
            Controls.Add(lblIndice);
            pnlImage.Width = 800;
            pnlImage.Height = 600;
       
            pnlImage.BackgroundImageLayout = ImageLayout.Center;
            pnlImage.BackgroundImageLayout = ImageLayout.Zoom;
            pnlImage.BackgroundImage = Properties.Resources.salle_de_bain;
            Controls.Add(pnlImage);

           
 

            pbxChoix1.MouseHover += new EventHandler(btnChoix1rouge_MouseHover);
            pbxChoix1.MouseLeave += new EventHandler(btnChoix1MouseLeave);

            pbxChoix2.MouseHover += new EventHandler(btnChoix2jaune_MouseHover);
            pbxChoix2.MouseLeave += new EventHandler(btnChoix2MouseLeave);

            pbxChoix3.MouseHover += new EventHandler(btnChoix3vert_MouseHover);
            pbxChoix3.MouseLeave += new EventHandler(btnChoix3MouseLeave);


            
            pbxChoix1.Click += new EventHandler(Random_Click);
            pbxChoix2.Click += new EventHandler(Random2_Click);
            pbxChoix3.Click += new EventHandler(Random3_Click);
            
            
           
      
           Controls.Add(lblReponse);
            Controls.Add(lblTexte);

            pnlImage.Width = 800;
            pnlImage.Height = 600;
           

            
            Controls.Add(pnlImage);
            



        }


        // Evenement permettant de changer la couleur du button survolé et de générer une image
        void btnChoix1MouseLeave(object sender, EventArgs e)
        {
            pbxChoix1.BackColor = Color.White;
            
        }
        void btnChoix2MouseLeave(object sender, EventArgs e)
        {
            pbxChoix2.BackColor = Color.White;
            
        }
        void btnChoix3MouseLeave(object sender, EventArgs e)
        {
            pbxChoix3.BackColor = Color.White;
    
        }
        void btnChoix1rouge_MouseHover(object sender, EventArgs e)
        {
            pbxChoix1.BackColor = Color.Red;
            Cursor.Current = System.Windows.Forms.Cursors.Hand;
            LockIndice1();

          
        
            
        }
        void btnChoix1jaune_MouseHover(object sender, EventArgs e)
        {
            pbxChoix1.BackColor = Color.Yellow;
            Cursor.Current = System.Windows.Forms.Cursors.Hand;
            LockIndice1();
        }
        void btnChoix1vert_MouseHover(object sender, EventArgs e)
        {
            pbxChoix1.BackColor = Color.Green;
            Cursor.Current = System.Windows.Forms.Cursors.Hand;
            LockIndice1();
        }
        

        void btnChoix2rouge_MouseHover(object sender, EventArgs e)
        {
            pbxChoix2.BackColor = Color.Red;
            Cursor.Current = System.Windows.Forms.Cursors.Hand;
            LockIndice2();
        }
        void btnChoix2jaune_MouseHover(object sender, EventArgs e)
        {
            pbxChoix2.BackColor = Color.Yellow;
            Cursor.Current = System.Windows.Forms.Cursors.Hand;
            LockIndice2();
        }
        void btnChoix2vert_MouseHover(object sender, EventArgs e)
        {
            pbxChoix2.BackColor = Color.Green;
            Cursor.Current = System.Windows.Forms.Cursors.Hand;
            LockIndice2();
        }
       

        void btnChoix3rouge_MouseHover(object sender, EventArgs e)
        {
            pbxChoix3.BackColor = Color.Red;
            Cursor.Current = System.Windows.Forms.Cursors.Hand;
            LockIndice3();
        }
        void btnChoix3jaune_MouseHover(object sender, EventArgs e)
        {
            pbxChoix3.BackColor = Color.Yellow;
            Cursor.Current = System.Windows.Forms.Cursors.Hand;
            LockIndice3();
        }
        void btnChoix3vert_MouseHover(object sender, EventArgs e)
        {
            pbxChoix3.BackColor = Color.Green;
            Cursor.Current = System.Windows.Forms.Cursors.Hand;
            LockIndice3();
        }
        void btnChoix1_MouseLeave(object sender, EventArgs e)
        {
            this.pbxChoix1.BackColor = Color.White;
            Cursor.Current = System.Windows.Forms.Cursors.Default;
      
        }

        // même fonction pour chaque button : permet de générer l'image suivante aléatoirement et de créer un chemin
        private int CliqueRandom1()
        {


            // on test si le premier affichage a été fait.
            if (iEtape1 == 0)
            {

                GenerationButton(iEtape1);

                iEtape1 = 1;
                random = randomNombre.Next(1, 4);
                if (random == 1)
                {



                    GenerationButton(iEtape1);

                    iNumeroImage = 1;
                    iNombreRandom = 3;
                    
                    return iNombreRandom;



                }
                if (random == 2)
                {


                    GenerationButton(iEtape1);

                    iNumeroImage = 2;
                  
                    iNombreRandom = 4;
                    return iNombreRandom;

                }
                if (random == 3)
                {


                    GenerationButton(iEtape1);

                    iNumeroImage = 3;
                    
                    iNombreRandom = 5;
                    return iNombreRandom;

                }


            }
            if (iEtape1 == 1)
            {
                
                switch (iNumeroImage)
                {
                    
                    case 1:
                        GenerationButton(iEtape1);

                        random = randomNombre.Next(1, 4);
                        if (random == 1)
                        {

                            GenerationButton(iEtape1); 

                            iNombreRandom = 1;
                            return iNombreRandom;

                        }
                        if (random == 2)
                        {
                            GenerationButton(iEtape1);
                            iEtape1 = 2;
                         
                            iNombreRandom = 6;
                            return iNombreRandom;

                        }
                        if (random == 3)
                        {
                            GenerationButton(iEtape1);
                            iEtape1 = 0; // on retourne au point de départ
                            iNombreRandom = 0;
                           
                            return iNombreRandom;
                        }
                        else
                        {
                            iNombreRandom = 0;
                            return iNombreRandom;
                        }
                        break;
                    case 2:

                        GenerationButton(iEtape1);
                        random = randomNombre.Next(1, 4);
                        if (random == 1)
                        {

                            GenerationButton(iEtape1);

                            iNombreRandom = 1;
                            return iNombreRandom;

                        }
                        if (random == 2)
                        {
                            GenerationButton(iEtape1);
                            iEtape1 = 2;
                             iNombreRandom = 7;
                            return iNombreRandom;
                        }
                        if (random == 3)
                        {
                            GenerationButton(iEtape1);
                            iEtape1 = 0;
                            iNombreRandom = 0;
                            
                            return iNombreRandom;
                        }
                        else
                        {
                            iNombreRandom = 0;
                            return iNombreRandom;
                        }
                        break;
                    case 3:

                        GenerationButton(iEtape1);
                        random = randomNombre.Next(1, 4);
                        if (random == 1)
                        {

                            GenerationButton(iEtape1);
                            iNombreRandom = 1;
                            return iNombreRandom;

                        }
                        if (random == 2)
                        {
                            GenerationButton(iEtape1);

                            iEtape1 = 2;
                            
                            iNombreRandom = 2;
                            return iNombreRandom;
                        }
                        if (random == 3)
                        {
                            GenerationButton(iEtape1);

                            iEtape1 = 0;
                            iNombreRandom = 6;
                          
                            return iNombreRandom;
                        }
                        else
                        {
                            iNombreRandom = 0;
                            return iNombreRandom;
                        }
                        break;

                }
            }
            if (iEtape1 == 2)
            {
                GenerationButton(iEtape1);
                random = randomNombre.Next(1, 4);
                if (random == 1)
                {
                    GenerationButton(iEtape1);
                    iNombreRandom = 8;
                    return iNombreRandom;
                }
                if (random == 2)
                {
                    GenerationButton(iEtape1);
                   
                    iEtape1 = 1;
                    iNombreRandom = 4;
                    return iNombreRandom;

                }
                if (random == 3)
                {

                    GenerationButton(iEtape1);



                    iNombreRandom = 1;
                    return iNombreRandom;
                }
                else
                {
                    iNombreRandom = 0;
                    return iNombreRandom;
                }
            }
            else
            {
                iNombreRandom = 0;
                return iNombreRandom;
            }



        }
        //fonction qui permet de générer alétoirement une image du tableau d'image.
        private int CliqueRandom2()
        {


            // on test si le premier affichage a été fait.
            if (iEtape2 == 0)
            {

                GenerationButton(iEtape2);

                iEtape2 = 1;
                random = randomNombre.Next(1, 4);
                if (random == 1)
                {


                    GenerationButton(iEtape2);
                    
                    // lblTexte.Text = "Le couloir semble calme...";
                    iNumeroImage = 1;
                    iNombreRandom = 3;
                    // return imgFinaleDepart = aImageDeBase[2];
                    return iNombreRandom;



                }
                if (random == 2)
                {

                    GenerationButton(iEtape2);
               
                    
                    iNumeroImage = 2;
                    
                    iNombreRandom = 4;
                    return iNombreRandom;

                }
                if (random == 3)
                {

                    GenerationButton(iEtape2);
                   
                    
                    iNumeroImage = 3;
             
                    iNombreRandom = 5;
                    return iNombreRandom;

                }


            }
            if (iEtape2 == 1)
            {
                
                switch (iNumeroImage)
                {

                    case 1:
                        GenerationButton(iEtape2);
                        // iNumeroImage = 4;
                        random = randomNombre.Next(1, 4);
                        if (random == 1)
                        {
                            GenerationButton(iEtape2);

                            // lblTexte.Text = "Cette pièce vous semble familier";
                            //return imgFinaleDepart = aImageDeBase[0];
                            iNombreRandom = 1;
                            return iNombreRandom;

                        }
                        if (random == 2)
                        {
                            GenerationButton(iEtape2);
                            iEtape2 = 2;
                            //  lblTexte.Text = "Vous semblez être au rez-de-chaussez"; 
                            //return imgFinaleDepart = aImageDeBase[5];
                            iNombreRandom = 6;
                            return iNombreRandom;

                        }
                        if (random == 3)
                        {
                            GenerationButton(iEtape2);
                            iEtape2 = 0;
                            iNombreRandom = 0;
                      
                            return iNombreRandom;
                        }
                        else
                        {
                            iNombreRandom = 0;
                            return iNombreRandom;
                        }
                        break;
                    case 2:
                        GenerationButton(iEtape2);
                        iNumeroImage = 5;
                        random = randomNombre.Next(1, 4);
                        if (random == 1)
                        {
                            GenerationButton(iEtape2);

                            iNombreRandom = 1;
                            return iNombreRandom;

                        }
                        if (random == 2)
                        {
                            GenerationButton(iEtape2);
                            iEtape2 = 2;
                            
                            iNombreRandom = 7;
                            return iNombreRandom;
                        }
                        if (random == 3)
                        {
                            GenerationButton(iEtape2);
                            iEtape2 = 0;
                            iNombreRandom = 0;
                            
                            return iNombreRandom;
                        }
                        else
                        {
                            iNombreRandom = 0;
                            return iNombreRandom;
                        }
                        break;
                    case 3:
                        GenerationButton(iEtape2);
                        iNumeroImage = 6;
                        random = randomNombre.Next(1, 4);
                        if (random == 1)
                        {
                            GenerationButton(iEtape2);

                            iNombreRandom = 1;
                            return iNombreRandom;

                        }
                        if (random == 2)
                        {
                            GenerationButton(iEtape2);
                            iEtape2 = 2;
                           
                            iNombreRandom = 2;
                            return iNombreRandom;
                        }
                        if (random == 3)
                        {
                            GenerationButton(iEtape2);
                            iEtape2 = 0;
                            iNombreRandom = 0;
                
                            return iNombreRandom;
                        }
                        else
                        {
                            iNombreRandom = 0;
                            return iNombreRandom;
                        }
                        break;

                }
            }
            if (iEtape2 == 2)
            {
                GenerationButton(iEtape2);
                random = randomNombre.Next(1, 4);
                if (random == 1)
                {
                    GenerationButton(iEtape2);
                    iNombreRandom = 8;
                    return iNombreRandom;
                }
                if (random == 2)
                {
                    GenerationButton(iEtape2);
                    iEtape2 = 1;
                    iNombreRandom = 5;
                    return iNombreRandom;

                }
                if (random == 3)
                {
                    GenerationButton(iEtape2);
                    iNombreRandom = 1;


                    return iNombreRandom;
                }
                else
                {
                    iNombreRandom = 0;
                    return iNombreRandom;
                }
            }
            else
            {
                return iEtape2;
            }
           



        }
        private int CliqueRandom3()
        { 


            // on test si le premier affichage a été fait.
            if (iEtape3 == 0)
            {

                GenerationButton(iEtape3);

                iEtape3 = 1;
                random = randomNombre.Next(1, 4);
                if (random == 1)
                {
                   

                    GenerationButton(iEtape3);
                   
                    iNumeroImage = 1;
                    iNombreRandom = 3;
               
                    return iNombreRandom;



                }
                if (random == 2)
                {
                    
                    GenerationButton(iEtape3);
                  
           
                    iNumeroImage = 2;
                    
                    iNombreRandom = 4;
                    return iNombreRandom;

                }
                if (random == 3)
                {
                  
                    GenerationButton(iEtape3);
                
   
                    iNumeroImage = 3;
                   
                    iNombreRandom = 5;
                    return iNombreRandom;

                }


            }
            if(iEtape3 == 1)
            {
                
                switch (iNumeroImage)
                {
                     
                    case 1 :
                        GenerationButton(iEtape3);

                        random = randomNombre.Next(1, 4);
                            if (random == 1)
                                 {


                            GenerationButton(iEtape3);
                            iNombreRandom = 1;
                            return iNombreRandom;

                        }
                            if (random == 2)
                                {
                            GenerationButton(iEtape3);
                            iEtape3 = 2;
                              
                            iNombreRandom = 6;
                            return iNombreRandom;

                        }
                            if (random == 3)
                                {
                            GenerationButton(iEtape3);
                            iEtape3 = 0;
                            iNombreRandom = 0;

                            return iNombreRandom;
                        }
                        else
                        {
                            iNombreRandom = 0;
                            return iNombreRandom;
                        }
                        break;
                    case 2:
                        GenerationButton(iEtape3);
                        iNumeroImage = 5;
                               random = randomNombre.Next(1, 4);
                            if (random == 1)
                                 {
                            GenerationButton(iEtape3);

                            iNombreRandom = 1;
                            return iNombreRandom;

                        }
                            if (random == 2)
                                {
                            GenerationButton(iEtape3);
                            iEtape3 = 2;
                                
                            iNombreRandom = 7;
                            return iNombreRandom;
                        }
                            if (random == 3)
                                {
                            GenerationButton(iEtape3);
                            iNombreRandom = 0;
                            iEtape3 = 0;
                            return iNombreRandom;
                        }
                        else
                        {
                            iNombreRandom = 0;
                            return iNombreRandom;
                        }
                        break;
                    case 3:
                        GenerationButton(iEtape3);
                        iNumeroImage = 6;
                               random = randomNombre.Next(1, 4);
                            if (random == 1)
                                 {
                            GenerationButton(iEtape3);


                            iNombreRandom = 1;
                            return iNombreRandom;

                        }
                            if (random == 2)
                                {
                            GenerationButton(iEtape3);
                            iEtape3 = 2;
                                
                            iNombreRandom = 2;
                            return iNombreRandom;
                        }
                            if (random == 3)
                                {
                            GenerationButton(iEtape3);
                            iNombreRandom = 0;
                            iEtape3 = 0;
                            return iNombreRandom;
                        }
                        else
                        {
                            iNombreRandom = 0;
                            return iNombreRandom;
                        }
                        break;

                }
            }
            if(iEtape3 == 2)
            {
                GenerationButton(iEtape3);
                random = randomNombre.Next(1, 4);
                if (random == 1)
                {
                    GenerationButton(iEtape3);

                    iNombreRandom = 8;
                    
                    return iNombreRandom;
                    

                }
                if (random == 2)
                {
                    GenerationButton(iEtape3);
                    iEtape3 = 1;
                    iNombreRandom = 6;
                    return iNombreRandom;
                    
                }
                if (random == 3)
                {
                    GenerationButton(iEtape3);
                    iNombreRandom = 1;
                  
                    return iNombreRandom;
                    
                 
              
                }
                else
                {
                    iNombreRandom = 0;
                    return iNombreRandom;
                }
            }
            else
            {
                return iEtape3;
            }
            

            
        }

        //Fonction permettant de renvoyer l'image servant à l'evénement click par rapport au numéro d'indice donné par la fonction CliqueRandom()
       private Image ChoixImage(int numeroRandom)
        {


            Image[] aImageDeBase = new Image[] { depart, imageDefaite, imageDepart1, imageDepart2, imageDepart3, imageMilieu4, imageMilieu5, imageMilieu6, imageFin };

            switch (numeroRandom)
            {
                case 0:
          
                    return aImageDeBase[1];

                    break;
                case 1:
                    pbxChoix1.Location = new Point(40, 200);
                    pbxChoix2.Location = new Point(680, 300);
                    pbxChoix3.Location = new Point(350, 170);
                    pbxChoix1.Size = new Size(60, 150);
                    pbxChoix2.Size = new Size(40, 200);
                    pbxChoix3.Size = new Size(90, 200);


                    return aImageDeBase[0];
                   

                    break;
                case 2:
                    pbxChoix1.Location = new Point(0, 230); // pour chaque image, réajustement des bouttons
                    pbxChoix2.Location = new Point(400, 50);
                    pbxChoix3.Location = new Point(600, 400);
                    pbxChoix1.Size = new Size(40, 130);
                    pbxChoix2.Size = new Size(300, 140);
                    pbxChoix3.Size = new Size(300, 400);
                    return aImageDeBase[2];

                 
                    break;
                case 3:
                    pbxChoix1.Location = new Point(85, 130);
                    pbxChoix2.Location = new Point(275, 170);
                    pbxChoix3.Location = new Point(400, 500);
                    pbxChoix1.Size = new Size(90, 200);
                    pbxChoix2.Size = new Size(80, 140);
                    pbxChoix3.Size = new Size(180, 100);
                    return aImageDeBase[3];
               
                    break;
                case 4:
                    pbxChoix1.Location = new Point(0, 260);
                    pbxChoix2.Location = new Point(440, 170);
                    pbxChoix3.Location = new Point(560, 260);
                    pbxChoix1.Size = new Size(90, 70);
                    pbxChoix2.Size = new Size(60, 80);
                    pbxChoix3.Size = new Size(45, 150);
                    return aImageDeBase[4];
                
                    break;
                case 5:

                    pbxChoix1.Location = new Point(39, 140);
                    pbxChoix2.Location = new Point(230, 170);
                    pbxChoix3.Location = new Point(450, 140);
                    pbxChoix1.Size = new Size(16, 250);
                    pbxChoix2.Size = new Size(50, 80);
                    pbxChoix3.Size = new Size(30, 60);
                    return aImageDeBase[5];
                    break;
                case 6:
                    pbxChoix1.Location = new Point(0, 140);
                    pbxChoix2.Location = new Point(433, 200);
                    pbxChoix3.Location = new Point(700, 140);
                    pbxChoix1.Size = new Size(16, 250);
                    pbxChoix2.Size = new Size(40, 130);
                    pbxChoix3.Size = new Size(300, 270);
                    return aImageDeBase[6];
                    break;
                case 7:
                    pbxChoix1.Location = new Point(210, 123);
                    pbxChoix2.Location = new Point(410, 120);
                    pbxChoix3.Location = new Point(700, 240);
                    pbxChoix1.Size = new Size(40, 220);
                    pbxChoix2.Size = new Size(50, 200);
                    pbxChoix3.Size = new Size(300, 265);
                    return aImageDeBase[7];
                    
                    break;
                case 8:
                    return aImageDeBase[8];
                    break;
                default:
                    return null;
                    break;

            }
          

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
                                pbxChoix1.BackColor = Color.Red;
                                
                                break;
                                case 1:
                                pbxChoix1.BackColor = Color.Yellow;
                          
                                break;
                                case 2:
                                pbxChoix1.BackColor = Color.Green;
                                
                                break;
                        }
                        
                    }
                  if(i == 1)
                    {
                        pbxChoix2.MouseLeave += new EventHandler(btnChoix1_MouseLeave);
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
                                pbxChoix2.BackColor = Color.Red;
                               
                                break;
                            case 1:
                                pbxChoix2.BackColor = Color.Yellow;
                            
                                break;
                            case 2:
                                pbxChoix2.BackColor = Color.Green;
                               
                                break;
                        }
                        
                    }
                  if(i == 2)
                    {
                        randomCouleur = randomNombre.Next(0, 3);
                        iButton3 = randomCouleur;
                        pbxChoix3.MouseLeave += new EventHandler(btnChoix1_MouseLeave);
                        while(iButton3 == iButton1 || iButton3 == iButton2)
                        {
                            randomCouleur = randomNombre.Next(0, 3);
                            iButton3 = randomCouleur;
                        }
                        switch (iButton3)
                        {
                            case 0:
                                pbxChoix3.BackColor = Color.Red;
                                
                                break;
                            case 1:
                                pbxChoix3.BackColor = Color.Yellow;
                                
                                break;
                            case 2:
                                pbxChoix3.BackColor = Color.Green;
                               
                                break;
                        }
                        
                    }

                }
                
               if(pbxChoix1.BackColor == Color.Red)
               {
                   pbxChoix1.BackColor = Color.White;
                   pbxChoix1.MouseHover += new EventHandler(btnChoix1rouge_MouseHover);
                   pbxChoix1.MouseLeave += new EventHandler(btnChoix1MouseLeave);
               }
               if (pbxChoix1.BackColor == Color.Yellow)
               {
                   pbxChoix1.BackColor = Color.White;
                   pbxChoix1.MouseHover += new EventHandler(btnChoix1jaune_MouseHover);
                   pbxChoix1.MouseLeave += new EventHandler(btnChoix1MouseLeave);
               }
               if (pbxChoix1.BackColor == Color.Green)
               {
                   pbxChoix1.BackColor = Color.White;
                   pbxChoix1.MouseHover += new EventHandler(btnChoix1vert_MouseHover);
                   pbxChoix1.MouseLeave += new EventHandler(btnChoix1MouseLeave);
               }
               
                
               if (pbxChoix2.BackColor == Color.Red)
               {
                   pbxChoix2.BackColor = Color.White;
                   pbxChoix2.MouseHover += new EventHandler(btnChoix2rouge_MouseHover);
                   pbxChoix2.MouseLeave += new EventHandler(btnChoix2MouseLeave);
               }
               if (pbxChoix2.BackColor == Color.Yellow)
               {
                   pbxChoix2.BackColor = Color.White;
                   pbxChoix2.MouseHover += new EventHandler(btnChoix2jaune_MouseHover);
                   pbxChoix2.MouseLeave += new EventHandler(btnChoix2MouseLeave);
               }
               if (pbxChoix2.BackColor == Color.Green)
               {
                   pbxChoix2.BackColor = Color.White;
                   pbxChoix2.MouseHover += new EventHandler(btnChoix2vert_MouseHover);
                   pbxChoix2.MouseLeave += new EventHandler(btnChoix2MouseLeave);
               }


               if (pbxChoix3.BackColor == Color.Red)
               {
                   pbxChoix3.BackColor = Color.White;
                   pbxChoix3.MouseHover += new EventHandler(btnChoix3rouge_MouseHover);
                   pbxChoix3.MouseLeave += new EventHandler(btnChoix3MouseLeave);
               }
               if (pbxChoix3.BackColor == Color.Yellow)
               {
                   pbxChoix3.BackColor = Color.White;
                   pbxChoix3.MouseHover += new EventHandler(btnChoix3jaune_MouseHover);
                   pbxChoix3.MouseLeave += new EventHandler(btnChoix3MouseLeave);
               }
               if (pbxChoix3.BackColor == Color.Green)
               {
                   pbxChoix3.BackColor = Color.White;
                   pbxChoix3.MouseHover += new EventHandler(btnChoix3vert_MouseHover);
                   pbxChoix3.MouseLeave += new EventHandler(btnChoix3MouseLeave);
               }
                
            }
          

            
            


        }
        //Fonction permettant de générer le texte d'une image
        private void TexteImage1()
        {
            switch (iIndice1)
            {
                case 0:
                    DialogResult perdu = MessageBox.Show("Vous avez perdu, recommencer ? ", "Vous êtes tombé dans un sommeil profond...", MessageBoxButtons.YesNo);
                    if (perdu == DialogResult.Yes)
                    {
                        ReinitialisationValeur();
                    }
                    else
                    {
                        Application.Exit();
                    }

                    break;
                case 1:
                    lblTexte.Text = "Cette pièce vous semble familier";
                    break;
                case 2:
                    lblTexte.Text = "Le couloir semble calme...";
                  break;
                case 3:
                    lblTexte.Text = "Apparement, c'est une chambre d'enfant";
                   break;
                case 4:
                    lblTexte.Text = "Le froid semble vous atteindre dans ce couloir";
                    
                    break;
                case 5:
                    lblTexte.Text = "Vous semblez être au rez-de-chaussez";
                    break;
                case 6:
                    lblTexte.Text = "Le salon est bien accueillant";
                    break;
                case 7:
                    lblTexte.Text = "Vous vous sentez oppressé dans cette pièce";
                    break;
                case 8:
                    DialogResult gagne = MessageBox.Show("Dans la cave, vous trouvez une porte grande ouvert et vous vous échapper. recommencer ? ", "bien joué !", MessageBoxButtons.YesNo);
                    if (gagne == DialogResult.Yes)
                    {
                        ReinitialisationValeur();
                    }
                    else
                    {
                        Application.Exit();
                    }
                    break;

            }
           
        }
        private void TexteImage2()
        {
            switch (iIndice2)
            {
                case 0:
                    DialogResult perdu = MessageBox.Show("Vous avez perdu, recommencer ? ", "Vous êtes tombé dans un sommeil profond...", MessageBoxButtons.YesNo);
                    if (perdu == DialogResult.Yes)
                    {
                        ReinitialisationValeur();
                    }
                    else
                    {
                        Application.Exit();
                    }

                    break;
                case 1:
                    lblTexte.Text = "Cette pièce vous semble familier";
                    break;
                case 2:
                    lblTexte.Text = "Le couloir semble calme...";
                    break;
                case 3:
                    lblTexte.Text = "Apparement, c'est une chambre d'enfant";
                    break;
                case 4:
                    lblTexte.Text = "Le froid semble vous atteindre dans ce couloir";

                    break;
                case 5:
                    lblTexte.Text = "Vous semblez être au rez-de-chaussez";
                    break;
                case 6:
                    lblTexte.Text = "Le salon est bien accueillant";
                    break;
                case 7:
                    lblTexte.Text = "Vous vous sentez oppressé dans cette pièce";
                    break;
                case 8:
                    DialogResult gagne = MessageBox.Show("Dans la cave, vous trouvez une porte grande ouvert et vous vous échapper. recommencer ? ", "bien joué !", MessageBoxButtons.YesNo);
                    if (gagne == DialogResult.Yes)
                    {
                        ReinitialisationValeur();
                    }
                    else
                    {
                        Application.Exit();
                    }
                    break;
                    

            }

        }
        private void TexteImage3()
        {
            switch (iIndice3)
            {
                case 0:
                    DialogResult perdu = MessageBox.Show("Vous avez perdu, recommencer ? ", "Vous êtes tombé dans un sommeil profond...", MessageBoxButtons.YesNo);
                    if(perdu == DialogResult.Yes)
                    {
                        ReinitialisationValeur();
                    }
                    else
                    {
                        Application.Exit();
                    }
                   

                    break;
                case 1:
                    lblTexte.Text = "Cette pièce vous semble familier";
                    break;
                case 2:
                    lblTexte.Text = "Le couloir semble calme...";
                    break;
                case 3:
                    lblTexte.Text = "Apparement, c'est une chambre d'enfant";
                    break;
                case 4:
                    lblTexte.Text = "Le froid semble vous atteindre dans ce couloir";

                    break;
                case 5:
                    lblTexte.Text = "Vous semblez être au rez-de-chaussez";
                    break;
                case 6:
                    lblTexte.Text = "Le salon est bien accueillant";
                    break;
                case 7:
                    lblTexte.Text = "Vous vous sentez oppressé dans cette pièce";
                    break;
                case 8:
                    DialogResult gagne = MessageBox.Show("Dans la cave, vous trouvez une porte grande ouvert et vous vous échapper. recommencer ? ", "bien joué !", MessageBoxButtons.YesNo);
                    if (gagne == DialogResult.Yes)
                    {
                        ReinitialisationValeur();
                    }
                    else
                    {
                        Application.Exit();
                    }
                    break;

            }

        }

        //fonction permetant de générer des indices par rapport au nombre envoyé par la fonction CliqueRandom. Même fonction pour chaque boutton
        private void LockIndice1()
        {
            if (iLock1 == false)
            {
                
                iIndice1 = CliqueRandom1();
                iLock1 = true;
              
                switch (iIndice1)
                {
                    case 0:

                        strQuestionLocale1 = "Vous vous sentez mal à l'aise en regardant dans cette direction";

                        break;
                    case 1:

                        strQuestionLocale1 = "Une impression de déjà vu !";

                        break;
                    case 2:

                        strQuestionLocale1 = "Vous vous sentez mal à l'aise en regardant dans cette direction";

                        break;
                    case 3:

                        strQuestionLocale1 = "Vous sentez un courant d'air par là";

                        break;
                    case 4:

                        strQuestionLocale1 = "Il y une odeur bizarre";

                        break;
                    case 5:

                        strQuestionLocale1 = "Une impression de déjà vu !";

                        break;
                    case 6:

                        strQuestionLocale1 = "Vous sentez un courant d'air par là!";

                        break;
                    case 7:
                        strQuestionLocale1 = "Vous vous sentez mal à l'aise en regardant dans cette direction !!";
                        break;
                    case 8:
                        strQuestionLocale1 = "Il y une odeur bizarre!";
                        break;


                }
             
            }
            lblIndice.Text = strQuestionLocale1;
            
        }
        private void LockIndice2()
        {
            if (iLock2 == false)
            {
                
                iIndice2 = CliqueRandom2();
               
                iLock2 = true;

                switch (iIndice2)
                {
                    case 0:

                        strQuestionLocale2 = "Vous vous sentez mal à l'aise en regardant dans cette direction";

                        break;
                    case 1:

                        strQuestionLocale2 = "Une impression de déjà vu !";

                        break;
                    case 2:

                        strQuestionLocale2 = "Vous vous sentez mal à l'aise en regardant dans cette direction";

                        break;
                    case 3:

                        strQuestionLocale2 = "Vous sentez un courant d'air par là";

                        break;
                    case 4:

                        strQuestionLocale2 = "Il y une odeur bizarre";

                        break;
                    case 5:

                        strQuestionLocale2 = "Une impression de déjà vu !";

                        break;
                    case 6:

                        strQuestionLocale2 = "Vous sentez un courant d'air par là!";

                        break;
                    case 7:
                        strQuestionLocale2 = "Vous vous sentez mal à l'aise en regardant dans cette direction !!";
                        break;
                    case 8:
                        strQuestionLocale2 = "Il y une odeur bizarre!";
                        break;



                }

            }
            lblIndice.Text = strQuestionLocale2;
           
        }
        private void LockIndice3()
        {
            if (iLock3 == false)
            {
                iIndice3 = CliqueRandom3();
                iLock3 = true;
               

                switch (iIndice3)
                {
                    case 0:

                        strQuestionLocale3 = "Vous vous sentez mal à l'aise en regardant dans cette direction";

                        break;
                    case 1:

                        strQuestionLocale3 = "Une impression de déjà vu !";

                        break;
                    case 2:

                        strQuestionLocale3 = "Vous vous sentez mal à l'aise en regardant dans cette direction";

                        break;
                    case 3:

                        strQuestionLocale3 = "Vous sentez un courant d'air par là";

                        break;
                    case 4:

                        strQuestionLocale3 = "Il y une odeur bizarre";

                        break;
                    case 5:

                        strQuestionLocale3 = "Une impression de déjà vu !";

                        break;
                    case 6:

                        strQuestionLocale3 = "Vous sentez un courant d'air par là!";

                        break;
                    case 7:
                        strQuestionLocale3 = "Vous vous sentez mal à l'aise en regardant dans cette direction !!";
                        break;
                    case 8:
                        strQuestionLocale3 = "Il y une odeur bizarre!";
                        break;

                }

            }
            lblIndice.Text = strQuestionLocale3;
          
            }
        //Fonction qui réinitialise les valeurs quand on recommence le jeu
        private void ReinitialisationValeur()
        {
            lblTexte.Text = "Vous êtes retrouvez dans une maison inconnue en vous réveillant";
            lblIndice.Text = "Chercher les chemins possibles sur l'image";
            pnlImage.BackgroundImage = depart;
           iEtape1 = 0;
            iEtape2 = 0;
           iEtape3 = 0;
           iLock1 = false;
         iLock2 = false;
        iLock3 = false;
             pbxChoix1.Location = new Point(40, 200);
            pbxChoix2.Location = new Point(680, 300);
            pbxChoix3.Location = new Point(350, 170);
            pbxChoix1.Size = new Size(60, 150);
            pbxChoix2.Size = new Size(40, 200);
            pbxChoix3.Size = new Size(90, 200);
        }
    }
}
