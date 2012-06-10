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
        public IList<Shop_Store> GetList(string strshopid, string keyWord, int pageIndex, int pageSize)
        {
           IList<Shop_Store> stores = new List<Shop_Store>();
            Guid shopId = new Guid(strshopid);
            string nql = "";
            if (shopId == Guid.Empty)
            {
                nql = @"select a.ProInfo,sum(a.CurrQty) as CurrQty from Shop_Store a
                      group by a.ProInfo";
            }
            else
            {
                nql = @"select a from Shop_Store a
                      where a.ShopInfo.ShopID='"+shopId+"'";
            }
            string where = " 1=1 ";
            if (!string.IsNullOrEmpty(keyWord))
            { 
                where+=" and a.ProInfo.Name like '%"+keyWord+"%'";           
             }

            stores = QueryFutureList(nql);

            return stores;
        }
    }
}
