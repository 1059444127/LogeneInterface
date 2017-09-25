using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LGI.Core
{
    public static class Factory
    {
        /// <summary>
        /// 获得LgInterface接口实体,如果不传入医院名称,默认取sz.ini-savetohis里面的hisName
        /// </summary>
        /// <param name="hisName"></param>
        /// <returns></returns>
        public static IGetApplicationFormThirdParty GetLgInterfaceInstanceByHisName(string hisName="")
        {
            //todo:实现工厂方法
            return ((IGetApplicationFormThirdParty) new object());
        }
    }
}
