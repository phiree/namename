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
            ucProInfo1.ProInfo = proinfo;
            if (qty != 0)
            {
                ucProInfo1.ShowQty = true;
                ucProInfo1.Qty = qty;
            }
            //ucProInfo1.LoadProInfo();

            this.btnDelete.Visible = CanDelete;

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
