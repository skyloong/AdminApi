using Model.Models.Common;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models.System
{
    [SugarTable("sys_menu", IsDisabledUpdateAll = true)]
    public class Menu : GUIDBaseModel
    {
        public string ParentId { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public int Sort { get; set; }
        /// <summary>
        /// 是否需要授权,true需要，false不需要
        /// </summary>
        public bool IsAuthorize { get; set; }
        public bool IsUse { get; set; }
        public string Description { get; set; }
    }
}
