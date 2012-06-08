using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NameName.Model;
namespace NameName.Model.Mapping
{
    public class Shop_AccountSumMap : ClassMap<Shop_AccountSum>
    {
        public Shop_AccountSumMap()
        {
            Id(x => x.Id);
            Map(x => x.ChkQty);
            Map(x => x.CurrQty);
            Map(x => x.ExpQty);
            Map(x => x.ImpQty);
            Map(x => x.PreQty);
            References<ProInfo>(x => x.ProInfo);
            References<ShopInfo>(x => x.ShopInfo);
            References<Account_Period>(x => x.Account_Period);
        }
    }
}
