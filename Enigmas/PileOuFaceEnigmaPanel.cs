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
       private List<string> _lstCombi = new List<string>();
       public PileOuFaceEnigmaPanel()
            {
                
                Label lblinfo = new Label();
                lblinfo.Text = "Choisi ta combinaison!";
                lblinfo.Name = "lblinfo";           
                lblinfo.Size = new Size(200, 50);
                lblinfo.Font = new Font("Arial", 12);
                lblinfo.Location = new Point(300, 200);
                lblinfo.BackColor = Color.Red;
                lblinfo.TextAlign = ContentAlignment.MiddleCenter;

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

                ListBox lbxCombi = new ListBox();
                lbxCombi.DataSource = _lstCombi;
                lbxCombi.Size = new Size(200, 50);
                lbxCombi.Location = new Point(300, 400);
                Controls.Add(lbxCombi);
                
                //TextBox tbxCombi = new TextBox();
                //tbxCombi.Name = "tbxCombi";
                //tbxCombi.Size = new Size(200, 50);
                //tbxCombi.Location = new Point(300,400);

                //Controls.Add(tbxCombi);
                Controls.Add(btnPile);
                Controls.Add(btnFace);
                Controls.Add(lblinfo);
            }
        public void btnPile_click(object sender, EventArgs e)
        {
            _lstCombi.Add("Pile");
            
        }
        public void btnFace_click(object sender, EventArgs e)
        {
            _lstCombi.Add("Face");
        }
    }
}
