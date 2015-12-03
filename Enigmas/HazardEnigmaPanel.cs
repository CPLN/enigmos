using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    public class HazardEnigmaPanel : EnigmaPanel
    {
        private int iBonBouton;
        //Création des boutons__________________________________________________________
        private Button[] btnReponse = new Button[4];
        Random randoChoixDuBouton = new Random();
        public HazardEnigmaPanel()
        {
            CreationBouton();
        }

        private void CreationBouton()
        {
            SuspendLayout();
            iBonBouton = randoChoixDuBouton.Next(0, 4);//Choix du bouton qui donnera la bonne réponse.
            for (int i = 0; i < 4; i++)
            {
                Controls.Remove(btnReponse[i]);
                btnReponse[i] = new Button();
            }

            btnReponse[0].Location = new Point(0, 0);//Placement des boutons
            btnReponse[1].Location = new Point(410, 0);
            btnReponse[2].Location = new Point(0, 310);
            btnReponse[3].Location = new Point(410, 310);

            for (int i = 0; i < 4; i++)
            {
                btnReponse[i].Width = 390;//attribution d'une taille et d'un texte pour les boutons
                btnReponse[i].Height = 290;
                btnReponse[i].Text = "Bonne réponse?";
                btnReponse[i].Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);
                btnReponse[i].FlatStyle = FlatStyle.System;
                Controls.Add(btnReponse[i]);

                if (i == iBonBouton)
                {
                    btnReponse[iBonBouton].Click += new EventHandler(BonneReponse);
                }
                else
                {
                    btnReponse[i].Click += new EventHandler(MauvaiseReponse);
                }
            }
            ResumeLayout();
            //Fin de la création des boutons_______________________________________________________________
        }
        private void BonneReponse(object sender, EventArgs e)
        {
            MessageBox.Show("La reponse est \"suivant\".", "Reponse");//Affichage de la reponse.
            CreationBouton();
        }

        private void MauvaiseReponse(object sender, EventArgs e)
        {
            MessageBox.Show("Vous avez cliqué sur un mauvais bouton.", "Mauvais Bouton");//affichage du clique sur un mauvais boutons
            CreationBouton();
        }
    }
}
