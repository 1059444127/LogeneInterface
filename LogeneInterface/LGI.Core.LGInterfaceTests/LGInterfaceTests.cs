using Microsoft.VisualStudio.TestTools.UnitTesting;
using LGInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGInterface.Tests
{
    [TestClass()]
    public class LGInterfaceTests
    {
        [TestMethod()]
        public void LGGetHISINFOTest()
        {
            LGInterface lgi = new LGInterface();
           lgi.LGGetHISINFO("测试医院", "门诊号", "001", "0", "");
        }
    }
}