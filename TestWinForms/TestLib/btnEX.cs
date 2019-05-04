using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestLib
{
    public partial class btnEX : Button
    {
        private Color btnBColor;
        public Color BtnBColor
        {
            get
            {
                return btnBColor;
            }
            set
            {
                btnBColor = value;
                this.BackColor = btnBColor;
            }
        }
        public btnEX()
        {
            InitializeComponent();
        }

        public btnEX(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
