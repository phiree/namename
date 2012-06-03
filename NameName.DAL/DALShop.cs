using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NameName.Model;
using NHibernate;
namespace NameName.DAL
{
    public class DALShopInfo : DALBase<ShopInfo>
    {
        public IList<ShopInfo> GetShops()
        {
           
            return QueryFutureList(" select u from ShopInfo u where DeleteFlag=false");
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
            session.Flush();
        }

        public ShopInfo GetByShopID(Guid shopid)
        {
            return session.Get<ShopInfo>(shopid);
            //return Reposi.Single<ShopInfo>(shopid);
        }

        public bool Delete(Guid shopid)
        {
            ShopInfo shopinfo = GetByShopID(shopid);
            if (shopinfo.ShopUsers.Where(x => x.DeleteFlag == false).Count() > 0) return false;
            shopinfo.DeleteFlag = true;
            Save(shopinfo);
            return true;
        }
        public void SetManager(string userName)
        {
            DALUser dalUser = new DALUser();
            UserInfo user = dalUser.GetByUserName(userName);

            if (user.IsShopManager)
            {
                user.IsShopManager = false;
                dalUser.Save(user);
            }
            else
            {
                string sql = @"update UserInfo u set u.IsShopManager = false
                    where u.ShopInfo.ShopID='" + user.ShopInfo.ShopID + "'";
                IQuery query = session.CreateQuery(sql);
                query.ExecuteUpdate();

                user.IsShopManager = true;
                dalUser.Save(user);
            }
        }
    }
}
