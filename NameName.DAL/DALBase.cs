using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.Repository;
namespace NameName.DAL
{
   public class DALBase
    {
       public IRepository Reposi = new SimpleRepository("conn", SimpleRepositoryOptions.RunMigrations);
    }
}
