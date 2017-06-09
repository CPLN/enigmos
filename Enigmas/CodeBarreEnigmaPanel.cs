using Cpln.Enigmos.Enigmas.Components;
using Cpln.Enigmos.Enigmas.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    class CodeBarreEnigmaPanel : EnigmaPanel
    {
        /// <summary>
        /// Création d'une liste pour les panel
        /// Créer une instance de Random
        /// </summary>
        List<MovablePanel> list = new List<MovablePanel>();
        int iPosX = 120;
        Random rnd = new Random();
        RotatingLabel cpln = new RotatingLabel();


        /// <summary>
        /// Constructeur par défaut (instancie les panels et le mot caché)
        /// </summary>
        public CodeBarreEnigmaPanel()
        {
            // instancie le code barre
            for (int i = 0; i < 15; i++)
            {
                MovablePanel Barre = new MovablePanel();
                Barre.Cursor = Cursors.Arrow;
                list.Add(Barre);
                list[i].Size = new Size(rnd.Next(9, 22), 200);
                list[i].BackColor = Color.Black;
                this.Controls.Add(list[i]);
                iPosX += 12;
            }
            // Définie une taille pour le panel qui est sur le mot caché
            list[11].Size = new Size(11, 200);

            // instancie le mot caché
            cpln.Text = "CodeBarreVicieux";
            cpln.Location = new Point(504, 300);
            cpln.Size = new Size(1, 10);
            cpln.Angle = 90;
            this.Controls.Add(cpln);
        }
        /// <summary>
        /// Repositionne les panels
        /// </summary>
        public override void Load()
        {
            iPosX = 120;
            for (int i = 0; i < 15; i++)
            {
                list[i].Location = new Point(2 * iPosX, 200);
                iPosX += 12;
            }
            list[11].Location = new Point(505, 200);
        }
    }
}
