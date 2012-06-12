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

namespace ShopClient.BillList
{
    public partial class ListFrm : Form
    {
        public ListFrm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        public DateTime Bdate { get; set; }
        public DateTime EDate { get; set; }


        public virtual void GetData()
        {
            lbDate.Text = "开始时间：" + Bdate + "\r\n" + "结束时间：" + Bdate;
        }


        private void label1_Click(object sender, EventArgs e)
        {
            DateTime begindate, enddate;
            if (new DateSelect().SelectDate(out begindate, out enddate))
            {
                Bdate = begindate;
                Bdate = enddate;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string billno = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
