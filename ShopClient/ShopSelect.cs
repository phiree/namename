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
using System.Configuration;
using P = ShopClient.Properties;
namespace ShopClient
{
    public partial class ShopSelect : Form
    {
        bool ToExit = true;
        public ShopSelect()
        {

            InitializeComponent();

        }
        private void LoadAreas()
        {
            tabControl1.TabPages.Clear();

            IList<AreaInfo> areas = new DALArea().GetAreas();
            foreach (AreaInfo area in areas)
            {
                TabPage tp = new TabPage();
                tp.Name = area.AreaName;
                tp.Text = area.AreaName;
                tabControl1.TabPages.Add(tp);
                LoadShops(area, tp);

            }
        }

        public void LoadShops(AreaInfo area, TabPage tp)
        {
            IList<ShopInfo> shops = area.AreaShops.Where(x => x.IsCenter == false).ToList();
            GridBuilder<ShopInfo> g = new GridBuilder<ShopInfo>(shops, new Size(100, 100), tp, 10, 20, 20);
            g.OnAddItem += new GridBuilder<ShopInfo>.AddItem(g_OnAddItem);
            g.BuildButtons();
        }

        void g_OnAddItem(ShopInfo t, Rectangle position, Control gridcontainer)
        {
            Button btn = new Button();
            btn.Left = position.Left;
            btn.Top = position.Top; ;
            btn.Size = position.Size;
            btn.Text = t.ShopName;
            btn.Tag = t;
            btn.Click += new EventHandler(btn_Click);
            gridcontainer.Controls.Add(btn);

        }

        void btn_Click(object sender, EventArgs e)
        {
            //将该选择放入设置
            GlobalValue.GShop = (ShopInfo)((Button)sender).Tag;
            P.Settings.Default.ShopId = GlobalValue.GShop.ShopID.ToString();
            P.Settings.Default.Save();

            ToExit = false;
            this.Close();

            new UserSelect().Show();
        }

        private void ShopSelect_Load(object sender, EventArgs e)
        {
            LoadAreas();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShopSelect_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ToExit)
            {
                Application.Exit();
            }
        }
    }
}
