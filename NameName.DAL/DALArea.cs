using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NameName.Model;

namespace NameName.DAL
{
    public class DALArea : DALBase
    {
        public IList<AreaInfo> GetAreas()
        {
            IList<AreaInfo> areas = Reposi.Find<AreaInfo>(x => x.DeleteFlag == false).OrderBy(x => x.OrderNO).ToList();

            return areas;
        }

        public void Save(AreaInfo areainfo)
        {
            if (areainfo.AreaID == null || areainfo.AreaID == Guid.Empty)
            {
                areainfo.AreaID = Guid.NewGuid();
                Reposi.Add(areainfo);
            }
            else
            {
                Reposi.Update(areainfo);
            }
        }
        public AreaInfo GetByAreaID(Guid areaid)
        {
            return Reposi.Single<AreaInfo>(areaid);
        }

        public void Delete(Guid areaid)
        {
            AreaInfo Area = GetByAreaID(areaid);
            Area.DeleteFlag = true;
            Save(Area);
        }
    }
}
