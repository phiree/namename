using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NameName.Model;
using NHibernate;

namespace NameName.DAL
{
    public class DALUser : DALBase<UserInfo>
    {
        /// <summary>
        /// 获得某个部门没有分配的人员
        /// </summary>
        /// <param name="departid"></param>
        /// <returns></returns>
        public IList<UserInfo> GetUsersByDepartAndNotAssign(Guid departid)
        {            
            string sql = @"select u 
                        from UserInfo u 
                        where u.DepartInfo.DepartID='" + departid.ToString() + "' and u.ShopInfo = null and u.IsShopUser = true and u.DeleteFlag=false";

       
            return QueryFutureList(sql);
        }

        public IList<UserInfo> GetUsers()
        {
            string sql = " select u from UserInfo u ";
          
            return QueryFutureList(sql);
        }

        public void Save(UserInfo user)
        {
            UserInfo u = GetByUserName(user.UserName);
            if (u == null)
            {
                user.Pwd = "1111";
                session.Save(user);
                //  Reposi.Add(user);
            }
            else
            {
                if (!user.IsShopUser)
                {
                    user.IsShopManager = false;
                    user.ShopInfo = null;
                }
                session.Update(user);
                // Reposi.Update(user);
            }
            session.Flush();
        }

        public UserInfo GetByUserName(string username)
        {
            return session.Get<UserInfo>(username);
            //  return Reposi.Single<UserInfo>(x => x.UserName == username && x.DeleteFlag == false);
        }

        public void Delete(string username)
        {
            UserInfo user = GetByUserName(username);
            user.DeleteFlag = true;
            Save(user);
        }

        public void InitPwd(string username)
        {
            UserInfo user = GetByUserName(username);
            user.Pwd = "1111";
            Save(user);
        }

        public void RemoveUserFromShop(string username)
        {
            UserInfo user = GetByUserName(username);            
            user.ShopInfo = null;
            user.IsShopManager = false;
            Save(user);
        }
        public bool ValidateUser(string userName, string pwd)
        {
           
            UserInfo user = QueryFutureValue(string.Format(@"select u
                from UserInfo u
                where u.UserName='{0}' and Pwd='{1}'"
                , userName
                , pwd));
            return user != null;
        }
        public IList<UserInfo> GetAllUserNoAssigned(Guid departid)
        {
            string sql = @"select u 
                        from UserInfo u 
                        where u.DepartInfo.DepartID='" + departid.ToString() + "' and u.AreaInfo = null and u.DeleteFlag=false ";

            IList<UserInfo> purUsers = QueryFutureList(sql);

            return QueryFutureList(sql);
        }

        public void RemoveUserFromArea(string username)
        {
            UserInfo user = GetByUserName(username);
            user.AreaInfo = null;
           
            Save(user);
        }
    }
}
