using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NameName.Model;
namespace NameName.DAL
{
    public class DALUser : DALBase
    {
        public IList<UserInfo> GetUserByDepartment(Guid departId)
        {
            IList<UserInfo> users = Reposi.Find<UserInfo>(x => x.DepartID == departId);
            return users;
        }

        public IList<UserInfo> GetUsers()
        {
            IList<UserInfo> users = Reposi.Find<UserInfo>(x => !x.DeleteFlag);
            return users;
        }

        public void Save(UserInfo user)
        {
            UserInfo u = GetByUserName(user.UserName);
            if (u == null)
            {
                Reposi.Add(user);
            }
            else
            {
                Reposi.Update(user);
            }
        }
        public UserInfo GetByUserName(string username)
        {
            return Reposi.Single<UserInfo>(x => x.UserName == username && x.DeleteFlag == false);
        }

        public void Delete(string username)
        {
            UserInfo user = GetByUserName(username);
            user.DeleteFlag = true;
            Save(user);
        }

    }
}
