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
        private Button[] btnReponse = new Button[4];
        public HazardEnigmaPanel()
        {
            Random randoChoixDuBouton = new Random();
            iBonBouton = randoChoixDuBouton.Next(0, 4);

            for (int i = 0; i < 4; i++)
            {
                btnReponse[i] = new Button();
            }
            CreationBouton();

            btnReponse[0].Location = new Point(0, 0);
            btnReponse[1].Location = new Point(410, 0);
            btnReponse[2].Location = new Point(0, 310);
            btnReponse[3].Location = new Point(410, 310);

        }

        private void CreationBouton()
        {
            for (int i = 0; i < 4; i++)
            {
                btnReponse[i].Width = 390;
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
        }
        private void BonneReponse(object sender, EventArgs e)
        {
            MessageBox.Show("La reponse est suivant.", "Reponse");
           /* for (int i = 0; i < 4; i++)
            {
                btnReponse[i].Enabled = false;
            }
            */

        }

        private void MauvaiseReponse(object sender, EventArgs e)
        {
            MessageBox.Show("Vous avez cliqué sur un mauvais bouton.", "Mauvais Bouton");
            Random randoChoixDuBouton = new Random();
            iBonBouton = randoChoixDuBouton.Next(0, 4);
            CreationBouton();
        }
    }
}
