using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace BTE.Presentation.Web
{
    public class WebApiExceptionAdapter
    {
        public static HttpResponseMessage ConverToHttpResponse(HttpActionExecutedContext context)
        {

            var exception = context.Exception;
            var error = new HttpError(exception,true);
            //var dic = ExceptionConvertorService.Convert(exception);
            //foreach (var item in dic)
            //{
            //    error.Add(item.Key, item.Value);
            //}
            return context.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, error);
        }

        //private static void logException(Exception exp)
        //{
        //    User user;
        //    var securityService = SecurityServiceFacadeFactory.Create();
        //    try
        //    {
        //        user = securityService.GetLogonUser();
        //    }
        //    finally
        //    {
        //        SecurityServiceFacadeFactory.Release(securityService);
        //    }

        //    var logServicelc = LogServiceFactory.Create();
        //    try
        //    {
        //        var logService = logServicelc.GetService();
        //        string code = "ServiceHost_HandleExp";
        //        string title = exp.Message;
        //        string messages = ExceptionHelper.GetExceptionTextInfo(exp, true);
        //        logService.AddExceptionLog(code, LogLevel.Error, user, "", "", title, messages);
        //    }
        //    finally
        //    {
        //        LogServiceFactory.Release(logServicelc);
        //    }

        //}
    }
}
