using IRepository.System;
using IRepository.UnitOfWork;
using Model.Models.System;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Model.ExcelMapper.Export.System;

namespace Repository.System
{
    public class SysMenusRepository : BaseRepository<Menu>, ISysMenusRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public SysMenusRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Menu> All()
        {
            return Db.Queryable<Menu>().ToList();
        }

        public (List<Menu> list, int totalNumber, int totalPage) GetList(SysMenuForm form, int pageIndex = 1, int pageSize = 20)
        {
            int totalPage = 0;
            int totalNumber = 0;
            var list = Db.Queryable<Menu>()
                .WhereIF(!string.IsNullOrEmpty(form.Name), a => a.Name.Contains(form.Name))
                .WhereIF(!string.IsNullOrEmpty(form.Url), a => a.Url.Contains(form.Url))
                .WhereIF(form.IsAuthorize.HasValue, a => a.IsAuthorize == form.IsAuthorize.Value)
                .ToPageList(pageIndex, pageSize, ref totalNumber, ref totalPage);
            return (list, totalNumber, totalPage);
        }

        public List<Menu> GetMenus(ICollection<string> menuIds)
        {
            return Db.Queryable<Menu>()
                .Where(a => menuIds.Contains(a.Id))
                .ToList();
        }

        public Menu Single(string menuId)
        {
            return Db.Queryable<Menu>()
                .Where(a => a.Id == menuId)
                .First();
        }
    }
}
