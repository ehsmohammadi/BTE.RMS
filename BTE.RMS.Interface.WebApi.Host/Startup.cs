using System.Web.Http;
using AngularJSAuthentication.API;
using BTE.RMS.Interface.WebApi.Host;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace AngularJSAuthentication.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var boostrapper = new Bootstrapper();
            boostrapper.Execute();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            app.UseWebApi(WebApiConfig.Config);

        }

    }
}
