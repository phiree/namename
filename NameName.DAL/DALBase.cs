using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.Repository;
using NHibernate;
namespace NameName.DAL
{
    public class DALBase<T>
    {
        protected ISession session = new HybridSessionBuilder().GetSession();

        // public IRepository Reposi = new SimpleRepository("conn", SimpleRepositoryOptions.RunMigrations);

        public DALBase()
        {
            session.FlushMode = FlushMode.Always;
        }
        public T QueryFutureValue(string querystr)
        {

            IQuery query = session.CreateQuery(querystr);
            T t = query.FutureValue<T>().Value;
            return t;
        }
        public IList<T> QueryFutureList(string querystring)
        {
           IQuery query = session.CreateQuery(querystring);
            IList<T> ts = query.Future<T>().ToList();

            return ts;
        }
    }
}
