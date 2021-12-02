using Eum.Service.MailArchive.Core;
using Eum.Service.MailArchive.Modules.StreamNoti;
using log4net;
using System;
using System.ServiceProcess;

namespace Eum.Service.MailArchive
{
    public partial class WindowsService : ServiceBase, IContainerResolvable
    {
        private ILog _log;

        public WindowsService()
        {
            InitializeComponent();
            _log = this.Logger("WindowsService");
        }

        /// <summary>
        /// 서비스를 콘솔 모드로 실행합니다.
        /// </summary>
        internal void RunAsConsole(string[] args)
        {
            this.OnStart(args);
            ConsoleKeyInfo key;
            do
            {
                Console.WriteLine("Press [x] key to stop...");
                key = Console.ReadKey(true);
            } while (key.Key != ConsoleKey.X);
            this.OnStop();
        }
         
        protected override void OnStart(string[] args)
        {
            _log.Info("======================================================================");
            _log.Info("OnStart ( args )");

            try
            {
                Bootstrapper.Bootstrap();
                this.GetInstance<IMailArchiveAgent>().Start();
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }
        }

        protected override void OnStop()
        {
            _log.Info("OnStop ( )");
            try
            {
                this.GetInstance<IMailArchiveAgent>().Stop();
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
        }
    }
}
