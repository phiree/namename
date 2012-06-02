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
            LoadAreas();
        }
        private void LoadAreas()
        {
            IList<AreaInfo> areas = new DALArea().GetAreas();
            foreach (AreaInfo area in areas)
            {
                TabPage tp = new TabPage();
                tp.Name = area.AreaName;
                tp.Text = area.AreaName;
                LoadShops(area, tp);
                tabControl1.TabPages.Add(tp);
            }
        }
        public void LoadShops(AreaInfo area, TabPage tp)
        {
            IList<ShopInfo> shops = area.AreaShops;
            int btnIndex = 0,
                initLeft = 20, initTop = 20,
                space = 30,
                width = 40, height = 40,
                cols = 4;
            foreach (ShopInfo shop in shops)
            {
                int currentRow = btnIndex / cols;
                int currentCol = btnIndex % cols;
                int left = initLeft + width * currentCol + space;
                int top = initTop + height * currentRow;

                Button btn = new Button();
                btn.Left = left;
                btn.Top = top;
                btn.Width = width;
                btn.Height = height;

                btn.Text = shop.ShopName;
                btn.Tag = shop.ShopID;
                btn.Click += new EventHandler(btn_Click);
                tp.Controls.Add(btn);

                btnIndex++;
            }
        }

        void btn_Click(object sender, EventArgs e)
        {
            //将该选择放入设置
            string shopId =((Button)sender).Tag.ToString();
            P.Settings.Default.ShopId = shopId;

            P.Settings.Default.Save();
            new Login().Show();

        }
    }
}
