using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace TestWinForms
{
    public partial class TreeView : Form
    {
        public TreeView()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void loadDirinfo(TreeNode node)
        {
            try
            {
                var dirinfos = new DirectoryInfo(node.Tag.ToString()).GetDirectories();
                foreach (var dirinfo in dirinfos)
                {
                    var sNode = new TreeNode(dirinfo.Name);
                    sNode.Tag = dirinfo.FullName;
                    node.Nodes.Add(sNode);
                }
            }
            catch {}
           
        }

        private void TreeView_Load(object sender, EventArgs e)
        {
            #region
            //var deptList = new List<string>() {"内一科", "内二科","内三科" };
            //var empList = new List<string>() { "张三", "李四", "王五","赵六" };


            //foreach (var item in deptList)
            //{
            //    var rootNode = new TreeNode(item);
            //    treeView1.Nodes.Add(rootNode);

            //    foreach (var emp1 in empList)
            //    {
            //        rootNode.Nodes.Add(emp1);
            //    }

            //}
            //treeView1.ExpandAll();
            #endregion

            try
            {
                foreach (var drive in Environment.GetLogicalDrives())
                {
                    var node = new TreeNode(drive);
                    node.Tag = drive;
                    treeView1.Nodes.Add(node);
                    loadDirinfo(node);
                }

                listView1.Columns.Add("文件名", 100);
                listView1.Columns.Add("大小", 100);
                listView1.Columns.Add("最后访问日期", 100);
                listView1.View = View.Details;
 
            }
            catch { }


        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {

        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                foreach (TreeNode node in e.Node.Nodes)
                {
                    loadDirinfo(node);
                }
            }
            catch { }

        }

        private void treeView1_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            try
            {
                foreach (TreeNode node in e.Node.Nodes)
                {
                    node.Nodes.Clear();
                }
            }
            catch { }
        }

        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            listView1.Items.Clear();
            var fileinfos = new DirectoryInfo(e.Node.Tag.ToString()).GetFiles();
            foreach (FileInfo fileinfo in fileinfos)
            {
                var item = new ListViewItem(fileinfo.Name);
                item.SubItems.Add(fileinfo.Length.ToString());
                item.SubItems.Add(fileinfo.LastAccessTime.ToLocalTime().ToString());
                listView1.Items.Add(item);
            }
        }
    }
}
