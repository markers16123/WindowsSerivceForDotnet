using Eum.Service.MailArchive.Core;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

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
            _log.Info("-------------------------------------------------------------------------------");
            _log.Info("OnStart ( args )");

            try
            {
                Bootstrapper.Bootstrap();

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
                //var scheduler = this.GetInstance<FullSyncScheduler>();
                //scheduler.Stop();

                //var context = this.GetInstance<SubscriptionManager>();
                //context.UnSubscribe();

                //var manager = this.GetInstance<ApprovalManager>();
                //manager.Close();
            }
            catch (Exception ex)
            {
                _log.Equals(ex);
            }
        }
    }
}
