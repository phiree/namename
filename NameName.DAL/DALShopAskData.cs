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
        //按照ShopID返回当前的要货信息
        public IList<Shop_AskData> GetAskDataByShopID(Guid shopid)
        {
            string sql = "delete Shop_AskData Where Qty = 0 and ShopInfo.ShopID = '" + shopid + "'";
            IQuery qry = session.CreateQuery(sql);
            qry.ExecuteUpdate();
            session.Flush();

            sql = " select a from Shop_AskData a where a.ShopInfo.ShopID = '" + shopid + "'";
            return QueryFutureList(sql);
        }

        public IList<string> AskCates(Guid shopid)
        {
            string sql = "select distinct a.ProInfo.ProCate from Shop_AskData a where a.ShopInfo.ShopID = '" + shopid + "'";
            IQuery qry = session.CreateQuery(sql);
            IList<string> cates = qry.List<string>();

            return cates;
        }


        public void Delete(Shop_AskData sa)
        {
            session.Delete(sa);
            session.Flush();
        }

        public void Save(Shop_AskData sad)
        {
            session.Save(sad);
            session.Flush();
        }
    }
}
