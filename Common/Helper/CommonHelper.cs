using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Common.Helper
{
    public class CommonHelper
    {
        public static List<T> ListToTree<T>(ICollection<T> list, string parentField = "ParentId", string keyField = "Id", string childField = "Children")
        {
            var type = typeof(T);
            var tree = new List<T>();
            var dic = new Dictionary<string, List<T>>();

            foreach (var item in list)
            {
                var id = type.GetProperty(keyField).GetValue(item).ToString();

                if (dic.TryGetValue(id, out var record))
                {
                    type.GetProperty(childField).SetValue(item, record);
                } else
                {
                    dic.Add(id, new List<T>());
                    type.GetProperty(childField).SetValue(item, dic[id]);
                }

                var parentId = type.GetProperty(parentField).GetValue(item).ToString();
                if (!string.IsNullOrEmpty(parentId))
                {
                    if (!dic.ContainsKey(parentId))
                    {
                        dic.Add(parentId, new List<T>());
                    }
                    dic[parentId].Add(item);
                } else
                {
                    tree.Add(item);
                }
            }

            return tree;
        }
    }
}
