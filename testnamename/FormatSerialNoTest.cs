using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
namespace testnamename
{
    [TestFixture]
 public  class FormatSerialNoTest
    {
        [Test]
        public void testGetSerialNo()
        {
       
           Assert.AreEqual("BI1206050001",
               new NameName.DAL.DALSys_FormatSerialNo().GetSerialNo("BI",true));
           Assert.AreEqual("BI1206050002",
             new NameName.DAL.DALSys_FormatSerialNo().GetSerialNo("BI", true));
           Assert.AreEqual("FG1206050001",
        new NameName.DAL.DALSys_FormatSerialNo().GetSerialNo("FG", true));
        }
    }
}
