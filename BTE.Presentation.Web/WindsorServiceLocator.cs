using System;
using System.Collections.Generic;
using System.Linq;
using BTE.Core;
using Castle.Windsor;

namespace BTE.Presentation.Web
{
    /// <summary>
    /// Adapts the behavior of the Windsor container to the common
    /// IServiceLocator
    /// </summary>
    public class WindsorServiceLocator : IServiceLocator
    {
        private readonly IWindsorContainer container;

        /// <summary>
        /// Initializes a new instance of the <see cref="WindsorServiceLocator"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public WindsorServiceLocator(IWindsorContainer container)
        {
            this.container = container;
        }

        ///// <summary>
        /////             When implemented by inheriting classes, this method will do the actual work of resolving
        /////             the requested service instance.
        ///// </summary>
        ///// <param name="serviceType">Type of instance requested.</param>
        ///// <param name="key">Name of registered service you want. May be null.</param>
        ///// <returns>
        ///// The requested service instance.
        ///// </returns>
        //protected override object DoGetInstance(Type serviceType, string key)
        //{
        //    if (container.Kernel.GetAssignableHandlers(serviceType).Any())
        //    {
        //        if (key != null)
        //            return container.Resolve(key, serviceType);
        //        return container.Resolve(serviceType);
        //    }
        //    return null;
        //}

        ///// <summary>
        /////             When implemented by inheriting classes, this method will do the actual work of
        /////             resolving all the requested service instances.
        ///// </summary>
        ///// <param name="serviceType">Type of service requested.</param>
        ///// <returns>
        ///// Sequence of service instance objects.
        ///// </returns>
        //protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        //{
        //    return (object[])container.ResolveAll(serviceType);
        //}
        public object GetService(Type serviceType)
        {
            return container.Resolve(serviceType);
        }

        public object GetInstance(Type serviceType)
        {
            return container.Resolve(serviceType);
        }

        public object GetInstance(Type serviceType, string key)
        {
            if (key != null)
                return container.Resolve(key, serviceType);
            return container.Resolve(serviceType);
        }

        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return (object[])container.ResolveAll(serviceType);
        }

        public TService GetInstance<TService>()
        {
            return container.Resolve<TService>();
        }

        public TService GetInstance<TService>(string key)
        {
            if (key != null)
                return container.Resolve<TService>(key);
            return container.Resolve<TService>();
        }

        public IEnumerable<TService> GetAllInstances<TService>()
        {
            return container.ResolveAll<TService>();
        }

        public bool IsRegistered<TService>()
        {
            return container.Kernel.GetAssignableHandlers(typeof(TService)).Any();
        }

        public bool IsRegistered(Type serviceType)
        {
            return container.Kernel.GetAssignableHandlers(serviceType).Any();
        }
        public void Release(object instance)
        {
            container.Release(instance);
        }
    }
}
