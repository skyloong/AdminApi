using System;
using System.Collections.Generic;
using System.Text;

namespace Common.TypeMapper
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class ListColumnAttribute : Attribute
    {
        private readonly string _name;
        private readonly int? _width;
        private readonly bool _export;
        private readonly bool _sort;
        private readonly string _align;

        public ListColumnAttribute(string name, string align = "center", bool export = false, bool sort = false)
        {
            _name = name;
            _width = null;
            _export = export;
            _align = align;
            _sort = sort;
        }

        public ListColumnAttribute(string name, int width, string align = "center", bool export = false, bool sort = false)
        {
            _name = name;
            _width = width;
            _export = export;
            _align = align;
            _sort = sort;
        }

        public string Name => _name;
        public int? Width => _width;
        public bool Exoort => _export;
        public string Align => _align;
        public bool Sort => _sort;
    }
}
