using System;
using System.Collections.Generic;
using System.Text;

namespace Common.TypeMapper
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class PageInfoAttribute : Attribute
    {
        public bool IsUse { get; set; }
        private readonly bool _isPage = true;
        private readonly int _pageSize = 20;
        private readonly bool _checkbox = false;

        public PageInfoAttribute(bool isUse = true, bool isPage = true, int pageSize = 20, bool checkbox = false)
        {
            IsUse = isUse;
            _isPage = isPage;
            _pageSize = pageSize;
            _checkbox = checkbox;
        }

        public bool IsPage => _isPage;
        public int PageSize => _pageSize;
        public bool Checkbox => _checkbox;
    }
}
