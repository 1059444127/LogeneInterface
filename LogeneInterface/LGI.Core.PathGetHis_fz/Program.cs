using System;
using System.Windows.Forms;
using LGI.Core;
using LGI.Core.Model;
using LGI.Core.Utils;
using Maticsoft.DAL;

namespace PathGetHis_fz
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Send(args);
        }

        public static void Send(string[] args)
        {
            Logger.Debug("接口exe被调用,入参:" + args[0]);

            IniFiles f = new IniFiles("sz.ini");
            var blh = "";
            var bglx = ""; //cg/bd/bc
            var reportNumber = "";
            var czlb = ""; //new/old
            var dz = ""; //save/qxsh/dy/qxdy
            EditType editType;
            PisAction pisAction;
            string hospName;
            ReportType reportType;

            #region 处理入参

            //处理入参
            try
            {
                string[] aa = args[0].Split('^');
                blh = aa[0];
                bglx = aa[1].ToLower(); //cg/bd/bc
                reportNumber = aa[2];
                czlb = aa[3].ToLower(); //new/old
                dz = aa[4].ToLower(); //save/qxsh/dy/qxdy

                reportType = ReportType.常规报告;
                switch (bglx)
                {
                    case "cg":
                    default:
                        reportType = ReportType.常规报告;
                        break;
                    case "bd":
                        reportType = ReportType.冰冻报告;
                        break;
                    case "bc":
                        reportType = ReportType.补充报告;
                        break;
                }
                editType = czlb == "new" ? EditType.新建 : EditType.修改;
                switch (dz)
                {
                    case "save":
                        if (editType == EditType.新建)
                        {
                            pisAction = PisAction.新登记;
                        }
                        else
                        {
                            pisAction = PisAction.保存;
                        }
                        break;
                    case "qxsh":
                        pisAction = PisAction.取消审核;
                        break;
                    case "dy":
                        pisAction = PisAction.打印;
                        break;
                    case "qxdy":
                        pisAction = PisAction.取消打印;
                        break;
                    default:
                        pisAction = PisAction.未知;
                        break;
                }

                hospName = f.ReadString("savetohis", "yymc", "123").Replace("\0", "");
            }
            catch (Exception e)
            {
                Logger.Error("传入参数解析出错:" + e);
                MessageBox.Show("回传EXE入参错误:" + e);
                return;
            }

            #endregion

            Logger.Debug("EXE接口查询jcxx,病理号:" + blh);
            T_JCXX jcxx = T_JCXX_DAL.GetModel(blh);

            Logger.Debug("尝试获取接口实例,医院名称:" + hospName);
            var sender = Factory.GetSendToThirdPartyByHisName(hospName);

            Logger.Info($"开始调用EXE接口,病理号:{blh},操作类型:{pisAction}");
            switch (pisAction)
            {
                case PisAction.新登记:
                    sender.OnAddReport(jcxx, reportType);
                    break;
                case PisAction.保存:
                    if (jcxx.F_BGZT == "已审核")
                    {
                        sender.OnCheckReport(jcxx, reportType);
                    }
                    else
                    {
                        sender.OnSaveReport(jcxx, reportType);
                    }
                    break;
                case PisAction.取消审核:
                    sender.OnCancelCheckReport(jcxx, reportType);
                    break;
                case PisAction.打印:
                    sender.OnPrintReport(jcxx, reportType);
                    break;
                case PisAction.取消打印:
                    sender.OnCancelPrintReport(jcxx, reportType);
                    break;
                default:
                    throw new Exception("接口调用失败,无法解析PIS给的入参.");
            }
        }
    }
}