using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NameName.Model;
namespace NameName.Model.Mapping
{
    public class Shop_SellListMap : ClassMap<Shop_SellList>
    {
        public Shop_SellListMap()
        {
            Id(x => x.BillNO);

            Map(x => x.ActAmount);
            Map(x => x.BackBillNo);
            Map(x => x.BackFlag);
            Map(x => x.BillAmount);

            Map(x => x.BillDate);
            References<Shop_DutyInfo>(x => x.Duty);
            Map(x => x.Memo);
            Map(x => x.ActCustomAmount);
            HasMany<Shop_SellDetail>(x => x.Details).Cascade.All().Inverse();

        }
    }
}
