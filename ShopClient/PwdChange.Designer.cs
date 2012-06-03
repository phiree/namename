namespace ShopClient
{
    partial class PwdChange
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
            this.button4 = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // numInupt1
            // 
            this.numInupt1.Dock = System.Windows.Forms.DockStyle.Top;
            this.numInupt1.Location = new System.Drawing.Point(0, 0);
            this.numInupt1.Name = "numInupt1";
            this.numInupt1.PasswordChar = '\0';
            this.numInupt1.Size = new System.Drawing.Size(464, 444);
            this.numInupt1.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Cyan;
            this.button4.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.ForeColor = System.Drawing.Color.CadetBlue;
            this.button4.Location = new System.Drawing.Point(58, 450);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(163, 75);
            this.button4.TabIndex = 19;
            this.button4.Text = "返回";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Cyan;
            this.btnOK.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.ForeColor = System.Drawing.Color.CadetBlue;
            this.btnOK.Location = new System.Drawing.Point(235, 450);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(163, 75);
            this.btnOK.TabIndex = 18;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // PwdChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 530);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.numInupt1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PwdChange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改密码";
            this.Load += new System.EventHandler(this.PwdChange_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private uc.NumInupt numInupt1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnOK;
    }
}