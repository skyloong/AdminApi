using Common.AppConfig;
using Common.Helper;
using Microsoft.AspNetCore.Mvc;
using Model.ViewModels.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseController : Controller
    {
        protected int UserId
        {
            get
            {
                return GetUserId();
            }
        }

        protected string Route
        {
            get
            {
                return $"/{ControllerContext.ActionDescriptor.ControllerName.ToLower()}/{ControllerContext.ActionDescriptor.ActionName.ToLower()}";
            }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        protected int GetUserId()
        {
            var claims = User.Claims;
            foreach (var claim in claims)
            {
                if (claim.Type == TokenClaims.UserId)
                {
                    return claim.Value.ObjToInt();
                }
            }
            return 0;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        protected IActionResult BadRequest(string msg)
        {
            return BadRequest(new ItemResult<string>
            {
                msg = msg,
                code = 0,
                data = msg
            });
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        protected IActionResult NotFound(string msg)
        {
            return NotFound(new ItemResult<string>
            {
                msg = msg,
                code = 0,
                data = msg
            });
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        protected IActionResult Message(string msg)
        {
            return Ok(new ItemResult<string>
            {
                msg = msg,
                code = 0,
                data = msg
            });
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        protected IActionResult Success<T>(T data)
        {
            return Ok(new ItemResult<T>
            {
                msg = "",
                code = 0,
                data = data
            });
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        protected IActionResult Page<T>(int totalCount, int page, ICollection<T> data)
        {
            return Ok(new PageResult<T>
            {
                msg = "",
                code = 0,
                data = data,
                totalCount = totalCount,
                page = page
            });
        }
    }
}
