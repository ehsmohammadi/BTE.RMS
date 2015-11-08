using System;
using System.Collections.Generic;

namespace BTE.Core
{
    public static class ServiceLocator
    {
        public static IServiceLocator Current { get; private set; }

        public static void SetLocatorProvider(Func<IServiceLocator> createLocatorFunc)
        {
            ServiceLocator.Current = createLocatorFunc();
        }
    }

    public interface IServiceLocator : IServiceProvider
    {
        object GetInstance(Type serviceType);

        object GetInstance(Type serviceType, string key);

        IEnumerable<object> GetAllInstances(Type serviceType);

        TService GetInstance<TService>();

        TService GetInstance<TService>(string key);

        IEnumerable<TService> GetAllInstances<TService>();

        bool IsRegistered<TService>();

        bool IsRegistered(Type serviceType);

        void Release(object instance);
    }
}
