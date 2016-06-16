using System.Web.Http.Filters;
using BTE.Presentation.Web;

namespace BTE.RMS.Interface.WebApi.Host
{
    public class ApplicationExceptionFilterAttribute : ExceptionFilterAttribute
    {

        public override void OnException(HttpActionExecutedContext context)
        {
            context.Response = WebApiExceptionAdapter.ConverToHttpResponse(context);
        }

    }
}