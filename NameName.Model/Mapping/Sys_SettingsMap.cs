using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NameName.Model;
namespace NameName.Model.Mapping
{
    public class Sys_SettingsMap : ClassMap<Sys_Settings>
    {
        public Sys_SettingsMap()
        {
            Id(x => x.Name);
            Map(x => x.Value);
        }
    }
}
