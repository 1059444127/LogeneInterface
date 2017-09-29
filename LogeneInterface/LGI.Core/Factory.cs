using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
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
        public static IGetApplicationFormThirdParty GetLgInterfaceInstanceByHisName(string hisName = "")
        {
            string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            Assembly assembly = Assembly.LoadFile(path+"\\"+$"LGI.Hsp.{hisName}.dll");

//          if (hospName == "")
//              hospName = IniFiles.GetInstant("sz.ini").ReadString("savetohis", "yymc", "123").Replace("\0", "");

            var types = assembly.GetTypes();
            foreach (Type type in types)
            {
                if (type.GetInterface(nameof(IGetApplicationFormThirdParty)) == null)
                    continue;
                return (IGetApplicationFormThirdParty) assembly.CreateInstance(type.FullName);
            }

            throw new Exception($"实例化提取接口失败,因为没有找到 {hisName} 的接口实现.请联系管理员!");
        }

        public static ISendToThirdParty GetSendToThirdPartyByHisName(string hisName = "")
        {
            string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            Assembly assembly = Assembly.LoadFile(path + "\\" + $"LGI.Hsp.{hisName}.dll");

            var types = assembly.GetTypes();
            foreach (Type type in types)
            {
                if (type.GetInterface(nameof(ISendToThirdParty)) == null)
                    continue;
                return (ISendToThirdParty)assembly.CreateInstance(type.FullName);
            }

            throw new Exception($"返回病理结果失败,因为没有找到 {hisName} 的接口实现.请联系管理员!");
        }
    }
}