using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NameName.DAL;
namespace testnamename
{
    [TestFixture]
  public  class CommonFuncTest
    {
        [Test]
        public void GetUserTimeTest()
        {
            
         DateTime dt=   new CommonFunctions().GetServerTime();
         Console.Write(dt.ToString());
        }
    }
}
