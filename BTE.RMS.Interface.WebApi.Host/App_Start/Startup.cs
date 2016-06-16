using System;
using System.Web.Http;
using BTE.RMS.Interface.WebApi.Host;
using BTE.RMS.Interface.WebApi.Host.SecurityProvider;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace BTE.RMS.Interface.WebApi.Host
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use<GlobalExceptionMiddlewareHandler>();
            ConfigureOAuth(app);
            var boostrapper = new Bootstrapper();
            boostrapper.Execute();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            app.UseWebApi(WebApiConfig.HttpConfig);
     
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            var oAuthServerOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new AuthorizationServerProvider()
            };

            // Token Generation
            //app.u
            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }

    }
}
