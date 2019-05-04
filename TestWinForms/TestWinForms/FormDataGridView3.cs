using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace TestWinForms
{
    public partial class FormDataGridView3 : Form
    {

        DataSet carsInventoryDS = new DataSet("carDataSet");
     
        public FormDataGridView3()
        {
            InitializeComponent();

            //
            FillDataSet(carsInventoryDS);
            this.dataGridView1.DataSource = carsInventoryDS.Tables["Inventory"];
        }

        static void FillDataSet(DataSet ds)
        { 

            
            //建立字段
            DataColumn caridColumn = new DataColumn("CarID", typeof(int));
            caridColumn.Caption = "汽车ID";
            caridColumn.ReadOnly = true;
            caridColumn.AllowDBNull = false;
            caridColumn.Unique = true;
            caridColumn.AutoIncrement = true;
            caridColumn.AutoIncrementSeed = 0;
            caridColumn.AutoIncrementStep = 1;
          

            DataColumn makeColumn = new DataColumn("Make", typeof(string));
            makeColumn.Caption = "标志";
            DataColumn colorColumn = new DataColumn("Color", typeof(string));
            colorColumn.Caption = "颜色";
            DataColumn petnameColumn = new DataColumn("PetName", typeof(string));
            petnameColumn.Caption = "汽车名称";
            
            //创建表
            DataTable inventoryTable = new DataTable("Inventory");

           
            //装载字段到DataTable
            inventoryTable.Columns.AddRange(new DataColumn[] { caridColumn, makeColumn, colorColumn, petnameColumn });

            //设置主键
            inventoryTable.PrimaryKey = new DataColumn[] { inventoryTable.Columns["CarID"] };

            //增加行
            DataRow carRow = inventoryTable.NewRow();
            carRow["MAKE"] = "BMW";
            carRow["Color"] = "银色";
            carRow["PetName"] = "宝马500";
            inventoryTable.Rows.Add(carRow);
            //第0列是自增ID字段，所有从1开始
            carRow = inventoryTable.NewRow();
            carRow[1] = "FT";
            carRow[2] = "白色";
            carRow[3] = "丰田";
            inventoryTable.Rows.Add(carRow);

            //把表加入到dataset
            ds.Tables.Add(inventoryTable);

            ////映射列名友好界面
            //DataTableMapping custMap = new DataTableMapping("Inventory", "carsInventoryDS");
            //custMap.ColumnMappings.Add("CarID", "汽车ID");

        }

        public void PrintDataSet(DataSet ds)
        {
            //输出每一张表
            foreach (DataTable dt in ds.Tables)
            {
                this.textBox1.Text += dt.TableName + "\n" ;

                //输出列名
                for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                {
                    this.textBox1.Text += dt.Columns[curCol].ColumnName + "\t";
                }
                this.textBox1.Text += "\n";
                //输出表
                for (int curRow = 0; curRow < dt.Rows.Count; curRow++)
                {
                    for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                    {
                        this.textBox1.Text += dt.Rows[curRow][curCol].ToString() + "\n\t";
                    }

                    this.textBox1.Text += "\n";
                }
            }
        }

        public void PrintDataTable(DataTable dt)
        {
            this.textBox1.Text = "";
            DataTableReader dtReader = dt.CreateDataReader();
            while (dtReader.Read())
            {
                for (int i = 0; i < dtReader.FieldCount; i++)
                {
                    this.textBox1.Text += dtReader.GetValue(i).ToString().Trim();
                }
            }
            dtReader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintDataSet(carsInventoryDS);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintDataTable(carsInventoryDS.Tables["Inventory"]);

        }
    }
}
