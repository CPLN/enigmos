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
        //Maximum d'essaie
        const int NB_ESSAIE = 1;
        //Image à deviner
        PictureBox _pbx1 = new PictureBox();
        //Compteur d'essaie
        int iCompteur = 0;
        public DevineAnimalEnigmaPanel()
        {
            //Déclaration PictureBox
            _pbx1.BackgroundImage = Resources.ElephantOmbre;
            _pbx1.Width = 243;
            _pbx1.Height = 275;
            _pbx1.Location = new Point(250, 100);
            Controls.Add(_pbx1);

            //Déclaration Button
            Button[] _tButton = new Button[] { new Button {Text= "Raie Manta" }, new Button { Text = "Papillon" }, new Button { Text = "Eléphant" } };
            for (int i=0;i<_tButton.Length;i++)
            {
                //Design des boutons
                _tButton[i].ForeColor = Color.White;
                _tButton[i].BackColor = Color.FromArgb(26, 189, 155);
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
        /// Evènement lors d'un click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btnClick = (Button)sender;

            if (iCompteur<NB_ESSAIE)
            {
                if (btnClick.Text == "Eléphant")
                {
                    _pbx1.BackgroundImage = Resources.elephant;
                    MessageBox.Show("Effectivement c'est bien un éléphant\nLa réponse est \"éléphant\"");
                }
                else
                {
                    iCompteur++;
                    MessageBox.Show("Faux");
                }
            }
            else
            {
                MessageBox.Show("Vous avez malheuresement plus d'essaie, passez cette énigme");
            }

        }
    }
}
