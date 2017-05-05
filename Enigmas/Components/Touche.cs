using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Cpln.Enigmos.Enigmas.Components
{
    class Touche : MovablePanel
    {
        private Label lblLettre;

        public Label LabelLettre
        {
            get
            {
                return lblLettre;
            }
            private set
            {
                lblLettre = value;
            }
        }

        public Touche(string nom,int Width, int Height)
        {
            LabelLettre = new Label();
            LabelLettre.Text = nom;
            LabelLettre.Font = new Font(FontFamily.GenericMonospace, 10);
            LabelLettre.AutoSize = true;
            LabelLettre.BackColor = Color.Transparent;
            LabelLettre.ForeColor = Color.White;
            Controls.Add(LabelLettre);

            this.Width = Width ;
            this.Height = Height ;

            BackColor = Color.Black;
            BorderStyle = BorderStyle.Fixed3D;
        }
    }
}

