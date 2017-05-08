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
        PictureBox _pbx1 = new PictureBox();
        public DevineAnimalEnigmaPanel()
        {
            //Déclaration PictureBox
            
            _pbx1.BackgroundImage = Resources.ombre;
            _pbx1.Width = 480;
            _pbx1.Height = 624;
            Controls.Add(_pbx1);
            //Déclaration Button
            Button[] _tButton = new Button[] { new Button {Text= "Raie Manta" }, new Button { Text = "Papillon" }, new Button { Text = "Eléphant" } };
            for (int i=0;i<_tButton.Length;i++)
            {
                _tButton[i].Width=110;
                _tButton[i].Height = 60;
                _tButton[i].Location = new Point(120 * i, 400);
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

            if (btnClick.Text=="Eléphant")
            {
                _pbx1.BackgroundImage = Resources.elephant;
                MessageBox.Show("Effectivement c'est bien un éléphant\nLa réponse est \"éléphant\"");
            }
            else
            {
                MessageBox.Show("Faux");
            }
        }
    }
}
