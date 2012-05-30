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
                session.Save(user);
              //  Reposi.Add(user);
            }
            else
            {
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

    }
}
