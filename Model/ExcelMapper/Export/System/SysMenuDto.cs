using Common.TypeMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ExcelMapper.Export.System
{
    [PageInfo()]
    public class SysMenuDto
    {
        public string Id { get; set; }
        [ListColumn("菜单名称")]
        public string Name { get; set; }
        [ListColumn("接口URL")]
        public string Url { get; set; }
        [ListColumn("页面URL")]
        public string Path { get; set; }
        [ListColumn("图标")]
        public string Icon { get; set; }
        [ListColumn("是否需要授权")]
        public bool IsAuthorize { get; set; }
        [ListColumn("说明")]
        public string Description { get; set; }
        [ListColumn("是否启用")]
        public bool IsUse { get; set; }
    }

    public class SysMenuForm
    {
        [FormColumn(name: "名称", field: "name")]
        public string Name { get; set; }
        [FormColumn(name: "接口", field: "url")]
        public string Url { get; set; }
        [FormColumn(name: "是否需要授权", field: "isAuthorize")]
        public bool? IsAuthorize { get; set; }
    }
}
