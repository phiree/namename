using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NameName.Model;
using NameName.DAL;

namespace ShopClient
{
    public partial class ProQtyInput : Form
    {
        public ProQtyInput()
        {
            InitializeComponent();
        }

        public decimal GetQty(ProInfo proinfo, decimal qty, bool CanDelete)
        {
            return GetQty(proinfo, qty, CanDelete, true);

        }

        public decimal GetQty(ProInfo proinfo, decimal qty, bool CanDelete, bool CanEditQty)
        {
            ucProInfo1.LeftField = "单价：" + new DALProInfo().GetPrice(proinfo.ProID, GlobalValue.GShop.AreaInfo.AreaID).Price.ToString("0.00");
            ucProInfo1.ProInfo = proinfo;
            if (qty != 0)
            {
                ucProInfo1.RightField = "数量:" + qty.ToString("0.00");
            }
            //ucProInfo1.LoadProInfo();

            this.btnDelete.Visible = CanDelete;
            ucProInfo1.Enabled = btnGet.Enabled = btnOK.Enabled = CanEditQty;
            decimal q = 0;

            switch (ShowDialog())
            {

                case DialogResult.Cancel:
                    q = 0;
                    break;
                case DialogResult.Ignore:
                    q = -1;
                    break;

                default:
                    decimal.TryParse(numInupt1.InputValue, out q);
                    break;
            }
            return q;

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            //读取电子秤数据

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Ignore;
        }


    }
}
