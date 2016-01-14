using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas.Components
{
    public class Ennemi : PictureBox
    {
        private Direction direction;
        private static Random rnd1 = new Random();

        //constructeur
        public Ennemi()
        {
            switch (rnd1.Next(2))
            {
                case 0:
                    direction = Direction.GAUCHE;
                    break;
                case 1:
                    direction = Direction.DROITE;
                    break;
            }
        }

        //renvoie si le point de spawn del'ennemi est à gauche ou à droite
        public Direction getDirection()
        {
            return direction;
        }

        //Génére un ennemi
        public static Ennemi CreateEnnemi(EnigmaPanel panel, PictureBox pbxGround, List<Ennemi> listEnnemi)
        {
            Ennemi pbxEnnemi = new Ennemi();
            pbxEnnemi.Size = new Size(70, 80);
            pbxEnnemi.Size = Properties.Resources.ennemi1.Size;

            if (pbxEnnemi.direction == Direction.DROITE)
            {
                pbxEnnemi.Location = new Point(pbxGround.Left, pbxGround.Top - pbxEnnemi.Height);
            }
            else if (pbxEnnemi.direction == Direction.GAUCHE)
            {
                pbxEnnemi.Location = new Point(pbxGround.Right - pbxEnnemi.Width, pbxGround.Top - pbxEnnemi.Height);
            }

            pbxEnnemi.BackColor = Color.Transparent;
            pbxEnnemi.Image = Properties.Resources.ennemi1;
            panel.Controls.Add(pbxEnnemi);

            listEnnemi.Add(pbxEnnemi);

            return pbxEnnemi;
        }
    }
}
