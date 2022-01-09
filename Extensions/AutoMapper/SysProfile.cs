using AutoMapper;
using Common.TypeMapper;
using Model.ExcelMapper.Export.System;
using Model.Models.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Extensions.AutoMapper
{
    public class SysProfile : Profile
    {
        public SysProfile()
        {
            CreateMap<MenuButton, Button>()
                .ForMember(to => to.Text, opt => opt.MapFrom(source => source.Name))
                .ForMember(to => to.Action, opt => opt.MapFrom(source => source.Action))
                .ForMember(to => to.Icon, opt => opt.MapFrom(source => source.Icon))
                .ForMember(to => to.FrontUrl, opt => opt.MapFrom(source => source.FrontUrl))
                .ForMember(to => to.Reuqest, opt => opt.MapFrom(source => source.Url));

            CreateMap<MenuButton, SysButtonDto>();
        }
    }
}
