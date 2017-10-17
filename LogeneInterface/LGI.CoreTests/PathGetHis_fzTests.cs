using Microsoft.VisualStudio.TestTools.UnitTesting;
using PathGetHis_fz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using LGI.Core.Model;

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

        [TestMethod]
        public void EfTest()
        {
            PathnetEntities db = ContextPool.GetContext();
            var lst = (from  o in db.T_JCXX
                       orderby  o.F_BLH
                       select o).Skip(10).Take(5).ToList();
            Assert.AreEqual(lst.Count,5);
        }
    }
}