using Model.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models.System
{
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
