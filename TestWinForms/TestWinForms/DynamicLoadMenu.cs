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
    public partial class DynamicLoadMenu : Form
    {
        public DynamicLoadMenu()
        {
            InitializeComponent();
            LoadMenu();
        }

        void LoadMenu()
        {
            tc_Main.DrawMode =  TabDrawMode.OwnerDrawFixed;//
            tc_Main.Alignment = TabAlignment.Left;//选项卡向左靠齐
            tc_Main.SizeMode = TabSizeMode.Fixed;//设置此项后，设置ItemSize使表格更美观
            tc_Main.ItemSize = new Size(20,100);//选项卡内的控件大小

            //tc_Main.TabPages.Clear();

        }
         
        private void tc_Main_DrawItem(object sender, DrawItemEventArgs e)
        {
            SolidBrush _Brush = new SolidBrush(Color.Black);//单色画刷
            RectangleF _TabTextArea = (RectangleF)tc_Main.GetTabRect(e.Index);//绘制区域
            StringFormat _sf = new StringFormat();//封装文本布局格式信息
            _sf.LineAlignment = StringAlignment.Center;
            _sf.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(tc_Main.Controls[e.Index].Text, SystemInformation.MenuFont, _Brush, _TabTextArea, _sf);
        }
    }
}
