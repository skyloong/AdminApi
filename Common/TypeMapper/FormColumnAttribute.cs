using System;
using System.Collections.Generic;
using System.Text;

namespace Common.TypeMapper
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class FormColumnAttribute : Attribute
    {
        private readonly string _name;
        private readonly string _field;
        private readonly string _type;
        private readonly bool _autocomplete;
        
        public FormColumnAttribute(string name, string field, string type = "text", bool autocomplete = false)
        {
            _name = name;
            _field = field;
            _type = type;
            _autocomplete = autocomplete;
        }

        public string Name => _name;
        public string Field => _field;
        public string Type => _type;
        public bool Autocomplete => _autocomplete;
    }
}
