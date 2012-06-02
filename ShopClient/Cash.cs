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

        private void ClientLogin()
        {


            string strShopId = Properties.Settings.Default.ShopId;

            if (string.IsNullOrEmpty(strShopId))
            {
                new ShopSelect().ShowDialog();
            }
            else
            {
                Guid shopId;
                Guid.TryParse(strShopId, out shopId);
                if (shopId != Guid.Empty)
                {
                    ShopInfo shop = new DALShopInfo().GetByShopID(shopId);
                    if (shop == null)
                    {
                        new ShopSelect().ShowDialog();
                    }
                    else
                    {
                        GlobalValue.ShopID = shop.ShopID;
                        new UserSelect().ShowDialog();
                    }
                }
                else
                {
                    new ShopSelect().ShowDialog();
                }
            }
        }
    }
}
