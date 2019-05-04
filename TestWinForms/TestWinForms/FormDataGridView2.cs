using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//增加引用
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
using AutoLotDAL.AutoLotConnectedLayer;

namespace TestWinForms
{
    public partial class FormDataGridView2 : Form
    {
        public FormDataGridView2()
        {
            InitializeComponent();
            BindData();
        } 
        DataTable dtInventory;
             
        public void BindData()
        {
            //LoadDate();
            LoadDate_EX();
            if (dtInventory == null)
            {
                dtInventory = new DataTable();
                dtInventory.Columns.Add("CarID");
                dtInventory.Columns.Add("Make");
                dtInventory.Columns.Add("Color");
                dtInventory.Columns.Add("PetName"); 
                
            }
            this.dataGridView1.DataSource = dtInventory;
            
        }

        // 单一模式
        public void LoadDate()
        {
            
            using(SqlConnection cn= new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;
                //cn.ConnectionString = "Data Source =.; Initial Catalog = Blog; User ID = sa; Password = YeQiang";
                string sql = "SELECT * FROOM Inventory";
                SqlDataAdapter da = new SqlDataAdapter(sql,cn);
                DataSet ds = new DataSet("InventoryDataSet");

                //映射列名友好界面
                DataTableMapping custMap = da.TableMappings.Add("Inventory", "InventoryDataSet");
                custMap.ColumnMappings.Add("MAKE", "ZIDING");

                da.Fill(ds, "Inventory");
                dtInventory = ds.Tables["Inventory"];
                
            }
        }

        // 工厂提供模式
        public void LoadDate_EX()
        {
           //从配置文件读取字符串和提供程序
            string dp = ConfigurationManager.AppSettings["provider"];
            string cnStr = ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;
    
            //得到工厂提供程序
            DbProviderFactory df = DbProviderFactories.GetFactory(dp);
            //得到连接对象
            using (DbConnection cn = df.CreateConnection())
            {
                cn.ConnectionString = cnStr;
                cn.Open();
                //得到命令对象
                DbCommand cmd = df.CreateCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT * FROM Inventory";
                //得到适配器
                DbDataAdapter da = df.CreateDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet("InventoryDataSet");
  
                da.Fill(ds, "Inventory");
                dtInventory = ds.Tables["Inventory"];

            }
        }

        //插入数据1
        private void button1_Click(object sender, EventArgs e)
        {
            string cnStr = ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;
            InventoryDAL inventoryDAL = new InventoryDAL();
            inventoryDAL.OpenConnection(cnStr);
            NewCar newCar = new NewCar();
            newCar.CarID = 888;
            newCar.Make = "1";
            newCar.Color = "蓝色";
            newCar.PetName = "法拉第";
            inventoryDAL.InsertAutoForClass(newCar);
            inventoryDAL.CloseConnection();
            BindData();
        }
        //插入数据2
        private void button2_Click(object sender, EventArgs e)
        {
            string cnStr = ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;
            InventoryDAL inventoryDAL = new InventoryDAL();
            inventoryDAL.OpenConnection(cnStr);
            inventoryDAL.InsertAutoForParm(999, "红色", "123", "法拉第");
            inventoryDAL.CloseConnection();
            BindData();
        }
        //查询
        private void button3_Click(object sender, EventArgs e)
        {
            string cnStr = ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;
            InventoryDAL inventoryDAL = new InventoryDAL();
            inventoryDAL.OpenConnection(cnStr);

            dtInventory = inventoryDAL.GetAllInventoryAsDataTable();
            inventoryDAL.CloseConnection();
            BindData();
            

        }
        //删除1
        private void button4_Click(object sender, EventArgs e)
        {
            string cnStr = ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;
            InventoryDAL inventoryDAL = new InventoryDAL();
            inventoryDAL.OpenConnection(cnStr);
            inventoryDAL.DeleteCar(888);
            inventoryDAL.CloseConnection();
            BindData();
        }
        //删除2
        private void button5_Click(object sender, EventArgs e)
        {
            string cnStr = ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;
            InventoryDAL inventoryDAL = new InventoryDAL();
            inventoryDAL.OpenConnection(cnStr);
            inventoryDAL.DeleteCar(999);
            inventoryDAL.CloseConnection();
            BindData();
        }
        //更新1
        private void button6_Click(object sender, EventArgs e)
        {
            string cnStr = ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;
            InventoryDAL inventoryDAL = new InventoryDAL();
            inventoryDAL.OpenConnection(cnStr);
            inventoryDAL.UpdateCarPetNmae(888, "黑色");
            inventoryDAL.CloseConnection();
            BindData();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string cnStr = ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;
            InventoryDAL inventoryDAL = new InventoryDAL();
            inventoryDAL.OpenConnection(cnStr);
            inventoryDAL.UpdateCarPetNmae(999, "白色");
            inventoryDAL.CloseConnection();
            BindData();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string cnStr = ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;
            InventoryDAL inventoryDAL = new InventoryDAL();
            inventoryDAL.OpenConnection(cnStr);
            string petname = string.Empty;
            petname = inventoryDAL.LookUpPetName(888);
            inventoryDAL.CloseConnection();
            MessageBox.Show(petname);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string cnStr = ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;
            InventoryDAL inventoryDAL = new InventoryDAL();
            inventoryDAL.OpenConnection(cnStr);
            int custid = 1;
            bool throwex = true;
            inventoryDAL.ProcessCreditRisk(throwex, custid);
            inventoryDAL.CloseConnection();
            
        }

       
    }
}
