using Model.Models.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRepository.System
{
    public interface ISysButtonsRepository : IBaseRepository<MenuButton>
    {
        List<MenuButton> GetList(string menuId);
        List<MenuButton> GetListByUrl(string url);
    }
}
