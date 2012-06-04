using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NameName.Model;
namespace NameName.Model.Mapping
{
    public class DepartInfoMap : ClassMap<DepartInfo>
    {
        public DepartInfoMap()
        {
            Id(x => x.DepartID);
            Map(x => x.DeleteFlag);
            Map(x => x.OrderNO);
            Map(x => x.DepartName);
            HasMany<UserInfo>(x => x.DepartUsers).Cascade.All().Inverse() ;

        }
    }
}
