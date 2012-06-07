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

        public delegate void SelectPro(object sender, ProInfo proinfo);
        public event SelectPro OnSelectPro;

        public decimal Qty { get; set; }

        public bool ShowQty { get; set; }


        public ProInfo ProInfo { get; set; }

        public ucProInfo()
        {
            InitializeComponent();
        }

        public void LoadProInfo()
        {
            ucProInfo_Load(null, null);
        }

        private void ucProInfo_Load(object sender, EventArgs e)
        {
            lbqty.Visible = ShowQty;
            lbqty.Text = Qty.ToString("0.00");
            if (ProInfo == null)
            {
                this.Visible = false;
                return;
            }

            lbproname.Text = ProInfo.Name;
            lbunit.Text = ProInfo.Unit;
            lbprice.Text = new DALProInfo().GetPrice(ProInfo.ProID, GlobalValue.GShop.AreaInfo.AreaID).Price.ToString("0.00");
            //加载图片

            string filename = Application.StartupPath + "\\proimg\\" + ProInfo.PicName;
            if (File.Exists(filename))
            {
                picpro.Load(filename);
            }
        }

        private void lbproname_Click(object sender, EventArgs e)
        {
            GlobalFun.MessageBoxHint(lbproname.Text);
        }

        private void picpro_Click(object sender, EventArgs e)
        {
            if (OnSelectPro != null)
            {
                OnSelectPro(sender, ProInfo);
            }
        }
    }
}
