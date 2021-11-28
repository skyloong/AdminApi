using AutoMapper;
using IRepository;
using IServices;
using Model.ExcelMapper.Import;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class ProductTestService : BaseService<ProductTest>, IProductTestService
    {
        public ProductTestService(IMapper mapper)
        {
            base.Mapper = mapper;
        }
        public IEnumerable<ProductTest> ExcelMapper(string filePath)
        {
            return base.ExcelToEntity<ProductTest>(filePath);
        }
    }
}
