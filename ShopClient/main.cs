﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NameName.DAL;
using NameName.Model;
using System.Net;

namespace ShopClient
{
    public partial class main : Form
    {

        DALDuty dalduty = new DALDuty();
        Shop_DutyInfo dutyinfo;
        Shop_SellList selllist = null;

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

        private void SellBillInit()
        {
            pnlselllist.Visible = pnlselldetail.Visible = false;
            btnProSelect.Enabled = btnCash.Enabled = false;
            lbAmount.Text = lbPreAmount.Text = lbPreNo.Text = lbbillNo.Text = string.Empty;
        }

        /// <summary>
        /// 更新本地图片
        /// </summary>
        private void UpDateImage()
        {
            string ImgPath = Application.StartupPath + "\\ProImg\\";
            if (!System.IO.Directory.Exists(ImgPath))
            {
                System.IO.Directory.CreateDirectory(ImgPath);
            }
            DALSysSettings dss = new DALSysSettings();
            Sys_Settings ss = dss.GetValue(GlobalValue.GShop.ShopID.ToString() + "/ProUpDateTime");
            DateTime dt = Convert.ToDateTime("2000-01-01");
            if (ss != null)
            {
                DateTime.TryParse(ss.Value, out dt);
            }
            IList<ProInfo> pis = new DALProInfo().GetProsByLastUpDateTime(dt);
            WebClient wc = new WebClient();
            foreach (ProInfo pi in pis)
            {
                //通过HTTP取得服务器上的图片数据，保存到本地的ImaPath路径下               
                try
                {
                    wc.DownloadFile("http://LocalHost/propic/imgsmall/" + pi.PicName, ImgPath + pi.PicName);
                }
                catch
                {
                }
            }
            //取得服务器时间
            if (ss == null)
            {
                ss = new Sys_Settings();
                ss.Name = GlobalValue.GShop.ShopID.ToString() + "/ProUpDateTime";
            }
            ss.Value = new CommonFunctions().GetServerTime().ToString();
            dss.Save(ss);
        }

        public void LoginSuccess()
        {
            //更新图片数据
            UpDateImage();
            //加载产品数据
            ProSelect proselect = new ProSelect();
            proselect.LoadProInfo();

            this.Show();
            this.Text = GlobalValue.GShop.AreaInfo.AreaName + "-" + GlobalValue.GShop.ShopName + "-" + GlobalValue.GUser.TrueName + " 正在使用 么么 门店系统";
            //不可能为null的！
            GlobalValue.GAccount = new DALAccount().GetCurrAccount();

            SellBillInit();
            //创建界面了！！！
            string errorstr;
            Shop_DutyInfo sd = dalduty.OnDuty(GlobalValue.GUser, GlobalValue.GShop, GlobalValue.GAccount, false, out errorstr);

            if (sd != null)
            {
                //正在当班
                dutyinfo = sd;

                btnDutyBegin.Enabled = false;
                btnDutyEnd.Enabled = true;
                btnNew.Enabled = true;
                btnBack.Enabled = true;
                btnAsk.Enabled = false;
                btnCheck.Enabled = false;
                //判断是否有单据！有单据则下面的显示,新开一张单据后，数据都保存在内存中！所以不需要判断


            }
            else
            {

                if (string.IsNullOrEmpty(errorstr))
                {
                    //允许当班
                    btnDutyBegin.Enabled = true;

                    btnDutyEnd.Enabled = false;
                    btnNew.Enabled = false;
                    btnBack.Enabled = false;
                    btnAsk.Enabled = true;
                    btnCheck.Enabled = true;
                }
            }
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
            string errorstr;
            Shop_DutyInfo sd = dalduty.OnDuty(GlobalValue.GUser, GlobalValue.GShop, GlobalValue.GAccount, true, out errorstr);
            if (sd != null)
            {
                dutyinfo = sd;
                //开始当班
                btnDutyBegin.Enabled = false;
                btnDutyEnd.Enabled = true;
                btnNew.Enabled = true;
                btnBack.Enabled = true;
                btnAsk.Enabled = false;
                btnCheck.Enabled = false;

                pnlselllist.Visible = pnlselldetail.Visible = true;

            }
            else
            {
                GlobalFun.MessageBoxError(errorstr);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //产生一个SellList
            selllist = new Shop_SellList();
            btnProSelect.Enabled = true;
            btnCash.Enabled = true;

        }

        private void btnCash_Click(object sender, EventArgs e)
        {

        }

        private void btnProSelect_Click(object sender, EventArgs e)
        {
            //产品选择

        }
    }
}
