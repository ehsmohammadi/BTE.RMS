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
            var dic = ExceptionConverterService.Convert(exception);
            foreach (var item in dic)
            {
                error.Add(item.Key, item.Value);
            }
            return context.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, error);
        }
        
    }
}
