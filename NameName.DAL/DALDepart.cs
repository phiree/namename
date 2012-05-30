using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NameName.Model;
using NHibernate;
namespace NameName.DAL
{
    public class DALDepart : DALBase
    {
        public IList<DepartInfo> GetDeparts()
        {

            string sql = " select d from DepartInfo d where d.DeleteFlag=false order by d.OrderNO";
            IQuery query = session.CreateQuery(sql);
            IList<DepartInfo> departs = query.Future<DepartInfo>().ToList();


            return departs;
        }

        public void Save(DepartInfo depart)
        {
            if (depart.DepartID == null || depart.DepartID == Guid.Empty)
            {
                depart.DepartID = Guid.NewGuid();
                session.Save(depart);
               // Reposi.Add(depart);
            }
            else
            {
                session.Update(depart);
            //    Reposi.Update(depart);
            }
        }
        public DepartInfo GetById(Guid departid)
        {
            return session.Get<DepartInfo>(departid);
            //return Reposi.Single<DepartInfo>(departid);
        }

        public bool Delete(Guid departid)
        {
            DepartInfo depart = GetById(departid);
            if (depart.DepartUsers.Count > 0) return false;
            depart.DeleteFlag = true;
            Save(depart);
            return true;
        }
    }
}
