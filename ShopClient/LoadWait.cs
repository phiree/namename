using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShopClient
{
    public partial class LoadWait : Form
    {
        public LoadWait()
        {
            InitializeComponent();
        }

        public void LoadData(ProSelect ps)
        {
            DateTime t1 = DateTime.Now;
            ps.Show();
            //ps.LoadProInfo();
            ps.Hide();
            DateTime t2 = DateTime.Now;
            TimeSpan ts1 = t2 - t1;
            this.Text = ts1.ToString();

            //使用那种模式需要1分钟

            this.ShowDialog();
        }

        private void LoadWait_Load(object sender, EventArgs e)
        {

        }
    }
}
