using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//
using AutoLotDAL.AutoLotDisconnectedLayer;
namespace TestWinForms
{
    public partial class FormDataGridView4 : Form
    {
        InventoryDALDisLayer dal;
        public FormDataGridView4()
        {
            InitializeComponent();
            DataBind();
        }

        public void DataBind()
        {
            string cnStr = ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;
            string sql = "select * from inventory";
            string tableNmae = "inventory";
            dal = new InventoryDALDisLayer(cnStr,sql);
            this.dataGridView1.DataSource = dal.GetAllInventory(tableNmae);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //从网格获取修改的数据
            DataTable changedDT =(DataTable)this.dataGridView1.DataSource;
            try
            {
                dal.UpdateInventory(changedDT);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
