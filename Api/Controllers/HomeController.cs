using IServices;
using Microsoft.AspNetCore.Mvc;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HomeController : Controller
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
    }
}
