using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NameName.DAL;
using NameName.Model;
using System.IO;

namespace ShopClient.uc
{
    public partial class ucProInfo : UserControl
    {
        public decimal Qty { get; set; }

        public bool ShowQty { get; set; }


        public ProInfo ProInfo { get; set; }

        public ucProInfo()
        {
            InitializeComponent();
        }

        private void ucProInfo_Load(object sender, EventArgs e)
        {
            lbqty.Visible = ShowQty;
            lbproname.Text = ProInfo.Name;
            lbunit.Text = ProInfo.Unit;
            lbprice.Text = ProInfo.ProPrices.Single<ProPrice>(x => x.AreaInfo.AreaID == GlobalValue.GShop.AreaInfo.AreaID).Price.ToString("0.00");
            //加载图片

            //string filename = Application.StartupPath + "\\ProImg\\" + ProInfo.PicName;
            //if (File.Exists(filename))
            //{
            //    picpro.Load(filename);
            //}
        }

        private void lbproname_Click(object sender, EventArgs e)
        {
            GlobalFun.MessageBoxHint(lbproname.Text);
        }
    }
}
