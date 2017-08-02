using log4net;
using Microsoft.Practices.Unity;
using System;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Web.Http.Filters;

namespace Remit.API.Filter
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        [Dependency]
        public ILog Logger { get; set; }

        public ExceptionFilter()
        {
        }

        public override void OnException(HttpActionExecutedContext filterContext)
        {
            base.OnException(filterContext);
            if (filterContext.Exception is ArgumentException)
            {
                filterContext.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            else if (filterContext.Exception is AuthenticationException)
            {
                filterContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
            else
            {
                filterContext.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
            filterContext.Response.Content = new StringContent(filterContext.Exception.Message);
            Logger.Error(filterContext.Exception.Message);
        }
    }
}