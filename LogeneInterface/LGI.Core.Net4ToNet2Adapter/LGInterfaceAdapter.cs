using System.Runtime.InteropServices;
using LGI.Core.Model;

namespace LGI.Core.Net4ToNet2Adapter
{
    [ComVisible(true)]
    [Guid("A6574755-925A-4E41-A01B-B6A0EEF72DF0")]
    public class MyClassAdapter : ILGInterfaceAdapter
    {
        public string LGGetHISINFO(GetHisInfo info)
        {
            IGetApplicationFormThirdParty _myClass = Factory.GetLgInterfaceInstanceByHisName();
            return _myClass.GetApplicationFormThirdParty(info);
        }
    }
}
