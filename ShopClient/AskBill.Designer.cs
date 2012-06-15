namespace ShopClient
{
    partial class AskBill
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
            this.pnlPro = new System.Windows.Forms.Panel();
            this.pnlselllist = new System.Windows.Forms.Panel();
            this.btnProSelect = new System.Windows.Forms.Button();
            this.lbAmount = new System.Windows.Forms.Label();
            this.btConfirm = new System.Windows.Forms.Button();
            this.lbbackamount = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlselllist.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(833, 0);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 64);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(841, 28);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(0, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 64);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnpre);
            this.panel1.Controls.Add(this.btnnext);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(841, 64);
            this.panel1.TabIndex = 5;
            // 
            // btnpre
            // 
            this.btnpre.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnpre.Location = new System.Drawing.Point(713, 0);
            this.btnpre.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnpre.Name = "btnpre";
            this.btnpre.Size = new System.Drawing.Size(64, 64);
            this.btnpre.TabIndex = 4;
            this.btnpre.Text = "上一页";
            this.btnpre.UseVisualStyleBackColor = true;
            this.btnpre.Click += new System.EventHandler(this.btnpre_Click);
            // 
            // btnnext
            // 
            this.btnnext.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnnext.Location = new System.Drawing.Point(777, 0);
            this.btnnext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(64, 64);
            this.btnnext.TabIndex = 5;
            this.btnnext.Text = "下一页";
            this.btnnext.UseVisualStyleBackColor = true;
            this.btnnext.Click += new System.EventHandler(this.btnnext_Click);
            // 
            // pnlPro
            // 
            this.pnlPro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPro.Location = new System.Drawing.Point(0, 92);
            this.pnlPro.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlPro.Name = "pnlPro";
            this.pnlPro.Size = new System.Drawing.Size(841, 413);
            this.pnlPro.TabIndex = 6;
            // 
            // pnlselllist
            // 
            this.pnlselllist.Controls.Add(this.btnProSelect);
            this.pnlselllist.Controls.Add(this.lbAmount);
            this.pnlselllist.Controls.Add(this.btConfirm);
            this.pnlselllist.Controls.Add(this.lbbackamount);
            this.pnlselllist.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlselllist.Location = new System.Drawing.Point(708, 92);
            this.pnlselllist.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlselllist.Name = "pnlselllist";
            this.pnlselllist.Size = new System.Drawing.Size(133, 413);
            this.pnlselllist.TabIndex = 7;
            // 
            // btnProSelect
            // 
            this.btnProSelect.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnProSelect.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnProSelect.Location = new System.Drawing.Point(0, 281);
            this.btnProSelect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnProSelect.Name = "btnProSelect";
            this.btnProSelect.Size = new System.Drawing.Size(133, 40);
            this.btnProSelect.TabIndex = 7;
            this.btnProSelect.Text = "产品";
            this.btnProSelect.UseVisualStyleBackColor = true;
            this.btnProSelect.Click += new System.EventHandler(this.btnProSelect_Click);
            // 
            // lbAmount
            // 
            this.lbAmount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbAmount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.lbAmount.Location = new System.Drawing.Point(0, 321);
            this.lbAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbAmount.Name = "lbAmount";
            this.lbAmount.Size = new System.Drawing.Size(133, 26);
            this.lbAmount.TabIndex = 2;
            this.lbAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btConfirm
            // 
            this.btConfirm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btConfirm.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btConfirm.Location = new System.Drawing.Point(0, 347);
            this.btConfirm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btConfirm.Name = "btConfirm";
            this.btConfirm.Size = new System.Drawing.Size(133, 40);
            this.btConfirm.TabIndex = 3;
            this.btConfirm.Text = "提交";
            this.btConfirm.UseVisualStyleBackColor = true;
            this.btConfirm.Click += new System.EventHandler(this.btConfirm_Click);
            // 
            // lbbackamount
            // 
            this.lbbackamount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbbackamount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.lbbackamount.Location = new System.Drawing.Point(0, 387);
            this.lbbackamount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbbackamount.Name = "lbbackamount";
            this.lbbackamount.Size = new System.Drawing.Size(133, 26);
            this.lbbackamount.TabIndex = 12;
            this.lbbackamount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AskBill
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(841, 505);
            this.Controls.Add(this.pnlselllist);
            this.Controls.Add(this.pnlPro);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AskBill";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "产品库存查询";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AskBill_FormClosing);
            this.Load += new System.EventHandler(this.ProSelect_Load);
            this.tabControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlselllist.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnnext;
        private System.Windows.Forms.Button btnpre;
        private System.Windows.Forms.Panel pnlPro;
        private System.Windows.Forms.Panel pnlselllist;
        private System.Windows.Forms.Button btnProSelect;
        private System.Windows.Forms.Label lbAmount;
        private System.Windows.Forms.Button btConfirm;
        private System.Windows.Forms.Label lbbackamount;
    }
}