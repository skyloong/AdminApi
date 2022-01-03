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
            var buttonId = _db.Queryable<MenuButton>().Where(a => a.Url == url).Select(a => a.Id).First();
            if (string.IsNullOrEmpty(buttonId) || !_casbinHelper.Enforce(userId, buttonId))
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                context.Result = new ContentResult()
                {
                    Content = "没有权限"
                };
            }
        }

        private bool IsSkip(string userId, string path)
        {
            //_casbinHelper.AddRoleForUser("C11DA582-3824-4992-A036-5C021DB833E4", "C4589779-AE52-4A27-9A9B-795501C13FFD");//sky 超管
            //_casbinHelper.AddRoleForUser("E6070FD3-8973-446F-AF2D-CFF1DB3035DD", "C4589779-AE52-4A27-9A9B-795501C13FFD");//loong 超管
            //_casbinHelper.AddRoleForUser("C11DA582-3824-4992-A036-5C021DB833E4", "10CF3A92-9227-421D-A2EB-4946E25CC6ED");//sky 县级管理员
            //_casbinHelper.AddRoleForUser("E6070FD3-8973-446F-AF2D-CFF1DB3035DD", "2A40A0A0-6E77-4D11-8EB8-6B9CEA5BF2CD");//loong 超管
            //_casbinHelper.AddButtonForRole("C4589779-AE52-4A27-9A9B-795501C13FFD", "8DD5C0BE-3913-42CF-8992-119358B40885");//超管 新增
            //_casbinHelper.AddButtonForRole("C4589779-AE52-4A27-9A9B-795501C13FFD", "DEB403F5-FBED-4026-920D-ED45F3CFEA2B");//超管 修改
            //_casbinHelper.AddButtonForRole("C4589779-AE52-4A27-9A9B-795501C13FFD", "5366A9FD-7D0D-49E4-A00C-F394215768AE");//超管 删除
            //_casbinHelper.AddButtonForRole("10CF3A92-9227-421D-A2EB-4946E25CC6ED", "DEB403F5-FBED-4026-920D-ED45F3CFEA2B");//管理员 删除
            #region users
            var users = new List<AdminUser>();
            users.Add(new AdminUser
            {
                Id = "C11DA582-3824-4992-A036-5C021DB833E4",
                Account = "sky",
                Name = "sky",
                Password = "1233",
            });
            users.Add(new AdminUser
            {
                Id = "E6070FD3-8973-446F-AF2D-CFF1DB3035DD",
                Account = "loong",
                Name = "loong",
                Password = "1233",
            });
            users.Add(new AdminUser
            {
                Id = "20E7F7A0-2118-4EAF-8696-B957211A89F3",
                Account = "skyloong",
                Name = "skyloong",
                Password = "1233",
            });
            users.Add(new AdminUser
            {
                Id = "AFBF0322-A354-4F16-8E4E-5490380AC0D0",
                Account = "ltl",
                Name = "ltl",
                Password = "1233",
            });
            users.Add(new AdminUser
            {
                Id = "94096D52-13B4-44EC-8C64-01CB5BA94341",
                Account = "lil",
                Name = "lil",
                Password = "1233",
            });
            #endregion
            #region roles
            var roles = new List<Role>();
            roles.Add(new Role
            {
                Id = "C4589779-AE52-4A27-9A9B-795501C13FFD",
                Name = "超级管理员"
            });
            roles.Add(new Role
            {
                Id = "10CF3A92-9227-421D-A2EB-4946E25CC6ED",
                Name = "管理员"
            });
            roles.Add(new Role
            {
                Id = "2A40A0A0-6E77-4D11-8EB8-6B9CEA5BF2CD",
                Name = "县级管理员"
            });
            #endregion
            #region menus
            var menus = new List<Menu>();
            menus.Add(new Menu
            {
                Id = "7B81DCC5-0320-4FB0-8F5D-F5DBB1F9FBCE",
                Name = "首页"
            });
            menus.Add(new Menu
            {
                Id = "0109046E-BC29-4CCB-B972-DF51A6F85D39",
                Name = "用户"
            });
            menus.Add(new Menu
            {
                Id = "09CC2309-85AC-4D33-9A65-54DAC82C1384",
                Name = "班级"
            });
            #endregion
            #region buttons
            var buttons = new List<MenuButton>();
            buttons.Add(new MenuButton
            {
                Id = "8DD5C0BE-3913-42CF-8992-119358B40885",
                Name = "新增",
                Url = "/test/add"
            });
            buttons.Add(new MenuButton
            {
                Id = "DEB403F5-FBED-4026-920D-ED45F3CFEA2B",
                Name = "修改",
                Url = "/test/edit"
            });
            buttons.Add(new MenuButton
            {
                Id = "5366A9FD-7D0D-49E4-A00C-F394215768AE",
                Name = "删除",
                Url = "/test/delete"
            });
            buttons.Add(new MenuButton
            {
                Id = "3E968DFB-928E-4F7E-A8AE-267E2417AF38",
                Name = "导出",
                Url = "/test/export"
            });
            #endregion

            //var buttonId = buttons.Where(a => a.Url == path).Select(a => a.Id).FirstOrDefault();
            //var userId = users.Where(a => a.Name == "sky").Select(a => a.Id).FirstOrDefault();
            //return _casbinHelper.Enforce(userId, buttonId);
            return true;
        }
    }
}
