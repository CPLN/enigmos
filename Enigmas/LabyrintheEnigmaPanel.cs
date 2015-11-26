using Cpln.Enigmos.Enigmas.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    /// <summary>
    /// Panel affichant une énigme.
    /// </summary>
    public class LabyrintheEnigmaPanel : EnigmaPanel
    {

        List<Panel> Case;

        private void test()
        {
            Panel test = new Panel();
            test.Name = "test1";
            Case.Add(test);
            test.Width = 50;
            test.Height = 50;
            test.BackColor = Color.Red;
            this.Controls.Add(test);
        }

        public LabyrintheEnigmaPanel()
        {
            Graph<Panel> graph = new Graph<Panel>(new Panel());

            Case = new List<Panel>();
            test();
            graph.Root.Element = Case[0];
            graph.Root.FindNeighbor(Case[0]);
            graph.Root.AddNeighbor(Case[0]);
            
        }
    }
}
