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
    public partial class InputQty : Form
    {
        public InputQty()
        {
            InitializeComponent();
        }

        public decimal GetInputValue()
        {
            if (this.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                decimal v = 0;
                decimal.TryParse(numInupt1.InputValue, out v);
                return v;
            }
            else
            {
                return 0;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

        }
    }
}
