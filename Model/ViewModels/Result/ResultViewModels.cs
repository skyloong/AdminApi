using Common.TypeMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModels.Result
{
    public class BaseResult
    {
        public int code { get; set; }
        public string msg { get; set; }
    }

    public class ItemResult<T> : BaseResult
    {
        public T data { get; set; }
    }

    public class PageResult<T> : BaseResult
    {
        public ICollection<T> data { get; set; }
        public int totalCount { get; set; }
        public int page { get; set; }
    }

    public class AutoPage<T> where T : class
    {
        public FormInfo Form { get; set; }
        public PageInfo<T> Page { get; set; }
    }
}
