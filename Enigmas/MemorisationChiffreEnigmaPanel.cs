using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Cpln.Enigmos.Enigmas
{
    class MemorisationChiffreEnigmaPanel : EnigmaPanel
    {
        private Random rChiffre = new Random(); //Creation d'un random qui vas prendre au chiffre de 9 nombres
        private Button btnRecommencer = new Button(); //Creation du boutton sur lequel l'utilisateur pourras recommencer
        private TextBox tbxRep = new TextBox(); //Textbox pour écrire la réponse
        private Label lblChiffre = new Label(); //Label ou le chiffre tiré au est affiché
        private Label lblReponse = new Label(); //Label ou le chiffre tiré au est affiché
        private Timer tVisible = new Timer(); //Timer dans lequel le chiffre sera visible
        private int i = 0;
        private int iChiffre = 0;
        public override void Load()
        {
            iChiffre = rChiffre.Next(100000000, 900000000);

            //Mise en place du timer
            tVisible.Interval = 1000;
            tVisible.Enabled = true;
            tVisible.Tick += new EventHandler(tVisible_timer);
            tVisible.Start();

            //Caractéristiques du label ou sera afficher le chiffre
            lblChiffre.Font = new Font("Century Gothic", 40);
            lblChiffre.Size = new Size(500, 60);
            lblChiffre.Text = iChiffre.ToString();
            lblChiffre.Location = new Point(250, 250);

            //Caractéristiques du label ou sera afficher la réponse
            lblReponse.Font = new Font("Century Gothic", 15);
            lblReponse.Size = new Size(250, 60);
            lblReponse.Text = "La réponse est : we";
            lblReponse.Location = new Point(300, 450);
            lblReponse.Visible = false;

            //Caractéristiques du boutton qui permettera de recommencer
            btnRecommencer.Font = new Font("Century Gothic", 10);
            btnRecommencer.Visible = false;
            btnRecommencer.Size = new Size(150, 45);
            btnRecommencer.Click += new EventHandler(btnRecommencer_click);
            btnRecommencer.Text = "Recommencer";
            btnRecommencer.Location = new Point(325, 350);

            //Caractéristiques de la textbox qui permetera de saisir la réponse
            tbxRep.Size = new Size(267, 60);
            tbxRep.Font = new Font("Century Gothic", 40);
            tbxRep.Location = new Point(250, 250);
            tbxRep.Visible = false;

            //Ajout du label dans la Form
            Controls.Add(btnRecommencer);
            Controls.Add(lblChiffre);
            Controls.Add(tbxRep);
            Controls.Add(lblReponse);
        }
        public override void Unload()
        {
            lblChiffre.Text = null;
        }
        private void tVisible_timer(object sender, EventArgs e)
        {
            i++;
            if (i == 5)
            {
                lblChiffre.Visible = false;
                tbxRep.Visible = true;
                btnRecommencer.Visible = true;
                i = 4;
                while (tbxRep.Text == iChiffre.ToString())
                {
                    lblReponse.Visible = true;
                    tVisible.Stop();
                    break;
                }
            }
        }
        void btnRecommencer_click(object sender, EventArgs e)
        {
            lblReponse.Visible = false;
            i = 0;
            btnRecommencer.Visible = false;
            lblChiffre.Visible = true;
            tbxRep.Visible = false;
            iChiffre = rChiffre.Next(100000000, 900000000);
            lblChiffre.Text = Convert.ToString(iChiffre);
            tbxRep.Text = "";
            tVisible.Start();
        }
    }
}