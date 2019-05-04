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
using AutoLotDAL.AutoLotDisconnectedLayer;
using System.Data.Common;

namespace TestWinForms
{
    public partial class FormDataGridView5 : Form
    {
        public SqlDataAdapter sqlDataAdapterMaster = null;
        public SqlDataAdapter sqlDataAdapterDetail = null;
        DataSet ds = new DataSet("BusinessDataSet");
        
        public FormDataGridView5()
        {
            InitializeComponent();
            
            SetDataGridViewProperty(this.dataGridView1);
            SetDataGridViewProperty(this.dataGridView2);
            BindDateMaster();  
        }

        #region 主记录数据绑定
        private void BindDateMaster()
        {
            string cnStr = ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;
            //string sql = "select * from BusinessMaster";
            string sql = "SELECT BusinessNO,Type,CreateDate,Flag,UserName FROM BusinessMaster";
            string tableNmae = "BusinessMaster";  
            sqlDataAdapterMaster = new SqlDataAdapter(sql, cnStr);
            SqlCommandBuilder builder = new SqlCommandBuilder(sqlDataAdapterMaster);

            ////映射列名友好界面(针对字段别名设置)
            //DataTableMapping dtmMaster = sqlDataAdapterMaster.TableMappings.Add(tableNmae, "主表");
            //dtmMaster.ColumnMappings.Add("UserName", "用户名");
            
            sqlDataAdapterMaster.Fill(ds, tableNmae);
            this.dataGridView1.DataSource = ds.Tables[0];
             
            //绑定
            SetDataGridViewDataInit();
            SetDataGridViewAddCloumns(this.dataGridView1);
            this.dataGridView1.ClearSelection();

        }
        #endregion

        #region 明细记录数据绑定
        private void BindDateDetail(string businessNO)
        {
            string cnStr = ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;
            string sql =string.Format("select * from BusinessDetail where BusinessNO='{0}'",businessNO); 
            string tableNmae = "BusinessDetail";
            sqlDataAdapterDetail = new SqlDataAdapter(sql, cnStr);
            SqlCommandBuilder builder = new SqlCommandBuilder(sqlDataAdapterDetail);

            ////映射列名友好界面(针对字段别名设置)
            //DataTableMapping dtmMaster = sqlDataAdapterMaster.TableMappings.Add(tableNmae, "主表");
            //dtmMaster.ColumnMappings.Add("UserName", "用户名");

            //
            if(ds.Tables["BusinessDetail"] != null)
            {
                ds.Tables["BusinessDetail"].Clear();
            }

            sqlDataAdapterDetail.Fill(ds, tableNmae);
            this.dataGridView2.DataSource = ds.Tables[1];
             
            if (dataGridView1.CurrentRow.Cells["Flag"].Value.ToString() == "1" ) 
            {
                dataGridView2.ReadOnly = true;
            }
            else
            {
                dataGridView2.ReadOnly = false;
            }

            //绑定
            SetDataGridViewDataInit();
            this.dataGridView2.ClearSelection();

        }
        #endregion

        #region 数据初始化
        private void SetDataGridViewDataInit()
        {
            //主表
            Dictionary<string, string> pairsMaster = new Dictionary<string, string>();
            pairsMaster.Add("BusinessNO", "出库单号");
            pairsMaster.Add("CreateDate", "创建日期");
            pairsMaster.Add("UserName", "用户名");
            pairsMaster.Add("Type", "出库类别");
            pairsMaster.Add("Flag", "记账标志");
            //只读字段
            List<string> readOnlyMaster = new List<string>();
            readOnlyMaster.Add("BusinessNO");
            readOnlyMaster.Add("CreateDate");
            //readOnlyMaster.Add("Flag");
            //隐藏数据
            List<string> visibleMaster = new List<string>();
            visibleMaster.Add("Type");
            visibleMaster.Add("Flag");
            SetDataGridViewTitle(this.dataGridView1, pairsMaster, readOnlyMaster, visibleList: visibleMaster);
            //明细表
            Dictionary<string, string> pairsDetail = new Dictionary<string, string>();
            pairsDetail.Add("BusinessNO", "出库单号");
            pairsDetail.Add("ItemNO", "序号");
            pairsDetail.Add("Code", "药品编码");
            pairsDetail.Add("Name", "药品名称");
            pairsDetail.Add("Spec", "药品规格");
            pairsDetail.Add("FactoryName", "生产厂家");
            pairsDetail.Add("Price", "价格");
            pairsDetail.Add("Amount", "数量");
            pairsDetail.Add("Charges", "金额");
            //只读字段
            List<string> readOnlyDetail = new List<string>();
            readOnlyDetail.Add("BusinessNO");
            readOnlyDetail.Add("ItemNO");
            readOnlyDetail.Add("Code");
            readOnlyDetail.Add("Spec");
            readOnlyDetail.Add("FactoryName");
            //readOnlyDetail.Add("Price");
            readOnlyDetail.Add("Charges");
            //隐藏数据
            List<string> visibleDetail = new List<string>();
            visibleDetail.Add("BusinessNO");
            visibleDetail.Add("ItemNO");
            visibleDetail.Add("Code");
            SetDataGridViewTitle(this.dataGridView2, pairsDetail, readOnlyDetail, visibleDetail);
 
        }
        #endregion

        #region 设置dgv属性 
        private void SetDataGridViewProperty(DataGridView dataGridView)
        {
            //数据窗口的单击行选择方式
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false; 
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        #endregion 

        #region 自定义增加列样式
        /// <summary>
        /// 自定义增加列样式
        /// </summary>
        /// <param name="dataGridView"></param>
        private void SetDataGridViewAddCloumns(DataGridView dataGridView)
        {
            Dictionary<string, string> kvDictonary = new Dictionary<string, string>();
            kvDictonary.Add("正常出库","1");
            kvDictonary.Add("申请出库","2");
            kvDictonary.Add("退药出库","3"); 
            BindingSource bs = new BindingSource();
            bs.DataSource = kvDictonary;  


            DataGridViewComboBoxColumn comUserName = new DataGridViewComboBoxColumn();
            comUserName.DataPropertyName = "Type";//**设置数据源属性的名称  
            comUserName.HeaderText = "类别";//列头显示的汉字  
            comUserName.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            comUserName.DataSource = bs;//下拉框绑定的数据源  
            comUserName.DisplayMember = "Key";//下拉框显示内容  
            comUserName.ValueMember = "Value";//要和上面**处的一样   
            comUserName.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            comUserName.FlatStyle = FlatStyle.Popup;
            dataGridView.Columns.Add(comUserName); 

            DataGridViewCheckBoxColumn dgvCbxColumn = new DataGridViewCheckBoxColumn();
            dgvCbxColumn.DataPropertyName = "Flag";//**设置数据源属性的名称  
            dgvCbxColumn.HeaderText = "记账标志";//列头显示的汉字  
            //dgvCbxColumn.ReadOnly = true;
            dataGridView.Columns.Add(dgvCbxColumn);
 
        }
        #endregion
          
        #region 自定义标题显示
        private void SetDataGridViewTitle(DataGridView dataGridView,Dictionary<string,string> keyValuePairs,List<string> readOnlyList=null,List<string> visibleList=null)
        {
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                foreach (var item in keyValuePairs)
                { 
                    if (column.Name.ToString().Equals(item.Key))
                    {
                        dataGridView.Columns[column.Name].HeaderText = item.Value;
                        break;
                    }
                }

                if (!(readOnlyList == null))
                {
                    foreach (var read in readOnlyList)
                    {
                        if (column.Name.ToString().Equals(read))
                        {
                            dataGridView.Columns[column.Name].ReadOnly = true;
                            break;
                        }
                    }
                }

                if (!(visibleList == null))
                {
                    foreach (var item in visibleList)
                    {
                        if (column.Name.ToString().Equals(item))
                        {
                            dataGridView.Columns[column.Name].Visible = false;
                            break;
                        }
                    }
                }
              

            }
        }
        #endregion 

        #region 设置dgv行号和背景色
        private void SetDataGridViewBackColor(DataGridView dataGridView)
        {
            int i = 0;
            foreach (DataGridViewRow dr in dataGridView.Rows)
            {
                i++;
                //设置行号
              
                dr.HeaderCell.Value = string.Format("{0}", i);
                if (!dr.IsNewRow)
                {
                    if (dr.Cells["Flag"].Value.ToString().Trim()=="1")
                    {
                        dr.DefaultCellStyle.BackColor = Color.Gray;
                        //dr.ReadOnly = true;
                    }
                    else
                    {
                        dr.DefaultCellStyle.BackColor = Color.White;
                        dr.ReadOnly = false;
                    }
                } 
            }
        }
        #endregion 

        #region 过滤窗口
        private void radioButton3_Click(object sender, EventArgs e)
        { 
            dataGridView1.DataSource = ds.Tables["BusinessMaster"];
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            DataView dataView = new DataView(ds.Tables["BusinessMaster"]);
            dataView.RowFilter =null;
            dataView.RowFilter="Flag=1";
            dataGridView1.DataSource = dataView;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            DataView dataView = new DataView(ds.Tables["BusinessMaster"]);
            dataView.RowFilter = null;
            dataView.RowFilter = "Flag=0";
            dataGridView1.DataSource = dataView;
        }
        #endregion

        //设置行编号
        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        { 
            SetDataGridViewBackColor(this.dataGridView1);
          
        }

        
        #region dgv1单击事件
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            { 
            }
            else
            {
                string businessNO = string.Empty;
                businessNO = dgv.CurrentRow.Cells["BusinessNO"].Value.ToString();
                BindDateDetail(businessNO); 
                //string flag = dgv.CurrentRow.Cells["Flag"].Value.ToString();
                string flag = dgv.Rows[e.RowIndex].Cells["Flag"].Value.ToString();
                if (string.IsNullOrEmpty(flag) || flag == "0")
                {
                    //dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0; 
                    dgv.ReadOnly = false;
                    dgv.BeginEdit(true);

                }
               
            }
           
        }
        #endregion

        #region dgv2单击事件
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (!dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly)
            {
                dgv.BeginEdit(true);

            }
            else
            {
                dgv.BeginEdit(false);
            }

             
        }
        #endregion

             
        #region 回车事件
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                bool flag = false; 
                //if (DataGridViewCloumnSwitch(ref this.dataGridView1))
                //{
                //    flag = true;
                //}
                if (DataGridViewCloumnSwitch(ref this.dataGridView2))
                {
                    flag = true;
                }
                return flag;
                  
            }
            
            base.ProcessCmdKey(ref msg, keyData);
            int WM_KEYDOWN = 256;
            int WM_SYSKEYDOWN = 260;
            bool _disable = false;
            if (msg.Msg == WM_KEYDOWN || msg.Msg == WM_SYSKEYDOWN)
            {
                switch (keyData)
                {
                    case Keys.Enter:
                        SendKeys.Send("{Tab}");
                        _disable = true;
                        break;
                }
            }
            return _disable;
        }

        public bool DataGridViewCloumnSwitch(ref DataGridView dataGridView)
        {
            DataGridViewCell dgvCell = dataGridView.CurrentCell;
            if (dgvCell == null) return false;
            if (dataGridView.CurrentCell.Selected)
            {
                for (int i = dgvCell.ColumnIndex; i <= dataGridView.ColumnCount - 1; i++)
                {
                    //当前列是最后一列
                    if(i==(dataGridView.ColumnCount - 1))
                    {
                        //当前行最后一行则增加一行
                        if(dgvCell.RowIndex==dataGridView.RowCount - 1)
                        {
                            button3_Click(null, null);
                            return true;
                        }
                        else//循环到下一行
                        {
                            for (int j = 0; j < dataGridView.ColumnCount - 1; j++)
                            {
                                //是否显示列
                                if (dataGridView[j, dgvCell.RowIndex + 1].Visible == true)
                                {
                                    //是否只读属性
                                    if (!(dataGridView[j, dgvCell.RowIndex + 1].ReadOnly))
                                    {
                                        //设置当前单元格为后一个单元格
                                        dataGridView.CurrentCell = dataGridView[j, dgvCell.RowIndex + 1];
                                        //进入编辑模式
                                        dataGridView.BeginEdit(true);
                                        return true;
                                    }
                                }
                            }
                        }
                     
                    }
                    else
                    {
                        //当前列加1=最后一列
                        if((i + 1) == (dataGridView.ColumnCount - 1))
                        {
                            //是否显示列
                            if (dataGridView[i + 1, dgvCell.RowIndex].Visible == true)
                            {
                                //是否只读属性
                                if (!(dataGridView[i + 1, dgvCell.RowIndex].ReadOnly))
                                {
                                    //设置当前单元格为后一个单元格
                                    dataGridView.CurrentCell = dataGridView[i, dgvCell.RowIndex + 1];
                                    //进入编辑模式
                                    dataGridView.BeginEdit(true);
                                    return true;
                                }
                            }
                        }
                        else
                        {
                            //是否显示列
                            if (dataGridView[i + 1, dgvCell.RowIndex].Visible == true)
                            {
                                //是否只读属性
                                if (!(dataGridView[i + 1, dgvCell.RowIndex].ReadOnly))
                                {
                                    //设置当前单元格为后一个单元格
                                    dataGridView.CurrentCell = dataGridView[i + 1, dgvCell.RowIndex];
                                    //进入编辑模式
                                    dataGridView.BeginEdit(true);
                                    return true;
                                }
                            }
                        }
                    } 
                }
                 
                return true;
            }
            else
            {
                return false;
            }
             
        }
        #endregion

        #region 增加主记录
        private void btn_Add_Click(object sender, EventArgs e)
        {
            //增加新行
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            //增加新行在指定位置
            //ds.Tables[0].Rows.InsertAt(ds.Tables[0].NewRow(), 0);

            string bussNO = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            DateTime createDate = DateTime.Now;
            //滚动到相应的行
            int row = dataGridView1.Rows.Count - 1;
            dataGridView1.FirstDisplayedScrollingRowIndex = row;

            dataGridView1.Rows[row].Cells["BusinessNO"].Value = bussNO;
            dataGridView1.Rows[row].Cells["CreateDate"].Value = createDate;
            dataGridView1.CurrentCell = dataGridView1["UserName", row];
            dataGridView1.BeginEdit(true);
        }
        #endregion

        #region 删除主记录
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentRow.Selected)
            {
                this.dataGridView1.Rows.Remove(this.dataGridView1.CurrentRow);
            } 
        }
        #endregion

        #region 保存主记录
        private void button1_Click(object sender, EventArgs e)
        {
            //从网格获取修改的数据
            DataTable changedMaster = (DataTable)this.dataGridView1.DataSource;
            
            try
            {
                sqlDataAdapterMaster.Update(changedMaster);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
             
        }
        #endregion

      
        #region 增加明细
        private void button3_Click(object sender, EventArgs e)
        {
            //增加新行
            ds.Tables[1].Rows.Add(ds.Tables[1].NewRow());
            //增加新行在指定位置
            //ds.Tables[1].Rows.InsertAt(ds.Tables[1].NewRow(), 0);

            //取主记录内容
            if (dataGridView1.CurrentRow.Selected)
            {
                string bussNO = dataGridView1.CurrentRow.Cells["BusinessNO"].Value.ToString();
                //滚动到相应的行
                int row = dataGridView2.Rows.Count - 1;
                dataGridView2.FirstDisplayedScrollingRowIndex = row;

                dataGridView2.Rows[row].Cells["BusinessNO"].Value = bussNO;
                dataGridView2.Rows[row].Cells["ItemNO"].Value = row +1;
                dataGridView2.CurrentCell = dataGridView2["Name", row];
                dataGridView2.BeginEdit(true);
            }
            else
            {
                MessageBox.Show("请单击选择左表列表内容！");
                return;
            }
             
        }
        #endregion

        #region 删除明细
        private void button4_Click(object sender, EventArgs e)
        {
            if (this.dataGridView2.CurrentRow.Selected)
            {
                this.dataGridView2.Rows.Remove(this.dataGridView2.CurrentRow);
            }
        }
        #endregion

        #region 保存明细 
        private void button5_Click(object sender, EventArgs e)
        {
            DataTable changedDetail = (DataTable)this.dataGridView2.DataSource;
            try
            {
                sqlDataAdapterDetail.Update(changedDetail);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        
        private void dataGridView2_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //DataGridView dgv = (DataGridView)sender;
            //MessageBox.Show(e.RowIndex.ToString() + dgv.Columns[e.ColumnIndex].Name);
        }

        //获取当前数据窗口只读状态
        private void button6_Click(object sender, EventArgs e)
        {
            int rowIndex = 0;
            this.textBox1.Text = "";
            foreach (DataGridViewRow dgvr in dataGridView1.Rows)
            {  
                foreach (DataGridViewColumn dgvc in dataGridView1.Columns)
                {

                    this.textBox1.Text += "\n" + rowIndex.ToString() + "行：" + dgvc.Name + dgvr.Cells[dgvc.Name].ReadOnly.ToString();
                     
                }

                rowIndex++;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            base.Close();
        }
        //编辑事件
        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            DataGridView dgv = (DataGridView)sender;
            decimal price = 0;
            decimal amount = 0;
            decimal changes = 0;
         
            //取当前列名
            if (dgv.Columns[e.ColumnIndex].Name == "Amount")
            { 
                price = Convert.ToDecimal(dgv.Rows[e.RowIndex].Cells["Price"].Value);
                amount = Convert.ToDecimal(dgv.Rows[e.RowIndex].Cells["Amount"].Value);
                changes = price * amount;
                dgv.Rows[e.RowIndex].Cells["Charges"].Value = changes;
            }
            
        }

        private void dataGridView2_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        #region dgv1单元格验证
        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //DataGridView dgv = (DataGridView)sender;
            //if (dgv.Columns[e.ColumnIndex].Name == "UserName")
            //{
            //    if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
            //    {
            //        dgv.Rows[e.RowIndex].ErrorText = "用户名不能为空！";
            //        e.Cancel = true;
            //    }
            //}

        }

        #endregion

        #region dgv2单元格验证
        private void dataGridView2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex].Name == "Name")
            {
                if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    dgv.Rows[e.RowIndex].ErrorText = "名称不能为空！";
                    e.Cancel = true;
                }
            }
        }
        #endregion

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            DataGridView dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex].Name == "Flag")
            {
                if (string.IsNullOrEmpty(dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                {
                    dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                }
            }
        }
    }
}
