using CommonServiceLocator;
using log4net;
using System;

namespace Eum.Service.MailArchive.Core
{
    public interface IContainerResolvable { }

    public static class ContainerResolver
    {
        public static bool Impl<T>(this IContainerResolvable obj)
        {
            try { return obj.GetInstance<T>() != null; }
            catch (Exception ex) { obj.Logger("IOC").Error(ex.Message); }
            return false;
        }

        public static T GetInstance<T>(this IContainerResolvable obj)
        {
            return GetInstance<T>();
        }

        public static T GetInstance<T>(this IContainerResolvable obj, string key)
        {
            return GetInstance<T>(key);
        }

        public static ILog Logger(this IContainerResolvable obj, string name, bool unique = false)
        {
            return Logger(name, unique);
        }

        public static ILog Logger(string name, bool unique = false)
        {
            return unique ?
                LogManager.GetLogger($"{name}") :
                LogManager.GetLogger($"{name}:{Contract.InstanceIdentity}");
        }

        #region ServiceContainer Wrapper Methods
        static IServiceLocator Container => ServiceLocator.Current;

        public static T GetInstance<T>()
        {
            return Container.GetInstance<T>();
        }

        public static T GetInstance<T>(string key)
        {
            return Container.GetInstance<T>(key);
        }
        #endregion // ServiceContainer Wrapper Methods
    }
}
