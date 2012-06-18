using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
namespace NameName.Model.Mapping
{
    public class Pur_ListMap : ClassMap<Pur_List>
    {
        public Pur_ListMap()
        {
            Id(x => x.PurBillNo);
            References<AreaInfo>(x => x.AreaInfo);
            Map(x => x.ChkDate);
            References<UserInfo>(x => x.ChkUser);
            References<UserInfo>(x => x.PurUser);
            Map(x => x.State);
            Map(x => x.CrtDate);
        }
    }
}
