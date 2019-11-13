using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWinForms
{
    public partial class BackgroundWorker : Form
    {
        public BackgroundWorker()
        {
            InitializeComponent();
          
        }

        private void BackgroundWorker_Load(object sender, EventArgs e)
        {
            worker.WorkerReportsProgress = true;                  //允许报告进度
            worker.WorkerSupportsCancellation = true;             //允许取消线程
            worker.DoWork += worker_DoWork;                       //设置主要工作逻辑
            worker.ProgressChanged += worker_ProgressChanged;     //进度变化的相关处理
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;  //线程完成时的处理
        }

        /// <summary>
        /// 主要工作逻辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            System.ComponentModel.BackgroundWorker tempWorker = sender as System.ComponentModel.BackgroundWorker;
            for (int i = 0; i <= 100; i++)
            {
                if (tempWorker.CancellationPending)  //当点击Cancel按钮时，CancellationPending被设置为true
                {
                    e.Cancel = true;  //此处设置Cancel=true后，就可以在RunWorkerCompleted中判断e.Cancelled是否为true
                    break;
                }
                Thread.Sleep(200);    //避免太快，让线程暂停一会再报告进度
                tempWorker.ReportProgress(i);   //调用ReportProgress()方法报告进度，同时触发ProgressChanged事件
            }
        }

        /// <summary>
        /// 处理进度变化，改变进度条的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// 线程完成后的处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)  //被取消时
                MessageBox.Show("线程被取消了");
            else              //正常结束   
                MessageBox.Show("线程工作完成");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            worker.RunWorkerAsync();   //调用该方法才会启动线程
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (worker.IsBusy)
                worker.CancelAsync();
            else
                MessageBox.Show("There is no thead running now.");
        }
    }
}
