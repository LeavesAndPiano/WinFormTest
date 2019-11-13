namespace TestWinForms
{
    partial class DynamicLoadMenu
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
            this.userMenu = new System.Windows.Forms.MenuStrip();
            this.tc_Main = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tc_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // userMenu
            // 
            this.userMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.userMenu.Location = new System.Drawing.Point(0, 0);
            this.userMenu.Name = "userMenu";
            this.userMenu.Size = new System.Drawing.Size(800, 24);
            this.userMenu.TabIndex = 0;
            this.userMenu.Text = "menuStrip1";
            // 
            // tc_Main
            // 
            this.tc_Main.Controls.Add(this.tabPage1);
            this.tc_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_Main.Location = new System.Drawing.Point(0, 24);
            this.tc_Main.Name = "tc_Main";
            this.tc_Main.SelectedIndex = 0;
            this.tc_Main.Size = new System.Drawing.Size(800, 426);
            this.tc_Main.TabIndex = 1;
            this.tc_Main.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tc_Main_DrawItem);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 397);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "我的首页";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DynamicLoadMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tc_Main);
            this.Controls.Add(this.userMenu);
            this.MainMenuStrip = this.userMenu;
            this.Name = "DynamicLoadMenu";
            this.Text = "DynamicLoadMenu";
            this.tc_Main.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip userMenu;
        private System.Windows.Forms.TabControl tc_Main;
        private System.Windows.Forms.TabPage tabPage1;
    }
}