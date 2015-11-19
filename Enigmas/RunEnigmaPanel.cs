using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    class RunEnigmaPanel : EnigmaPanel
    {
        public RunEnigmaPanel()
        {
            //Création des composants
            PictureBox pbxHomme = new PictureBox();
            pbxHomme.Size = new Size(25, 50);
            pbxHomme.BackColor = Color.Red;
            pbxHomme.Location = new Point(400 - pbxHomme.Width,575 - pbxHomme.Height);

            //Ajout des éléments
            Controls.Add(pbxHomme);

        }
    }
}
