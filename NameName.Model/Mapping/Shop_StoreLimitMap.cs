using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NameName.Model;
namespace NameName.Model.Mapping
{
    public class Shop_StoreLimitMap:ClassMap<Shop_StoreLimit>
    {
        public Shop_StoreLimitMap()
        {
            Id(x => x.Id);
            Map(x =>x.MaxLimit);
            Map(x => x.MinLimit);
            References<ShopInfo>(x => x.ShopInfo);
            References<ProInfo>(x => x.ProInfo);
          
           
            
        }
    }
}
