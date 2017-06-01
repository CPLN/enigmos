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
       private static Random r1 = new Random();
       private ListBox lbxCombi = new ListBox();
       private ListBox lbxCombi2 = new ListBox();
       private List<string> _lstCombi = new List<string>();
       private List<string> _lstCombi2 = new List<string>();
       private int iLancement = 0;
       private Button btnPile = new Button();
       private Button btnFace = new Button();
       private Button btnLanceSuite = new Button();
       private Button btnRepGauche = new Button();
       private Button btnRepDroite = new Button();
       private Button btnRecommencer = new Button();
       private Button btnRepFinal = new Button();
       private Label lblinfo = new Label();
       private Label lblReponsefinal = new Label();
       private Label lblReponseGauche = new Label();
       private Label lblReponseDroite = new Label();
       private Timer t1 = new Timer();
       private PictureBox pbxGif = new PictureBox();
       private Button btnJeu = new Button();
       private int iNbrReponseJuste = 0;
       private int iFinDuJeu = 0;
       private System.Drawing.SolidBrush myBrushFaux = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
       private System.Drawing.SolidBrush myBrushVrai = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
       private System.Drawing.Graphics formGraphics;

        public PileOuFaceEnigmaPanel()
            {
                r1 = new Random();
                formGraphics = this.CreateGraphics();

                lblinfo.Text = "Choisi une combinaison!";
                lblinfo.Name = "lblinfo";           
                lblinfo.Size = new Size(200, 50);
                lblinfo.Font = new Font("Arial", 12);
                lblinfo.Location = new Point(300, 200);
                lblinfo.BackColor = Color.Red;
                lblinfo.TextAlign = ContentAlignment.MiddleCenter;

                lblReponsefinal.Text = "Pile poil";
                lblReponsefinal.Name = "lblReponseFinal";
                lblReponsefinal.Size = new Size(350, 350);
                lblReponsefinal.Font = new Font("Arial", 16);
                lblReponsefinal.Location = new Point(375, 300);               
                lblReponsefinal.TextAlign = ContentAlignment.MiddleCenter;
                lblReponsefinal.Visible = false;

                lblReponseGauche.Text = "Deuxième mot :Poil";
                lblReponseGauche.Name = "lblReponseGauche";
                lblReponseGauche.Size = new Size(200, 200);
                lblReponseGauche.Font = new Font("Arial", 16);
                lblReponseGauche.Location = new Point(200, 200);
                lblReponseGauche.TextAlign = ContentAlignment.MiddleCenter;
                lblReponseGauche.Visible = false;

                lblReponseDroite.Text = "Premier mot :Pile";
                lblReponseDroite.Name = "lblReponseGauche";
                lblReponseDroite.Size = new Size(200, 200);
                lblReponseDroite.Font = new Font("Arial", 16);
                lblReponseDroite.Location = new Point(200, 200);
                lblReponseDroite.TextAlign = ContentAlignment.MiddleCenter;
                lblReponseDroite.Visible = false;

                btnPile.Text = "Pile";
                btnPile.Name = "btnPile";
                btnPile.Font = new Font("Arial", 12);
                btnPile.Size = new Size(100,50);
                btnPile.Location = new Point(200, 400);
                btnPile.TextAlign = ContentAlignment.MiddleCenter;
                btnPile.Click += new System.EventHandler(btnPile_click);
   
                btnRepGauche.Text = "Réponse 1";
                btnRepGauche.Name = "btnRepGauche";
                btnRepGauche.Font = new Font("Arial", 12);
                btnRepGauche.Size = new Size(100, 50);
                btnRepGauche.Location = new Point(200, 500);
                btnRepGauche.TextAlign = ContentAlignment.MiddleCenter;
                btnRepGauche.Click += new System.EventHandler(btnRepGauche_click);
                btnRepGauche.Visible = false;
                btnRepGauche.Enabled = false;

                btnRepDroite.Text = "Réponse 2";
                btnRepDroite.Name = "btnRepDroite";
                btnRepDroite.Font = new Font("Arial", 12);
                btnRepDroite.Size = new Size(100, 50);
                btnRepDroite.Location = new Point(500, 500);
                btnRepDroite.TextAlign = ContentAlignment.MiddleCenter;
                btnRepDroite.Click += new System.EventHandler(btnRepDroite_click);
                btnRepDroite.Visible = false;
                btnRepDroite.Enabled = false;

                btnRecommencer.Text = "Recommencer";
                btnRecommencer.Name = "btnRecommencer";
                btnRecommencer.Font = new Font("Arial", 12);
                btnRecommencer.Size = new Size(150, 50);
                btnRecommencer.Location = new Point(325, 500);
                btnRecommencer.TextAlign = ContentAlignment.MiddleCenter;
                btnRecommencer.Click += new System.EventHandler(btnRecommencer_click);
                btnRecommencer.Enabled = false;
                btnRecommencer.Visible = false;

                btnRepFinal.Text = "Réponse final";
                btnRepFinal.Name = "btnRepFinal";
                btnRepFinal.Font = new Font("Arial", 12);
                btnRepFinal.Size = new Size(150, 50);
                btnRepFinal.Location = new Point(325, 500);
                btnRepFinal.TextAlign = ContentAlignment.MiddleCenter;
                btnRepFinal.Click += new System.EventHandler(btnRepFinal_click);
                btnRepFinal.Enabled = false;
                btnRepFinal.Visible = false;

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
                lbxCombi2.Location = new Point(580, 20);
                lbxCombi2.Name = "lbxCombi2";
                lbxCombi2.Font = new Font("Arial", 9);
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
                btnJeu.Location = new Point(350, 350);
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
                pbxGif.Location = new Point(350, 200);
                pbxGif.Visible = false;
                pbxGif.Enabled = false;

            // Controls.Add(lblReponseGauche);
            // Controls.Add(lblReponsefinal);
            // Controls.Add(lblReponseDroite);
            // Controls.Add(btnRecommencer);
            // Controls.Add(btnRepFinal);
            // Controls.Add(btnRepDroite);
            // Controls.Add(btnRepGauche);
            // Controls.Add(btnPile);
            // Controls.Add(btnFace);
            // Controls.Add(lblinfo);
            // Controls.Add(lbxCombi);
            // Controls.Add(lbxCombi2);
            // Controls.Add(btnLanceSuite);
            // Controls.Add(btnJeu);              
            //Controls.Add(pbxGif); 
            Unload();
            Load();
        }
        private void btnRepFinal_click(object sender, EventArgs e)
        {
            lblReponsefinal.Visible = true;
            btnRecommencer.Visible = true;
            btnRecommencer.Enabled = true;
        }
        public override void Unload()
        {
            Controls.Remove(lblReponseGauche);
            Controls.Remove(lblReponsefinal);
            Controls.Remove(lblReponseDroite);
            Controls.Remove(btnRecommencer);
            Controls.Remove(btnRepFinal);
            Controls.Remove(btnRepDroite);
            Controls.Remove(btnRepGauche);
            Controls.Remove(btnPile);
            Controls.Remove(btnFace);
            Controls.Remove(lblinfo);
            Controls.Remove(lbxCombi);
            Controls.Remove(lbxCombi2);
            Controls.Remove(btnLanceSuite);
            Controls.Remove(btnJeu);
            Controls.Remove(pbxGif);                    
            Invalidate();

        }
        public override void Load()
        {
            Controls.Add(lblReponseGauche);
            Controls.Add(lblReponsefinal);
            Controls.Add(lblReponseDroite);
            Controls.Add(btnRecommencer);
            Controls.Add(btnRepFinal);
            Controls.Add(btnRepDroite);
            Controls.Add(btnRepGauche);
            Controls.Add(btnPile);
            Controls.Add(btnFace);
            Controls.Add(lblinfo);
            Controls.Add(lbxCombi);
            Controls.Add(lbxCombi2);
            Controls.Add(btnLanceSuite);
            Controls.Add(btnJeu);
            Controls.Add(pbxGif);
        }
        private void btnRecommencer_click(object sender, EventArgs e)
        {
            Unload();
            Load();                 
        }
        private void btnRepDroite_click(object sender, EventArgs e)
        {
            lblReponseDroite.Visible = true;
            btnRecommencer.Visible = true;
            btnRecommencer.Enabled = true;
        }
        private void btnRepGauche_click(object sender, EventArgs e)
        {
            lblReponseGauche.Visible = true;
            btnRecommencer.Visible = true;
            btnRecommencer.Enabled = true;
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
            string strRandomChoix = ChoixRandom();
            bool bTest = TestChoixRandom(strRandomChoix);
            switch (iFinDuJeu)
                {
                             
                case 1:
                        if (bTest)
                        {
                            formGraphics.FillRectangle(myBrushVrai, new Rectangle(315,450, 50, 50));
                            iNbrReponseJuste++;
                        }
                        else
                        {
                            formGraphics.FillRectangle(myBrushFaux, new Rectangle(315, 450, 50, 50));
                        }
                    break;
                    case 2:
                        if (bTest)
                        {
                            formGraphics.FillRectangle(myBrushVrai, new Rectangle(375, 450, 50, 50));
                            iNbrReponseJuste++;
                        }
                        else
                        {
                            formGraphics.FillRectangle(myBrushFaux, new Rectangle(375, 450, 50, 50));
                        }
                    break;
                    case 3:
                        if (bTest)
                        {
                            formGraphics.FillRectangle(myBrushVrai, new Rectangle(435, 450, 50, 50));
                            iNbrReponseJuste++;
                        }
                        else
                        {
                            formGraphics.FillRectangle(myBrushFaux, new Rectangle(435, 450, 50, 50));
                        }
                    break;
                   
                    default:
                        break;
                
                }
            SelectChamps();          
            if (TestBonNombre(iFinDuJeu))
            {            
                btnJeu.Enabled = false;
                if (iNbrReponseJuste < 2)
                {
                    btnRecommencer.Visible = true;
                    btnRecommencer.Enabled = true;
                }
                else if (iNbrReponseJuste == 2)
                {
                    btnRepDroite.Visible = true;
                    btnRepDroite.Enabled = true;
                    btnRepGauche.Visible = true;
                    btnRepGauche.Enabled = true;
                }
                else
                {
                    btnRepFinal.Visible = true;
                    btnRepFinal.Enabled = true;
                }
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
        public void SelectChamps()
        {          
            int iSelect = lbxCombi.SelectedIndex;
            lbxCombi2.SetSelected(iSelect, false);
            lbxCombi.SetSelected(iSelect, false); 
            if (iSelect < 2)
              {
                 lbxCombi2.SetSelected(iSelect + 1, true);
                 lbxCombi.SetSelected(iSelect + 1, true);
              }
            else
              {
                lbxCombi2.SetSelected(iSelect, true);
                lbxCombi.SetSelected(iSelect, true);
              }                                                                                  
        }
        public string ChoixRandom()
        {
               
            if (r1.Next(0,2)==0)
            {
                return "Pile";
            }
            else
            {
                return "Face";
            }
            
        }
        public bool TestChoixRandom(string strchoix)
        {
            string strRandom = Convert.ToString(lbxCombi.SelectedItem);
            if (strchoix == strRandom)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
