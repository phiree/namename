using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NameName.Model;
using NHibernate;

namespace NameName.DAL
{

    public class DALUnity : DALSession
    {

        public void ExcuteStoredProcedure(string procedureName)
        {
            ExcuteStoredProcedure(procedureName, new string[] { });
        }

        public void ExcuteStoredProcedure(string procedureName, string[] paramValues)
        {
            string sql = string.Format("exec {0}", procedureName);

            foreach (string value in paramValues)
            {
                sql += " '" + value + "',";
            }
            sql = sql.TrimEnd(',');

            int i = session.CreateSQLQuery(sql).ExecuteUpdate();
            session.Flush();
        }
    }
}