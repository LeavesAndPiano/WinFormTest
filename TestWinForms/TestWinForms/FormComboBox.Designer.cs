namespace TestWinForms
{
    partial class FormComboBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbIList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_IList = new System.Windows.Forms.Button();
            this.btn_Dictionary = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_Dictionary = new System.Windows.Forms.ComboBox();
            this.btn_DataTable = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_DataTable = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbIList
            // 
            this.cmbIList.FormattingEnabled = true;
            this.cmbIList.Location = new System.Drawing.Point(166, 70);
            this.cmbIList.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cmbIList.Name = "cmbIList";
            this.cmbIList.Size = new System.Drawing.Size(238, 32);
            this.cmbIList.TabIndex = 0;
            this.cmbIList.SelectedIndexChanged += new System.EventHandler(this.cmbIList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 76);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "IList:";
            // 
            // btn_IList
            // 
            this.btn_IList.Location = new System.Drawing.Point(420, 66);
            this.btn_IList.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_IList.Name = "btn_IList";
            this.btn_IList.Size = new System.Drawing.Size(150, 46);
            this.btn_IList.TabIndex = 2;
            this.btn_IList.Text = "IList绑定";
            this.btn_IList.UseVisualStyleBackColor = true;
            this.btn_IList.Click += new System.EventHandler(this.btn_IList_Click);
            // 
            // btn_Dictionary
            // 
            this.btn_Dictionary.Location = new System.Drawing.Point(420, 190);
            this.btn_Dictionary.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_Dictionary.Name = "btn_Dictionary";
            this.btn_Dictionary.Size = new System.Drawing.Size(204, 46);
            this.btn_Dictionary.TabIndex = 5;
            this.btn_Dictionary.Text = "Dictionary绑定";
            this.btn_Dictionary.UseVisualStyleBackColor = true;
            this.btn_Dictionary.Click += new System.EventHandler(this.btn_Dictionary_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 200);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Dictionary:";
            // 
            // cmb_Dictionary
            // 
            this.cmb_Dictionary.FormattingEnabled = true;
            this.cmb_Dictionary.Location = new System.Drawing.Point(166, 194);
            this.cmb_Dictionary.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cmb_Dictionary.Name = "cmb_Dictionary";
            this.cmb_Dictionary.Size = new System.Drawing.Size(238, 32);
            this.cmb_Dictionary.TabIndex = 3;
            this.cmb_Dictionary.Text = "Dictionary";
            this.cmb_Dictionary.SelectedIndexChanged += new System.EventHandler(this.cmb_Dictionary_SelectedIndexChanged);
            // 
            // btn_DataTable
            // 
            this.btn_DataTable.Location = new System.Drawing.Point(420, 326);
            this.btn_DataTable.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_DataTable.Name = "btn_DataTable";
            this.btn_DataTable.Size = new System.Drawing.Size(204, 46);
            this.btn_DataTable.TabIndex = 8;
            this.btn_DataTable.Text = "DataTable绑定";
            this.btn_DataTable.UseVisualStyleBackColor = true;
            this.btn_DataTable.Click += new System.EventHandler(this.btn_DataTable_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 332);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "DataTable:";
            // 
            // cmb_DataTable
            // 
            this.cmb_DataTable.FormattingEnabled = true;
            this.cmb_DataTable.Location = new System.Drawing.Point(166, 326);
            this.cmb_DataTable.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cmb_DataTable.Name = "cmb_DataTable";
            this.cmb_DataTable.Size = new System.Drawing.Size(238, 32);
            this.cmb_DataTable.TabIndex = 6;
            this.cmb_DataTable.Text = "DataTable";
            this.cmb_DataTable.SelectedIndexChanged += new System.EventHandler(this.cmb_DataTable_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(903, 26);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(673, 346);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "联动";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(633, 190);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 46);
            this.button1.TabIndex = 10;
            this.button1.Text = "赋值";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_DataTable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmb_DataTable);
            this.Controls.Add(this.btn_Dictionary);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_Dictionary);
            this.Controls.Add(this.btn_IList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbIList);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "FormComboBox";
            this.Text = "FormComboBox";
            this.Load += new System.EventHandler(this.FormComboBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbIList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_IList;
        private System.Windows.Forms.Button btn_Dictionary;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_Dictionary;
        private System.Windows.Forms.Button btn_DataTable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_DataTable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
    }
}