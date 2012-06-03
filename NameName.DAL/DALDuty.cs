using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NameName.DAL;
using NameName.Model;
using NHibernate;
namespace NameName.DAL
{
   public class DALDuty:DALBase
    {
       /// <summary>
       /// 商店的当班人员
       /// 没有则返回nulll
       /// </summary>
       /// <param name="shopId"></param>
       public UserInfo GetDutyUser(Guid shopId)
       {
            IQuery qry = session.CreateQuery(
               string.Format(@"select u from Shop_DutyInfo u where u.Shop.ShopId='{0}'"
               ,shopId)
               );
            Shop_DutyInfo duty = qry.FutureValue<Shop_DutyInfo>().Value;
            if (duty == null) return null;
            UserInfo user = duty.User;
            if (user == null) return null;
            return duty.User;
       
       }
       /// <summary>
       /// 用户正在当班的门店
       /// 没有则返回null
       /// </summary>
       /// <param name="username"></param>
       public ShopInfo GetDutyShop(string username)
       {
           IQuery qry = session.CreateQuery(
                 string.Format(@"select u from Shop_DutyInfo u where u.User.UserName='{0}'"
                 , username)
                 );
           Shop_DutyInfo duty = qry.FutureValue<Shop_DutyInfo>().Value;
           if (duty == null) return null;
           if (duty.Shop == null) return null;
           return duty.Shop;
       }

       /// <summary>
       /// 开始当班
       /// </summary>
       /// <param name="userName"></param>
       /// <param name="shopId"></param>
       /// <returns></returns>
       public bool OnDuty(UserInfo user,ShopInfo shop,Account_Period currentPeriod)
       {
           UserInfo currentDutyUser = GetDutyUser(shop.ShopID);
           ShopInfo currentDutyShop = GetDutyShop(user.UserName);
           if (currentDutyShop == null && currentDutyUser == null)
           {
               Shop_DutyInfo duty = new Shop_DutyInfo();
               duty.AccountPeriod = currentPeriod;
               duty.ActAmount = 0;
               duty.BackAmount = 0;
               duty.BackCount = 0;
               duty.BeginDate = DateTime.Now;
               duty.BillAmount = 0;
               duty.BillCount = 0;
               duty.EndDate = null;
               duty.Shop = shop;
               duty.User = user;

               session.Save(duty);
               session.Flush();
               return true;

           }
           else
           {
               return false;
           }
       }
    }
}
