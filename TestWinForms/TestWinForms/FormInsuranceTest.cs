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
using Insurance.Interface;
using Insurance.Comm;
using Insurance.City;


using Insurance.Neusoft.Business;
//using Insurance.Neusoft.Factory;

namespace TestWinForms
{
    public partial class FormInsuranceTest : Form
    {
        InsuranceNeusoft insuranceNeusoft = null; 

        public FormInsuranceTest()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            Dictionary<string, string> kvDictonary = new Dictionary<string, string>();
            kvDictonary.Add("郑州市医保", "ZhengZhou");
            kvDictonary.Add("长葛市医保", "ChangGe");
            BindingSource bs = new BindingSource();
            bs.DataSource = kvDictonary;  
            comboBox1.DataSource = bs;
            comboBox1.ValueMember = "Value";
            comboBox1.DisplayMember = "Key"; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lsh = string.Empty;
            insuranceNeusoft.SignIn(out lsh);
            this.textBox1.Text = lsh;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string centerName = comboBox1.SelectedValue.ToString();
            string msg = string.Empty;
            insuranceNeusoft = new InsuranceNeusoft(centerName);
            insuranceNeusoft.INIT(ref msg);
            MessageBox.Show(msg);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string hand = string.Empty;
            hand = insuranceNeusoft.GetHead("1","");
            textBox2.Text = hand;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string  msg = string.Empty;
            insuranceNeusoft.Registration(ref msg);
            textBox3.Text = msg;
        }
    }
}
