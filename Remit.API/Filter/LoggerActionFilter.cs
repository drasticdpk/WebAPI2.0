using log4net;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Remit.API.Filter
{
    public class LoggerActionFilter : ActionFilterAttribute
    {
        [Dependency]
        public ILog Logger { get; set; }

        public LoggerActionFilter()
        {
        }

        public override void OnActionExecuting(HttpActionContext context)
        {
            string controllerName = context.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionName = context.ActionDescriptor.ActionName;

            // Log the action entry
            var message = new StringBuilder();
            message.AppendFormat("Entering action '{0}.{1}'.", controllerName, actionName);
            if (context.ActionArguments.Count > 0)
            {
                message.AppendLine().Append("Action parameters:");
                foreach (KeyValuePair<string, object> parameter in context.ActionArguments)
                {
                    object valueToLog = parameter.Value;

                    string argumentDesctiption = General.GetObjectDescription(valueToLog);
                    message.AppendLine().AppendFormat("\t {0}: {1}", parameter.Key, argumentDesctiption);
                }
            }

            Logger.Debug(message.ToString());
        }

        public override void OnActionExecuted(HttpActionExecutedContext context)
        {
            var message = new StringBuilder();
            message.AppendFormat("Exiting action '{0}.{1}'.",
                context.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                context.ActionContext.ActionDescriptor.ActionName);

            var responseObject = context.Response?.Content as ObjectContent;
            if (responseObject != null)
            {
                message.AppendLine().AppendFormat("Action Result: {0}",
                    General.GetObjectDescription(responseObject.Value)).AppendLine();
            }

            Logger.Debug(message.ToString());
        }
    }
}