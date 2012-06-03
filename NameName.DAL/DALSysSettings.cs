using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NameName.Model;

namespace NameName.DAL
{
    public class DALSysSettings : DALBase<Sys_Settings>
    {
        public void Save(Sys_Settings syssettings)
        {
            if (session.Get<Sys_Settings>(syssettings.Name) == null)
            {
                session.Save(syssettings);
            }
            else
            {
                session.Update(syssettings);
            }

        }

        public Sys_Settings GetValue(string settingName)
        {
            return session.Get<Sys_Settings>(settingName);
        }
    }
}
