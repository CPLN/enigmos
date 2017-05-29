using Cpln.Enigmos.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    public class DevineAnimalEnigmaPanel:EnigmaPanel
    {
        //Nombre maximum d'essai(s)
        const int NB_ESSAI = 2;

        //Essai(s) restant(s) affiché à l'écran
        Label _lblEssai = new Label { Text = "Essai(s) restant(s): " + NB_ESSAI, Width = 200, Font = new Font("Century Gothic", 14, FontStyle.Bold) };

        //Image à deviner
        PictureBox _pbx1 = new PictureBox {BackgroundImage=Resources.ElephantOmbre, Width=243, Height=275, Location=new Point(250,100)};

        //Compteur d'essai
        int iCompteurEssai = 1;

        //Tableau de boutons utilisé pour les choix
        Button[] _tButton = new Button[] {new Button { Text = "Raie Manta" }, new Button { Text = "Papillon" }, new Button { Text = "Eléphant" } };

        public DevineAnimalEnigmaPanel()
        {
            //Affichage des essaie(s) restant(s)
            Controls.Add(_lblEssai);

            //Affichage PictureBox
            Controls.Add(_pbx1);

            //Affichage et design des boutons
            for (int i=0;i<_tButton.Length;i++)
            {
                _tButton[i].ForeColor = Color.White;
                _tButton[i].BackColor = Color.FromArgb(38, 175, 145);
                _tButton[i].Font = new Font("Century Gothic",14, FontStyle.Bold);
                _tButton[i].FlatStyle = FlatStyle.Flat;
                _tButton[i].Width=110;
                _tButton[i].Height = 60;
                _tButton[i].Location = new Point(200 + 120 * i, 500);
                _tButton[i].Click += Btn_Click;
                Controls.Add(_tButton[i]);
            }
        }
        /// <summary>
        /// Evènement lors d'un click sur un bouton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Click(object sender, EventArgs e)
        {
            //Affichage essai(s) restant(s)
            _lblEssai.Text = "Essai(s) restant(s): " + (NB_ESSAI - iCompteurEssai).ToString();

            //Le bouton sur le quel le joueur a cliqué
            Button btnClick = (Button)sender;

            //Si le bouton cliqué est le bouton éléphant
            if (btnClick.Text == "Eléphant")
            {
                //On affiche l'image de l'éléphant
                _pbx1.BackgroundImage = Resources.elephant;

                //Message de victoire
                MessageBox.Show("Effectivement c'est bien un éléphant\nLa réponse est \"éléphant\"");

                //Désactivation des boutons lors d'une victoire
                foreach (Button b in _tButton)
                    b.Enabled = false;
            }
            else
            {            
                iCompteurEssai++;

                if (iCompteurEssai <= NB_ESSAI)
                {
                    //Affichage d'un message lorsque le joueur a cliqué sur le mauvais bouton
                    MessageBox.Show("Faux");
                }
                else
                {
                    //Message de défaite
                    MessageBox.Show("Vous avez malheuresement plus d'essaie, passez cette énigme");

                    //Désactivation des boutons lors que le joueur n'a plus d'essai
                    foreach (Button b in _tButton)
                        b.Enabled = false;
                }
            }
        }
    }
}
