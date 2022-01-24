using Api.Helper;
using AutoMapper;
using Common.Helper;
using IServices.System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.ExcelMapper.Export.System;
using Model.Models.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers.System
{
    [Authorize]
    public class MenusController : BaseController
    {
        private readonly ISysMenusService _sysMenusService;
        private readonly IMapper _mapper;
        private readonly IPageMapperHelper _pageHelper;
        public MenusController(ISysMenusService sysMenusService, IMapper mapper, IPageMapperHelper pageHelper)
        {
            _sysMenusService = sysMenusService;
            _mapper = mapper;
            _pageHelper = pageHelper;
        }

        [HttpGet]
        public IActionResult Index([FromQuery] SysMenuForm form, int pageIndex = 1, int pageSize = 20)
        {
            var menus = _sysMenusService.GetList(form, pageIndex, pageSize);
            return Success(_pageHelper.ToPage(_mapper.Map<List<SysMenuDto>>(menus.list), Route, menus.totalNumber, menus.totalPage));
        }

        [HttpGet]
        public IActionResult Search([FromQuery]SysMenuForm form, int pageIndex = 1, int pageSize = 20)
        {
            var menus = _sysMenusService.GetList(form, pageIndex, pageSize);
            return Page(menus.totalNumber, menus.totalPage, menus.list);
        }

        [HttpGet]
        public IActionResult GetMenusForUser()
        {
            var data = CommonHelper.ListToTree(_sysMenusService.GetMenusForUser(UserId));
            return Success(data);
        }

        // GET: MenusController/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View();
        }

        // POST: MenusController/Create
        [HttpPost]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: MenusController/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: MenusController/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
