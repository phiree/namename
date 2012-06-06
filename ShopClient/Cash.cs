using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NameName.DAL;
using NameName.Model;

namespace ShopClient
{
    public partial class Cash : Form
    {
        public Cash()
        {
            InitializeComponent();
        }

        Shop_SellList ssl;

        public string CashSellList(Shop_SellList selllist)
        {
            ssl = selllist;

            dataGridView1.AutoGenerateColumns = false;
         
            dataGridView1.DataSource =  ssl.Details;

            lbbillamount.Text = selllist.Details.Sum(x => x.Price * x.Amount).ToString("0.00");
            lbactamount.Text = lbbillamount.Text;
            lbbackamount.Text = GetBackAmount();
            this.ShowDialog();
            return "";
        }
        
        private string GetBackAmount()
        {
            return (Convert.ToDecimal(lbactamount.Text) - Convert.ToDecimal(lbbillamount.Text)).ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void lbactamount_Click(object sender, EventArgs e)
        {
            decimal d = new InputQty().GetInputValue();
            if (d != 0)
            {
                lbactamount.Text = d.ToString("0.00");
                lbbackamount.Text = GetBackAmount();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lbactamount.Text == lbbillamount.Text)
            {
                lbbillamount.Text = ssl.Details.Sum(x => x.Price * x.Amount).ToString("0.00");
                lbactamount.Text = lbbillamount.Text;
            }
            else
            {
                lbbillamount.Text = ssl.Details.Sum(x => x.Price * x.Amount).ToString("0.00");
                lbbackamount.Text = GetBackAmount();
            }
        }
    }
}
