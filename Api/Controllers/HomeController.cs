using Common.Helper;
using IServices;
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
        public HomeController(IAutoFacTestService autoFacTestService)
        {
            _autoFacTestService = autoFacTestService;
        }
        /// <summary>
        /// fuck you
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Fuck(SwaggerTest test)
        {
            return Ok(_autoFacTestService.Fuck("you"));
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string userId)
        {
            return Success(JwtHelper.IssueJwt(userId));
        }

        [HttpGet]
        public IActionResult GetUserId(string userId)
        {
            return Success(UserId);
        }
    }
}
