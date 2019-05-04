using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLib
{
    public partial class Component21 : Component
    {
        public Component21()
        {
            InitializeComponent();
        }

        public Component21(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
