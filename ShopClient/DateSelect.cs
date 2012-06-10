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
    public partial class DateSelect : Form
    {

        public DateSelect()
        {
            InitializeComponent();
            DateTime d = new CommonFunctions().GetServerTime();
            monthCalendar1.SelectionStart = d.AddMonths(-1);
            monthCalendar2.SelectionStart = d;

        }

        public bool SelectDate(out DateTime begindate, out DateTime enddate)
        {
            begindate = monthCalendar1.SelectionStart;
            enddate = monthCalendar2.SelectionStart;
            if (this.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                begindate = monthCalendar1.SelectionStart;
                enddate = monthCalendar2.SelectionStart;
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }


    }
}
