using Model.ExcelMapper.Export.System;
using Model.Models.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRepository.System
{
    public interface ISysMenusRepository : IBaseRepository<Menu>
    {
        List<Menu> All();
        (List<Menu> list, int totalNumber, int totalPage) GetList(SysMenuForm form, int pageIndex = 1, int pageSize = 20);
        List<Menu> GetMenus(ICollection<string> menuIds);
        List<Menu> GetMenusByRole(ICollection<string> roleIds);
        Menu Single(string menuId);
    }
}
