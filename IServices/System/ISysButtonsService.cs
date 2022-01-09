using Model.Models.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace IServices.System
{
    public interface ISysButtonsService : IBaseService<MenuButton>
    {
        List<MenuButton> GetList(string menuId);
        List<MenuButton> GetListByUrl(string url);
    }
}
