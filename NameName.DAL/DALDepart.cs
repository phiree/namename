using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NameName.Model;
namespace NameName.DAL
{
    public class DALDepart : DALBase
    {
        public IList<DepartInfo> GetDeparts()
        {
            IList<DepartInfo> Departs = Reposi.Find<DepartInfo>(x => !x.DeleteFlag);

            return Departs;
        }

        public void Save(DepartInfo depart)
        {
            if (depart.DepartID == null)
            {
                depart.DepartID = Guid.NewGuid();
                Reposi.Add(depart);
            }
            else
            {
                Reposi.Update(depart);
            }
        }
        public DepartInfo GetById(Guid departid)
        {
            return Reposi.Single<DepartInfo>(departid);
        }

        public void Delete(Guid departid)
        {
            DepartInfo depart = GetById(departid);
            depart.DeleteFlag = true;
            Save(depart);
        }


    }
}
