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
        private Label lblStart = new Label();
        private Random rTempsAleatoire = new Random();
        private Stopwatch stopwatch;
        private int iSec = 0;
        private int iDix = 0;
        private int iCent = 0;
        private int iMili = 0;

        /// <summary>
        /// Tranfome le temps pour l'affichage
        /// </summary>
        /// <param name="iTempsEcoule">Temps que le joueur a mis pour presser sur la barre espace</param>
        public void TransformerTemps(int iTempsEcoule)
        {
            int iTempsModif = iTempsEcoule;
            iSec = Convert.ToInt32(iTempsModif / 1000);
            iTempsModif = iTempsModif - iSec * 1000;
            iDix = Convert.ToInt32(iTempsModif / 100);
            iTempsModif = iTempsModif - iDix * 100;
            iCent = Convert.ToInt32(iTempsModif / 10);
            iTempsModif = iTempsModif - iCent * 10;
            iMili = Convert.ToInt32(iTempsModif / 1);
            iTempsModif = iTempsModif - iMili;
        }

        public CompteurEnigmaPanel()
        {
            //Mise en place des labels
            lblTemps.Size = new Size(200, 200);
            lblTemps.Location = new Point(300, 200);
            lblTemps.BackColor = Color.Red;
            lblTemps.Font = new Font("Arial", 30);
            lblTemps.AutoSize = false;
            lblTemps.TextAlign=ContentAlignment.MiddleCenter;
            Controls.Add(lblTemps);
            lblStart.Size = new Size(200, 50);
            lblStart.Location = new Point(300, 400);
            lblStart.Font = new Font("Arial", 30);
            lblStart.BackColor = Color.Beige;
            lblStart.Text = "Start";
            lblStart.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(lblStart);
            lblStart.Click+=new EventHandler(lblStart_Click);
        }

        /// <summary>
        /// Lancement du compteur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblStart_Click(object sender, EventArgs e)
        {
            //Bloquer le label
            lblStart.Enabled = false;

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
            int iTempsMax = iTemps * 1000 + 250;
            int iTempsMin = iTemps * 1000 - 250;
            //Contrôle pression barre espace
            if (e.KeyCode == Keys.Space)
            {
                //Fin du timer
                stopwatch.Stop();
                int iTempsJoueur = Convert.ToInt32(stopwatch.ElapsedMilliseconds);

                //Transformation du temps
                TransformerTemps(iTempsJoueur);

                //Teste de gain
                if (iTempsJoueur >= iTempsMin && iTempsJoueur <= iTempsMax)
                {  
                    MessageBox.Show("Bravo la réponse est: temps\n\nVous avez fait : " + iSec.ToString() + ":" + iDix.ToString() + iCent.ToString() + iMili.ToString(), "Bravo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }else
                {
                    lblStart.Enabled = true;

                    //Affichage du temps à atteindre
                    iTemps = rTempsAleatoire.Next(5, 15);
                    lblTemps.Text = iTemps.ToString();
                    MessageBox.Show(iSec.ToString() + ":" + iDix.ToString() + iCent.ToString() + iMili.ToString(), "Fin", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            //Débloquer le label
            lblStart.Enabled = true;

            //Affichage du temps à atteindre
            lblTemps.Text = iTemps.ToString();
        }
    }
}
