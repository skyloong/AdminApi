using Model.Models.Common;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models.System
{
    [SugarTable("sys_button", IsDisabledUpdateAll = true)]
    public class MenuButton : GUIDBaseModel
    {
        public string MenuId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int Sort { get; set; }
        public string Description { get; set; }
        public bool IsUse { get; set; }
    }
}
