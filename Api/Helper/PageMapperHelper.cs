using AutoMapper;
using Common.TypeMapper;
using IServices.System;
using Model.ExcelMapper.Export.System;
using Model.ViewModels.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Helper
{
    public interface IPageMapperHelper
    {
        AutoPage<TDto> ToPage<TDto>(List<TDto> data, string route, int totalCount, int totalPage) where TDto : class;
    }
    public class PageMapperHelper : IPageMapperHelper
    {
        private IMapper Mapper;
        private ISysButtonsService _sysButtonsService;
        public PageMapperHelper(IMapper mapper, ISysButtonsService sysButtonsService)
        {
            Mapper = mapper;
            _sysButtonsService = sysButtonsService;
        }

        public AutoPage<TDto> ToPage<TDto>(List<TDto> data, string route, int totalCount, int totalPage) where TDto : class
        {
            var buttons = Mapper.Map<List<Button>>(_sysButtonsService.GetListByUrl(route));
            var page = TypeInfoFactory.Create(typeof(TDto)).GetResult(data, buttons);
            page.TotalCount = totalCount;
            page.TotalPage = totalPage;
            return new AutoPage<TDto>
            {
                Form = new FormInfo
                {
                    Url = route,
                    Columns = TypeInfoFactory.CreateForm(typeof(SysButtonForm)).ColumnInfos,
                },
                Page = page
            };
        }
    }
}
