using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShopClient.uc
{
    public partial class NumInupt : UserControl
    {

        public char PasswordChar
        {
            get { return tbxValue.PasswordChar; }
            set { tbxValue.PasswordChar = value; }
        }

        public string InputValue
        {
            get { return tbxValue.Text; }
        }


        public NumInupt()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (tbxValue.TextLength > 0)
            {
                tbxValue.Text = tbxValue.Text.Substring(0, tbxValue.TextLength - 1);
            }
        }

        private void btnNum_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string value = btn.Text;
            tbxValue.Text += value;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbxValue.Text = string.Empty;
        }
    }
}
