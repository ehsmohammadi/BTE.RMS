using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BTE.RMS.Interface.WebApi.Host
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "SyncApi",
                routeTemplate: "api/Sync/{id}",
                defaults: new {controller = "Task", id = RouteParameter.Optional}
                );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


        }
    }
}
