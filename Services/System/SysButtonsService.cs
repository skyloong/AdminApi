using IRepository.System;
using IServices.System;
using Model.Models.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.System
{
    public class SysButtonsService : BaseService<MenuButton>, ISysButtonsService
    {
        private readonly ISysButtonsRepository _sysButtonsRepository;
        public SysButtonsService(ISysButtonsRepository sysButtonsRepository)
        {
            _sysButtonsRepository = sysButtonsRepository;
        }

        public List<MenuButton> GetList(string menuId)
        {
            return _sysButtonsRepository.GetList(menuId);
        }

        public List<MenuButton> GetListByUrl(string url)
        {
            return _sysButtonsRepository.GetListByUrl(url);
        }
    }
}
