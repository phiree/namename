namespace ShopClient
{
    partial class ProSelect
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnpre = new System.Windows.Forms.Button();
            this.btnnext = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(826, 365);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 85);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(834, 395);
            this.tabControl1.TabIndex = 4;
            
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(734, 0);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 85);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnnext);
            this.panel1.Controls.Add(this.btnpre);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(834, 85);
            this.panel1.TabIndex = 5;
            // 
            // btnpre
            // 
            this.btnpre.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnpre.Location = new System.Drawing.Point(0, 0);
            this.btnpre.Name = "btnpre";
            this.btnpre.Size = new System.Drawing.Size(75, 85);
            this.btnpre.TabIndex = 4;
            this.btnpre.Text = "上一页";
            this.btnpre.UseVisualStyleBackColor = true;
            // 
            // btnnext
            // 
            this.btnnext.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnnext.Location = new System.Drawing.Point(75, 0);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(75, 85);
            this.btnnext.TabIndex = 5;
            this.btnnext.Text = "下一页";
            this.btnnext.UseVisualStyleBackColor = true;
            // 
            // ProSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 480);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ProSelect";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "产品选择";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnnext;
        private System.Windows.Forms.Button btnpre;
    }
}