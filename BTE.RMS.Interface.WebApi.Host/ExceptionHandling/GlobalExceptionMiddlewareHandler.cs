using System;
using System.Threading.Tasks;
using BTE.Presentation.Web;
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
                WebApiExceptionAdapter.ConverToHttpResponse(ex, context);
            }
        }
    }
}