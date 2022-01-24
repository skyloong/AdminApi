using Common.AppConfig;
using Common.Helper;
using IRepository.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Model.Models.System;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Api.Filter
{
    public class PermissionFilter : IActionFilter
    {
        private readonly CasbinHelper _casbinHelper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISqlSugarClient _db;
        public PermissionFilter(CasbinHelper casbinHelper, IUnitOfWork unitOfWork)
        {
            _casbinHelper = casbinHelper;
            _unitOfWork = unitOfWork;
            _db = unitOfWork.GetDbClient();
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            var allowAnonymous = actionDescriptor.MethodInfo.GetCustomAttributes(typeof(AllowAnonymousAttribute), false).FirstOrDefault();
            if (allowAnonymous != null)
            {
                return;
            }
            var route = context.RouteData;
            var controllerName = route.Values["controller"].ToString();
            //var controllerName = actionDescriptor.ControllerName;
            var actionName = route.Values["action"].ToString();
            //var actionName = actionDescriptor.ActionName;

            var userIdToken = context.HttpContext.User.FindFirst(TokenClaims.UserId);
            string userId = string.Empty;
            if (userIdToken != null)
            {
                userId = userIdToken.Value.ToString();
            }
            var url = string.Format("/{0}/{1}", controllerName, actionName);
            //先找按钮
            var menu = _db.Queryable<MenuButton>().Where(a => a.Url == url).Select(a => new { a.Id, a.IsAuthorize }).First();
            
            if (menu == null)
            {
                //再找菜单
                menu = _db.Queryable<Menu>().Where(a => a.Url == url).Select(a => new { a.Id, a.IsAuthorize }).First();
            }

            if (menu == null || !menu.IsAuthorize)
            {
                return;
            }

            if (!_casbinHelper.HasButtonForUser(userId, menu.Id))
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                context.Result = new ContentResult()
                {
                    Content = "没有权限"
                };
            }
        }
    }
}
