using Model.ExcelMapper.Import;
using System;
using System.Collections.Generic;
using System.Text;

namespace IServices
{
    public interface IProductTestService
    {
        IEnumerable<ProductTest> ExcelMapper(string filePath);
    }
}
