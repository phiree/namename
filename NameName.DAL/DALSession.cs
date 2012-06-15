using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
namespace NameName.DAL
{
  public  class DALSession
    {
        public ISession session = new HybridSessionBuilder().GetSession();
    }
}
