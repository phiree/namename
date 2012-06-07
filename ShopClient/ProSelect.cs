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
    public partial class ProSelect : Form
    {

        IList<ProInfo> proinfos;
        uc.ucProInfo[] pis = new uc.ucProInfo[18];
        public ProSelect()
        {
            InitializeComponent();
            for (int i = 0; i < 18; i++)
            {
                pis[i] = new uc.ucProInfo();
                pnlPro.Controls.Add(pis[i]);
            }
        }

        public void LoadProInfo()
        {
            tabControl1.TabPages.Clear();

            DALProInfo dpi = new DALProInfo();

            foreach (string s in dpi.GetProCatesByAreaID(GlobalValue.GShop.AreaInfo.AreaID))
            {
                TabPage tp = new TabPage();
                tp.Tag = 0;
                tp.Text = s;
                tabControl1.TabPages.Add(tp);
            }

            //获得本区域的产品价格定义过的产品
            proinfos = dpi.GetProsByAreaID(GlobalValue.GShop.AreaInfo.AreaID);
            //第一次需要加载第0页的第0页数据！
            ShowByCateAndPageNo(tabControl1.TabPages[0]);
        }

        private void ShowByCateAndPageNo(TabPage tp)
        {
            //DateTime t1 = DateTime.Now;
            lbErrorInfo.Text = "";
            if (tp == null)
                return;
            int currPage = (int)tp.Tag;
            //在页面上显示！

            IList<ProInfo> CatePros = proinfos.Where<ProInfo>(x => x.ProCate == tp.Text).ToList();
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
            IList<ProInfo> source = new List<ProInfo>();
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
                    pis[i].ProInfo = source[i];
                    pis[i].LoadProInfo();
                    pis[i].Visible = true;
                }
                else
                {
                    pis[i].ProInfo = null;
                    pis[i].Visible = false;
                }
            }

            //tp.Controls.Clear();
            //GridBuilder<ProInfo> g = new GridBuilder<ProInfo>(source, new Size(190, 190), tp, 6, 10, 10);
            //g.OnAddItem += new GridBuilder<ProInfo>.AddItem(g_OnAddItem);
            ////DateTime t2 = DateTime.Now;
            //g.BuildButtons();
            ////DateTime t3 = DateTime.Now;

            ////TimeSpan ts1 = t2 - t1;
            ////TimeSpan ts2 = t3 - t2;

            //// this.Text = ts1.ToString() + "!" + ts2.ToString();
        }

        void g_OnAddItem(ProInfo t, Rectangle position, Control gridcontainer)
        {
            uc.ucProInfo pi = new uc.ucProInfo();
            pi.Left = position.Left;
            pi.Top = position.Top;
            pi.Size = position.Size;
            pi.ShowQty = false;
            pi.ProInfo = t;
            pi.OnSelectPro += new uc.ucProInfo.SelectPro(pi_OnSelectPro);
            gridcontainer.Controls.Add(pi);
        }

        void pi_OnSelectPro(object sender, ProInfo proinfo)
        {
            //显示输入产品数量的窗口
            lbErrorInfo.Text = "";
            decimal qty = new ProQtyInput().GetQty(proinfo, 0, false);
            if (qty == 0)
            {
                return;
            }
            else if (Program.mainfrm.AddPro(proinfo, qty))
            {
                this.Hide();
            }
            else
            {
                lbErrorInfo.Text = "产品已经选择，不能重复选择";
            }
        }



        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            ShowByCateAndPageNo(e.TabPage);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
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


        private void ProSelect_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
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
    }
}
