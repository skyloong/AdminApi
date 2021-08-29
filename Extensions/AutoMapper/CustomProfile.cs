using AutoMapper;

namespace Extensions.AutoMapper
{
    public class CustomProfile : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public CustomProfile()
        {
            //将Model映射到ViewModel
            //CreateMap<Model, ViewModel>();
            // 使用自定义映射Student类的ID映射到StudentDTO类的StudentID
            //CreateMap<Student, StudentDTO>()
            //    .ForMember(destinationMember: des => des.StudentID, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.ID); })
            //    .ReverseMap();//ReverseMap()表示可以逆向映射
        }
    }
}
