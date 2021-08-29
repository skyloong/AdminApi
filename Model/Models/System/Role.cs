using Model.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models.System
{
    public class Role : GUIDBaseModel
    {
        public string Name { get; set; }
        /// <summary>
        /// 角色说明
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsUse { get; set; }
        public int Sort { get; set; }
    }
}
