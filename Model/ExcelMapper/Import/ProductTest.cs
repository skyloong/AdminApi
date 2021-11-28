using System;
using System.Collections.Generic;
using System.Text;
using Ganss.Excel;

namespace Model.ExcelMapper.Import
{
    public class ProductTest
    {
        public string Name { get; set; }
        [Column("Number")]
        public int NumberInStock { get; set; }
        public decimal Price { get; set; }
        public string Value { get; set; }
    }
}
