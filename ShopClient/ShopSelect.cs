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
            IList<ShopInfo> shops = area.AreaShops;
            int btnIndex = 0,
                initTop = 20,

                buttonwidth = 100, height = 100,
                cols = 4;

            int space = (tp.Width - 4 * buttonwidth) / 5;

            foreach (ShopInfo shop in shops)
            {
                if (shop.IsCenter == false)
                {
                    int currentRow = btnIndex / cols;
                    int currentCol = btnIndex % cols;

                    int left = space + (buttonwidth + space) * currentCol;
                    int top = (initTop + height) * currentRow + initTop;

                    Button btn = new Button();
                    btn.Left = left;
                    btn.Top = top;
                    btn.Width = buttonwidth;
                    btn.Height = height;

                    btn.Text = shop.ShopName;
                    btn.Tag = shop.ShopID;
                    btn.Click += new EventHandler(btn_Click);
                    tp.Controls.Add(btn);

                    btnIndex++;
                }
            }
        }

        void btn_Click(object sender, EventArgs e)
        {
            //将该选择放入设置
            string shopId = ((Button)sender).Tag.ToString();
            P.Settings.Default.ShopId = shopId;

            P.Settings.Default.Save();
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
            this.Close();
        }
    }
}
