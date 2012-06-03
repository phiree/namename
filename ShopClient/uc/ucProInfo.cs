using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShopClient.uc
{
    public partial class ucProInfo : UserControl
    {
        public decimal Qty { get; set; }
        public bool ShowQty { get; set; }

        public ucProInfo()
        {
            InitializeComponent();
        }
    }
}
