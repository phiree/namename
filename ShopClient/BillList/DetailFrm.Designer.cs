namespace ShopClient.BillList
{
    partial class DetailFrm
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
            this.btnpre = new System.Windows.Forms.Button();
            this.btnnext = new System.Windows.Forms.Button();
            this.pnlPro = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblistInfo = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnpre
            // 
            this.btnpre.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnpre.Location = new System.Drawing.Point(659, 0);
            this.btnpre.Name = "btnpre";
            this.btnpre.Size = new System.Drawing.Size(86, 85);
            this.btnpre.TabIndex = 4;
            this.btnpre.Text = "上一页";
            this.btnpre.UseVisualStyleBackColor = true;
            // 
            // btnnext
            // 
            this.btnnext.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnnext.Location = new System.Drawing.Point(745, 0);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(86, 85);
            this.btnnext.TabIndex = 5;
            this.btnnext.Text = "下一页";
            this.btnnext.UseVisualStyleBackColor = true;
            // 
            // pnlPro
            // 
            this.pnlPro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPro.Location = new System.Drawing.Point(0, 110);
            this.pnlPro.Name = "pnlPro";
            this.pnlPro.Size = new System.Drawing.Size(831, 381);
            this.pnlPro.TabIndex = 9;
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(0, 0);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 85);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(8);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(823, 0);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 85);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(8);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(831, 25);
            this.tabControl1.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblistInfo);
            this.panel1.Controls.Add(this.btnpre);
            this.panel1.Controls.Add(this.btnnext);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(831, 85);
            this.panel1.TabIndex = 8;
            // 
            // lblistInfo
            // 
            this.lblistInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblistInfo.Font = new System.Drawing.Font("宋体", 18F);
            this.lblistInfo.Location = new System.Drawing.Point(100, 0);
            this.lblistInfo.Name = "lblistInfo";
            this.lblistInfo.Size = new System.Drawing.Size(559, 85);
            this.lblistInfo.TabIndex = 6;
            this.lblistInfo.Text = "lblistInfo";
            this.lblistInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Detail
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(831, 491);
            this.Controls.Add(this.pnlPro);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.Name = "Detail";
            this.Text = "Detail";
            this.tabControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnpre;
        private System.Windows.Forms.Button btnnext;
        private System.Windows.Forms.Panel pnlPro;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblistInfo;
    }
}