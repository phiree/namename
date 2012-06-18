using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NameName.Model;
using NHibernate;
namespace NameName.DAL
{
    public class DALArea : DALBase<AreaInfo>
    {
        public IList<AreaInfo> GetAreas()
        {
            string sql = " select a from AreaInfo a where a.DeleteFlag=false order by OrderNO ";
            IList<AreaInfo> areas = QueryFutureList(sql);
            return areas;
        }

        public void Save(AreaInfo areainfo)
        {
            if (areainfo.AreaID == null || areainfo.AreaID == Guid.Empty)
            {
                areainfo.AreaID = Guid.NewGuid();
                session.Save(areainfo);
              // Reposi.Add(areainfo);
            }
            else
            {
                session.Update(areainfo);
               // Reposi.Update(areainfo);
            }
            session.Flush();
        }

        public AreaInfo GetByAreaID(Guid areaid)
        {
           return session.Get<AreaInfo>(areaid);
           // return Reposi.Single<AreaInfo>(areaid);
        }

        public bool Delete(Guid areaid)
        {
            AreaInfo Area = GetByAreaID(areaid);
            if (Area.AreaShops.Where(x=>x.DeleteFlag==false).Count() > 0) return false;
            Area.DeleteFlag = true;
            Save(Area);
            return true;
        }
       
    }
}
