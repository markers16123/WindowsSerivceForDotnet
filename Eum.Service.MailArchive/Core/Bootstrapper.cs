using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using log4net;
using System;
using System.Reflection;

namespace Eum.Service.MailArchive.Core
{
    public class Bootstrapper: IContainerResolvable
    {
        private ILog _log;

        public Bootstrapper()
        {
            _log = this.Logger("WindowsService");
        }

        internal static void Bootstrap()
        {
            new Bootstrapper().ConfigureContainer();
        }

        /// <summary>
        /// Configures the container.
        /// </summary>
        private void ConfigureContainer()
        {
            _log.Info("ConfigureContainer ( )");

            //
            // Container를 구성합니다.

            var builder = new ContainerBuilder();
            RegisterModule(builder);
            var container = builder.Build();

            //
            // ServiceLocator를 구성합니다.

            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));

            //
            // Unhandled Exception Handler

            UnhandledExceptionHandler.Register();
        }

        /// <summary>
        /// Registers the module.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private void RegisterModule(ContainerBuilder builder)
        {
            _log.Info("RegisterModule ( builder )");

            //
            // Service Module

            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
        }
    }
}
