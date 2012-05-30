using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NameName.Model;
namespace NameName.Model.Mapping
{
    public class AreaInfoMap:ClassMap<AreaInfo>
    {
        public AreaInfoMap()
        {
            Id(x => x.AreaID);
            Map(x => x.AreaName);
            HasMany<ShopInfo>(x => x.AreaShops);
            Map(x => x.DeleteFlag);
            Map(x => x.OrderNO);
           
            
        }
    }
}
