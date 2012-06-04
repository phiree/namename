using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NameName.Model;
namespace NameName.Model.Mapping
{
    public class Sys_FormatSerialNoMap : ClassMap<Sys_FormatSerialNo>
    {
        public Sys_FormatSerialNoMap()
        {
            Id(x => x.FormatId);

            Map(x => x.Day);

            Map(x => x.Flag);
            Map(x => x.Month);
            Map(x => x.Year);
            Map(x => x.Value);



        }
    }
}
