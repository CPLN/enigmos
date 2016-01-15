using Cpln.Enigmos.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace Cpln.Enigmos.Enigmas
{
    /// <summary>
    /// enigme ou l'on doit trouver le rectangle parmi plusieurs carrés
    /// </summary>
    public class RectangleEnigmaPanel : EnigmaPanel
    {
        // Initialisation de divers variables
        Panel[] tpnlCarre = new Panel[110];
        FlowLayoutPanel centerLayout = new FlowLayoutPanel();
        
        /// <summary>
        /// Constructeur par défaut, génère plusieurs carrés.
        /// </summary>
        public RectangleEnigmaPanel()
        {
            //changement de taille de l'espace graphique
            Width = 550;
            Height = 500;

            //Proriétés de la disposition du jeu
            centerLayout.Dock = DockStyle.Fill;

            //ajout d'un contrôle sur la disposition
            Controls.Add(centerLayout);

            Random rndArgb = new Random();
            //création de carré dans le rectangle             
            for (int i = 0; i < tpnlCarre.Length; i++)
            {
                tpnlCarre[i] = new Panel();
                tpnlCarre[i].Margin = new Padding(2);
                tpnlCarre[i].Size = new Size(46, 46);
                Color rndColor = Color.FromArgb(rndArgb.Next(240), rndArgb.Next(240),rndArgb.Next(255));
                tpnlCarre[i].BackColor = rndColor;
                centerLayout.Controls.Add(tpnlCarre[i]);
                tpnlCarre[i].Click += new EventHandler(ClickOnCarre);
            }
            //Evenement d'un clic sur le panel rectangle
            centerLayout.Click += new EventHandler(ClickOnPanel);
        }
        //message si le jouer appuie sur le panel rectangle
        private void ClickOnPanel(object sender, EventArgs e)
        {
            MessageBox.Show("Bien ! (⌐■_■)" + "\n" + "La réponse à l'énigme est la couleur du rectangle.");
        }
        //message si le jouer appuie sur l'un des panels carrés
        private void ClickOnCarre(object sender, EventArgs e)
        {
            MessageBox.Show("NON C'est un carré");
        }
    }
}