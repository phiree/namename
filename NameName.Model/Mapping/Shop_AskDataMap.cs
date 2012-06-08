using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NameName.Model;
namespace NameName.Model.Mapping
{
    public class Shop_AskDataMap : ClassMap<Shop_AskData>
    {
        public Shop_AskDataMap()
        {
            Id(x => x.ID);
            Map(x => x.Qty);
            References<ProInfo>(x => x.ProInfo);
            References<ShopInfo>(x => x.ShopInfo);
        }
    }
}
