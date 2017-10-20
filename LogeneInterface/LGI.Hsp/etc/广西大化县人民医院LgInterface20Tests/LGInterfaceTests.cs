using Microsoft.VisualStudio.TestTools.UnitTesting;
using LGInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LGI.Hsp.广西大化县人民医院;

namespace LGInterface.Tests
{
    [TestClass()]
    public class LGInterfaceTests
    {
        [TestMethod()]
        public void LGInterfaceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void IniZlInterfaceTest()
        {
            LGInterface tt = new LGInterface();
            tt.IniZlInterface();
            var xml = tt.LGGetHISINFO("", "住院", "201700013", "1", "1");
        }

        [TestMethod()]
        public void LGGetHISINFOTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetValueTest()
        {
            Assert.Fail();
        }
    }
}