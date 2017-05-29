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
       private ListBox lbxCombi2 = new ListBox();
       private List<string> _lstCombi = new List<string>();
       private List<string> _lstCombi2 = new List<string>();
       private int iLancement = 0;
       private Button btnPile = new Button();
       private Button btnFace = new Button();
       private Button btnLanceSuite = new Button();
       private Label lblinfo = new Label();
       private Timer t1 = new Timer();
       private PictureBox pbxGif = new PictureBox();
       private Button btnJeu = new Button();
       private int iFinDuJeu = 0;
             
       public PileOuFaceEnigmaPanel()
            {
                
                lblinfo.Text = "Choisi une combinaison!";
                lblinfo.Name = "lblinfo";           
                lblinfo.Size = new Size(200, 50);
                lblinfo.Font = new Font("Arial", 12);
                lblinfo.Location = new Point(300, 200);
                lblinfo.BackColor = Color.Red;
                lblinfo.TextAlign = ContentAlignment.MiddleCenter;
                                                     
                btnPile.Text = "Pile";
                btnPile.Name = "btnPile";
                btnPile.Font = new Font("Arial", 12);
                btnPile.Size = new Size(100,50);
                btnPile.Location = new Point(200, 400);
                btnPile.TextAlign = ContentAlignment.MiddleCenter;
                btnPile.Click += new System.EventHandler(btnPile_click);

                
                btnFace.Text = "Face";
                btnFace.Name = "btnFace";
                btnFace.Font = new Font("Arial", 12);
                btnFace.Size = new Size(100, 50);
                btnFace.Location = new Point(500, 400);
                btnFace.TextAlign = ContentAlignment.MiddleCenter;
                btnFace.Click += new System.EventHandler(btnFace_click);

                
                lbxCombi.Size = new Size(200, 50);
                lbxCombi.Location = new Point(300, 400);
                lbxCombi.Name = "lbxCombi";
                lbxCombi.Font = new Font("Arial", 8);

                lbxCombi2.Size = new Size(200, 50);
                lbxCombi2.Location = new Point(500, 400);
                lbxCombi2.Name = "lbxCombi2";
                lbxCombi2.Font = new Font("Arial", 8);
                lbxCombi2.Visible = false;

                btnLanceSuite.Text = "Let's go!";
                btnLanceSuite.Name = "btnLanceSuite";
                btnLanceSuite.Font = new Font("Arial", 12);
                btnLanceSuite.Size = new Size(100, 50);
                btnLanceSuite.Location = new Point(200, 200);
                btnLanceSuite.BackColor = Color.Red;
                btnLanceSuite.TextAlign = ContentAlignment.MiddleCenter;
                btnLanceSuite.Click += new System.EventHandler(btnLanceSuite_Click);
                btnLanceSuite.Enabled = false;
                btnLanceSuite.Visible = false;

                btnJeu.Text = "Suite";
                btnJeu.Name = "btnJeu";
                btnJeu.Font = new Font("Arial", 12);
                btnJeu.Size = new Size(100, 50);
                btnJeu.Location = new Point(300, 350);
                btnJeu.BackColor = Color.Red;
                btnJeu.TextAlign = ContentAlignment.MiddleCenter;
                btnJeu.Click += new System.EventHandler(btnJeu_click);
                btnJeu.Enabled = false;
                btnJeu.Visible = false;
                
                t1.Interval = 1500;
                t1.Enabled = false;
                t1.Tick += new System.EventHandler(t1_tick);

                pbxGif.Image = Properties.Resources.Pileouface;
                pbxGif.Size = pbxGif.Image.Size;
                pbxGif.Location = new Point(300, 200);
                pbxGif.Visible = false;
                pbxGif.Enabled = false;

                Controls.Add(btnPile);
                Controls.Add(btnFace);
                Controls.Add(lblinfo);
                Controls.Add(lbxCombi);
                Controls.Add(lbxCombi2);
                Controls.Add(btnLanceSuite);
                Controls.Add(btnJeu);              
                Controls.Add(pbxGif);        
        }

        public void btnJeu_click(object sender, EventArgs e)
        {
            t1.Enabled = true;
            btnJeu.Enabled = false;            
            pbxGif.Enabled = true;
        }
        public void t1_tick(object sender, EventArgs e)
        {            
            pbxGif.Enabled = false;
            t1.Enabled = false;
            btnJeu.Enabled = true;
            btnJeu.Visible = true;
            iFinDuJeu++;
            SelectChangement();
            
            if (TestBonNombre(iFinDuJeu))
            {
                //Quand la partie est fini
                btnJeu.Enabled = false;
            }
        }       
        public void btnLanceSuite_Click(object sender, EventArgs e)
        {
            btnFace.Visible = false;
            btnPile.Visible = false;
            btnLanceSuite.Enabled = false;
            btnLanceSuite.Visible = false;
            lbxCombi.Location = new Point(20, 20);
            lblinfo.Visible = false;
            lbxCombi.Font = new Font("Arial", 9);
            lbxCombi2.Visible = true;
            lbxCombi2.DataSource = _lstCombi2;
            
            pbxGif.Visible = true;
            pbxGif.Enabled = true;           
            t1.Enabled = true;
                 
        }
        public void btnPile_click(object sender, EventArgs e)
        {
            DataListbox("Pile");
            iLancement++;
            if (TestBonNombre(iLancement))
            {
                AfficheBtnLance();
            }           
        }
        public void btnFace_click(object sender, EventArgs e)
        {
            DataListbox("Face");
            iLancement++;
            if (TestBonNombre(iLancement))
            {
                AfficheBtnLance();
            }
        }
        public void AfficheBtnLance()
        {
            btnFace.Enabled = false;
            btnPile.Enabled = false;
            btnLanceSuite.Visible = true;
            btnLanceSuite.Enabled = true;
        }
        public void DataListbox(string strChoix)
        {            
            if (strChoix == "Pile")
            {
                _lstCombi.Add(strChoix);
                _lstCombi2.Add("Face");
            }
            else
            {
                _lstCombi.Add(strChoix);
                _lstCombi2.Add("Pile");
            }   
            
             lbxCombi.DataSource = null;
             lbxCombi.DataSource = _lstCombi;                                                                 
        }
        public bool TestBonNombre(int iLance)
        {
            return iLance >= 3;
        }
        public void SelectChangement()
        {          
            int iSelect = lbxCombi.SelectedIndex;
            lbxCombi2.SetSelected(iSelect, false);
            lbxCombi.SetSelected(iSelect, false); 
            if (iSelect < 2)
              {
                 lbxCombi2.SetSelected(iSelect + 1, true);
                 lbxCombi.SetSelected(iSelect + 1, true);
              }                                                                                  
        }
    }
}
