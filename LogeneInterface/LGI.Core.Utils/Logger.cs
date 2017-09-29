using System;
using System.IO;

namespace LGI.Core.Utils
{
    public static class Logger
    {
        private static void WriteMyLog(string message, LogLevel logLevel = LogLevel.一般)
        {
            var logLevelSetting = LogLevel.一般;
            try
            {
                //判断日志级别
                IniFiles inifile = new IniFiles("sz_log.ini");
                var strLoglevel = inifile.ReadString("日志", "日志级别", "一般");
                logLevelSetting = (LogLevel) Enum.Parse(typeof (LogLevel), strLoglevel);
            }
            catch (Exception e)
            {
            }

            //判断日志级别,如果程序配置的日志级别小于当前日志级别,则不记录
            if (logLevel > logLevelSetting)
                return;


            string LOG_FOLDER = AppDomain.CurrentDomain.BaseDirectory + "Log";
            try
            {
                //日志文件路径 
                string filePath = LOG_FOLDER + "\\PATHGETHIS-" + DateTime.Now.ToString("yyyyMMdd") + ".log";
                if (!System.IO.Directory.Exists(LOG_FOLDER))
                {
                    Directory.CreateDirectory(LOG_FOLDER);
                }
                if (!File.Exists(filePath)) //如果文件不存在 
                {
                    File.Create(filePath).Close();
                }
                StreamWriter sw = File.AppendText(filePath);
                sw.WriteLine("-------------------------------------------------------------------------------------");
                sw.WriteLine("日志级别:" + logLevel);
                sw.WriteLine("Date:" + DateTime.Now.ToShortDateString() + " Time:" + DateTime.Now.ToString("HH:mm:ss"));
                sw.WriteLine(message);
                //sw.WriteLine(ex.StackTrace);
                sw.WriteLine();
                sw.Close();
            }
            catch
            {
            }
        }

        public static string readlog()
        {
            string LOG_FOLDER = AppDomain.CurrentDomain.BaseDirectory + "Log";
            string hl7log = "";
            try
            {
                //日志文件路径 
                string filePath = LOG_FOLDER + "\\" + DateTime.Now.ToShortDateString() + ".log";
                if (!System.IO.Directory.Exists(LOG_FOLDER))
                {
                    Directory.CreateDirectory(LOG_FOLDER);
                }
                if (!File.Exists(filePath)) //如果文件不存在 
                {
                    File.Create(filePath).Close();
                }
                hl7log = File.ReadAllText(filePath);
                return hl7log;
            }
            catch
            {
                return "";
            }
        }

        public static void clearlog()
        {
            string LOG_FOLDER = AppDomain.CurrentDomain.BaseDirectory + "Log";
            //string hl7log = "";
            try
            {
                //日志文件路径 
                string filePath = LOG_FOLDER + "\\" + DateTime.Now.ToShortDateString() + ".log";
                if (!System.IO.Directory.Exists(LOG_FOLDER))
                {
                    Directory.CreateDirectory(LOG_FOLDER);
                }
                if (!File.Exists(filePath)) //如果文件不存在 
                {
                    File.Create(filePath).Close();
                }
                File.WriteAllText(filePath, "");
            }
            catch
            {
            }
        }

        public static void Debug(string message)
        {
            WriteMyLog(message, LogLevel.调试信息);
        }

        public static void Info(string message)
        {
            WriteMyLog(message, LogLevel.一般);
        }

        public static void Error(string message)
        {
            WriteMyLog(message, LogLevel.异常);
        }


        public enum LogLevel
        {
            调试信息 = 9,
            一般 = 3,
            异常 = 0
        }
    }
}