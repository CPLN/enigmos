using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    public class PileOuFaceEnigmaPanel : EnigmaPanel
    {
       private ListBox lbxCombi = new ListBox();
       private List<string> _lstCombi = new List<string>();
       private bool bLancement = false;
       public PileOuFaceEnigmaPanel()
            {
                
                Label lblinfo = new Label();
                lblinfo.Text = "Choisi une combinaison!";
                lblinfo.Name = "lblinfo";           
                lblinfo.Size = new Size(200, 50);
                lblinfo.Font = new Font("Arial", 12);
                lblinfo.Location = new Point(300, 200);
                lblinfo.BackColor = Color.Red;
                lblinfo.TextAlign = ContentAlignment.MiddleCenter;
            if (bLancement == false)
            {            
                Button btnPile = new Button();
                btnPile.Text = "Pile";
                btnPile.Name = "btnPile";
                btnPile.Font = new Font("Arial", 12);
                btnPile.Size = new Size(100,50);
                btnPile.Location = new Point(200, 400);
                btnPile.TextAlign = ContentAlignment.MiddleCenter;
                btnPile.Click += new System.EventHandler(btnPile_click);

                Button btnFace = new Button();
                btnFace.Text = "Face";
                btnFace.Name = "btnFace";
                btnFace.Font = new Font("Arial", 12);
                btnFace.Size = new Size(100, 50);
                btnFace.Location = new Point(500, 400);
                btnFace.TextAlign = ContentAlignment.MiddleCenter;
                btnFace.Click += new System.EventHandler(btnFace_click);


                Controls.Add(btnPile);
                Controls.Add(btnFace);

            }
            
                lbxCombi.Size = new Size(200, 50);
                lbxCombi.Location = new Point(300, 400);
        //TextBox tbxCombi = new TextBox();
        //tbxCombi.Name = "tbxCombi";
        //tbxCombi.Size = new Size(200, 50);
        //tbxCombi.Location = new Point(300,400);

        //Controls.Add(tbxCombi);
       
                Controls.Add(lblinfo);
                Controls.Add(lbxCombi);
        }
        public void btnPile_click(object sender, EventArgs e)
        {           
            AfficheListbox("Pile");           
        }
        public void btnFace_click(object sender, EventArgs e)
        {           
            AfficheListbox("Face");
        }
        public void AfficheListbox(string strChoix)
        {
            _lstCombi.Add(strChoix);
            lbxCombi.DataSource = null;
            lbxCombi.DataSource = _lstCombi;           
        }
    }
}
