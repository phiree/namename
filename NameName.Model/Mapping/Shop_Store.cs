using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NameName.Model;
namespace NameName.Model.Mapping
{
    public class Shop_StoreMap: ClassMap<Shop_Store>
    {
        public Shop_StoreMap()
        {
            Id(x => x.Id);

            References<Account_Period>(x => x.Account_Period);
            References<ProInfo>(x => x.ProInfo);
            References<ShopInfo>(x=>x.ShopInfo);
            Map(x => x.ChkQty);
            Map(x => x.CurrQty);
            Map(x => x.ExpQty);
            Map(x => x.ImpQty);
            Map(x => x.PreQty);
        }
    }
}
