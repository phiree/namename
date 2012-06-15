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
    public partial class ProStore : Form
    {
        uc.ucProInfo[] pis = new uc.ucProInfo[18];
        IList<Shop_Store> ss;

        public ProStore()
        {
            InitializeComponent();
            for (int i = 0; i < 18; i++)
            {
                pis[i] = new uc.ucProInfo();

                pnlPro.Controls.Add(pis[i]);
            }
            DALProInfo dpi = new DALProInfo();
            List<string> cates = dpi.GetProCatesByAreaID(GlobalValue.GShop.AreaInfo.AreaID).ToList();
            GlobalFun.LoadProCate(cates, tabControl1);
            DALShopStore dss = new DALShopStore();
            ss = dss.GetShopStoreByShopID(GlobalValue.GShop.ShopID);
            ShowByCateAndPageNo(tabControl1.TabPages[0]);
        }

        private void ShowByCateAndPageNo(TabPage tp)
        {
            if (tp == null)
                return;
            int currPage = (int)tp.Tag;
            //在页面上显示！

            IList<Shop_Store> CatePros = ss.Where<Shop_Store>(x => x.ProInfo.ProCate == tp.Text).ToList();
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
            IList<Shop_Store> source = new List<Shop_Store>();
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
                    pis[i].LeftField = "单价：" + new DALProInfo().GetPrice(source[i].ProInfo.ProID, GlobalValue.GShop.AreaInfo.AreaID).Price.ToString("0.00");
                    pis[i].RightField = "数量：" + source[i].CurrQty.ToString("0.00");
                    pis[i].LoadProInfo();
                    pis[i].Visible = true;
                }
                else
                {
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

        private void TransPage(bool next)
        {
            TabPage tg = tabControl1.SelectedTab;
            int CurrPage = (int)tg.Tag;
            if (next)
            {
                CurrPage++;
            }
            else
            {
                CurrPage--;
            }
            tg.Tag = CurrPage;
            ShowByCateAndPageNo(tg);
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            TransPage(true);
        }

        private void btnpre_Click(object sender, EventArgs e)
        {
            TransPage(false);
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

                btnIndex++;
            }
        }
    }
}
