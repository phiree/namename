﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NameName.Model;
using NHibernate;
namespace NameName.DAL
{
    public class DALProInfo : DALBase
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

        public IList<ProInfo> GetPros()
        {
            string sql = " select a from ProInfo a where a.DeleteFlag=false order by a.LastUpDateTime desc ";
            IQuery query = session.CreateQuery(sql);
            IList<ProInfo> pros = query.Future<ProInfo>().ToList();

            return pros;
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