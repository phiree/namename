using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NameName.Model;
using NHibernate;
namespace NameName.DAL
{
    public class DALUser : DALBase
    {
        /// <summary>
        /// 获得某个部门没有分配的人员
        /// </summary>
        /// <param name="departid"></param>
        /// <returns></returns>
        public IList<UserInfo> GetUsersByDepartAndNotAssign(Guid departid)
        {
            string sql=@"select u 
                        from UserInfo u 
                        where u.Depart.DepartId='"+departid.ToString()+"' and u.Shop=null";

            IQuery query = session.CreateQuery(sql);
            IList<UserInfo> users = query.Future<UserInfo>().ToList();
            return users;
        }

        public IList<UserInfo> GetUsers()
        {
            string sql = " select u from UserInfo u ";
            IQuery query = session.CreateQuery(sql);
            IList<UserInfo> users = query.Future<UserInfo>().ToList();
            return users;
        }

        public void Save(UserInfo user)
        {
            UserInfo u = GetByUserName(user.UserName);
            if (u == null)
            {
                u.Pwd = "1111";
                session.Save(user);
                //  Reposi.Add(user);
            }
            else
            {
                if (!user.IsShopUser)
                {
                    user.IsShopManager = false;
                    user.Shop = null;
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
            user.Shop = null;
            Save(user);
        }
    }
}
