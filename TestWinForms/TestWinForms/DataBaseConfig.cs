using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWinForms
{
    public partial class DataBaseConfig : Form
    {
        public DataBaseConfig()
        {
            InitializeComponent();
        }

        private void DataBaseConfig_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = "车卫士"; 
            this.textBox2.Text = "也许明天会更好";
            this.listBox1.Items.Add("123");
            this.listBox1.Items.Add("456");

        }
    }
}
