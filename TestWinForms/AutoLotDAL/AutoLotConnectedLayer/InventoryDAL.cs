using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data.SqlClient;
using System.Data;

namespace AutoLotDAL.AutoLotConnectedLayer
{
    public class InventoryDAL
    {
        private SqlConnection sqlcn=null;

        public void OpenConnection(string connectionString)
        {
            sqlcn = new SqlConnection();
            sqlcn.ConnectionString = connectionString;
            sqlcn.Open();
        }

        public void CloseConnection()
        {
            sqlcn.Close(); 
        }

        public void InsertAutoForClass(NewCar car)
        {
            string sql = string.Format("INSERT INTO INVENTORY(CARID,MAKE,COLOR,PETNAME) VALUES " + "('{0}','{1}','{2}','{3}')",car.CarID,car.Make,car.Color,car.PetName);
            //参数化查询
            string sqlParm = string.Format("INSERT INTO INVENTORY(CARID,MAKE,COLOR,PETNAME) VALUES " + "(@CardID,@Make,@Color,@PetName)");
            using (SqlCommand cmd= new SqlCommand(sql,this.sqlcn))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public void InsertAutoForParm(int id,string color,string make,string petname)
        { 
            //参数化查询
            string sqlParm = string.Format("INSERT INTO INVENTORY(CARID,MAKE,COLOR,PETNAME) VALUES " + "(@CardID,@Make,@Color,@PetName)");
            using (SqlCommand cmd = new SqlCommand(sqlParm, this.sqlcn))
            {
                //填充参数集合
                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@CardID";
                sqlParameter.Value = id;
                sqlParameter.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@Make";
                sqlParameter.Value = make;
                sqlParameter.SqlDbType = SqlDbType.VarChar;
                sqlParameter.Size = 50;
                cmd.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@Color";
                sqlParameter.Value = color;
                sqlParameter.SqlDbType = SqlDbType.VarChar;
                sqlParameter.Size = 50;
                cmd.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@PetName";
                sqlParameter.Value = petname;
                sqlParameter.SqlDbType = SqlDbType.VarChar;
                sqlParameter.Size = 50;
                cmd.Parameters.Add(sqlParameter);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCar(int id)
        {
            string sql = string.Format("Delete From Inventory Where CarID='{0}'",id);
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlcn))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("", ex);
                    throw error;
                }
               
            }
        }
        

        public void ProcessCreditRisk(bool throwEX,int custID)
        {
            string fName = string.Empty;
            string lName = string.Empty; 
            string sql = string.Format("select * From Customers Where CustID={0}", custID);
            SqlCommand cmdSelect = new SqlCommand(sql, this.sqlcn);

            using(SqlDataReader dr = cmdSelect.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    dr.Read();
                    fName = dr["FirstName"].ToString();
                    lName = dr["LastName"].ToString();
                }
                else
                {
                    return;
                }
                //创建表示每一步的操作命令对象
                SqlCommand cmdRemove = new SqlCommand(string.Format("delete from customers where custid={0}", custID),this.sqlcn);
                SqlCommand cmdInsert = new SqlCommand(string.Format("insert into creditrisks (custid,firstname,lastname) values ({0},{1},{2})", custID, fName, lName));
                //从连接对象获取
                SqlTransaction tx = null;
                try
                {
                    tx = this.sqlcn.BeginTransaction();
                    //将命令加入事务
                    cmdInsert.Transaction = tx;
                    cmdRemove.Transaction = tx;
                    //执行命令
                    cmdInsert.ExecuteNonQuery();
                    cmdRemove.ExecuteNonQuery();
                    //模拟错误
                    if (throwEX)
                    {
                        throw new Exception("测试错误！");
                    }
                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw new Exception(ex.Message);
                }

            }

            using (SqlCommand cmd = new SqlCommand(sql, this.sqlcn))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("", ex);
                    throw error;
                }

            }
        }

        public void UpdateCarPetNmae(int id,string petname)
        {
            string sql = string.Format("update Inventory set petname='{1}' Where CarID='{0}'", id, petname);
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlcn))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("", ex);
                    throw error;
                }

            }
        }

        public List<NewCar> GetAllInventoryAsList()
        {
            List<NewCar> newCars = new List<NewCar>();
            string sql = "SELECT * FROM INVENTORY";
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlcn))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    newCars.Add(new NewCar
                    {
                        CarID = (int)dr["CarID"],
                        Color = dr["Color"].ToString(),
                        Make = dr["Make"].ToString(),
                        PetName = dr["PetName"].ToString()
                    });
                }
                dr.Close();
            }

            return newCars;
        }

        public DataTable GetAllInventoryAsDataTable()
        {
            DataTable dtInv = new DataTable();
            string sql = "SELECT * FROM INVENTORY";
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlcn))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                dtInv.Load(dr);
                dr.Close();

            } 
            return dtInv;
        }

        public string LookUpPetName(int carID)
        {
            string carPetName = string.Empty;
            using (SqlCommand cmd = new SqlCommand("GetPetName", this.sqlcn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@carID";
                sqlParameter.SqlDbType = SqlDbType.Int;
                sqlParameter.Value = carID;
                //默认的方向即为input
                sqlParameter.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(sqlParameter);

                //输出参数
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@petName";
                sqlParameter.SqlDbType = SqlDbType.VarChar;
                sqlParameter.Size = 50;
                sqlParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(sqlParameter);
                //执行存储过程
                cmd.ExecuteNonQuery();
                //返回输出参数
                carPetName = cmd.Parameters["@petName"].Value.ToString();

            }
            return carPetName;
        }
    }
    public class NewCar
    {
        public int CarID { get; set; }
        public string Color { get; set; }
        public string Make { get; set; }
        public string PetName { get; set; }

    }
}
