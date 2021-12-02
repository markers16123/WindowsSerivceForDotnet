using Autofac;

namespace Eum.Service.MailArchive.Modules.StreamNoti
{
    public class StreamNotiModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //
            // Core

            builder.RegisterType<StreamNotiConfig>()
                .SingleInstance()
                .AsSelf();

            builder.RegisterType<MailArchiveAgent>()
                .As<IMailArchiveAgent>()
                .SingleInstance()
                .AsSelf();

            base.Load(builder);
        }
    }
}