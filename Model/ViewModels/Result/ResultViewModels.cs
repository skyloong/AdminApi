using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModels.Result
{
    public class BaseResul
    {
        public int code { get; set; }
        public string msg { get; set; }
    }

    public class ItemResult<T> : BaseResul
    {
        public T data { get; set; }
    }

    public class PageResult<T> : BaseResul
    {
        public ICollection<T> data { get; set; }
        public int totalCount { get; set; }
        public int page { get; set; }
    }
}
