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
    //DAVID DARMANGER
    //2M4I2C

    public class DevineAnimalEnigmaPanel:EnigmaPanel
    {
        //Label qui affichera les essai(s) restant(s)
        Label _lblEssai = new Label { Text = "Essai(s) restant(s): " + NB_ESSAI, Width = 200, Font = new Font("Century Gothic", 14, FontStyle.Bold) };
        
        public override void Load()
        {
            _lblEssai.Text = "Essai(s) restant(s): " + NB_ESSAI;
        }

        public override void Unload()
        {
            base.Unload();
        }

        /// <summary>
        /// Permet de désactiver les boutons utilisés pour les choix lors d'une victoire ou d'une défaite
        /// </summary>
        /// <param name="_Bouton">Tableau de boutons utilisé lors des choix</param>
        public void DesactivationBouton(Button[] _Bouton)
        {
            foreach (Button b in _Bouton)
                b.Enabled = false;
        }

        //Nombre maximum d'essai(s)
        const int NB_ESSAI = 2;

        //Compteur d'essai
        int iCompteurEssai = 1;

        //PictureBox qui contiendra l'image à deviner
        PictureBox _pbxElephant = new PictureBox {BackgroundImage=Resources.ElephantOmbre, Width=243, Height=275, Location=new Point(250,100)};
        
        //Tableau de boutons utilisé pour les choix
        Button[] _tBoutonChoix = new Button[] {new Button { Text = "Raie Manta" }, new Button { Text = "Papillon" }, new Button { Text = "Eléphant" } };

        public DevineAnimalEnigmaPanel()
        {
            //Affichage du label qui montrera les essaie(s) restant(s)
            Controls.Add(_lblEssai);

            //Affichage PictureBox qui contiendra l'image a deviner
            Controls.Add(_pbxElephant);

            //Construction et affichage des boutons de choix
            for (int i=0;i<_tBoutonChoix.Length;i++)
            {
                _tBoutonChoix[i].ForeColor = Color.White;
                _tBoutonChoix[i].BackColor = Color.FromArgb(38, 175, 145);
                _tBoutonChoix[i].Font = new Font("Century Gothic",14, FontStyle.Bold);
                _tBoutonChoix[i].FlatStyle = FlatStyle.Flat;
                _tBoutonChoix[i].Width=110;
                _tBoutonChoix[i].Height = 60;
                _tBoutonChoix[i].Location = new Point(200 + 120 * i, 500);
                _tBoutonChoix[i].Click += Btn_Click;
                Controls.Add(_tBoutonChoix[i]);
            }
        }

        /// <summary>
        /// Evènement lors d'un click sur un bouton
        /// </summary>
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
                _pbxElephant.BackgroundImage = Resources.elephant;

                //Message de victoire
                MessageBox.Show("Effectivement c'est bien un éléphant\nLa réponse est \"éléphant\"");

                //Désactivation des boutons de choix lors d'une victoire
                DesactivationBouton(_tBoutonChoix);
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
                    MessageBox.Show("Vous avez malheuresement plus d'essai(s), passez cette énigme");

                    //Désactivation des boutons lors que le joueur n'a plus d'essai
                    DesactivationBouton(_tBoutonChoix);
                }
            }
        }
    }
}
