using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    public class ReflexeEnigmaPanel : EnigmaPanel
    {
        private Label lblPartiJuste = new Label();
        private Panel pnlTonneaux = new Panel(), pnlTable = new Panel(), pnlPartiJuste = new Panel();
        private Button btnStart = new Button();
        private Timer tJeu = new Timer();
        private int iTemp = 0, iVitesse = 1;
        private bool bStop = false;
        public ReflexeEnigmaPanel()
        {
            Controls.Add(btnStart);
            btnStart.Width = 150;
            btnStart.Height = 40;
            btnStart.Location = new Point(650, 560);
            btnStart.Text = "Commencer";
            btnStart.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
            btnStart.FlatStyle = FlatStyle.System;
            btnStart.Click += new EventHandler(Start);

            Controls.Add(pnlTonneaux);
            pnlTonneaux.Width = 60;
            pnlTonneaux.Height = 60;
            pnlTonneaux.BackgroundImage = Properties.Resources.Verre;
            pnlTonneaux.Left = 370;

            Controls.Add(pnlTable);
            pnlTable.Width = 300;
            pnlTable.Height = 60;
            pnlTable.BackgroundImage = Properties.Resources.Table;
            pnlTable.Location = new Point(250, 540);

            Controls.Add(pnlPartiJuste);
            pnlPartiJuste.Width = 20;
            pnlPartiJuste.Height = 25;
            pnlPartiJuste.BackgroundImage = Properties.Resources.PartiJuste;
            pnlPartiJuste.Location = new Point(350, 515);

            Controls.Add(lblPartiJuste);
            lblPartiJuste.Text = "Partie juste";
            lblPartiJuste.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
            lblPartiJuste.ForeColor = Color.Green;
            lblPartiJuste.Location = new Point(250, 515);

            tJeu.Interval = 1;
            tJeu.Tick += new EventHandler(timer_tJeu);

        }
        private void Start(object sender, EventArgs e)
        {
            if (bStop == false)
            {
                tJeu.Start();
                btnStart.Text = "Stop";
                bStop = true;
            }
            else
            {
                tJeu.Stop();
                iVitesse = 1;
                if(pnlTonneaux.Bottom <= pnlTable.Top && pnlTonneaux.Bottom >= pnlTable.Top - 25)
                {
                    MessageBox.Show("Bravo, vous avez réussi voici la reponse. \n \n Bon réflexe", "Bravo");
                    bStop = false;
                    btnStart.Text = "Commencer";
                    pnlTonneaux.Location = new Point(370, 0);
                }
                else
                {
                    MessageBox.Show("Dommage, vous n'avez pas cliquez au bon moment", "Dommage");
                    bStop = false;
                    btnStart.Text = "Commencer";
                    pnlTonneaux.Location = new Point(370, 0);
                }
            }
        }
        private void timer_tJeu(object sender, EventArgs e)
        {
            if(iTemp%10 == 0)
            {
                iVitesse+=1;
            }
            if (iTemp % 15 == 0)
            {
                iVitesse += 2;
            }
            pnlTonneaux.Top += iVitesse;
            iTemp++;
        }
    }
}
