using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
namespace NameName.Model.Mapping
{
    public class ProInfoMap : ClassMap<ProInfo>
    {
        public ProInfoMap()
        {
            Id(x => x.ProID);
            Map(x => x.DeleteFlag);
            Map(x => x.Name);
            Map(x => x.PicName);
            Map(x => x.ProCate);
            Map(x => x.Unit);
            Map(x => x.LastUpDateTime);
            HasMany<ProPrice>(x => x.ProPrices).Inverse().Not.LazyLoad();


        }
    }
}
