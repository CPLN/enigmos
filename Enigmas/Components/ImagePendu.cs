using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    public class ImagePendu : PictureBox
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public void SetImage(int i)
        {
            ID = i;
            switch (i)
            {
                case 0: Image = Cpln.Enigmos.Properties.Resources.pendu0; break;
                case 1: Image = Cpln.Enigmos.Properties.Resources.pendu1; break;
                case 2: Image = Cpln.Enigmos.Properties.Resources.pendu2; break;
                case 3: Image = Cpln.Enigmos.Properties.Resources.pendu3; break;
                case 4: Image = Cpln.Enigmos.Properties.Resources.pendu4; break;
                case 5: Image = Cpln.Enigmos.Properties.Resources.pendu5; break;
                case 6: Image = Cpln.Enigmos.Properties.Resources.pendu6; break;
                case 7: Image = Cpln.Enigmos.Properties.Resources.pendu7; break;
                case 8: Image = Cpln.Enigmos.Properties.Resources.pendu8; break;
            }
        }
    }
}
