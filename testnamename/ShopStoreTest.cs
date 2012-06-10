using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NameName.DAL;
using NameName.Model;
using Rhino.Mocks;
namespace testnamename
{
    [TestFixture]
  public  class ShopStoreTest
    {
        [Test]
      public void TestGetList()
      {
        
            
          Assert.AreEqual(0, new DALShopStore().GetList(Guid.NewGuid().ToString(), "", 1, 2).Count);
       
      }

        
    }
}
