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
        /// <summary>
        /// fuck you
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Fuck(SwaggerTest test)
        {
            return Ok();
        }
    }
}
