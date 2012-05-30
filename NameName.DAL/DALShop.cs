using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NameName.Model;
using NHibernate;
namespace NameName.DAL
{
    public class DALShopInfo : DALBase
    {
        public IList<ShopInfo> GetShops()
        {
            string sql = " select u from ShopInfo u ";
            IQuery query = session.CreateQuery(sql);
            IList<ShopInfo> shops = query.Future<ShopInfo>().ToList();
          
            return shops;
        }



        public void Save(ShopInfo shopinfo)
        {
            if (shopinfo.ShopID == Guid.Empty)
            {
                shopinfo.ShopID = Guid.NewGuid();
                session.Save(shopinfo);
                //Reposi.Add(shopinfo);
            }
            else
            {
                session.Update(shopinfo);
                //Reposi.Update(shopinfo);
            }
        }
        public ShopInfo GetByShopID(Guid shopid)
        {
            return session.Get<ShopInfo>(shopid);
            //return Reposi.Single<ShopInfo>(shopid);
        }

        public void Delete(Guid shopid)
        {
            ShopInfo shopinfo = GetByShopID(shopid);
            shopinfo.DeleteFlag = true;
            Save(shopinfo);
        }


    }
}
