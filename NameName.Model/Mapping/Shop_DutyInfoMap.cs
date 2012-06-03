using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NameName.Model;
namespace NameName.Model.Mapping
{
    public class Shop_DutyInfoMap: ClassMap<Shop_DutyInfo>
    {
        public Shop_DutyInfoMap()
        {
            Id(x => x.DutyID);
            References<Account_Period>(x => x.AccountPeriod);
            Map(x => x.ActAmount);
            Map(x => x.BackAmount);
            Map(x => x.BackCount);
            Map(x => x.BeginDate);
            Map(x => x.BillAmount);
            Map(x => x.BillCount);

            Map(x => x.EndDate);
           
            References<UserInfo>(x => x.User);
            References<ShopInfo>(x => x.Shop);
           
           

        }
    }
}
