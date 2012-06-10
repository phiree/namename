using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NameName.Model;
using NHibernate;
namespace NameName.DAL
{
    public class DALShop_AccountDetail : DALBase<Shop_AccountDetail>
    {
        //按照ShopID返回当前的库存信息
        public IList<Shop_AccountDetail> GetAccountDetail(Guid proId)
        {
            return QueryFutureList("select a from Shop_AccountDetail a where a.ProInfo.ProID='"+proId+"'");
        }

        public void Delete(Shop_AskData sa)
        {
            session.Delete(sa);
            session.Flush();
        }
    }
}
