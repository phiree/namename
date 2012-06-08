using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NameName.Model;
namespace NameName.Model.Mapping
{
    public class Shop_AskListMap : ClassMap<Shop_AskList>
    {
        public Shop_AskListMap()
        {
            Id(x => x.AskBillNo);
            Map(x => x.AppDate);
            Map(x => x.CrtDate);
            Map(x => x.State);
            References<ShopInfo>(x => x.ShopInfo);
            References<UserInfo>(x => x.UserInfo);
            HasMany<Shop_AskDetail>(x => x.Details).KeyColumn("AskBillNo").Cascade.All().Inverse();

        }
    }
}
