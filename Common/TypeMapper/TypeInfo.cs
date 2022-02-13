using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Common.TypeMapper
{
    public class TypeInfo
    {
        public bool IsUse { get; set; }
        public Type Type { get; set; }
        public TypeInfo(Type type)
        {
            Type = type;
        }

        private List<ColumnInfo> _columnInfos { get; set; }
        public string ColumnJson
        {
            get 
            {
                return JsonSerializer.Serialize(_columnInfos);
            }
        }

        private BaseInfo _baseInfo { get; set; }
        public string ListInfoJson
        {
            get
            {
                return JsonSerializer.Serialize(_baseInfo);
            }
        }

        public static TypeInfo Create(Type type)
        {
            var typeInfo = new TypeInfo(type);
            typeInfo.Parser();
            return typeInfo;
        }

        void Parser()
        {
            var classAttribute = Type.GetCustomAttribute<PageInfoAttribute>();
            if (classAttribute == null)
            {
                classAttribute = new PageInfoAttribute();
            }
            IsUse = classAttribute.IsUse;

            if (!IsUse)
            {
                return;
            }

            _baseInfo = new BaseInfo
            {
                IsPage = classAttribute.IsPage,
                PageSize = classAttribute.PageSize,
                Checkbox = classAttribute.Checkbox,
            };
            var props = Type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            _columnInfos = new List<ColumnInfo>();

            foreach (var prop in props)
            {
                //var attribs = Attribute.GetCustomAttributes(prop, typeof(ListColumnAttribute)).Cast<ListColumnAttribute>();
                var columnArrtibute = prop.GetCustomAttribute<ListColumnAttribute>();
                if (columnArrtibute != null)
                {
                    _columnInfos.Add(new ColumnInfo
                    {
                        Text = columnArrtibute.Name,
                        Width = columnArrtibute.Width,
                        Align = columnArrtibute.Align,
                        Sortable = columnArrtibute.Sort,
                        IsExport = columnArrtibute.Exoort,
                        Value = char.ToLower(prop.Name.First()) + prop.Name.Substring(1)
                    });
                }
            }
            _baseInfo.Columns = _columnInfos;
        }

        public PageInfo<TResult> GetResult<TResult>(ICollection<TResult> data, ICollection<Button> buttons) where TResult : class
        {
            return new PageInfo<TResult>
            {
                IsPage = _baseInfo.IsPage,
                PageSize = _baseInfo.PageSize,
                Checkbox = _baseInfo.Checkbox,
                Columns = _baseInfo.Columns,
                Buttons = buttons,
                Data = data
            };
        }
    }

    public class FormParser
    {
        public Type Type { get; set; }
        public FormParser(Type type)
        {
            Type = type;
        }

        private List<FormColumnInfo> _columnInfos { get; set; }
        public string ColumnJson
        {
            get
            {
                return JsonSerializer.Serialize(_columnInfos);
            }
        }

        public List<FormColumnInfo> ColumnInfos => _columnInfos;

        public static FormParser Create(Type type)
        {
            var typeInfo = new FormParser(type);
            typeInfo.Parser();
            return typeInfo;
        }

        void Parser()
        {
            var props = Type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            _columnInfos = new List<FormColumnInfo>();

            foreach (var prop in props)
            {
                var columnArrtibute = prop.GetCustomAttribute<FormColumnAttribute>();
                if (columnArrtibute != null)
                {
                    _columnInfos.Add(new FormColumnInfo
                    {
                        Text = columnArrtibute.Name,
                        Name = columnArrtibute.Field,
                        Type = columnArrtibute.Type,
                        Autocomplete = columnArrtibute.Autocomplete
                    });
                }
            }
        }
    }

    public static class TypeInfoFactory
    {
        private static Dictionary<Type, TypeInfo> TypeInfos { get; set; } = new Dictionary<Type, TypeInfo>();
        private static Dictionary<Type, FormParser> FormInfos { get; set; } = new Dictionary<Type, FormParser>();
        public static TypeInfo Create(Type type)
        {
            if (!TypeInfos.TryGetValue(type, out TypeInfo typeInfo))
                typeInfo = TypeInfos[type] = TypeInfo.Create(type);

            return typeInfo;
        }
        public static FormParser CreateForm(Type type)
        {
            if (!FormInfos.TryGetValue(type, out FormParser typeInfo))
                typeInfo = FormInfos[type] = FormParser.Create(type);

            return typeInfo;
        }

        public static TypeInfo Refresh(Type type)
        {
            TypeInfo typeInfo = TypeInfos[type] = TypeInfo.Create(type);
            return typeInfo;
        }

        public static void RefreshAll()
        {
            foreach ((var key, var value) in TypeInfos)
            {
                TypeInfos[key] = TypeInfo.Create(key);
            }
        }

        public static void Clear()
        {
            TypeInfos = new Dictionary<Type, TypeInfo>();
        }
    }
}
