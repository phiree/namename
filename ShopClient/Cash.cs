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
            Shop_SellList sslback = null;

            //产生billno 写数据库  库存 要货单 打印
            if (!string.IsNullOrEmpty(ssl.BackBillNo))
            {
                sslback = new Shop_SellList();
                sslback.BackBillNo = ssl.BackBillNo;
                sslback.Duty = ssl.Duty;

                //产生一张完全的退货单
                DALShopSellList dalshopselllist = new DALShopSellList();

                Shop_SellList selllistback = dalshopselllist.GetByBillNO(ssl.BackBillNo);

                sslback.BillNO = new DALSys_FormatSerialNo().GetSerialNo(GlobalValue.GShop.ShopNo); ;
                sslback.Details.Clear();
                foreach (Shop_SellDetail ssd in selllistback.Details)
                {
                    Shop_SellDetail sdnew = new Shop_SellDetail();
                    sdnew.Amount = -ssd.Amount;
                    sdnew.Price = ssd.Price;
                    sdnew.Pro = ssd.Pro;
                    sdnew.BillNO = sslback.BillNO;
                    sslback.Details.Add(sdnew);
                }

                sslback.BillAmount = -selllistback.BillAmount;
                sslback.ActAmount = -selllistback.ActAmount;
                sslback.ActCustomAmount = -selllistback.ActCustomAmount;
                sslback.BackFlag = true;

                new DALShopSellList().SaveList(sslback);

                new DALUnity().ExcuteStoredProcedure("usp_Shop_Sell_Cash",
                new string[] { GlobalValue.GAccount.AccountID.ToString(),
                    GlobalValue.GShop.ShopID.ToString(),
                    sslback.BillNO});

                Program.mainfrm.dutyinfo.BackCount++;
                Program.mainfrm.dutyinfo.BackAmount += sslback.ActAmount;
                Program.mainfrm.dalduty.Save(Program.mainfrm.dutyinfo);

                ssl.BackBillNo = null;
                ssl.Details.Clear();
                foreach (Shop_SellDetail sd in Program.mainfrm.ReMoveDetails)
                {
                    sd.Amount = -sd.Amount;
                    ssl.Details.Add(sd);
                }

            }

            if (ssl.Details.Count > 0)
            {
                string billNo = new DALSys_FormatSerialNo().GetSerialNo(GlobalValue.GShop.ShopNo);
                ssl.BillNO = billNo;
                ssl.BillAmount = ssl.Details.Sum(x => x.Price * x.Amount);
                ssl.ActAmount = ssl.BillAmount;
                ssl.ActCustomAmount = ssl.BillAmount;
                ssl.BackFlag = false;

                foreach (Shop_SellDetail detail in ssl.Details)
                {
                    detail.BillNO = billNo;
                }

                new DALShopSellList().SaveList(ssl);

                Program.mainfrm.dutyinfo.BillCount++;
                Program.mainfrm.dutyinfo.ActAmount += ssl.ActAmount;
                Program.mainfrm.dutyinfo.BillAmount += ssl.BillAmount;

                Program.mainfrm.dalduty.Save(Program.mainfrm.dutyinfo);
                //执行存储过程，进行库存处理
                new DALUnity().ExcuteStoredProcedure("usp_Shop_Sell_Cash",
                    new string[] { GlobalValue.GAccount.AccountID.ToString(),
                    GlobalValue.GShop.ShopID.ToString(),
                    ssl.BillNO});
            }
            if (sslback != null)
            {

                new CashPrint(sslback);

            }
            if (ssl.Details.Count > 0)
            {
                new CashPrint(ssl);
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }


    }
}
