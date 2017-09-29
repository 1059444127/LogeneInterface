using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LGI.Core;
using LGI.Core.Model;

namespace LGI.Hsp.测试医院
{
    public class Sender :ISendToThirdParty
    {
        #region Implementation of ISendToThirdParty

        /// <summary>
        /// PIS系统登记申请单时触发该方法
        /// </summary>
        /// <param name="jcxx"></param>
        /// <param name="reportType">常规,冰冻,补充</param>
        public void OnAddReport(T_JCXX jcxx, ReportType reportType)
        {
            Console.WriteLine("OnAddReport:"+jcxx.F_BLH);
        }

        /// <summary>
        /// PIS修改申请单时触发
        /// </summary>
        /// <param name="jcxx"></param>
        /// <param name="reportType">常规,冰冻,补充</param>
        public void OnEditReport(T_JCXX jcxx, ReportType reportType)
        {
            Console.WriteLine("OnEditReport:" + jcxx.F_BLH);

        }

        /// <summary>
        /// PIS保存报告时触发
        /// </summary>
        /// <param name="jcxx"></param>
        /// <param name="reportType">常规,冰冻,补充</param>
        public void OnSaveReport(T_JCXX jcxx, ReportType reportType)
        {
            Console.WriteLine("OnSaveReport:" + jcxx.F_BLH);
        }

        /// <summary>
        /// PIS审核报告时触发
        /// </summary>
        /// <param name="jcxx"></param>
        /// <param name="reportType">常规,冰冻,补充</param>
        public void OnCheckReport(T_JCXX jcxx, ReportType reportType)
        {
            Console.WriteLine("OnCheckReport:" + jcxx.F_BLH);
        }

        /// <summary>
        /// PIS取消审核报告时触发
        /// </summary>
        /// <param name="jcxx"></param>
        /// <param name="reportType">常规,冰冻,补充</param>
        public void OnCancelCheckReport(T_JCXX jcxx, ReportType reportType)
        {
            Console.WriteLine("OnCancelCheckReport:" + jcxx.F_BLH);
        }

        /// <summary>
        /// PIS打印报告时触发
        /// </summary>
        /// <param name="jcxx"></param>
        /// <param name="reportType">常规,冰冻,补充</param>
        public void OnPrintReport(T_JCXX jcxx, ReportType reportType)
        {
            Console.WriteLine("OnPrintReport:" + jcxx.F_BLH);
        }

        /// <summary>
        /// PIS取消打印报告时触发
        /// </summary>
        /// <param name="jcxx"></param>
        /// <param name="reportType">常规,冰冻,补充</param>
        public void OnCancelPrintReport(T_JCXX jcxx, ReportType reportType)
        {
            Console.WriteLine("OnCancelPrintReport:" + jcxx.F_BLH);
        }

        #endregion
    }
}
