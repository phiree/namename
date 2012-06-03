namespace ShopClient.uc
{
    partial class ucProInfo
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.picpro = new System.Windows.Forms.PictureBox();
            this.lbproname = new System.Windows.Forms.Label();
            this.lbunit = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbprice = new System.Windows.Forms.Label();
            this.lbqty = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picpro)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // picpro
            // 
            this.picpro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picpro.Location = new System.Drawing.Point(0, 0);
            this.picpro.Name = "picpro";
            this.picpro.Size = new System.Drawing.Size(195, 140);
            this.picpro.TabIndex = 0;
            this.picpro.TabStop = false;
            // 
            // lbproname
            // 
            this.lbproname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbproname.Location = new System.Drawing.Point(0, 0);
            this.lbproname.Name = "lbproname";
            this.lbproname.Size = new System.Drawing.Size(154, 29);
            this.lbproname.TabIndex = 1;
            this.lbproname.Text = "名称";
            this.lbproname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbunit
            // 
            this.lbunit.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbunit.Location = new System.Drawing.Point(154, 0);
            this.lbunit.Name = "lbunit";
            this.lbunit.Size = new System.Drawing.Size(41, 29);
            this.lbunit.TabIndex = 2;
            this.lbunit.Text = "单位";
            this.lbunit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbproname);
            this.panel1.Controls.Add(this.lbunit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 140);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(195, 29);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbprice);
            this.panel2.Controls.Add(this.lbqty);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 169);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(195, 29);
            this.panel2.TabIndex = 4;
            // 
            // lbprice
            // 
            this.lbprice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbprice.Location = new System.Drawing.Point(0, 0);
            this.lbprice.Name = "lbprice";
            this.lbprice.Size = new System.Drawing.Size(113, 29);
            this.lbprice.TabIndex = 1;
            this.lbprice.Text = "单价：";
            this.lbprice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbqty
            // 
            this.lbqty.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbqty.Location = new System.Drawing.Point(113, 0);
            this.lbqty.Name = "lbqty";
            this.lbqty.Size = new System.Drawing.Size(82, 29);
            this.lbqty.TabIndex = 2;
            this.lbqty.Text = "数量：100.00";
            this.lbqty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucProInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picpro);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "ucProInfo";
            this.Size = new System.Drawing.Size(195, 198);
            this.Load += new System.EventHandler(this.ucProInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picpro)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picpro;
        private System.Windows.Forms.Label lbproname;
        private System.Windows.Forms.Label lbunit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbprice;
        private System.Windows.Forms.Label lbqty;
    }
}
