using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NameName.DAL;

namespace ShopClient
{
    public partial class PwdChange : Form
    {
        public PwdChange()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //修改密码
            if (string.IsNullOrEmpty(numInupt1.InputValue))
            {
                GlobalFun.MessageBoxError("密码不能为空");
            }
            else
            {

                GlobalValue.GUser.Pwd = numInupt1.InputValue;
                new DALUser().Save(GlobalValue.GUser);
                GlobalFun.MessageBoxHint("密码修改成功");
                this.Close();
            }
        }
    }
}
