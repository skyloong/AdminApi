using System;
using System.Collections.Generic;
using System.Text;
using Model.Models.Common;

namespace Model.Models.System
{
    public class AdminUser : GUIDBaseModel
    {
        public string Account { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string Remark { get; set; }
        /// <summary>
        /// 所属地市
        /// </summary>
        public string LocalCityId { get; set; }
        /// <summary>
        /// 部门Id
        /// </summary>
        public string DeptId { get; set; }
        /// <summary>
        /// 最后一次修改密码时间
        /// </summary>
        public DateTime? ModifyPwdDate { get; set; }
        /// <summary>
        /// 上一次登录时间
        /// </summary>
        public DateTime? LastLoginDate { get; set; }
        /// <summary>
        /// 明码
        /// </summary>
        public string Pwd { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsUse { get; set; }
    }
}
