using Microsoft.VisualStudio.TestTools.UnitTesting;
using 广西大化县人民医院;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 广西大化县人民医院.Tests
{
    [TestClass()]
    public class GetAppTests
    {
        [TestMethod()]
        public void GetApplicationFormThirdPartyTest()
        {
            ZlHis.InitInterface(123, "12", "dwqdw", "dqdwdq", 12312, "dwqdwqd", "", "dwqdwq", 123);
        }
    }
}