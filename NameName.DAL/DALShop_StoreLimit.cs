using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NameName.Model;
using NHibernate;
namespace NameName.DAL
{
    public class DALShop_StoreLimit : DALBase<Shop_StoreLimit>
    {
        public void Save(Shop_StoreLimit limit)
        {

            Shop_StoreLimit existlimit = Get(limit.ShopInfo.ShopID, limit.ProInfo.ProID);
            if (existlimit == null)
            {
                session.Save(limit);
            }
            else
            {
                session.Update(existlimit);
            }

          
            session.Flush();
        }

        //public Shop_AskList GetListWithNotConfirm(ShopInfo shopinfo)
        //{
        //    string sql = " select a from Shop_AskList a where a.ShopInfo.ShopID='" + shopinfo.ShopID.ToString() + "' and a.State = 0";
        //    IQuery query = session.CreateQuery(sql);
        //    Shop_AskList shopasklist = query.FutureValue<Shop_AskList>().Value;
        //    return shopasklist;
        //}
        public Shop_StoreLimit Get(Guid ShopId,Guid ProId)
        {

            return QueryFutureValue(string.Format(@"select s from Shop_StoreLimit s where s.ShopInfo.ShopID='{0}' 

                        and s.ProInfo.ProID='{1}'",ShopId,ProId));
        }

    }
}