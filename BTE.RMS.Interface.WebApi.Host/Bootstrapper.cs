using System;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using BTE.Core;
using BTE.Presentation.Web;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace BTE.RMS.Interface.WebApi.Host
{
    public class Bootstrapper : IBootStrapper
    {
        public void Execute()
        {

            var container = new WindsorContainer().Install(FromAssembly.This());

            GlobalConfiguration.Configuration.Services.Replace(
                typeof (IHttpControllerActivator),
                new WindsorControllerActivator(container.Kernel));

            var locator = new WindsorServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => locator);

        }
    }



}
