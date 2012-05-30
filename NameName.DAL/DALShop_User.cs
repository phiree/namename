using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using NameName.Model;
namespace NameName.DAL
{
    public class DALShop_User : DALBase
    {
        public IList<Shop_User> GetUserByShopID(Guid shopid)
        {
            IList<Shop_User> users = Reposi.Find<Shop_User>(x => x.ShopID == shopid).ToList();

            return users;
        }

        public void Save(Guid shopid, string username)
        {
            Shop_User su = new Shop_User();
            su.ShopID = shopid;
            su.UserName = username;
           // Reposi.Add(su);
        }

        public void Delete(int id)
        {
           
           // Reposi.Delete<Shop_User>(id);
        }
    }
}
