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
        public delegate void RowDoubleClick(string billno);
        public event RowDoubleClick OnRowDoubleClick;

        public delegate object DateTimeSelect(DateTime begindate, DateTime enddate);
        public event DateTimeSelect OnDateTimeSelect;

        DateTime Bdate;
        DateTime EDate;

        public ListFrm(string thisname, DateTime begindate, DateTime enddate, List<DGVColumn> dgvColumns)
        {
            InitializeComponent();

            Bdate = begindate;
            EDate = enddate;
            this.Text = thisname;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            foreach (DGVColumn col in dgvColumns)
            {

                DataGridViewTextBoxColumn dgvcol = new DataGridViewTextBoxColumn();
                dgvcol.HeaderText = col.ColName;
                dgvcol.DataPropertyName = col.DataPropertyName;
                dgvcol.AutoSizeMode = col.AutoSizeMode;

                dataGridView1.Columns.Add(dgvcol);
            }
        }

        private void GetData()
        {
            lbDate.Text = "开始时间：" + Bdate + "\r\n" + "结束时间：" + EDate;
            if (OnDateTimeSelect != null)
            {
                dataGridView1.DataSource = OnDateTimeSelect(Bdate, EDate);
            }
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
            if (OnRowDoubleClick != null)
            {
                OnRowDoubleClick(billno);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListFrm_Load(object sender, EventArgs e)
        {
            GetData();
        }
    }

    public class DGVColumn
    {
        public DGVColumn(string cname, string dname)
            : this(cname, dname, DataGridViewAutoSizeColumnMode.AllCells)
        {

        }

        public DGVColumn(string cname, string dname, DataGridViewAutoSizeColumnMode mode)
        {
            ColName = cname;
            DataPropertyName = dname;
            AutoSizeMode = mode;
        }

        public string ColName { get; set; }
        public string DataPropertyName { get; set; }
        public DataGridViewAutoSizeColumnMode AutoSizeMode { get; set; }

    }
}
