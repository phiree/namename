using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NameName.DAL;
using NameName.Model;
namespace testnamename
{
    [TestFixture]
    public class DalUnityTest
    {
        [Test]
        public void ExecuteSP()
        {
            new DALUnity().ExcuteStoredProcedure("dbo.update_UserPassword_to_1234");
            Assert.AreEqual(new DALUser().GetUsers()[0].Pwd, "1234");

        }
    }
}
