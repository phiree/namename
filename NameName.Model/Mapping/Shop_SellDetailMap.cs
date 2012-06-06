using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NameName.Model;
namespace NameName.Model.Mapping
{
    public class Shop_SellDetailMap : ClassMap<Shop_SellDetail>
    {
        public Shop_SellDetailMap()
        {
            Id(x => x.ID);
            
            Map(x => x.Amount);
            Map(x => x.BillNO);
            Map(x => x.Price);
            References<ProInfo>(x => x.Pro).Column("ProInfo_Id");
           

          

        }
    }
}
