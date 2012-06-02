using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NameName.Model;
using System.Windows.Forms;

namespace ShopClient
{
    public class GlobalFun
    {
        public static void MessageBoxError(string ErrorStr)
        {
            MessageBox.Show(ErrorStr, "么么 门店系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
