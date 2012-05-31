using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
namespace NameName.Model.Mapping
{
   public class ProPriceMap:ClassMap<ProPrice>
    {
       public ProPriceMap()
       {
           Id(x => x.Id);
           Map(x => x.Price);
           References<ProInfo> (x => x.ProInfo);
           References<AreaInfo>(x => x.AreaInfo);
       }

    }
}
