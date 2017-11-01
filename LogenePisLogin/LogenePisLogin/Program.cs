using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LogenePisLogin
{
    static class Program
    {
        /// <summary>
        /// 通过快捷方式传参,指定启动的exe
        /// </summary>
        public static string ExeName = "PATHNetRPT";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
                ExeName = args[0];
            ExeName = ExeName.ToLower().Replace(".exe", "");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
