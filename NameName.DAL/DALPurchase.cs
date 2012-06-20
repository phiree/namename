using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NameName.Model;
using NHibernate;
using NameName.Model.Enums;
namespace NameName.DAL
{
    public class DALPurchase : DALBase<Pur_List>
    {
        public IList<Pur_List> GetList(string strbegin, string strend,PurchaseState state)
        {
            DateTime begin = Convert.ToDateTime(strbegin);
            DateTime end = Convert.ToDateTime(strend);
            string condition = string.Empty;
            condition += "and p.State=" + (int)state;
            if (state != PurchaseState.未审核)
            {
           
                condition += " and p.CrtDate between '{0}' and '{1}'";
            }
            return GetList(condition);


          
        }
        private IList<Pur_List> GetList(string condition)
        {
            string sql = "from Pur_List p where 1=1 "+condition;
            return QueryFutureList(sql);

        }
        public void Create(string userName)
        {
            UserInfo user = new DALUser().GetByUserName(userName);

            Pur_List p = new Pur_List();
            p.AreaInfo = user.AreaInfo;
            p.CrtDate = DateTime.Now;
            p.PurBillNo = new DALSys_FormatSerialNo().GetSerialNo("CG");
            p.PurUser = user;
            p.State =(int) PurchaseState.未审核;
            session.Save(p);
            session.Flush();
        }
    }
}
