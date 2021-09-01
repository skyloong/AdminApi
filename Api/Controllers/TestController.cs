using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Authorize]
    public class TestController : BaseController
    {
        [HttpGet]
        public IActionResult Add()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult Export()
        {
            return Ok();
        }
    }
}
