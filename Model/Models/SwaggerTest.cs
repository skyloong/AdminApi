using System;
using System.Collections.Generic;
using System.Text;
using Model.Models.Common;
using SqlSugar;

namespace Model.Models
{
    [SugarTable("SwaggerTest", IsDisabledUpdateAll = true)]
    public class SwaggerTest : GUIDBaseModel
    {
        /// <summary>
        /// fuck you
        /// </summary>
        public string fuck { get; set; }
    }
}
