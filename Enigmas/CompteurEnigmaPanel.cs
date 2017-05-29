using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace Cpln.Enigmos.Enigmas
{
    public class CompteurEnigmaPanel:EnigmaPanel
    {
        private int iTemps = 0;
        private Label lblTemps = new Label();
        private Button btnStart = new Button();
        private Random rTempsAleatoire = new Random();
        private Stopwatch stopwatch;
        public CompteurEnigmaPanel()
        {
            //Mise en place du bouton et du label
            lblTemps.Size = new Size(200, 200);
            lblTemps.Location = new Point(300, 200);
            lblTemps.BackColor = Color.Red;
            lblTemps.Font = new Font("Arial", 30);
            lblTemps.AutoSize = false;
            lblTemps.TextAlign=ContentAlignment.MiddleCenter;
            Controls.Add(lblTemps);
            btnStart.Size = new Size(200, 50);
            btnStart.Location = new Point(300, 400);
            btnStart.Font = new Font("Arial", 30);
            btnStart.Text = "Start";
            Controls.Add(btnStart);
            btnStart.Click+=new EventHandler(btnStart_Click);

        }

        /// <summary>
        /// Lancement du compteur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            //Débloquer le bouton
            btnStart.Enabled = false;

            //Démarrer le timer
            stopwatch = Stopwatch.StartNew();
        }
        /// <summary>
        /// Pression sur une touche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void PressKey(object sender, KeyEventArgs e)
        {
            int iTempsMax = iTemps * 2000 + 150;
            int iTempsMin = iTemps * 2000 - 150;
            //Contrôle pression barre espace
              if (e.KeyCode == Keys.Space)
            {
                //Fin du timer
                int iTempsJoueur = Convert.ToInt32(stopwatch.ElapsedMilliseconds);

                //Teste de gain
                if (iTempsJoueur >= iTempsMin && iTempsJoueur <= iTempsMax)
                {
                    MessageBox.Show("Bravo la réponse est: temps", "Bravo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }else if(iTempsJoueur > iTempsMax)
                {
                    btnStart.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Lancement de l'énigme
        /// </summary>
        public override void Load()
        {
            //Temps aléatoire
            iTemps=rTempsAleatoire.Next(5, 15);

            //Débloquer le bouton
            btnStart.Enabled = true;

            //Affichage du temps à atteindre
            lblTemps.Text = iTemps.ToString();
        }
    }
}
