using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using BTE.Core;
using BTE.RMS.Interface.WebApi.Host.Controllers;

namespace BTE.RMS.Interface.WebApi.Host
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //var boostrapper = new Bootstrapper();
            //boostrapper.Execute();
            //GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
