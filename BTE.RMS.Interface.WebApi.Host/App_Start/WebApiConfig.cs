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
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
               name: "MeetingFiles",
               routeTemplate: "api/Meetings/{MeetingId}/Files/{id}",
               defaults: new { Controller = "MeetingFiles", id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
               name: "MeetingHistories",
               routeTemplate: "api/Meetings/{MeetingId}/Histories/{id}",
               defaults: new { Controller = "MeetingHistories", id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
               name: "MeetingStateOperations",
               routeTemplate: "api/Meetings/{meetingId}/StateOperations/{meetingOperation}",
               defaults: new { Controller = "MeetingStateOperations" });

            config.Routes.MapHttpRoute(
              name: "MeetingStateOperationsByApp",
              routeTemplate: "api/AppTypes/{appType}/Meetings/{syncId}/StateOperations/{meetingOperation}",
              defaults: new { Controller = "MeetingStateOperations" });
            config.Filters.Add(new ApplicationExceptionFilterAttribute());

            //var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            //jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            HttpConfig = config;
        }

        public static HttpConfiguration HttpConfig { get; private set; }
    }
}
