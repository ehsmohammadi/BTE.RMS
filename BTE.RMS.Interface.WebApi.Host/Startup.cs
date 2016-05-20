using System.Web.Http;
using BTE.RMS.Interface.WebApi.Host;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace BTE.RMS.Interface.WebApi.Host
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var boostrapper = new Bootstrapper();
            boostrapper.Execute();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            app.UseWebApi(WebApiConfig.HttpConfig);
        }

    }
}
