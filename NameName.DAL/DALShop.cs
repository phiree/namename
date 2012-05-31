﻿using System;
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
            string sql = " select u from ShopInfo u where DeleteFlag=false";
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
            ShopInfo shop = user.Shop;
            IList<UserInfo> managers = shop.ShopUsers.Where(x => x.IsShopManager).ToList();
            foreach (UserInfo manager in managers)
            {
                if (manager.UserName == userName)
                {
                    manager.IsShopManager = !manager.IsShopManager;

                }
                else
                {
                    manager.IsShopManager = false;
                }
            }
            Save(shop);
        }
    }
}
