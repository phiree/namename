namespace ShopClient
{
    partial class Login
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.numInupt1 = new ShopClient.uc.NumInupt();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Cyan;
            this.btnLogin.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogin.ForeColor = System.Drawing.Color.CadetBlue;
            this.btnLogin.Location = new System.Drawing.Point(240, 469);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(163, 75);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Cyan;
            this.button4.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.ForeColor = System.Drawing.Color.CadetBlue;
            this.button4.Location = new System.Drawing.Point(63, 469);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(163, 75);
            this.button4.TabIndex = 17;
            this.button4.Text = "返回";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // numInupt1
            // 
            this.numInupt1.Dock = System.Windows.Forms.DockStyle.Top;
            this.numInupt1.Location = new System.Drawing.Point(0, 0);
            this.numInupt1.Name = "numInupt1";
            this.numInupt1.PasswordChar = '*';
            this.numInupt1.Size = new System.Drawing.Size(497, 463);
            this.numInupt1.TabIndex = 18;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 559);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.numInupt1);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button button4;
        private uc.NumInupt numInupt1;
    }
}