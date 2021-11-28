using AutoMapper;
using Model.ExcelMapper.Import;

namespace Extensions.AutoMapper
{
    /// <summary>
    /// Excel的对应类和实体类的映射关系
    /// </summary>
    public class ExcelProfile : Profile
    {
        public ExcelProfile()
        {
            CreateMap<ProductTest, ProductTest>();
        }
    }
}
