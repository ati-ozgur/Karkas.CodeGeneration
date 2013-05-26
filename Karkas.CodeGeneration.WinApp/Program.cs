using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using log4net;

namespace Karkas.CodeGeneration.WinApp
{
    static class Program
    {

        static ILog logger = LogManager.GetLogger(typeof(Program));

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            log4net.Config.XmlConfigurator.Configure();
            logger.Info("Starting Application");


            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += currentDomain_UnhandledException;



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        static void currentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            logger.Error(e);
            if (e.IsTerminating)
            {
                logger.Error("terminate - Atilla");
            }
        }
    }
}
