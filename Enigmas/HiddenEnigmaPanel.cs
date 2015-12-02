using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpln.Enigmos.Enigmas
{
    public partial class HiddenEnigmaPanel : Component
    {
        public HiddenEnigmaPanel()
        {
            InitializeComponent();
        }

        public HiddenEnigmaPanel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
