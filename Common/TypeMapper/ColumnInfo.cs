using System;
using System.Collections.Generic;
using System.Text;

namespace Common.TypeMapper
{
    public class ColumnInfo
    {
        public string Text { get; set; }
        public int? Width { get; set; }
        public bool Sortable { get; set; }
        public string Align { get; set; }
        public string ValueField { get; set; }
        public bool IsExport { get; set; }
    }

    public class BaseInfo
    {
        public bool IsPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPage { get; set; }
        public bool Checkbox { get; set; }
        public ICollection<ColumnInfo> Columns { get; set; }
    }

    public class PageInfo<TResult> : BaseInfo where TResult : class
    {
        public ICollection<Button> Buttons { get; set; }
        public ICollection<TResult> Data { get; set; }
    }

    public class FormInfo
    {
        public string Url { get; set; }
        public ICollection<FormColumnInfo> Columns { get; set; }
    }

    public class FormColumnInfo
    {
        public string Text { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Autocomplete { get; set; }
    }

    public class Button
    {
        public string Text { get; set; }
        public string Action { get; set; }
        public string Icon { get; set; }
        public string FrontUrl { get; set; }
        public string Reuqest { get; set; }
    }
}
