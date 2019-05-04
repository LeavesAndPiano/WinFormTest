using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestLib
{
    public partial class UserControl21 : UserControl
    {
        #region 自定义属性访问器用户调用窗体的属性设置
        private Color paneBColor;
        public Color PanBColor
        {
            get
            {
                return paneBColor;
            }
            set
            {
                paneBColor = value;
                panel1.BackColor = paneBColor;
            }
        }
        #endregion

        public UserControl21()
        {
            InitializeComponent();

            //默认状态下，DateTimePicker控件只显示日期，如果想更改为显示时间，或日期+时间，需要做以下设置：
            //控制日期或时间的显示格式
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            //使用自定义格式
            this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Value = System.Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-dd"));


        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            var dateStart = dateTimePicker1.Value;
            var dateEnd = dateTimePicker2.Value;

            MessageBox.Show("当前选择时间" + dateStart.ToString() + "至" + dateEnd.ToString(),"自定义控件提示");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
