using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Web.Mvc;
using BTE.Core;
using BTE.Presentation.Web;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace BTE.RMS.Presentation.Web
{
    public class Bootstrapper : IBootStrapper
    {
        public static DateTime SelectedDate;
        public void Execute()
        {
            var container = new WindsorContainer().Install(FromAssembly.This());

            var locator = new WindsorServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => locator);

            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
            ModelBinders.Binders.DefaultBinder = new CastleWindsorModelBiner();
        }
    }


    
}
