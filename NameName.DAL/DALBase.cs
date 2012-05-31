using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using SubSonic.Repository;
using NHibernate;
namespace NameName.DAL
{
   public class DALBase<T>
    {
       protected ISession session = new HybridSessionBuilder().GetSession();
       public DALBase()
       {
          // session.FlushMode = FlushMode.Always;
       }
      // public IRepository Reposi = new SimpleRepository("conn", SimpleRepositoryOptions.RunMigrations);

       
    }
}
