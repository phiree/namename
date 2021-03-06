﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NameName.DAL;
using NameName.Model;
namespace testnamename
{
    [TestFixture]
  public  class ProInfotest
    {
        [Test]
      public void TestGetProsByAreaID()
      {
          DALBase<object> dal = new DALBase<object>();
         IList<object> objects= dal.QueryFutureList(" select a from ProInfo a where a.DeleteFlag=false and a.LastUpDateTime > '" + DateTime.Now.AddDays(-10)+"'");
         Console.WriteLine(objects.Count);
         Assert.IsTrue(objects.Count > 0);
         IList<object> objects2 = dal.QueryFutureList(" select a from ProInfo a where a.DeleteFlag=false and a.LastUpDateTime > '" + DateTime.Now.AddDays(10) + "'");
         Console.WriteLine(objects2.Count);
         Assert.IsTrue(objects2.Count == 0);
     
            string qry=@" select a from ProInfo a,ProPrice b 
where a.DeleteFlag=false and a.ProID = b.ProID And b.AreaInfo.AreaID='"
                +Guid.NewGuid().ToString() +
                "' order by a.LastUpDateTime desc ";
            objects = dal.QueryFutureList(qry);
            Assert.IsTrue(objects.Count == 0);
       
      }
    }
}
