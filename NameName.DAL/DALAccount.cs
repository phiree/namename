using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NameName.Model;

namespace NameName.DAL
{
    public class DALAccount : DALBase
    {
        public Account_Period GetCurrAccount()
        {
         var query = from v in Reposi.All<Account_Period>()
            where v.EndDate == null
            select v;
         var ps = query.ToList();
         
           if (ps.Count == 0) return null;
           else
           {
               return ps[0];
           }
            
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
            Reposi.Add(ap);
        }

        public IList<Account_Period> GetAccounts()
        {
            IList<Account_Period> Accounts = Reposi.All<Account_Period>().OrderByDescending(x => x.BeginDate).ToList();
            return Accounts;
        }
    }
}
