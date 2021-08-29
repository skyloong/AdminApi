using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models.Common
{
    public class AutoIncrementBaseModel
    {
        public AutoIncrementBaseModel()
        {
            CreatedAt = UpdatedAt = DateTime.Now;
        }

        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public string Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
