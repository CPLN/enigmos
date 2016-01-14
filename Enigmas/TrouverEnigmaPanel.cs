using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    public class Boutton : EnigmaPanel
    {

    }
    public class TrouverEnigmaPanel : EnigmaPanel
    {
        /// <summary>
        /// Constructeur par défaut, génère un texte et l'affiche dans le Panel.
        /// </summary>
        bool bGo = false, bRebondXC = true, bRebondYC = true;
        int iAxeX = 4, iAxeY = 2;
        private Timer Timer = new Timer();
        Button bCristiano = new Button();
        List<Button> buttons = new List<Button>();
        bool[] brebondYA;
        bool[] brebondXA;
        public TrouverEnigmaPanel()
        {
            //bGo = true;
            Label lblEnigme = new Label();
            int i = 0;
            Random random = new Random();
            for (i = 0; i < 150; i++)
            {

                Button b = new Button();
                buttons.Add(b);
                this.Controls.Add(b);

                b.Size = new Size(100, 100);
                b.Location = new Point(random.Next(800), random.Next(600));
                b.Name = "Cristiano" + i;
                Controls.Add(b);
                brebondYA = new bool[i];
                brebondXA = new bool[i];
            }

            this.BackColor = Color.FromArgb(174, 0, 1);

            bCristiano.Text = "" + 666;
            bCristiano.Size = new Size(100, 100);
            bCristiano.Location = new Point(400, 300);
            bCristiano.BackColor = Color.Red;
            bCristiano.Click += new EventHandler(bCristiano_Click);
            bCristiano.FlatStyle = FlatStyle.Flat;
            bCristiano.FlatAppearance.BorderColor = Color.FromArgb(174, 0, 1);
            bCristiano.BackColor = System.Drawing.Color.Transparent;
            bCristiano.ForeColor = System.Drawing.Color.Transparent;
            bCristiano.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.cristiano));
            Controls.Add(bCristiano);
            lblEnigme.Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);
            lblEnigme.Dock = DockStyle.Fill;
            lblEnigme.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(lblEnigme);

            //Mise en place d'un timer
            Timer.Interval = 1; // 1 milliseconde
            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Start();
            bGo = true;

            //lblEnigme.Text = "fesse ?";



        }

        private void bCristiano_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Le mot à valider est cristiano", "Yo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

       

        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (Button b in buttons)
            {
                
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderColor = Color.FromArgb(174, 0, 1); 
                b.BackColor = System.Drawing.Color.Transparent;
                b.ForeColor = System.Drawing.Color.Transparent;
                b.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.supermeat));
                Deplacement(b);
          
            }
            
            if (bGo == true)
                {
                    if (bCristiano.Left <= 0 || bCristiano.Right >= this.Width)
                    {
                        bRebondXC = !bRebondXC;
                    }
                    if (bCristiano.Top <= 0 || bCristiano.Bottom >= this.Height)
                    {
                        bRebondYC = !bRebondYC;
                    }
                    if (bRebondYC == true)
                    {
                        bCristiano.Top += iAxeY;
                    }
                    else
                    {
                        bCristiano.Top -= iAxeY;
                    }
                    if (bRebondXC == true)
                    {
                        bCristiano.Left += iAxeX;
                    }
                    else
                    {
                        bCristiano.Left -= iAxeX;
                    }
                }
            }
        public void Deplacement(Button b)
        {
            if (bGo == true)
            {
                for (int i = 0; i < 10; i++ )
                {

                    if (b.Left <= 0 || b.Right >= this.Width)
                    {
                        brebondXA[i] = !brebondXA[i];
                    }
                    if (b.Top <= 0 || b.Bottom >= this.Height)
                    {
                        brebondYA[i] = !brebondYA[i];
                    }
                    if (brebondYA[i] == true)
                    {
                        b.Top += iAxeY;
                    }
                    else
                    {
                        b.Top -= iAxeY;
                    }
                    if (brebondXA[i] == true)
                    {
                        b.Left += iAxeX;
                    }
                    else
                    {
                        b.Left -= iAxeX;
                    }
                }
            }
        }
     }
 }


