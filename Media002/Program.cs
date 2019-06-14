using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Permissions;

namespace MediaInfo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        //public static event System.Threading.ThreadExceptionEventHandler ThreadException;

        [STAThread]       
        static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);

            logger.Log(LogLevel.Info, "Application started.");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            logger.Log(LogLevel.Info, "MyHandler caught : " + e.Message + " From: " + e.Source);
            logger.Log(LogLevel.Error, "Runtime terminating: {0}", args.IsTerminating);
        }
    }
}
