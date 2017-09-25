using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace 广西大化县人民医院
{
    public class ZlHis
    {
        [DllImport("zlPacsInterface.dll")]
        public static extern bool InitInterface(long lngDepartmentId, string strServerName, string strUserName,
            string strUserPwd, long SysNo, string SysOwner, string NullValue, string SplitChar, int errType);
    }
}
