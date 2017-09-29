using Microsoft.VisualStudio.TestTools.UnitTesting;
using PathGetHis_fz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PathGetHis_fz.Tests
{
    [TestClass()]
    public class PathGetHis_fzTests
    {
        [TestMethod()]
        public void SendTest()
        {
            string[] args = new[] { "201700003^cg^1^old^save" };
            Program.Send(args);
        }
    }
}