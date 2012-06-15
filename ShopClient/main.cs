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

        public DALDuty dalduty = new DALDuty();
        public Shop_DutyInfo dutyinfo;

        Shop_SellList selllist = null;

        public List<Shop_SellDetail> ReMoveDetails = new List<Shop_SellDetail>();

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
            NewBill(false);
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

        public ProSelect proselect = new ProSelect();

        public void LoginSuccess()
        {
            //更新图片数据
            UpDateImage();
            //加载产品数据
            LoadProInfos();
            //显示正在加载数据的窗口!!!            
            proselect.Show();
            proselect.OnProSelectQty += new ProSelect.ProSelectQty(proselect_OnProSelectQty);
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
                //判断是否有单据！有单据则下面的显示,新开一张单据后，数据都保存在内存中！所以不需要判断
            }
            else
            {
                if (string.IsNullOrEmpty(errorstr))
                {
                    //允许当班
                    btnDutyBegin.Enabled = true;
                    btnDutyEnd.Enabled = false;

                    btnAsk.Enabled = true;
                    btnCheck.Enabled = true;
                }
            }
        }

        bool proselect_OnProSelectQty(ProInfo proinfo, decimal qty)
        {

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
            pnlselldetail.Tag = 100;
            //重画界面
            ShowSellDetailByPageNo(true);
            return true;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnpwd_Click(object sender, EventArgs e)
        {
            new PwdChange().ShowDialog();
        }

        private void NewBill(bool IsNew)
        {
            btnNew.Enabled = btnBack.Enabled = !IsNew;
            btnPre.Enabled = btnnext.Enabled = btnProSelect.Enabled = btnCash.Enabled = btncancel.Enabled = IsNew;
            if (!IsNew)
            {
                pnlselldetail.Controls.Clear();
                selllist = null;
            }
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
            }
            else
            {
                GlobalFun.MessageBoxError(errorstr);
            }
        }

        private void CreateBill()
        {
            //产生一个SellList
            selllist = new Shop_SellList();
            selllist.Duty = dutyinfo;
            NewBill(true);
            pnlselldetail.Tag = 0;
            ReMoveDetails.Clear();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            CreateBill();
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            if (new Cash(selllist).ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //处理完成，初始化数据！
                lbAmount.Text = "";
                lbPreNo.Text = "单据号：" + selllist.BillNO;
                lbPreAmount.Text = "应收:" + selllist.BillAmount.ToString("0.00");
                lbCAmount.Text = "实付：" + selllist.ActCustomAmount.ToString("0.00");
                lbactamount.Text = "实收：" + selllist.ActAmount.ToString("0.00");
                lbbackamount.Text = "找零：" + (selllist.ActCustomAmount - selllist.ActAmount).ToString("0.00");
                NewBill(false);

            }
        }

        private void btnProSelect_Click(object sender, EventArgs e)
        {
            //产品选择            
            proselect.Show();

        }

        private string GetSumAmount()
        {
            string a = selllist.Details.Sum(x => x.Price * x.Amount).ToString("0.00");
            return "金额:" + a;
        }

        private void ShowSellDetailByPageNo(bool needRefresh)
        {
            int currPage = (int)pnlselldetail.Tag;
            //在页面上显示！

            if (currPage < 0)
            {
                currPage = 0;
                pnlselldetail.Tag = currPage;
                if (!needRefresh) return;
            }

            int MaxPage = selllist.Details.Count % 18 == 0 ? selllist.Details.Count / 18 -1: selllist.Details.Count / 18 ;

            if (currPage > MaxPage)
            {
                currPage = MaxPage;
                pnlselldetail.Tag = currPage;
               if(!needRefresh) return;
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
            pi.LeftField = "单价:" + t.Price.ToString("0.00");
            pi.RightField = "数量:" + t.Amount.ToString("0.00");
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

            decimal qty = new ProQtyInput().GetQty(proinfo, ssd.Amount, true, string.IsNullOrEmpty(selllist.BackBillNo));
            if (qty == 0)
            {
                return;
            }
            else if (qty == -1)
            {
                //删除操作
                if (!string.IsNullOrEmpty(selllist.BackBillNo))
                {
                    ReMoveDetails.Add(ssd);
                }
                selllist.Details.Remove(ssd);
                ShowSellDetailByPageNo(true);
            }
            else
            {
                ssd.Amount = qty;
                pi.RightField = "数量:" + qty.ToString("0.00");
                pi.LoadProInfo();
            }
            lbAmount.Text = GetSumAmount();
        }

        void PageNext(bool next)
        {
            int CurrPage = (int)pnlselldetail.Tag;
            if (next)
                CurrPage++;
            else
                CurrPage--;
            pnlselldetail.Tag = CurrPage;
            ShowSellDetailByPageNo(false);
        }

        private void btncancel_Click(object sender, EventArgs e)
        {

            NewBill(false);
            lbAmount.Text = "";
        }

        private void btnDutyEnd_Click(object sender, EventArgs e)
        {
            if (selllist != null)
            {
                GlobalFun.MessageBoxError("还有单据未处理，不能交班");
                return;
            }
            dalduty.DutyEnd(dutyinfo);
            dutyinfo = null;
            //允许当班
            btnDutyBegin.Enabled = true;
            btnDutyEnd.Enabled = false;

            btnAsk.Enabled = true;
            btnCheck.Enabled = true;


        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //退货，输入单据号
            if (selllist != null)
            {
                GlobalFun.MessageBoxError("还有单据未处理，不能进行退货操作");
                return;
            }

            InputQty iq = new InputQty();
            iq.Text = "请输入单据号";
            string billno = iq.GetInputValue().ToString();
            if (!string.IsNullOrEmpty(billno))
            {
                DALShopSellList dalshopselllist = new DALShopSellList();
                //查询这张单据！
                Shop_SellList ssl = dalshopselllist.GetByBillNO(billno);
                if (ssl == null)
                {
                    GlobalFun.MessageBoxError("找不到这张单据");
                    return;
                }
                if (ssl.BackFlag)
                {
                    GlobalFun.MessageBoxError("退货单，不能退货！");
                    return;
                }
                if (dalshopselllist.GetBackBillByNo(ssl.BillNO) != null)
                {
                    GlobalFun.MessageBoxError("已经退货的单据，不能重复退货");
                    return;
                }
                if (ssl.Duty.Shop.ShopID != GlobalValue.GShop.ShopID)
                {
                    GlobalFun.MessageBoxError("不是本门店的单据，不能退货");
                    return;
                }


                CreateBill();
                selllist.BackBillNo = ssl.BillNO;
                foreach (Shop_SellDetail ssd in ssl.Details)
                {
                    Shop_SellDetail sdnew = new Shop_SellDetail();

                    sdnew.Amount = -ssd.Amount;
                    sdnew.Price = ssd.Price;
                    sdnew.Pro = ssd.Pro;
                    selllist.Details.Add(sdnew);
                }

                ShowSellDetailByPageNo(true);
                //不允许增加产品！不允许修改数量！！！
                btnProSelect.Enabled = false;

            }
        }

        public void LoadProInfos()
        {
            DALProInfo dpi = new DALProInfo();
            GlobalValue.GProInfos = dpi.GetProsByAreaID(GlobalValue.GShop.AreaInfo.AreaID);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //库存查询
            new ProStore().ShowDialog();
        }

        private void btnAsk_Click(object sender, EventArgs e)
        {
            //要货单
            proselect.OnProSelectQty -= new ProSelect.ProSelectQty(proselect_OnProSelectQty);
            new AskBill().ShowDialog();
            proselect.OnProSelectQty += new ProSelect.ProSelectQty(proselect_OnProSelectQty);
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            PageNext(false);
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            PageNext(true);
        }

        private void btnasklist_Click(object sender, EventArgs e)
        {
            //历史要货单
            DateTime begindate, enddate;
            if (new DateSelect().SelectDate(out begindate, out enddate))
            {
                //
                List<BillList.DGVColumn> dgvcols = new List<BillList.DGVColumn>();
                //BillList.DGVColumn d1 = new BillList.DGVColumn("单据号","AskBillNo");
                dgvcols.Add(new BillList.DGVColumn("单据号", "AskBillNo"));
                dgvcols.Add(new BillList.DGVColumn("单据时间", "CrtDate", DataGridViewAutoSizeColumnMode.Fill));
                dgvcols.Add(new BillList.DGVColumn("单据状态", "StateName"));

                BillList.ListFrm lf = new BillList.ListFrm("要货单", begindate, enddate, dgvcols);
                lf.OnDateTimeSelect += new BillList.ListFrm.DateTimeSelect(lf_OnDateTimeSelect);
                lf.OnRowDoubleClick += new BillList.ListFrm.RowDoubleClick(lf_OnRowDoubleClick);
                lf.ShowDialog();
            }
        }

        void lf_OnRowDoubleClick(string billno)
        {
            new BillList.DetailFrm(billno).ShowDialog();
        }

        object lf_OnDateTimeSelect(DateTime begindate, DateTime enddate)
        {
            DALShopAskList dsal = new DALShopAskList();
            IList<Shop_AskList> sals = dsal.GetByDateTime(begindate, enddate, GlobalValue.GShop.ShopID);
            return sals;

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            //入库单
            DateTime begindate, enddate;
            if (new DateSelect().SelectDate(out begindate, out enddate))
            {

            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            //盘点

        }

        private void btnCheckLlist_Click(object sender, EventArgs e)
        {
            //盘点单
            DateTime begindate, enddate;
            if (new DateSelect().SelectDate(out begindate, out enddate))
            {

            }
        }




    }
}
