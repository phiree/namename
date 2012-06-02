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
       public static Cash cashFrm = null;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           cashFrm = new Cash();
            Application.Run(cashFrm);
        }
        /// <summary>
        /// 之前是否已经选择过.
        /// 是:读取配置信息 直接打开登录界面
        /// 否:打开选择页面
        /// </summary>
        //private static void InitClient()
        //{
        //    bool HasSelected = false;
        //    string strShopId = Properties.Settings.Default.ShopId;
        //    Application.Run(new ShopSelect());
        //    return;
        //    if (string.IsNullOrEmpty(strShopId))
        //    {
        //        HasSelected = false;

        //    }
        //    else
        //    {

        //        Guid shopId;
        //        Guid.TryParse(strShopId, out shopId);
        //        if (shopId != Guid.Empty)
        //        {
        //            ShopInfo shop = new DALShopInfo().GetByShopID(shopId);
        //            if (shop == null)
        //            {
        //                HasSelected = false;
        //            }
        //            else
        //            {
        //                HasSelected = true;
        //                GlobalValue.ShopID = shop.ShopID;
        //                Application.Run(new Login());
        //            }
        //        }
        //        else
        //        {
        //            HasSelected = false;
        //        }
        //    }
        //    if (!HasSelected)
        //    {
        //        Application.Run(new ShopSelect());

        //    }

        //}
    }
}
