using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LGI.Core.Model;

namespace LGI.Core
{
    /// <summary>
    /// PIS保存报告时调用,根据保存后的报告向第三方上报信息,如报告状态,报告结果,危急值等.
    /// </summary>
    public interface ISendToThirdParty
    {
        /// <summary>
        /// PIS系统登记申请单时触发该方法
        /// </summary>
        /// <param name="jcxx"></param>
        /// <param name="reportType"></param>
        void OnAddReport(T_JCXX jcxx,ReportType reportType);

        /// <summary>
        /// PIS修改申请单时触发
        /// </summary>
        /// <param name="jcxx"></param>
        /// <param name="reportType"></param>
        void OnEditReport(T_JCXX jcxx, ReportType reportType);

        /// <summary>
        /// PIS保存报告时触发
        /// </summary>
        /// <param name="jcxx"></param>
        /// <param name="reportType"></param>
        void OnSaveReport(T_JCXX jcxx, ReportType reportType);

        /// <summary>
        /// PIS审核报告时触发
        /// </summary>
        /// <param name="jcxx"></param>
        /// <param name="reportType"></param>
        void OnCheckReport(T_JCXX jcxx, ReportType reportType);

        /// <summary>
        /// PIS取消审核报告时触发
        /// </summary>
        /// <param name="jcxx"></param>
        /// <param name="reportType"></param>
        void OnCancelCheckReport(T_JCXX jcxx, ReportType reportType);

        /// <summary>
        /// PIS打印报告时触发
        /// </summary>
        /// <param name="jcxx"></param>
        /// <param name="reportType"></param>
        void OnPrintReport(T_JCXX jcxx, ReportType reportType);

        /// <summary>
        /// PIS取消打印报告时触发
        /// </summary>
        /// <param name="jcxx"></param>
        /// <param name="reportType"></param>
        void OnCancelPrintReport(T_JCXX jcxx, ReportType reportType);

        //void OnDelayReport();
    }
}
