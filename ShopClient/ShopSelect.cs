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

            Dictionary<string, ShopInfo> d = new Dictionary<string, ShopInfo>();
            foreach (ShopInfo shop in shops)
            {
                d.Add(shop.ShopName, shop);
            }

            GridBuilder<ShopInfo> g = new GridBuilder<ShopInfo>(d, new Size(100, 100), tp, 10, 20, 20);
            g.OnBindButtonClick += new GridBuilder<ShopInfo>.BindButtonClick(g_OnBindButtonClick);
            g.BuildButtons();
        }

        void g_OnBindButtonClick(Button b)
        {
            b.Click += new EventHandler(btn_Click);
        }

        void btn_Click(object sender, EventArgs e)
        {
            //将该选择放入设置
            ShopInfo shop = (ShopInfo)((Button)sender).Tag;
            P.Settings.Default.ShopId = shop.ShopID.ToString();
            P.Settings.Default.Save();

            GlobalValue.ShopID = shop.ShopID;
            this.Close();
            new UserSelect().ShowDialog();
        }

        private void ShopSelect_Load(object sender, EventArgs e)
        {
            LoadAreas();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            LoadAreas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
