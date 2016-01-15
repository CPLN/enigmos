using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    public class TrouverEnigmaPanel : EnigmaPanel
    {
        /// <summary>
        /// Constructeur par défaut, génère un texte et l'affiche dans le Panel.
        /// </summary>
        //Déclaration de toutes les variables
        bool bGo = false, bRebondXC = true, bRebondYC = true;
        int iAxeX = 4, iAxeY = 2;
        private Timer Timer = new Timer();
        Button bCristiano = new Button();
        List<Button> buttons = new List<Button>();
        bool[] brebondYA;
        bool[] brebondXA;
        public TrouverEnigmaPanel()
        {
            Label lblEnigme = new Label();
            int i = 0;
            Random random = new Random();
            //Instanciation des bouttons + ajouts d'attributs
            for (i = 0; i < 200; i++)
            {

                Button b = new Button();
                //Ajout des bouttons b dans la liste buttons
                buttons.Add(b);
                this.Controls.Add(b);
                b.Size = new Size(100, 100);
                b.Location = new Point(random.Next(800), random.Next(600));
                b.Name = "Cristiano" + i;
                Controls.Add(b);
                brebondYA = new bool[i];
                brebondXA = new bool[i];

            }
            //Fond d'écran de même couleur que les super meat boy
            this.BackColor = Color.FromArgb(174, 0, 1);

            //Modifications des attributs du boutton Cristiano :D
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
            bGo = true;

            



        }

        private void bCristiano_Click(object sender, EventArgs e)
        {
            //Message qui apparait lorsque l'on clique sur Cristiano
            MessageBox.Show("Le mot à valider est football", "Yo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }



        public override void Load()
        {
            Timer.Start();
        }

        public override void Unload()
        {
            Timer.Stop();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //Code dans l'event timer
            foreach (Button b in buttons)
            {
                //On parcourt la liste de boutton afin de pouvoir y appliquer des changements de paramètres
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderColor = Color.FromArgb(174, 0, 1); 
                b.BackColor = System.Drawing.Color.Transparent;
                b.ForeColor = System.Drawing.Color.Transparent;
                b.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.supermeat));
                //Et on applique "Deplacement" à tous les bouttons
                Deplacement(b);
          
            }
            
            //Voici le système de rebond pour Cristiano, basé sur ce qu'on a appris l'année passée
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
            //Code permettant aux boutton de se déplacer telle une foule
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


