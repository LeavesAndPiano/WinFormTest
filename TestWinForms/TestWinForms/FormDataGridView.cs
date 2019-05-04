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
    public partial class FormDataGridView : Form
    {
        public FormDataGridView()
        {
            InitializeComponent();
        }

        private void FormDataGridView_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“blogDataSet.UserInfo”中。您可以根据需要移动或删除它。
            this.userInfoTableAdapter.Fill(this.blogDataSet.UserInfo);
            //5、绑定数据源后的冻结列属性，使用户在使用横向条查看数据时，也能时刻看到是谁的数据，提高用户体验冻结了第一列的数据
            this.dataGridView1.Columns[0].Frozen = true;
            //DataGridView控件的标题列设置序号，同时设置默认宽度
            dataGridView1.RowHeadersWidth = 60;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                int j = i + 1;
                dataGridView1.Rows[i].HeaderCell.Value = j.ToString();
            }

        }

       

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
               BlogDataSet.UserInfoRow  userInfoRow= this.blogDataSet.UserInfo.NewUserInfoRow();
                userInfoRow.ID ="123456";
                userInfoRow.Password = "0";
                
                this.blogDataSet.UserInfo.Rows.Add(this.blogDataSet.UserInfo.NewRow());
                //this.blogDataSet.UserInfo.AddUserInfoRow(userInfoRow);
                //this.dataGridView1.Rows.Add();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            try
            {

                this.dataGridView1.Rows.Remove(this.dataGridView1.CurrentRow);

                #region 强类型删除方法（有问题）
                //string colName = this.blogDataSet.UserInfo.IDColumn.ColumnName;
                ////自动生成的列名与绑定名不一致（需手工修改DataGridView1Nane名称）
                //string colValue = this.dataGridView1.CurrentRow.Cells[colName].Value.ToString();
                //BlogDataSet.UserInfoRow rowDel = this.blogDataSet.UserInfo.FindByID(colValue);
                //this.userInfoTableAdapter.Delete(rowDel.ID, rowDel.Password, rowDel.Birthdate, rowDel.NO, rowDel.Unit, rowDel.HouseNumber, rowDel.RegistrationDate, rowDel.RepPassword);
                #endregion

                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                this.userInfoTableAdapter.Update(this.blogDataSet.UserInfo);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //双击事件
            MessageBox.Show(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());

        }

        //DataGirdView中的数据转化为DataTable
        public DataTable GetDgvToTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            for (int count = 0; count < dgv.Columns.Count; count++)
            {
                DataColumn dc = new DataColumn(dgv.Columns[count].Name);
                dt.Columns.Add(dc);
            }
            for (int count = 0; count < dgv.Rows.Count; count++)
            {
                DataRow dr = dt.NewRow();
                for (int countsub = 0; countsub < dgv.Columns.Count; countsub++)
                {
                    dr[countsub] = Convert.ToString(dgv.Rows[count].Cells[countsub].Value);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        //方法1：显示行号
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (var brush = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), dataGridView1.DefaultCellStyle.Font, brush, e.RowBounds.Location.X + 12, e.RowBounds.Y + 5);
            }
        }
        ////方法2：显示行号
        //private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        //{
        //    if (e.ColumnIndex == -1 && e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
        //    {
        //        //dataGridView1.Rows[e.RowIndex].HeaderCell.Value = (e.RowIndex).ToString();
        //        e.PaintBackground(e.ClipBounds, true);
        //        e.Graphics.DrawString((e.RowIndex + 1).ToString(), Font, Brushes.Black, e.CellBounds.Left + 6,
        //                              e.CellBounds.Top + 5);
        //        e.Handled = true;
        //    }
        //}
    }
}
