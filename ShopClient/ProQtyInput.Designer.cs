namespace ShopClient
{
    partial class ProQtyInput
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
            this.numInupt1 = new ShopClient.uc.NumInupt();
            this.ucProInfo1 = new ShopClient.uc.ucProInfo();
            this.btnGet = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // numInupt1
            // 
            this.numInupt1.Dock = System.Windows.Forms.DockStyle.Left;
            this.numInupt1.Font = new System.Drawing.Font("宋体", 9F);
            this.numInupt1.Location = new System.Drawing.Point(0, 0);
            this.numInupt1.Name = "numInupt1";
            this.numInupt1.PasswordChar = '\0';
            this.numInupt1.Size = new System.Drawing.Size(392, 414);
            this.numInupt1.TabIndex = 6;
            // 
            // ucProInfo1
            // 
            this.ucProInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucProInfo1.Location = new System.Drawing.Point(392, 102);
            this.ucProInfo1.Name = "ucProInfo1";
            this.ucProInfo1.ProInfo = null;
            
            this.ucProInfo1.Size = new System.Drawing.Size(210, 210);
            this.ucProInfo1.TabIndex = 7;
            // 
            // btnGet
            // 
            this.btnGet.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnGet.Location = new System.Drawing.Point(0, 0);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(105, 102);
            this.btnGet.TabIndex = 8;
            this.btnGet.Text = "电子秤";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOK.Location = new System.Drawing.Point(105, 0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(105, 102);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.btnGet);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(392, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 102);
            this.panel1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btncancel);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(392, 312);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(210, 102);
            this.panel2.TabIndex = 12;
            // 
            // btncancel
            // 
            this.btncancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btncancel.Location = new System.Drawing.Point(105, 0);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(105, 102);
            this.btncancel.TabIndex = 11;
            this.btncancel.Text = "返回";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDelete.Location = new System.Drawing.Point(0, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(105, 102);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.button1_Click);
            // 
            // ProQtyInput
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(602, 414);
            this.Controls.Add(this.ucProInfo1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.numInupt1);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.Name = "ProQtyInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数量";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private uc.NumInupt numInupt1;
        private uc.ucProInfo ucProInfo1;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnDelete;

    }
}