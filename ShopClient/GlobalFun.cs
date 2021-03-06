﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NameName.Model;
using System.Windows.Forms;
using NameName.DAL;

namespace ShopClient
{
    public class GlobalFun
    {
        public static void MessageBoxError(string ErrorStr)
        {
            MessageBox.Show(ErrorStr, "么么 门店系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void MessageBoxHint(string HintStr)
        {
            MessageBox.Show(HintStr, "么么 门店系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void LoadProCate(IList<string> Cates, TabControl tc)
        {
            tc.TabPages.Clear();
            foreach (string s in Cates)
            {
                TabPage tp = new TabPage();
                tp.Tag = 0;
                tp.Text = s;
                tc.TabPages.Add(tp);
            }
        }
    }
}
