using LGI.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LGI.CoreTests
{
    [TestClass()]
    public class FactoryTests
    {
        [TestMethod()]
        public void GetLgInterfaceInstanceByHisNameTest()
        {
            var lg = Factory.GetLgInterfaceInstanceByHisName("测试医院");
        }
    }
}