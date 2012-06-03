using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NameName.DAL;
using NameName.Model;
using NHibernate;
namespace NameName.DAL
{
    public class DALDuty : DALBase
    {
        /// <summary>
        /// 商店的当班人员
        /// 没有则返回nulll
        /// </summary>
        /// <param name="shopId"></param>
        public UserInfo GetDutyUser(ShopInfo shop)
        {
            IQuery qry = session.CreateQuery(
               string.Format(@"select u from Shop_DutyInfo u where u.Shop.ShopID='{0}'"
               , shop.ShopID)
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
        public ShopInfo GetDutyShop(UserInfo user)
        {
            IQuery qry = session.CreateQuery(
                  string.Format(@"select u from Shop_DutyInfo u where u.User.UserName='{0}'"
                  , user.UserName)
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
        public Shop_DutyInfo OnDuty(UserInfo user, ShopInfo shop, Account_Period currentPeriod, bool isDuty, out string errMsg)
        {
            errMsg = string.Empty;


            IQuery qry = session.CreateQuery(
                 string.Format(@"select u from Shop_DutyInfo u where u.User.UserName='{0}'
                                and u.Shop.ShopID='{1}' and u.EndDate=null "
                 , user.UserName, shop.ShopID)
                 );
            Shop_DutyInfo duty = qry.FutureValue<Shop_DutyInfo>().Value;

            if (duty != null)
            {
                return duty;
            }
            else
            {
                ShopInfo currentDutyShop = GetDutyShop(user);
                if (currentDutyShop != null)
                {
                    errMsg = string.Format("当前用户正在门店'{0}'当班", currentDutyShop.ShopName);
                }
                else
                {
                    UserInfo currentDutyUser = GetDutyUser(shop);
                    if (currentDutyUser != null)
                    {
                        errMsg = string.Format("当前门店已有当班人员:'{0}'", currentDutyUser.TrueName);
                    }
                    else
                    {
                        if (isDuty)
                        {
                            Shop_DutyInfo dutynew = new Shop_DutyInfo();
                            dutynew.AccountPeriod = currentPeriod;
                            dutynew.ActAmount = 0;
                            dutynew.BackAmount = 0;
                            dutynew.BackCount = 0;
                            dutynew.BeginDate = DateTime.Now;
                            dutynew.BillAmount = 0;
                            dutynew.BillCount = 0;
                            dutynew.EndDate = null;
                            dutynew.Shop = shop;
                            dutynew.User = user;

                            session.Save(dutynew);
                            session.Flush();
                            return dutynew;
                        }
                    }
                }
                return null;
            }
        }
    }
}
