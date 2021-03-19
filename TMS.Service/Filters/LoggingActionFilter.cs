using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Common.Core;
using TMS.Service.Controllers;

namespace TMS.Service.Filters
{
    public class LoggingActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Log("OnActionExecuting", context.RouteData, context.Controller);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Log("OnActionExecuted", context.RouteData, context.Controller);

        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            Log("OnResultExecuted", context.RouteData, context.Controller);
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            Log("OnResultExecuting", context.RouteData, context.Controller);
        }

        private void Log(string methodName, RouteData routeData, object controller)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = string.Format($"{methodName} controller: {controllerName} action: {actionName}");
            BaseController baseController = (BaseController)controller;
            baseController.Logger.LogInformation(LoggingEvents.ACCESS_METHOD, message);
        }
    }
}
