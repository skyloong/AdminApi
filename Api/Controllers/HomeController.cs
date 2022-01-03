using Common.Helper;
using IServices;
using IServices.System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly IAutoFacTestService _autoFacTestService;
        private readonly IUsersService _usersService;
        public HomeController(IAutoFacTestService autoFacTestService, IUsersService usersService)
        {
            _autoFacTestService = autoFacTestService;
            _usersService = usersService;
        }
        /// <summary>
        /// fuck you
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Fuck(SwaggerTest test)
        {
            throw new Exception("fuck");
            return Ok(_autoFacTestService.Fuck("you"));
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string usercode)
        {
            var userId = _usersService.Find(usercode)?.Id;
            return userId == null ? NotFound("未找到该用户") : Success(JwtHelper.IssueJwt(userId));
        }

        [HttpGet]
        public IActionResult GetUserId()
        {
            return Success(UserId);
        }
    }
}
