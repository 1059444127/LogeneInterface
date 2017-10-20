using Microsoft.VisualStudio.TestTools.UnitTesting;
using LGI.Hsp.广西大化县人民医院;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PathHisJk_fz;

namespace LGI.Hsp.广西大化县人民医院.Tests
{
    [TestClass()]
    public class SendToThirdPartyTests
    {
        [TestMethod()]
        public void IniZlInterfaceTest()
        {
            //201700003
            SendToThirdParty tt = new SendToThirdParty();
        }

        [TestMethod()]
        public void SendTest()
        {
            string[] args = new[] { "201700013^cg^1^old^save" };
            Program.Send(args);
        }
    }
}