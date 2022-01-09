using Common.TypeMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ExcelMapper.Export
{
    [PageInfo()]
    public class PageList
    {
        [ListColumn("姓名")]
        public string Name { get; set; }
        [ListColumn("性别")]
        public string Sex { get; set; }
        [ListColumn("类型")]
        public int Type { get; set; }
    }
}
