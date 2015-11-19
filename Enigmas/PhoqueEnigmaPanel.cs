using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    class PhoqueEnigmaPanel : EnigmaPanel
    {
        public PhoqueEnigmaPanel()
        {
            //Création du Phoque
            PictureBox pbxPhoque = new PictureBox();
            pbxPhoque.Size = new Size(20, 40);
            pbxPhoque.BackColor = Color.Blue;
            pbxPhoque.Location = new Point(400 - (pbxPhoque.Width / 2), 550 - (pbxPhoque.Height));

            //Ajout des composants
            Controls.Add(pbxPhoque);
        }
    }
}
