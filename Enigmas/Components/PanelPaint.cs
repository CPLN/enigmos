using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpln.Enigmos.Enigmas.Components
{
    public partial class PanelPaint : Component
    {
        public PanelPaint()
        {
            InitializeComponent();
        }

        public PanelPaint(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
