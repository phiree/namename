using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NameName.Model;
using NHibernate;
namespace NameName.DAL
{
    public class DALShopSellList : DALBase<Shop_SellList>
    {
        public void SaveList(Shop_SellList currentList)
        {
            currentList.BillDate = new CommonFunctions().GetServerTime();
            session.Save(currentList);
            session.Flush();
        }

        public Shop_SellList GetByBillNO(string billno)
        {
            return session.Get<Shop_SellList>(billno);
        }

        public Shop_SellList GetBackBillByNo(string billno)
        {
            string sql = " select a from Shop_SellList a where a.BackBillNo='" + billno + "'";
            
            Shop_SellList ssl = QueryFutureValue(sql);
            
            return ssl;

        }

    }
}