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
    public partial class AskBill : Form
    {
        uc.ucProInfo[] pis = new uc.ucProInfo[18];
        IList<Shop_AskData> sa;

        public AskBill()
        {
            InitializeComponent();

            Program.mainfrm.proselect.OnProSelectQty += new ProSelect.ProSelectQty(proselect_OnProSelectQty);

            for (int i = 0; i < 18; i++)
            {
                pis[i] = new uc.ucProInfo();
                pis[i].ShowQty = true;
                pnlPro.Controls.Add(pis[i]);
            }
            GlobalFun.LoadProCate(tabControl1);
            DALShopAskData dsa = new DALShopAskData();
            sa = dsa.GetAskDataByShopID(GlobalValue.GShop.ShopID);
            ShowByCateAndPageNo(tabControl1.TabPages[0]);
        }

        bool proselect_OnProSelectQty(ProInfo proinfo, decimal qty)
        {
            if (sa.Where(x => x.ProInfo.ProID == proinfo.ProID).ToList().Count != 0)
            {
                return false;
            }
            Shop_AskData sad = new Shop_AskData();
            sad.ProInfo = proinfo;
            sad.Qty = qty;
            sad.ShopInfo = GlobalValue.GShop;
            sa.Add(sad);
            new DALShopAskData().Save(sad);
            //重画界面
            ShowByCateAndPageNo(tabControl1.SelectedTab);
            return true;
        }

        private void ShowByCateAndPageNo(TabPage tp)
        {
            if (tp == null)
                return;
            int currPage = (int)tp.Tag;
            //在页面上显示！

            IList<Shop_AskData> CatePros = sa.Where<Shop_AskData>(x => x.ProInfo.ProCate == tp.Text).ToList();
            //当前页的产品数量！
            if (currPage < 0)
            {
                currPage = 0;
                tp.Tag = currPage;
                return;
            }

            if (currPage > CatePros.Count / 18)
            {
                currPage = CatePros.Count / 18;
                tp.Tag = currPage;
                return;
            }

            int pagecount = 18;
            //一页放20个
            IList<Shop_AskData> source = new List<Shop_AskData>();
            for (int i = currPage * pagecount; i < currPage * pagecount + pagecount; i++)
            {
                if (i < CatePros.Count)
                {
                    source.Add(CatePros[i]);
                }
            }

            for (int i = 0; i < 18; i++)
            {
                if (i < source.Count)
                {
                    pis[i].ProInfo = source[i].ProInfo;
                    pis[i].Qty = source[i].Qty;
                    pis[i].LoadProInfo();
                    pis[i].Visible = true;
                    pis[i].Tag = source[i];
                }
                else
                {
                    pis[i].Tag = null;
                    pis[i].ProInfo = null;
                    pis[i].Visible = false;
                }
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            ShowByCateAndPageNo(e.TabPage);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            TabPage tg = tabControl1.SelectedTab;
            int CurrPage = (int)tg.Tag;
            CurrPage++;
            tg.Tag = CurrPage;
            ShowByCateAndPageNo(tg);
        }

        private void btnpre_Click(object sender, EventArgs e)
        {
            TabPage tg = tabControl1.SelectedTab;
            int CurrPage = (int)tg.Tag;
            CurrPage--;
            tg.Tag = CurrPage;
            ShowByCateAndPageNo(tg);
        }



        private void ProSelect_Load(object sender, EventArgs e)
        {
            Size ItemSize = new Size(190, 190);
            int ColAmount = 6;
            int InitTop = 10, RowSpace = 10;

            int btnIndex = 0;
            int space = (this.Width - ColAmount * ItemSize.Width) / (ColAmount + 1);

            foreach (uc.ucProInfo pi in pis)
            {
                int currentRow = btnIndex / ColAmount;
                int currentCol = btnIndex % ColAmount;
                int left = space + (ItemSize.Width + space) * currentCol;
                int top = InitTop + (RowSpace + ItemSize.Height) * currentRow;

                pi.Left = left;
                pi.Top = top;
                pi.Size = ItemSize;
                pi.ShowQty = false;
                pi.ProInfo = null;
                pi.OnSelectPro += new uc.ucProInfo.SelectPro(pi_OnSelectPro);
                btnIndex++;
            }
        }

        void pi_OnSelectPro(object sender, ProInfo proinfo)
        {
            //显示输入产品数量的窗口
            uc.ucProInfo upi = (uc.ucProInfo)sender;
            decimal qty = new ProQtyInput().GetQty(proinfo, upi.Qty, true, true);
            if (qty == 0)
            {
                return;
            }
            else if (qty == -1)
            {
                //删除操作
                Shop_AskData removes = (Shop_AskData)upi.Tag;
                sa.Remove(removes);
                new DALShopAskData().Delete(removes);


            }
            else
            {
                Shop_AskData edtsa = (Shop_AskData)upi.Tag;
                edtsa.Qty = qty;
                upi.Qty = qty;
                upi.LoadProInfo();
            }

        }

        private void btConfirm_Click(object sender, EventArgs e)
        {
            //获得要货的单据号！！！
            string billNo = new DALSys_FormatSerialNo().GetSerialNo("AB", false);
            DALShopAskList sda = new DALShopAskList();
            Shop_AskList sal = new Shop_AskList();
            sal.AskBillNo = billNo;
            sal.CrtDate = new CommonFunctions().GetServerTime();
            sal.ShopInfo = GlobalValue.GShop;
            sal.UserInfo = GlobalValue.GUser;
            sal.State = 1;
            sda.SaveList(sal);

            new DALUnity().ExcuteStoredProcedure("usp_Shop_AskListCreate",
                new string[] { GlobalValue.GShop.ShopID.ToString(), billNo });
            //初始化
            GlobalFun.MessageBoxHint("要货单上传成功！");
            this.Close();
        }

        private void btnProSelect_Click(object sender, EventArgs e)
        {
            Program.mainfrm.proselect.Show();
        }

        private void AskBill_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.mainfrm.proselect.OnProSelectQty -= new ProSelect.ProSelectQty(proselect_OnProSelectQty);
        }
    }
}

