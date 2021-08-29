using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace Model.Models.Common
{
    public class GUIDBaseModel
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
