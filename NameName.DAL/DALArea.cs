using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NameName.Model;

namespace NameName.DAL
{
    public class DALArea:DALBase
    {
        public void AddArea(string areaName)
        {
            AreaInfo area = new AreaInfo();
            area.AreaID = Guid.NewGuid();
            area.AreaName = areaName;
            area.DeleteFlag = false;
            Reposi.Add<AreaInfo>(area);
        }
    }
}
