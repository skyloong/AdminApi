using Model.ExcelMapper.Export.System;
using Model.Models.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace IServices.System
{
    public interface ISysMenusService : IBaseService<Menu>
    {
        List<Menu> All();
        (List<Menu> list, int totalNumber, int totalPage) GetList(SysMenuForm form, int pageIndex = 1, int pageSize = 20);
        List<Menu> GetMenus(ICollection<string> menuIds);
        Menu Single(string menuId);
        List<Menu> GetMenusForUser(string userId);
    }
}
