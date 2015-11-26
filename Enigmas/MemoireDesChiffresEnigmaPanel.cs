using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    public class MemoireDesChiffresEnigmaPanel : EnigmaPanel
    {
        private Timer timer = new Timer(); //Création du timer
        Label lblQuestion = new Label(); //Création du label qui demande le chiffre qu'il faut entrer
        Label lblChiffres = new Label(); //Création du label qui affiche les chiffres aléatoires
        int[] tChiffresAleatoire = new int[8]; //Déclaration du tableau de chiffre aléatoire
        int iCompteur = 0; //Variable d'incrémentation pour les cases du tableau
        Random random = new Random(); //Déclaration du générateur de random
        int iCaseDemandee; //Déclaration de la case demandée

        public MemoireDesChiffresEnigmaPanel()
        {
            iCaseDemandee = random.Next(2, 5); //Affectation de la case demandée

            //Mise en place d'un timer
            timer.Interval = 500; // 1 milisecondes
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();

            //Caractéristiques du label qui pose la question
            Controls.Add(lblQuestion);
            lblQuestion.Size = new Size(1800, 80);
            lblQuestion.Font = new Font("Verdana", 40);
            lblQuestion.Location = new Point(50, 400);
            lblQuestion.Visible = false;
            
            //Caractéristiques du label qui fait apparaître les chiffres aléatoires
            Controls.Add(lblChiffres);
            lblChiffres.Size = new Size(160, 160);
            lblChiffres.Font = new Font("Verdana", 80);
            lblChiffres.Location = new Point(330, 220);




            lblChiffres.Text = Convert.ToString(iCaseDemandee);

            
        }
        void Timer_Tick(object sender, EventArgs e)
        {
            if (iCompteur <= 7)
            {
                if (iCompteur != iCaseDemandee)
                {
                    tChiffresAleatoire[iCompteur] = random.Next(1, 10);
                    lblChiffres.Text = Convert.ToString(tChiffresAleatoire[iCompteur]);
                    iCompteur++;
                }
                else
                {
                    tChiffresAleatoire[iCompteur] = 8;
                    lblChiffres.Text = Convert.ToString(tChiffresAleatoire[iCompteur]);
                    iCompteur++;
                }
                
            }
            else if(iCompteur == 8)
            {
                lblQuestion.Visible = true;
                lblQuestion.Text = String.Format("Quel est le {0}ème chiffre", iCaseDemandee);
                iCompteur = 0;
                timer.Stop();
            }
        }
    }
}
