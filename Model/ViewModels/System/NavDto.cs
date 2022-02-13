using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModels.System
{
    public class NavDto
    {
        public string Id { get; set; }
        public string Icon { get; set; }
        public string Text { get; set; }
        public string Path { get; set; }
        public List<NavDto> Children { get; set; }
    }
}
