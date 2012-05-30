using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.Repository;
using NHibernate;
namespace NameName.DAL
{
   public class DALBase
    {
       protected ISession session = new HybridSessionBuilder().GetSession();
      // public IRepository Reposi = new SimpleRepository("conn", SimpleRepositoryOptions.RunMigrations);
    }
}
