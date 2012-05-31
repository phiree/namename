using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NameName.Model;
using NHibernate;
namespace NameName.DAL
{
    public class DALAccount : DALBase
    {
        public Account_Period GetCurrAccount()
        {
            string sql = " select d from Account_Period d where d.EndDate is null";
            IQuery query = session.CreateQuery(sql);
            Account_Period acc = query.FutureValue<Account_Period>().Value;
            return acc;

        }

        public void AccountInit()
        {
            Account_Period ap = GetCurrAccount();
            if (ap == null)
            {
                Add();
            }
        }

        public void Add()
        {
            Account_Period ap = new Account_Period();
            ap.AccountID = Guid.NewGuid();
            ap.BeginDate = DateTime.Now;
            ap.EndDate = null;
            session.Save(ap);
          
            //  Reposi.Add(ap);
        }

        public IList<Account_Period> GetAccounts()
        {
            string sql = " select d from Account_Period  OrderBy BeginDate ";
            IQuery query = session.CreateQuery(sql);
            IList<Account_Period> acc = query.Future<Account_Period>().ToList();
            return acc;
        }
    }
}
