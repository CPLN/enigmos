﻿using System;
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
       private int iLancement = 0;
       private Button btnPile = new Button();
       private Button btnFace = new Button();
       private Button btnLanceSuite = new Button();
       private Label lblinfo = new Label();
       private Timer t1 = new Timer();
      
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

                

                Controls.Add(btnPile);
                Controls.Add(btnFace);
                Controls.Add(lblinfo);
                Controls.Add(lbxCombi);
                Controls.Add(btnLanceSuite);          
        }
        public override void Load()
        {

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
            
            
            
        }
        public void btnPile_click(object sender, EventArgs e)
        {
            AfficheListbox("Pile");
            iLancement++;
            if (TestBonNombre(iLancement))
            {
                AfficheBtnLance();
            }           
        }
        public void btnFace_click(object sender, EventArgs e)
        {
            AfficheListbox("Face");
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
        public void AfficheListbox(string strChoix)
        {               
             _lstCombi.Add(strChoix);
             lbxCombi.DataSource = null;
             lbxCombi.DataSource = _lstCombi;                                     
                
        }
        public bool TestBonNombre(int iLance)
        {
            return iLance >= 3;
        }
    }
}