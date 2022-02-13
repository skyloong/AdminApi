using Model.Models.Common;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models.System
{
    [SugarTable("sys_role_menu", IsDisabledUpdateAll = true)]
    public class RoleMenu : IntIDBaseModel
    {
        public string RoleId { get; set; }
        public string MenuId { get; set; }
    }
}
