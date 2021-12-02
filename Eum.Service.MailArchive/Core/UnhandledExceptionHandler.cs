using log4net;
using System;

namespace Eum.Service.MailArchive.Core
{
    public class UnhandledExceptionHandler
    {
        private static ILog _logger;

        public static void Register()
        {
            _logger = ContainerResolver.Logger("UnhandledException");
            var appDomain = AppDomain.CurrentDomain;
            appDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            _logger.Fatal($"CurrentDomain_UnhandledException - {e.ExceptionObject}");
            _logger.Fatal($"CurrentDomain_UnhandledException - IsTerminating: {e.IsTerminating}");

            if (e.IsTerminating == false)
            {
            }
        }
    }
}
