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

        public ProSelect()
        {
            InitializeComponent();
        }

        public void LoadProInfo()
        {
            tabControl1.TabPages.Clear();

            DALProInfo dpi = new DALProInfo();

            foreach (string s in dpi.GetProCates())
            {
                TabPage tp = new TabPage();
                tp.Tag = 0;
                tabControl1.TabPages.Add(tp);
            }

            proinfos = dpi.GetPros();
            //第一次需要加载第0页的第0页数据！
            ShowByCateAndPageNo(tabControl1.TabPages[0]);
        }

        private void ShowByCateAndPageNo(TabPage tp)
        {
            int currPage = (int)tp.Tag;
            //在页面上显示！

            IList<ProInfo> CatePros = proinfos.Where<ProInfo>(x => x.ProCate == tp.Text).ToList();
            int pagecount = 20;
            //一页放20个
            IList<ProInfo> source = new List<ProInfo>();
            for (int i = currPage * pagecount; i < currPage * pagecount + pagecount; i++)
            {
                if (i < CatePros.Count)
                {
                    source.Add(CatePros[i]);
                }
            }

            GridBuilder<ProInfo> g = new GridBuilder<ProInfo>(source, new Size(200, 200), tp, 10, 10, 10);
            g.OnAddItem += new GridBuilder<ProInfo>.AddItem(g_OnAddItem);
            g.BuildButtons();

        }

        void g_OnAddItem(ProInfo t, Rectangle position, Control gridcontainer)
        {
            uc.ucProInfo pi = new uc.ucProInfo();
            pi.Left = position.Left;
            pi.Top = position.Top;
            pi.Size = position.Size;

            //pi.SetProInfo(t);
            pi.Click += new EventHandler(pi_Click);
            gridcontainer.Controls.Add(pi);
        }

        void pi_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            ShowByCateAndPageNo(e.TabPage);
        }


    }
}
