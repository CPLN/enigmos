using Cpln.Enigmos.Enigmas.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    public class TapeTaupeEnigmaPanel : EnigmaPanel
    {       
        private Timer tJeuTapeTaupe = new Timer();
        PictureBox pbxTaupe = new PictureBox();
        Random RandoPosition = new Random();
        Random RandoDifficulte = new Random();


        private int iCompteur = 0;
        private int iAxeX;
        private int iAxey;
        private int iScore;
        private int iVitesse;

        public TapeTaupeEnigmaPanel()
        {
            tJeuTapeTaupe.Interval = 1;
            tJeuTapeTaupe.Tick += new EventHandler(timer_tJeuTapeTaupe);
            tJeuTapeTaupe.Start();
            
            pbxTaupe.Width = 50;
            pbxTaupe.Height = 50;
            pbxTaupe.Location = new Point(0, 0);
            pbxTaupe.Enabled = false;
            pbxTaupe.Visible = false;
            //pbxTaupe.Image = 
            pbxTaupe.BackColor = Color.Aqua;
            Controls.Add(pbxTaupe);
            pbxTaupe.BringToFront();
            pbxTaupe.MouseClick += new MouseEventHandler(pbxTaupe_Click);

            iVitesse = RandoDifficulte.Next(200, 250);
            this.Cursor = new Cursor(Properties.Resources.gifessai.GetHicon());
            this.Cursor.Size = new Size(2, 2);

        }

        private void pbxTaupe_Click(object sender, MouseEventArgs e)
        {
            //si taupe
            iScore++;
            pbxTaupe.Enabled = false;
            pbxTaupe.Visible = false;

            //si lapin
            iScore = 0;
        }

        private void timer_tJeuTapeTaupe(object sender, EventArgs e)
        {
            iCompteur++;

            if (iCompteur == 150)
            {
                iAxeX = RandoPosition.Next(0, Width - pbxTaupe.Width);
                iAxey = RandoPosition.Next(0, Height - pbxTaupe.Height);
                pbxTaupe.Location = new Point(iAxeX, iAxey);
                pbxTaupe.Enabled = true;
                pbxTaupe.Visible = true;
            } 
            else if (iCompteur == iVitesse)
            {
                iCompteur = 149;
            }

            if (iScore == 10)
            {
                tJeuTapeTaupe.Stop();
                MessageBox.Show("La réponse est \"taupe\"", "Réponse", MessageBoxButtons.OK);
            }
        }
    }
}
