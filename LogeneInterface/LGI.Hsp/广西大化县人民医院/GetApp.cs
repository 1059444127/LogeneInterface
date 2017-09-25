using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LGI.Core;
using LGI.Core.Model;

namespace 广西大化县人民医院
{
    public class GetApp: IGetApplicationFormThirdParty
    {
        public string GetApplicationFormThirdParty(GetHisInfo info)
        {
            ZlHis.InitInterface(123, "12", "dwqdw", "dqdwdq", 12312, "dwqdwqd", "", "dwqdwq", 123);
            return "0";
        }
    }
}
