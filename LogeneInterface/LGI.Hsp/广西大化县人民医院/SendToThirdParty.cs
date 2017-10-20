using System;
using LGI.Core;
using LGI.Core.Model;
using LGI.Core.Utils;
using zlPacsInterface;

namespace LGI.Hsp.广西大化县人民医院
{
    public class SendToThirdParty : ISendToThirdParty
    {
        private clsPacsInterface zlInterface;

        public SendToThirdParty()
        {
            int lngDepartmentId = 0; //病理科1597
            string strServerName = @"orcl";
            string strUserName = "pacsuser";
            string strUserPwd = "aqa";
            string strNullValue = "";
            int SysNo = 100;
            string SysOwner = "yhis";
            string SplitChar = "|";

            //初始化
            zlInterface = new clsPacsInterface();

            var iniSuccess = zlInterface.InitInterface(lngDepartmentId, strServerName, strUserName, strUserPwd, SysNo,
                SysOwner,
                strNullValue, SplitChar, TErrorShowType.estShowMsg);
            if (iniSuccess == false)
                throw new Exception("中联接口初始化失败:"+zlInterface.GetLastError());
        }

        #region Implementation of ISendToThirdParty

        /// <summary>
        /// PIS系统登记申请单时触发该方法
        /// </summary>
        /// <param name="jcxx"></param>
        /// <param name="reportType">常规,冰冻,补充</param>
        public void OnAddReport(T_JCXX jcxx, ReportType reportType)
        {
            ReceiveReport(jcxx);
        }

        /// <summary>
        /// PIS修改申请单时触发
        /// </summary>
        /// <param name="jcxx"></param>
        /// <param name="reportType">常规,冰冻,补充</param>
        public void OnEditReport(T_JCXX jcxx, ReportType reportType)
        {
//            throw new NotImplementedException();
        }

        /// <summary>
        /// PIS保存报告时触发
        /// </summary>
        /// <param name="jcxx"></param>
        /// <param name="reportType">常规,冰冻,补充</param>
        public void OnSaveReport(T_JCXX jcxx, ReportType reportType)
        {
//            throw new NotImplementedException();
        }

        /// <summary>
        /// PIS审核报告时触发
        /// </summary>
        /// <param name="jcxx"></param>
        /// <param name="reportType">常规,冰冻,补充</param>
        public void OnCheckReport(T_JCXX jcxx, ReportType reportType)
        {
            SendReport(jcxx, reportType);
        }

        /// <summary>
        /// PIS取消审核报告时触发
        /// </summary>
        /// <param name="jcxx"></param>
        /// <param name="reportType">常规,冰冻,补充</param>
        public void OnCancelCheckReport(T_JCXX jcxx, ReportType reportType)
        {
            DelReport(jcxx, reportType);
        }

        /// <summary>
        /// PIS打印报告时触发
        /// </summary>
        /// <param name="jcxx"></param>
        /// <param name="reportType">常规,冰冻,补充</param>
        public void OnPrintReport(T_JCXX jcxx, ReportType reportType)
        {
//            throw new NotImplementedException();
        }

        /// <summary>
        /// PIS取消打印报告时触发
        /// </summary>
        /// <param name="jcxx"></param>
        /// <param name="reportType">常规,冰冻,补充</param>
        public void OnCancelPrintReport(T_JCXX jcxx, ReportType reportType)
        {
//            throw new NotImplementedException();
        }

        #endregion

        private void ReceiveReport(T_JCXX jcxx)
        {
            #region 入参 参数名 类型及说明

            //    lngAdviceKey    Long，检查或检验申请单关键值(医嘱id入参必须)
            //
            //    strExeRoom String，执行间(默认空)
            //
            //    lngStudyNo Long，检查号(默认空)
            //
            //    strDevice String，检查设备(默认空)
            //
            //    lngHeight Long，身高(默认空)
            //
            //    lngWeight Long，体重(默认空)
            //
            //    strStudyDoc String，检查技师(默认空)
            //
            //    StrExeDate Date，执行时间(默认空)
            //
            //    strExeDes String，执行说明(默认空)
            //
            //    lngExecOne Long，是否分部位执行申请，0 - 成套执行；1 - 单独执行(默认0)

            #endregion

            int yzId = Convert.ToInt32(jcxx.F_YZID.Trim());
            var success = zlInterface.RecevieRequest(yzId);

            if (!success)
            {
                var lastErr = zlInterface.GetLastError();
                throw new Exception($"向HIS回发报告状态时出现错误[{jcxx.F_BLH}]:" + lastErr);
            }
            Logger.Info("HIS接口确认申请单成功:"+jcxx.F_BLH);
        }

        private void SendReport(T_JCXX jcxx, ReportType reportType)
        {
            #region 入参 参数名 类型及说明

            //         lngAdviceKey Long，医嘱ID
            //         strReportView   报告所见
            //         strReportAdvice 报告建议
            //         strReportDoctor 报告医生
            //         strAuditingDoctor   审核医生

            #endregion

            var success = zlInterface.SendReport(Convert.ToInt32(jcxx.F_YZID.Trim()), jcxx.F_JXSJ, jcxx.F_BLZD,
                jcxx.F_BGYS);

            if (!success)
                throw new Exception($"推送报告到HIS时出错[{jcxx.F_BLH}]:" + zlInterface.GetLastError());

            Logger.Info("HIS接口回传报告成功:" + jcxx.F_BLH);
        }

        private void DelReport(T_JCXX jcxx, ReportType reportType)
        {
            var success = zlInterface.DeleteReport(Convert.ToInt32(jcxx.F_YZID.Trim()));
            if (!success)
                throw new Exception($"删除HIS已审报告时出现错误[{jcxx.F_BLH}]:" + zlInterface.GetLastError());

            Logger.Info("HIS接口删除报告成功:" + jcxx.F_BLH);
        }
    }
}