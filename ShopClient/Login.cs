using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShopClient
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        private void button12_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string value = btn.Text;
            tbxPwd.Text += value;

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (tbxPwd.TextLength > 0)
            {
                tbxPwd.Text = tbxPwd.Text.Substring(0, tbxPwd.TextLength - 1);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbxPwd.Text = string.Empty;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
