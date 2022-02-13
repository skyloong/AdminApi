using Common.Helper;
using IRepository.System;
using IServices.System;
using Model.ExcelMapper.Export.System;
using Model.Models.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.System
{
    public class SysMenusService : BaseService<Menu>, ISysMenusService
    {
        private readonly ISysMenusRepository _sysMenusRepository;
        private readonly CasbinHelper _casbinHelper;
        public SysMenusService(ISysMenusRepository sysMenusRepository, CasbinHelper casbinHelper)
        {
            _sysMenusRepository = sysMenusRepository;
            _casbinHelper = casbinHelper;
        }

        public List<Menu> All()
        {
            return _sysMenusRepository.All();
        }

        public (List<Menu> list, int totalNumber, int totalPage) GetList(SysMenuForm form, int pageIndex = 1, int pageSize = 20)
        {
            return _sysMenusRepository.GetList(form, pageIndex, pageSize);
        }

        public List<Menu> GetMenus(ICollection<string> menuIds)
        {
            return _sysMenusRepository.GetMenus(menuIds);
        }

        public List<Menu> GetMenusForUser(string userId)
        {
            var roleIds = _casbinHelper.GetRolesForUser(userId);
            return _sysMenusRepository.GetMenusByRole(roleIds);
        }

        public Menu Single(string menuId)
        {
            return _sysMenusRepository.Single(menuId);
        }
    }
}
