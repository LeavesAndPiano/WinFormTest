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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //var loginForm = new Login();
            //loginForm.ShowDialog();
            //tsslUser.Text = UserInfo.UserName;
        }

       /// <summary>
       /// 判断是否存在激活窗口
       /// </summary>
       /// <param name="formName"></param>
       /// <returns>存在返回-1 否则返回0</returns>       
       private int formVisible(string formName)
        {
            foreach (Form childForm in this.MdiChildren)
            {
                if (childForm.Name == formName)
                {
                    childForm.Visible = true;
                    childForm.Activate();
                    return -1;
                }
               
            }
            return 0;
        }

        private void 数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.formVisible("DataBaseConfig") < 0) return;

            var farm = new DataBaseConfig();
            farm.MdiParent = this;
            farm.Show();
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void 数据库配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.数据库ToolStripMenuItem_Click(sender, e);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

            //if (e.CloseReason == CloseReason.UserClosing)
            //{
            //    e.Cancel = true;
            //    this.Hide();
            //    notifyIcon1.BalloonTipTitle = "注意哦";
            //    notifyIcon1.BalloonTipText = "单击启动我";
            //    notifyIcon1.ShowBalloonTip(1000);
            //}else if (e.CloseReason == CloseReason.ApplicationExitCall)
            //{
            //    if (MessageBox.Show("是否要退出程序？", "程序退出", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)== DialogResult.Yes)
            //    {
            //        Application.Exit();
            //    }
            //    else
            //    {
            //        e.Cancel = true;
            //        return;
            //    }
            //}

        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            this.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.tsslDatetime.Text = DateTime.Now.ToString();
        }

        private void 程序自定义设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.formVisible("Configini") < 0) return;
            var farm = new Configini();
            farm.MdiParent = this;
            farm.Show();
            //层叠
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void 程序字体设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.formVisible("FontConfig") < 0) return;
            var farm = new FontConfig();
            farm.MdiParent = this;
            farm.Show();
            //层叠
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void comboBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.formVisible("FormComboBox") < 0) return;
            var farm = new FormComboBox();
            farm.MdiParent = this;
            farm.Show();
            //层叠
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void dataGridView直连ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.formVisible("FormDataGridView") < 0) return;
            var farm = new FormDataGridView();
            farm.MdiParent = this;
            farm.Show();
            //层叠
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void treeView资源管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.formVisible("TreeView") < 0) return;
            var farm = new TreeView();
            farm.MdiParent = this;
            farm.Show();
            //层叠
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void 用户自定义ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.formVisible("Form_UserControl") < 0) return;
            var farm = new Form_UserControl();
            farm.MdiParent = this;
            farm.Show();
            //层叠
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void dataGridView断连ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.formVisible("FormDataGridView2") < 0) return;
            var farm = new FormDataGridView2();
            farm.MdiParent = this;
            farm.Show();
            //层叠
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void dataGridViewDataSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.formVisible("FormDataGridView3") < 0) return;
            var farm = new FormDataGridView3();
            farm.MdiParent = this;
            farm.Show();
            //层叠
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void dataGridView适配器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.formVisible("FormDataGridView4") < 0) return;
            var farm = new FormDataGridView4();
            farm.MdiParent = this;
            farm.Show();
            //层叠
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void 增删查改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.formVisible("FormDataGridView5") < 0) return;
            var farm = new FormDataGridView5();
            farm.MdiParent = this;
            farm.Show();
            //层叠
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void 一卡通测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.formVisible("FormCardTest") < 0) return;
            var farm = new FormCardTest();
            farm.MdiParent = this;
            farm.Show();
            //层叠
            this.LayoutMdi(MdiLayout.Cascade);
        }
 
        private void 医保测试ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.formVisible("FormInsuranceTest") < 0) return;
            var farm = new FormInsuranceTest();
            farm.MdiParent = this;
            farm.Show();
            //层叠
            this.LayoutMdi(MdiLayout.Cascade);
        }
    }
}
