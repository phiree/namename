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
    public partial class main : Form
    {
        public main()
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
            this.Text = GlobalValue.GShop.AreaInfo.AreaName + "-" + GlobalValue.GShop.ShopName + "-" + GlobalValue.GUser.TrueName + " 正在使用 么么 门店系统";
            //创建界面了！！！

            //判断当前的当班信息,如果当前用户在当前门店当班，则允许，
            //如果当前门店不是当前用户当班，则不允许，
            //如果当前用户


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnpwd_Click(object sender, EventArgs e)
        {
            new PwdChange().ShowDialog();
        }

        private void btnDutyBegin_Click(object sender, EventArgs e)
        {

        }
    }
}
