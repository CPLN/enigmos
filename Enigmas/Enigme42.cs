using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    public class Enigme42 : EnigmaPanel
    {

        public Enigme42()
        {
           
            //Crée des labels
            Label lblQuaranteDeux1 = new Label();
            Label lblQuaranteDeux2 = new Label();
            Label lblQuaranteDeux3 = new Label();
            Label lblQuaranteDeux4 = new Label();
            Label lblQuaranteDeux5 = new Label();


            //ajoute du texte dans les labels
            lblQuaranteDeux1.Text = "42";
            lblQuaranteDeux2.Text = "42";
            lblQuaranteDeux3.Text = "42";
            lblQuaranteDeux4.Text = "42";
            lblQuaranteDeux5.Text = "42";


            //permet de paramètrer les labels au niveau de la taille, du texte, de la couleur et de la position
            lblQuaranteDeux1.Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);
            lblQuaranteDeux1.ForeColor = Color.Green;
            lblQuaranteDeux1.Location = new Point(300, 300);
            lblQuaranteDeux1.AutoSize = false;
            lblQuaranteDeux1.Size = TextRenderer.MeasureText(lblQuaranteDeux1.Text, lblQuaranteDeux1.Font);


            lblQuaranteDeux2.Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);
            lblQuaranteDeux2.ForeColor = Color.Blue;
            lblQuaranteDeux2.Location = new Point(350, 300);
            lblQuaranteDeux2.AutoSize = false;
            lblQuaranteDeux2.Size = TextRenderer.MeasureText(lblQuaranteDeux2.Text, lblQuaranteDeux2.Font);


            lblQuaranteDeux3.Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);
            lblQuaranteDeux3.ForeColor = Color.Red;
            lblQuaranteDeux3.Location = new Point(400, 300);
            lblQuaranteDeux3.AutoSize = false;
            lblQuaranteDeux3.Size = TextRenderer.MeasureText(lblQuaranteDeux3.Text, lblQuaranteDeux3.Font);


            lblQuaranteDeux4.Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);
            lblQuaranteDeux4.ForeColor = Color.Black;
            lblQuaranteDeux4.Location = new Point(450, 300);
            lblQuaranteDeux4.AutoSize = false;
            lblQuaranteDeux4.Size = TextRenderer.MeasureText(lblQuaranteDeux4.Text, lblQuaranteDeux4.Font);

            lblQuaranteDeux5.Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);
            lblQuaranteDeux5.ForeColor = Color.Purple;
            lblQuaranteDeux5.Location = new Point(500, 300);
            lblQuaranteDeux5.AutoSize = false;
            lblQuaranteDeux5.Size = TextRenderer.MeasureText(lblQuaranteDeux5.Text, lblQuaranteDeux5.Font);


            //Affiche les labels 
            Controls.Add(lblQuaranteDeux1);
            Controls.Add(lblQuaranteDeux2);
            Controls.Add(lblQuaranteDeux3);
            Controls.Add(lblQuaranteDeux4);
            Controls.Add(lblQuaranteDeux5);
            }

        }
    }

