using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NameName.Model;
using NHibernate;
namespace NameName.DAL
{
    public class DALShopAskData : DALBase<Shop_AskData>
    {
        //按照ShopID返回当前的库存信息
        public IList<Shop_AskData> GetAskDataByShopID(Guid shopid)
        {
            string sql = "Delete Shop_AskData a Where a.qty = 0 and a.ShopInfo.ShopID = '" + shopid + "'";
            IQuery qry = session.CreateQuery(sql);
            qry.ExecuteUpdate();
            session.Flush();

            sql = " select a from Shop_AskData a where a.ShopInfo.ShopID = '" + shopid + "'";
            return QueryFutureList(sql);
        }

        public void Delete(Shop_AskData sa)
        {
            session.Delete(sa);
            session.Flush();
        }
    }
}
