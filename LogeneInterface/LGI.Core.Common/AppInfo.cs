
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LGI.Core.Model;
using LGI.Core.Utils;

namespace LGI.Core.Common
{
    public static class AppInfo
    {
        private static T_YH _currentUser=null;

        public static T_YH CurrentUser
        {
            get
            {
                if (_currentUser == null)
                {
                    var db = ContextPool.GetContext();
                    var sz = new IniFiles("sz.ini");
                    var yhbh = sz.ReadString("yh","yhbm","");
                    _currentUser = (from o in db.T_YH where o.F_YHBH == yhbh select o).SingleOrDefault();
                }

                return _currentUser;
            }
        }
    }
}
