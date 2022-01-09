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
        /// <summary>
        /// 接口url
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 前端URL，如果有
        /// </summary>
        public string FrontUrl { get; set; }
        /// <summary>
        /// 前后约定的，如Add、Delete等
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// 图标，如果有
        /// </summary>
        public string Icon { get; set; }
        public int Sort { get; set; }
        public string Description { get; set; }
        public bool IsUse { get; set; }
    }
}
