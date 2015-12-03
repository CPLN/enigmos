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
        Label lblReponse = new Label();
        Label lblTexte = new Label();
        Panel pnlImage = new Panel();
        Button btnChoix1 = new Button();
        Button btnChoix2 = new Button();
        Button btnChoix3 = new Button();
       private void btnChoix1_Click(object sender, EventArgs e)
       {
          // pnlImage.BackgroundImage = Properties.Resources.;
       }
       private void btnChoix2_Click(object sender, EventArgs e)
       {
           
       }
       private void btnChoix3_Click(object sender, EventArgs e)
       {
           
       }
       
     
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

            btnChoix1.Click += new EventHandler(btnChoix1_Click);
            btnChoix2.Click += new EventHandler(btnChoix2_Click);
            btnChoix3.Click += new EventHandler(btnChoix3_Click);
        
  
    


            /*lblReponse.Text = "Réponse A : \n" + "Réponse B : \n" + "Réponse C : \n";
            lblReponse.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
            lblReponse.Size = new Size(150, 70);
            lblReponse.Location = new Point(0, 0);*/
           
           /*while (!bFindeJeu)
           {
           



           }*/
            



         
            
            
           
      
           Controls.Add(lblReponse);
            Controls.Add(lblTexte);

            pnlImage.Width = 800;
            pnlImage.Height = 600;
           //pnlImage.BackColor = Color.BlueViolet;

            pnlImage.BackgroundImage = Properties.Resources.depart;
            Controls.Add(pnlImage);

           // Image[] images = new Image[2]{Properties.Resources.depart, Properties.Resources.depart, Properties.Resources.depart };

         
            
            

            
            



            
        }
     
    }
}
