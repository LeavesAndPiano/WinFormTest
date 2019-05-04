using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;


namespace AutoLotDAL.AutoLotDisconnectedLayer
{
    public class InventoryDALDisLayer
    {
        private string sqlcn = string.Empty;
        public SqlDataAdapter sqlDataAdapter = null;
        public InventoryDALDisLayer(string connectstr,string sql)
        {
            sqlcn = connectstr;
            //创建适配器并设置SelectCommand
            sqlDataAdapter = new SqlDataAdapter(sql, sqlcn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sqlDataAdapter);

            //ConfigureAdapter(out sqlDataAdapter,sql);
        }

        public void ConfigureAdapter(out SqlDataAdapter sqlDataAdapter,string sql)
        { 
            //创建适配器并设置SelectCommand
            sqlDataAdapter = new SqlDataAdapter(sql, sqlcn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sqlDataAdapter);
        }

        public DataTable GetAllInventory(string tableNmae)
        {
            DataTable dt = new DataTable(tableNmae);

            ////映射列名友好界面(针对字段别名设置)
            //DataTableMapping custMap = new DataTableMapping("Inventory", "carsInventoryDS");
            //custMap.ColumnMappings.Add("CarID", "汽车ID");


            sqlDataAdapter.Fill(dt);
            return dt; 
        }
        public void UpdateInventory(DataTable modifiedTable)
        {
            sqlDataAdapter.Update(modifiedTable);
        }
    }

  
}
