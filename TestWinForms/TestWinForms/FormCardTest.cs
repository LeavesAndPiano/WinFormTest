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
using System.Configuration;
using System.Data.Common;

namespace TestWinForms
{
   
    public partial class FormCardTest : Form
    {
       
        public FormCardTest()
        {
            InitializeComponent();
            this.dateTimePicker2.Value = DateTime.Now.Date;
            BindingData();
        }
        private static IList<DbParameter> listParameters;
        public static void AddParameters()
        {

        }

        private void BindingInit()
        {

        }
        public void BindingData()
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
                //DateTime startDate = DateTime.MinValue;
                //DateTime stopDate = DateTime.MinValue;
                //string cardNO = string.Empty;
                //string idNO = string.Empty; 
                //startDate = this.dateTimePicker2.Value;
                //stopDate = this.dateTimePicker3.Value;
                //cardNO = this.textBox2.Text;
                //idNO = this.textBox3.Text;
                //文本方式
                //cmd.CommandText = string.Format("SELECT * FROM CardInfo where CreateDate>='{0}' and CreateDate<='{1}' and (CardNO='{2}' or '{2}'='') and (id='{3}' or '{3}'='')", startDate, stopDate, cardNO, idNO);
                //参数方式
                cmd.CommandText = string.Format("SELECT * FROM CardInfo where CreateDate>=@startDatetime and CreateDate<=@stopDatetime and (CardNO=@cardNO or @cardNO='') and (id=@idNO or @idNO='')");
                //得到适配器
                DbDataAdapter da = df.CreateDataAdapter();
                da.SelectCommand = cmd;
                //参数 
                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@startDatetime";
                sqlParameter.Value = this.dateTimePicker2.Value;
                sqlParameter.SqlDbType = SqlDbType.DateTime;
                cmd.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@stopDatetime";
                sqlParameter.Value = this.dateTimePicker3.Value;
                sqlParameter.SqlDbType = SqlDbType.DateTime;
                cmd.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@cardNo";
                sqlParameter.Value = this.textBox2.Text;
                sqlParameter.SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@idNO";
                sqlParameter.Value = this.textBox3.Text;
                sqlParameter.SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.Add(sqlParameter); 

                DataSet ds = new DataSet("Inventory");
                da.Fill(ds, "CardInfo");
                this.dataGridView1.DataSource = ds.Tables["CardInfo"];

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BindingData();
        }
    }
}
