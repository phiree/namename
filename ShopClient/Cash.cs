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
            ClientLogin();
            InitializeComponent();
        }

        private void Cash_Load(object sender, EventArgs e)
        {

        }

        protected override void OnShown(EventArgs e)
        {

        }

        protected override void SetVisibleCore(bool value)
        {
            if (!IsHandleCreated && value)
            {
                base.CreateHandle();
                value = false;
            }
            base.SetVisibleCore(value);
        }

        private void ClientLogin()
        {
            string strShopId = Properties.Settings.Default.ShopId;

            if (string.IsNullOrEmpty(strShopId))
            {
                new ShopSelect().Show();
            }
            else
            {
                Guid shopId;
                Guid.TryParse(strShopId, out shopId);
                if (shopId != Guid.Empty)
                {
                    GlobalValue.GShop = new DALShopInfo().GetByShopID(shopId);
                    if (GlobalValue.GShop == null)
                    {
                        new ShopSelect().Show();
                    }
                    else
                    {
                        new UserSelect().Show();
                    }
                }
                else
                {
                    new ShopSelect().Show();
                }
            }
        }

        public void LoginSuccess()
        {
            this.Show();

            //创建界面了！！！

        }
    }
}
