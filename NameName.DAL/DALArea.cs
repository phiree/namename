using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NameName.Model;
using NHibernate;
namespace NameName.DAL
{
    public class DALArea : DALBase
    {
        public IList<AreaInfo> GetAreas()
        {
            string sql = " select a from AreaInfo a where a.DeleteFlag=false OrderBy ORderNO ";
            IQuery query = session.CreateQuery(sql);
            IList<AreaInfo> areas = query.Future<AreaInfo>().ToList();
           
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
        }
        public AreaInfo GetByAreaID(Guid areaid)
        {
           return session.Get<AreaInfo>(areaid);
           // return Reposi.Single<AreaInfo>(areaid);
        }

        public void Delete(Guid areaid)
        {
            AreaInfo Area = GetByAreaID(areaid);
            Area.DeleteFlag = true;
            Save(Area);
        }
    }
}
