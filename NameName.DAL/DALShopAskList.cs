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


        public IList<Shop_AskList> GetByDateTime(DateTime begindate, DateTime enddate, Guid shopid)
        {
            string sql = " select a from Shop_AskList a where a.CrtDate between '" + begindate + "' and '" + enddate.AddDays(1) + "' and a.ShopInfo.ShopID = '" + shopid + "'";

            IList<Shop_AskList> sas = QueryFutureList(sql).ToList();

            return sas;
        }

    }
}