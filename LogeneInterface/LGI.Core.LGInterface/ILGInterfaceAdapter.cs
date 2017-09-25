using System;
using System.IO.IsolatedStorage;
using System.Runtime.InteropServices;

namespace LGInterface
{
    /// <summary>
    /// 让2.0能调用4.0dll
    /// </summary>
    [ComVisible(true)]
    [Guid("E36BBF07-591E-4959-97AE-D439CBA392FB")]
    public interface ILGInterfaceAdapter
    {
        string LGGetHISINFO(GetHisInfo info);
    }

    public class LGInterface
    {
        public string LGGetHISINFO(string sHISName, string Sslbx, string Ssbz, string Debug, string by)
        {
            Type myClassAdapterType = Type.GetTypeFromProgID("Net4ToNet2Adapter.MyClassAdapter");
            object classAdapterInstance = Activator.CreateInstance(myClassAdapterType);
            ILGInterfaceAdapter lgInterfaceAdapter = (ILGInterfaceAdapter)classAdapterInstance;

            var info = new GetHisInfo();
            info.SHisName = sHISName;
            info.Sslbx = Sslbx;
            info.Ssbz = Ssbz;
            info.Debug = Debug=="1";
            info.By = by;
            string xml = lgInterfaceAdapter.LGGetHISINFO(info);

            return xml;
        }
    }
}
