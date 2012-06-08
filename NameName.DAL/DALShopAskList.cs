using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NameName.Model;
using NHibernate;
namespace NameName.DAL
{
    public class DALShopAskList : DALBase<Shop_AskList>
    {
        public void SaveList(Shop_AskList currentList)
        {
            session.Save(currentList);
            session.Flush();
        }

        //public Shop_AskList GetListWithNotConfirm(ShopInfo shopinfo)
        //{
        //    string sql = " select a from Shop_AskList a where a.ShopInfo.ShopID='" + shopinfo.ShopID.ToString() + "' and a.State = 0";
        //    IQuery query = session.CreateQuery(sql);
        //    Shop_AskList shopasklist = query.FutureValue<Shop_AskList>().Value;
        //    return shopasklist;
        //}

    }
}