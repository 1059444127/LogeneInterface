using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

[Guid("637A5736-FE03-4F91-ADB4-A543D6BF44C5")]
[ComVisible(true)]
public interface ILGIAdpter
{
    [DispId(0)]
    string LGGetHISINFO(string sHISName, string Sslbx, string Ssbz, string Debug, string by);
}

namespace LGI.Net20Adpter
{
    [Guid("354C231E-AF0B-48A9-8F4A-C3610BBD5ECA")]
    [ComVisible(true)]
    public class LGIAdpter:ILGIAdpter
    {
        public string LGGetHISINFO(string sHISName, string Sslbx, string Ssbz, string Debug, string @by)
        {
            return "";
        }
    }
}
