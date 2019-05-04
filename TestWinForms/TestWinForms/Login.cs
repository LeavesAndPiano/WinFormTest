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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
          
        }

        private void Login_Activated(object sender, EventArgs e)
        {
            //启动后设置窗体控件焦点
            //this.textPassword.Focus();
            this.textUser.Text = "admin";
            this.textPassword.Text = "admin";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = this.textUser.Text.Trim();
            string userPassword = this.textPassword.Text;
            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("请输入用户名！","验证");
                return;
            }
            if (string.IsNullOrEmpty(userPassword))
            {
                MessageBox.Show("请输入密码！");
                return;
            }
            if (userName == "admin" && userPassword == "admin")
            {
               
                UserInfo.UserID= "admin";
                UserInfo.UserName="admin";

                MessageBox.Show("登录成功！");
                this.Close();

            }
            else
            {
                MessageBox.Show("登录失败！");
                
            }
           
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (string.IsNullOrEmpty(UserInfo.UserID))
            {
                Application.Exit();
            }
        }

        private void textUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(this.Text.Trim()))
                {
                    this.textPassword.Focus();
                    this.textPassword.SelectAll();

                }
            }
        }

        private void textPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(this.Text.Trim()))
                {
                    this.button1.PerformClick();

                }
            }
        }
    }
}
