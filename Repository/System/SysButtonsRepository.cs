using IRepository.System;
using IRepository.UnitOfWork;
using Model.Models.System;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.System
{
    public class SysButtonsRepository : BaseRepository<MenuButton>, ISysButtonsRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public SysButtonsRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<MenuButton> GetList(string menuId)
        {
            return Db.Queryable<MenuButton>()
                .Where(a => a.MenuId == menuId)
                .ToList();
        }

        public List<MenuButton> GetListByUrl(string url)
        {
            return Db.Queryable<MenuButton>()
                .Where(a => SqlFunc.Subqueryable<Menu>().Where(b => b.Id == a.MenuId && b.Url == url).Any())
                .ToList();
        }
    }
}
