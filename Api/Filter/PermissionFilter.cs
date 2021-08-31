using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Api.Filter
{
    public class PermissionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var route = context.RouteData;
            var controllerName = route.Values["controller"].ToString();
            var actionName = route.Values["action"].ToString();

            var userIdToken = context.HttpContext.User.FindFirst("UserId");
            string userId = string.Empty;
            if (userIdToken != null)
            {
                userId = userIdToken.ToString();
            }

            if (false)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                context.Result = new ContentResult()
                {
                    Content = "没有权限"
                };
                return;
            }
        }

        private bool IsSkip()
        {

        }
    }
}
