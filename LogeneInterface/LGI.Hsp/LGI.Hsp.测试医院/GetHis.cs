using System;
using System.Collections.Generic;
using System.Text;
using LGI.Core;
using LGI.Core.Model;

namespace LGI.Hsp.测试医院
{
    public class GetHis : IGetApplicationFormThirdParty
    {
        public string GetApplicationFormThirdParty()
        { 
            return "调用测试医院接口成功!";
        }
    }
}