using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NameName.Model;
using NHibernate;
namespace NameName.DAL
{
    public class DALShopStore : DALBase<Shop_Store>
    {
        //按照ShopID返回当前的库存信息
        public IList<Shop_Store> GetShopStoreByShopID(Guid shopid)
        {
            string sql = " select a from Shop_Store a where a.ShopInfo.ShopID = '" + shopid + "'";
            return QueryFutureList(sql);
        }
    }
}
