using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShopClient.BillList
{
    public partial class DetailFrm : Form
    {

        public DetailFrm(string billno)
        {
            InitializeComponent();
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

        private void ShowByCateAndPageNo(TabPage tg)
        {
            //显示数据
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            TransPage(true);
        }

        private void btnpre_Click(object sender, EventArgs e)
        {
            TransPage(false);
        }
    }
}
