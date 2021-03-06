﻿using System;
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

                pnlPro.Controls.Add(pis[i]);
            }

            DALShopAskData dpa = new DALShopAskData();
            IList<string> cates = dpa.AskCates(GlobalValue.GShop.ShopID);
            GlobalFun.LoadProCate(cates, tabControl1);


            DALShopAskData dsa = new DALShopAskData();
            sa = dsa.GetAskDataByShopID(GlobalValue.GShop.ShopID);
            if (tabControl1.TabPages.Count != 0)
            {
                ShowByCateAndPageNo(tabControl1.TabPages[0],false);
            }
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
            //跳转到当前类别的页面！
            bool isExistInCate = false;
            
            foreach (TabPage tp in tabControl1.TabPages)
            {
                if (tp.Text == proinfo.ProCate) 
                { isExistInCate = true;
                tabControl1.SelectedTab = tp;
                    break; }
            }
            if (!isExistInCate)
            
            {
                TabPage tp = new TabPage();
                tp.Text = proinfo.ProCate;
                tp.Tag = 0;
                tabControl1.TabPages.Add(tp);
                tabControl1.SelectedTab = tp;
               
            }

            tabControl1.SelectedTab.Tag = 100;
            ShowByCateAndPageNo(tabControl1.SelectedTab,true);
            return true;
        }

        private void ShowByCateAndPageNo(TabPage tp,bool needRefresh)
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
            int MaxPage = CatePros.Count % 18 == 0 ? CatePros.Count / 18-1 : CatePros.Count / 18 ;
            if (currPage > MaxPage)
            {
                currPage = MaxPage;
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
                    pis[i].LeftField = "";
                    pis[i].RightField = "数量：" + source[i].Qty.ToString("0.00");
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
            ShowByCateAndPageNo(e.TabPage,false);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            ChangePage(true);
        }

        private void btnpre_Click(object sender, EventArgs e)
        {
            ChangePage(false);
        }

        private void ChangePage(bool isNext)
        {
            TabPage tg = tabControl1.SelectedTab;
            int CurrPage = (int)tg.Tag;
            if (isNext) CurrPage++;
            else
                CurrPage--;
            tg.Tag = CurrPage;
            ShowByCateAndPageNo(tg,false);
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

                pi.ProInfo = null;
                pi.OnSelectPro += new uc.ucProInfo.SelectPro(pi_OnSelectPro);
                btnIndex++;
            }
        }

        void pi_OnSelectPro(object sender, ProInfo proinfo)
        {
            //显示输入产品数量的窗口
            uc.ucProInfo upi = (uc.ucProInfo)sender;
            Shop_AskData sad = (Shop_AskData)upi.Tag;

            decimal qty = new ProQtyInput().GetQty(proinfo, sad.Qty, true, true);
            if (qty == 0)
            {
                return;
            }
            else if (qty == -1)
            {
                sa.Remove(sad);
                new DALShopAskData().Delete(sad);
            }
            else
            {
                sad.Qty = qty;
                upi.RightField = "数量：" + qty.ToString("0.00");
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

