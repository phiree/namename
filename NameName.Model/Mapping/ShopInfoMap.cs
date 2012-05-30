using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NameName.Model;
namespace NameName.Model.Mapping
{
    public class ShopInfoMap:ClassMap<ShopInfo>
    {
        public ShopInfoMap()
        {
            Id(x => x.ShopID);
            References<AreaInfo>(x => x.AreaInfo);
            Map(x => x.DeleteFlag);
            Map(x => x.Fax);
            Map(x => x.IsCenter);
            Map(x => x.ShopName);
            Map(x => x.ShopNo);
            Map(x => x.Tel);
            
            Map(x => x.Address);
            HasMany<UserInfo>(x => x.ShopUsers);
            
        }
    }
}
