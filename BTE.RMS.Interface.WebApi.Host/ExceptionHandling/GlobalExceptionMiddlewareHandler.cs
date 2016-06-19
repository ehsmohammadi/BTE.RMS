using System;
using System.Net;
using System.Threading.Tasks;
using BTE.Core;
using Microsoft.Owin;

namespace BTE.RMS.Interface.WebApi.Host
{
    public class GlobalExceptionMiddlewareHandler:OwinMiddleware
    {
        public GlobalExceptionMiddlewareHandler(OwinMiddleware next) : base(next)
        {
        }

        public override async Task Invoke(IOwinContext context)
        {
            try
            {
                await Next.Invoke(context);
            }
            catch (Exception ex)
            {
                var dic = ExceptionConverterService.Convert(ex);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ReasonPhrase = "Internal server error";
                context.Response.ContentType = "Application/Json";
                context.Response.Write(dic.ToString());
            }
        }
    }
}