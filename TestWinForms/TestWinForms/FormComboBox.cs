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
    public partial class FormComboBox : Form
    {
        
        public FormComboBox()
        {
            InitializeComponent();
        }

        public class Info
        {
            public string Id { get; set; }
            public string Name { get; set; }

        }
     
        private void btn_IList_Click(object sender, EventArgs e)
        {
            IList<Info> infoList = new List<Info>();
            Info info1 = new Info() { Id = "1", Name = "张三" };
            Info info2 = new Info() { Id = "2", Name = "李四" };
            Info info3 = new Info() { Id = "3", Name = "王五" };
            infoList.Add(info1);
            infoList.Add(info2);
            infoList.Add(info3);

            //取消触发事件
            cmbIList.SelectedIndexChanged -= cmbIList_SelectedIndexChanged;
       
            cmbIList.DataSource = infoList;
            cmbIList.ValueMember = "Id";
            cmbIList.DisplayMember = "Name";
            //取消默认
            cmbIList.SelectedIndex = -1;
            //增加触发事件
            cmbIList.SelectedIndexChanged += cmbIList_SelectedIndexChanged;
        }

        private void FormComboBox_Load(object sender, EventArgs e)
        {
            //设置不可编辑
            this.cmbIList.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmb_Dictionary.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmb_DataTable.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void btn_Dictionary_Click(object sender, EventArgs e)
        {
            Dictionary<int, string> kvDictonary = new Dictionary<int, string>();
            kvDictonary.Add(1, "张三");
            kvDictonary.Add(2, "李四");
            kvDictonary.Add(3, "王五");

          

            BindingSource bs = new BindingSource();
            bs.DataSource = kvDictonary;

            //取消触发事件
            cmb_Dictionary.SelectedIndexChanged-= cmb_Dictionary_SelectedIndexChanged;

            cmb_Dictionary.DataSource = bs;
            cmb_Dictionary.ValueMember = "Key";
            cmb_Dictionary.DisplayMember = "Value";
            //取消默认
            cmb_Dictionary.SelectedIndex = -1;
            //增加触发事件
            cmb_Dictionary.SelectedIndexChanged += cmb_Dictionary_SelectedIndexChanged;



        }

        private void btn_DataTable_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataColumn dc1 = new DataColumn("id");
            DataColumn dc2 = new DataColumn("name");
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);

            DataRow dr1 = dt.NewRow();
            dr1["id"] = "1";
            dr1["name"] = "aaaaaa";

            DataRow dr2 = dt.NewRow();
            dr2["id"] = "2";
            dr2["name"] = "bbbbbb";

            dt.Rows.Add(dr1);
            dt.Rows.Add(dr2);
            //取消触发事件
            cmb_DataTable.SelectedIndexChanged -= cmb_DataTable_SelectedIndexChanged;

            cmb_DataTable.DataSource = dt;
            cmb_DataTable.ValueMember = "id";
            cmb_DataTable.DisplayMember = "name";

            //取消默认
            cmb_DataTable.SelectedIndex = -1;
            //增加触发事件
            cmb_DataTable.SelectedIndexChanged += cmb_DataTable_SelectedIndexChanged;
        }

        private void cmbIList_SelectedIndexChanged(object sender, EventArgs e)
        { 
            string selectValue = this.cmbIList.SelectedValue.ToString();
            MessageBox.Show(selectValue);  
        }

        private void cmb_Dictionary_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectValue = this.cmb_Dictionary.SelectedValue.ToString();
            MessageBox.Show(selectValue);
        }

        private void cmb_DataTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectValue = this.cmb_DataTable.SelectedValue.ToString();
            MessageBox.Show(selectValue);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmb_Dictionary.SelectedValue = 3;
        }
    }
}
