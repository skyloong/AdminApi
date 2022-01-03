using IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Authorize]
    public class TestController : BaseController
    {
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly IProductTestService _productTestService;
        public TestController(IProductTestService productTestService, IWebHostEnvironment appEnvironment)
        {
            _productTestService = productTestService;
            _appEnvironment = appEnvironment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
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

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Export()
        {
            return Ok(_appEnvironment.WebRootPath);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ExcelMapper()
        {
            var filePath = Path.Combine(_appEnvironment.WebRootPath, "temp\\Products.xlsx");
            return Ok(_productTestService.ExcelMapper(filePath));
        }
    }
}
