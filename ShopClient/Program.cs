using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using NameName.Model;
using NameName.DAL;
namespace ShopClient
{
    static class Program
    {
        public static main mainfrm = null;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainfrm = new main();
            Application.Run(mainfrm);
        }

    }
}
