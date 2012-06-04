using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NameName.Model;
using NHibernate;
namespace NameName.DAL
{
    public class DALProInfo : DALBase<ProInfo>
    {
        public ProPrice GetPrice(Guid proid, Guid areaid)
        {
            string sql = " select a from ProPrice a where a.ProInfo.ProID='" + proid + "' and a.AreaInfo.AreaID='" + areaid + "'";
            IQuery query = session.CreateQuery(sql);
            ProPrice proprice = query.FutureValue<ProPrice>().Value;

            return proprice;

        }

        public void SavePrice(Guid proid, Guid areaid, decimal? price)
        {
            if (price == null)
            {
                string sql = " Delete from ProPrice a where a.ProInfo.ProID='" + proid + "' and a.AreaInfo.AreaID='" + areaid + "'";
                session.CreateQuery(sql).ExecuteUpdate();

            }
            else
            {
                ProPrice cprice = GetPrice(proid, areaid);
                if (cprice == null)
                {
                    //insert
                    cprice = new ProPrice();
                    cprice.ProInfo = GetByProID(proid);
                    cprice.AreaInfo = new DALArea().GetByAreaID(areaid);
                    cprice.Price = price.Value;
                }
                else
                {
                    //update
                    if (price == cprice.Price)
                    {
                        return;
                    }
                    else
                    {
                        cprice.Price = price.Value;
                    }
                }

                session.Save(cprice);
                session.Flush();
            }
        }

        public IList<ProInfo> GetProsByLastUpDateTime(DateTime lastupdate)
        {
            return QueryFutureList(" select a from ProInfo a where a.DeleteFlag=false and a.LastUpDateTime > '" + lastupdate + "'");
        }


        public IList<string> GetProCatesByAreaID(Guid areaid)
        {
            string sql = "Select distinct a.ProCate from ProInfo a,ProPrice b where a.DeleteFlag=false and a.ProID = b.ProInfo.ProID And b.AreaInfo.AreaID='" + areaid.ToString() + "' order by a.ProCate ";
            IQuery query = session.CreateQuery(sql);
            IList<string> procates = query.Future<string>().ToList();
            return procates;
        }

        public IList<ProInfo> GetProsByAreaID(Guid areaid)
        {
            return QueryFutureList(" select a from ProInfo a,ProPrice b where a.DeleteFlag=false and a.ProID = b.ProInfo.ProID And b.AreaInfo.AreaID='" + areaid.ToString() + "' order by a.LastUpDateTime desc ");
        }

        public IList<ProInfo> GetPros()
        {
            return QueryFutureList(" select a from ProInfo a where a.DeleteFlag=false order by a.LastUpDateTime desc ");
        }
        public IList<ProInfo> GetProsPaged(string proName ,string cate, int pageIndex, int pageSize, out int totalRecord)
        {
            string strCondition = string.Empty;
            if (!string.IsNullOrEmpty(cate))
            {
                strCondition += " and  s.ProCate='" + cate + "'";
            }
            if (!string.IsNullOrEmpty(proName))
            {
                strCondition += "  and  s.Name like '%" + proName + "%'";
            }
            string strQuery = "select s from ProInfo s where 1=1 ";
            string strQueryCount = "select count(*) from ProInfo s where 1=1 ";

            if (!string.IsNullOrWhiteSpace(strCondition))
            {
                strQuery += strCondition;
                strQueryCount += strCondition;
            }
            IQuery qryTotal = session.CreateQuery(strQueryCount);
            IQuery qry = session.CreateQuery(strQuery);
            List<ProInfo> scenicList = qry.Future<ProInfo>().Skip(pageIndex * pageSize).Take(pageSize).ToList();
            totalRecord =(int) qryTotal.FutureValue<long>().Value;
            return scenicList;
        }

        public Guid Save(ProInfo proinfo)
        {
            proinfo.LastUpDateTime = DateTime.Now;

            if (proinfo.ProID == null || proinfo.ProID == Guid.Empty)
            {
                proinfo.ProID = Guid.NewGuid();
                session.Save(proinfo);
                // Reposi.Add(proinfo);
            }
            else
            {

                session.Update(proinfo);
                // Reposi.Update(proinfo);
            }
            session.Flush();
            return proinfo.ProID; ;
        }

        public ProInfo GetByProID(Guid proid)
        {
            return session.Get<ProInfo>(proid);
            // return Reposi.Single<ProInfo>(proid);
        }

        public void Delete(Guid proid)
        {
            ProInfo Pro = GetByProID(proid);
            Pro.DeleteFlag = true;
            Save(Pro);
        }

        public IList<string> GetProCates()
        {
            string sql = "Select distinct a.ProCate From ProInfo a Where a.DeleteFlag = false";
            IQuery query = session.CreateQuery(sql);
            IList<string> procates = query.Future<string>().ToList();
            return procates;
        }
    }
}
