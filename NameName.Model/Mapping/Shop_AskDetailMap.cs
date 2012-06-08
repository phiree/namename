using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NameName.Model;
namespace NameName.Model.Mapping
{
    public class Shop_AskDetailMap : ClassMap<Shop_AskDetail>
    {
        public Shop_AskDetailMap()
        {
                Id(x => x.ID);
             Map(x => x.Qty);
             References<ProInfo>(x => x.ProInfo);
           

          

        }
    }
}
