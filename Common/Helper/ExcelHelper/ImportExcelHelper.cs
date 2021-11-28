using Ganss.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Common.Helper.ExcelHelper
{
    public static class ImportExcelHelper
    {
        /// <summary>
        /// 获取Excel对应的实体，并删除上传的Excel文件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static IEnumerable<T> ExcelMapper<T>(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"找不到excel文件，路径为{filePath}");
            }
            var result = GetInstance(filePath).Fetch<T>();
            File.Delete(filePath);
            return result;
        }

        public static IEnumerable ExcelMapper<T>(Stream fileStream, string sheetName)
        {
            return GetInstance().Fetch(fileStream, typeof(T), sheetName);
        }

        private static ExcelMapper GetInstance(string filePath)
        {
            return new ExcelMapper(filePath);
        }

        private static ExcelMapper GetInstance()
        {
            return new ExcelMapper();
        }
    }
}
