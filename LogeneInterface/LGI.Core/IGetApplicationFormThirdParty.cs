using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using LGI.Core.Model;

namespace LGI.Core
{
    /// <summary>
    /// PIS点提取时调用,从第三方获取申请单信息接口
    /// </summary>
    public interface IGetApplicationFormThirdParty
    {
        /// <summary>
        /// 从第三方获取申请单信息
        /// </summary>
        /// <returns>PIS申请单xml</returns>
        string GetApplicationFormThirdParty(GetHisInfo info);
    }
}