using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWinForms
{
    public partial class Configini : Form
    {
        public Configini()
        {
            InitializeComponent();
        }

        private void 打开ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            this.textBox1.Text = File.ReadAllText(openFileDialog1.FileName);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.WriteAllText(openFileDialog1.FileName, this.textBox1.Text);
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            File.WriteAllText(saveFileDialog1.FileName, this.textBox1.Text);
        }

        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            saveFileDialog1.ShowDialog();
        }
    }
}
