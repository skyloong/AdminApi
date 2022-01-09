using Common.TypeMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ExcelMapper.Export.System
{
    [PageInfo()]
    public class SysButtonDto
    {
        public string MenuId { get; set; }
        [ListColumn("名称")]
        public string Name { get; set; }
        [ListColumn("接口URL")]
        public string Url { get; set; }
        [ListColumn("页面URL")]
        public string FrontUrl { get; set; }
        [ListColumn("操作")]
        public string Action { get; set; }
        [ListColumn("图标")]
        public string Icon { get; set; }
        [ListColumn("说明")]
        public string Description { get; set; }
        [ListColumn("是否启用")]
        public bool IsUse { get; set; }
    }

    public class SysButtonForm
    {
        [FormColumn(name: "名称", field: "name")]
        public string Name { get; set; }
        [FormColumn(name: "菜单", field: "MenuName")]
        public string MenuName { get; set; }
    }
}
