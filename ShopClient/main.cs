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
            lbAmount.Text = lbPreAmount.Text = lbPreNo.Text = lbactamount.Text = lbCAmount.Text = lbbackamount.Text = string.Empty;
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

        ProSelect proselect = new ProSelect();
        public void LoginSuccess()
        {
            //更新图片数据
            UpDateImage();
            //加载产品数据
            //显示正在加载数据的窗口!!!            
            proselect.Show();
            proselect.LoadProInfo();
            proselect.Hide();
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
            selllist.Duty = dutyinfo;

            pnlselllist.Visible = pnlselldetail.Visible = true;
            btnProSelect.Enabled = true;
            btnCash.Enabled = true;
            pnlselldetail.Tag = 0;

        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            Cash cash = new Cash();

            string billno = cash.CashSellList(selllist);

            //if (cash.sho == System.Windows.Forms.DialogResult.OK)
            //{
            //    //处理完成，初始化数据！

            //}
        }

        private void btnProSelect_Click(object sender, EventArgs e)
        {
            //产品选择            
            proselect.Show();

        }

        internal bool AddPro(ProInfo proinfo, decimal qty)
        {
            //判断这个产品是否已经存在
            if (selllist.Details.Where(x => x.Pro.ProID == proinfo.ProID).ToList().Count != 0)
            {
                return false;
            }

            Shop_SellDetail ss = new Shop_SellDetail();
            ss.Pro = proinfo;
            ss.Price = proinfo.ProPrices.Single<ProPrice>(x => x.AreaInfo.AreaID == GlobalValue.GShop.AreaInfo.AreaID).Price;
            ss.Amount = qty;
            selllist.Details.Add(ss);
            //增加了一个产品，需要重新计算金额！
            lbAmount.Text = GetSumAmount();

            //重画界面
            ShowSellDetailByPageNo();
            return true;
        }

        private string GetSumAmount()
        {
            string a = selllist.Details.Sum(x => x.Price * x.Amount).ToString("0.00");
            return "金额:" + a;
        }

        private void ShowSellDetailByPageNo()
        {
            int currPage = (int)pnlselldetail.Tag;
            //在页面上显示！

            if (currPage < 0)
            {
                currPage = 0;
                pnlselldetail.Tag = currPage;
                return;
            }

            if (currPage > selllist.Details.Count / 18)
            {
                currPage = selllist.Details.Count / 18;
                pnlselldetail.Tag = currPage;
                return;
            }


            int pagecount = 18;
            //一页放20个
            IList<Shop_SellDetail> source = new List<Shop_SellDetail>();
            for (int i = currPage * pagecount; i < currPage * pagecount + pagecount; i++)
            {
                if (i < selllist.Details.Count)
                {
                    source.Add(selllist.Details[i]);
                }
            }
            pnlselldetail.Controls.Clear();

            GridBuilder<Shop_SellDetail> g = new GridBuilder<Shop_SellDetail>(source, new Size(170, 170), pnlselldetail, 6, 10, 10);
            g.OnAddItem += new GridBuilder<Shop_SellDetail>.AddItem(g_OnAddItem);
            g.BuildButtons();
        }

        void g_OnAddItem(Shop_SellDetail t, Rectangle position, Control gridcontainer)
        {
            uc.ucProInfo pi = new uc.ucProInfo();
            pi.Left = position.Left;
            pi.Top = position.Top;
            pi.Size = position.Size;
            pi.ShowQty = true;
            pi.Qty = t.Amount;
            pi.ProInfo = t.Pro;
            pi.Tag = t;
            pi.OnSelectPro += new uc.ucProInfo.SelectPro(pi_OnSelectPro);

            gridcontainer.Controls.Add(pi);
        }

        void pi_OnSelectPro(object sender, ProInfo proinfo)
        {
            //进行修改数量，与删除的操作
            uc.ucProInfo pi = (uc.ucProInfo)((Control)sender).Parent;
            Shop_SellDetail ssd = (Shop_SellDetail)(pi.Tag);
            decimal qty = new ProQtyInput().GetQty(proinfo, ssd.Amount, true);
            if (qty == 0)
            {
                return;
            }
            else if (qty == -1)
            {
                //删除操作
                selllist.Details.Remove(ssd);
                ShowSellDetailByPageNo();
            }
            else
            {
                ssd.Amount = qty;
                pi.Qty = qty;
                pi.LoadProInfo();
            }
            lbAmount.Text = GetSumAmount();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int CurrPage = (int)pnlselldetail.Tag;
            CurrPage--;
            pnlselldetail.Tag = CurrPage;
            ShowSellDetailByPageNo();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int CurrPage = (int)pnlselldetail.Tag;
            CurrPage++;
            pnlselldetail.Tag = CurrPage;
            ShowSellDetailByPageNo();
        }


    }
}
