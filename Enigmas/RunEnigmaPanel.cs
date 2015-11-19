using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    class RunEnigmaPanel : EnigmaPanel
    {
        public RunEnigmaPanel()
        {
            //Création du joueur
            PictureBox pbxHomme = new PictureBox();
            pbxHomme.Size = new Size(25, 50);
            pbxHomme.BackColor = Color.Red;
            pbxHomme.Location = new Point(400 - pbxHomme.Width,575 - pbxHomme.Height);

            //Création d'un obstacle
            PictureBox pbxCaillou = new PictureBox();
            pbxCaillou.Size = new Size(50, 50);
            pbxCaillou.BackColor = Color.Gray;
            pbxCaillou.Location = new Point(400 - pbxCaillou.Width, 75 - pbxCaillou.Height);

            //Ajout des éléments
            Controls.Add(pbxHomme);
            Controls.Add(pbxCaillou);

        }
    }
}
