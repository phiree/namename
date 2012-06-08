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
        Shop_SellList ssl;

        public Cash(Shop_SellList selllist)
        {
            InitializeComponent();

            ssl = selllist;

            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.DataSource = ssl.Details;

            lbbillamount.Text = selllist.Details.Sum(x => x.Price * x.Amount).ToString("0.00");
            lbactamount.Text = lbbillamount.Text;
            lbbackamount.Text = GetBackAmount();
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

        private void btnRemoveZero_Click(object sender, EventArgs e)
        {

            decimal price = decimal.Parse(lbbillamount.Text);
            string[] prices = lbbillamount.Text.Split('.');
            decimal xiaoshu = decimal.Parse(prices[1]);
            if (xiaoshu < 50)
            {
                xiaoshu = 0;
            }
            else
            {
                xiaoshu = 0.5M;
            }

            price = decimal.Parse(prices[0]) + xiaoshu;

            if (lbbillamount.Text == lbactamount.Text)
            {
                lbbillamount.Text = price.ToString("0.00");
                lbactamount.Text = lbbillamount.Text;
            }
            else
            {
                lbbillamount.Text = price.ToString("0.00");
            }


            lbbackamount.Text = GetBackAmount();
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            //产生billno 写数据库  库存 要货单 打印 
            string billNo = new DALSys_FormatSerialNo().GetSerialNo(GlobalValue.GShop.ShopNo);
            ssl.BillNO = billNo;
            ssl.BillAmount = ssl.Details.Sum(x => x.Price * x.Amount);
            ssl.ActAmount = decimal.Parse(lbbillamount.Text);
            ssl.ActCustomAmount = decimal.Parse(lbactamount.Text);
            ssl.BackFlag = false;

            foreach (Shop_SellDetail detail in ssl.Details)
            {
                detail.BillNO = billNo;
            }

            new DALShopSellList().SaveList(ssl);

            new CashPrint(ssl);
            //获得当前的号码

            //Shop_AskList sl = new DALShopAskList().GetListWithNotConfirm(GlobalValue.GShop);
            //if (sl == null)
            //{
            //    sl = new Shop_AskList();
            //    sl.CrtDate = new CommonFunctions().GetServerTime();
            //    sl.AskBillNo = new DALSys_FormatSerialNo().GetSerialNo("AB" + GlobalValue.GShop.ShopNo, false);
            //    sl.ShopInfo = GlobalValue.GShop;
            //    sl.State = 0;
            //    sl.UserInfo = GlobalValue.GUser;
            //    new DALShopAskList().SaveList(sl);
            //}
            //执行存储过程，进行库存处理
            new DALUnity().ExcuteStoredProcedure("usp_Shop_Sell_Cash",
                new string[] { GlobalValue.GAccount.AccountID.ToString(),
                    GlobalValue.GShop.ShopID.ToString(),
                    ssl.BillNO});
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new CashPrint(ssl);
        }
    }
}
