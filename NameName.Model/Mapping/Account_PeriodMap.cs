using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NameName.Model;
namespace NameName.Model.Mapping
{
    public class Account_PeriodMap: ClassMap<Account_Period>
    {
        public Account_PeriodMap()
        {
            Id(x => x.AccountID);
            
            Map(x => x.BeginDate);
          
            Map(x => x.EndDate);

        }
    }
}
