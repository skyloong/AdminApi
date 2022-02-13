using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace Model.Models.Common
{
    public class GUIDBaseModel
    {
        public GUIDBaseModel()
        {
            CreatedAt = UpdatedAt = DateTime.Now;
        }

        [SugarColumn(IsPrimaryKey = true)]
        public string Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public string NewGUID()
        {
            Id = Guid.NewGuid().ToString();
            return Id;
        }
    }

    public class IntIDBaseModel
    {
        public IntIDBaseModel()
        {
            CreatedAt = UpdatedAt = DateTime.Now;
        }

        [SugarColumn(IsPrimaryKey = true)]
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
