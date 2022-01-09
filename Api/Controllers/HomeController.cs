using AutoMapper;
using Common.Helper;
using Common.TypeMapper;
using IServices;
using IServices.System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.ExcelMapper.Export.System;
using Model.Models;
using Model.Models.System;
using Model.ViewModels.Result;
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
        private readonly ISysButtonsService _sysButtonsService;
        private readonly IMapper _mapper;
        public HomeController(IAutoFacTestService autoFacTestService, IUsersService usersService, ISysButtonsService sysButtonsService, IMapper mapper)
        {
            _autoFacTestService = autoFacTestService;
            _usersService = usersService;
            _sysButtonsService = sysButtonsService;
            _mapper = mapper;
        }

        public List<MenuButton> Buttons => _sysButtonsService.GetListByUrl(Route);

        /// <summary>
        /// fuck you
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
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

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetButtons([FromBody]SysButtonForm form)
        {
            return Success(new AutoPage<SysButtonDto>
            {
                Form = new FormInfo
                {
                    Url = Route,
                    Columns = TypeInfoFactory.CreateForm(typeof(SysButtonForm)).ColumnInfos,
                },
                Page = TypeInfoFactory.Create(typeof(SysButtonDto)).GetResult(_mapper.Map<List<SysButtonDto>>(Buttons), _mapper.Map<List<Button>>(Buttons))
            });
        }
    }
}
