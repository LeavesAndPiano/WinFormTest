namespace TestWinForms
{
    partial class Form_UserControl
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
            this.components = new System.ComponentModel.Container();
            this.btnEX1 = new TestLib.btnEX(this.components);
            this.userControl211 = new TestLib.UserControl21();
            this.SuspendLayout();
            // 
            // btnEX1
            // 
            this.btnEX1.BackColor = System.Drawing.Color.White;
            this.btnEX1.BtnBColor = System.Drawing.Color.White;
            this.btnEX1.Location = new System.Drawing.Point(12, 120);
            this.btnEX1.Name = "btnEX1";
            this.btnEX1.Size = new System.Drawing.Size(142, 64);
            this.btnEX1.TabIndex = 1;
            this.btnEX1.Text = "btnEX1";
            this.btnEX1.UseVisualStyleBackColor = false;
            // 
            // userControl211
            // 
            this.userControl211.Dock = System.Windows.Forms.DockStyle.Top;
            this.userControl211.Location = new System.Drawing.Point(0, 0);
            this.userControl211.Name = "userControl211";
            this.userControl211.PanBColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.userControl211.Size = new System.Drawing.Size(921, 91);
            this.userControl211.TabIndex = 0;
            // 
            // Form_UserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 400);
            this.Controls.Add(this.btnEX1);
            this.Controls.Add(this.userControl211);
            this.Name = "Form_UserControl";
            this.Text = "Form_UserControl";
            this.Load += new System.EventHandler(this.Form_UserControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private TestLib.UserControl21 userControl211;
        private TestLib.btnEX btnEX1;
    }
}