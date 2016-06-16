using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using BTE.Core;
using Microsoft.Owin;

namespace BTE.Presentation.Web
{
    public static class WebApiExceptionAdapter
    {
        public static HttpResponseMessage ConverToHttpResponse(HttpActionExecutedContext context)
        {

            var exception = context.Exception;
            var error = new HttpError();
            var dic = ExceptionConvertorService.Convert(exception);
            foreach (var item in dic)
            {
                error.Add(item.Key, item.Value);
            }
            return context.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, error);
        }

        public static void ConverToHttpResponse(Exception exp, IOwinContext owinContext)
        {
            var exception = exp;
            var dic = ExceptionConvertorService.Convert(exception);
            owinContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            owinContext.Response.ReasonPhrase = "Internal server error";
            owinContext.Response.ContentType = "Application/Json";
            owinContext.Response.Write(dic.ToString());
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
