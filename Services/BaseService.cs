using AutoMapper;
using Common.Helper.ExcelHelper;
using IRepository;
using IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {
        public IBaseRepository<TEntity> BaseDal;
        protected IMapper Mapper;
        
        public IEnumerable<TEntity> ExcelToEntity<T>(string filePath)
        {
            var excelEntities = ImportExcelHelper.ExcelMapper<T>(filePath);
            return Mapper.Map<IEnumerable<T>, IEnumerable<TEntity>>(excelEntities);
        }

        public bool ImportExcel<T>(string filePath)
        {
            return Insert(ExcelToEntity<T>(filePath));
        }

        #region 数据库插入操作
        public bool Insert(IEnumerable<TEntity> entities)
        {
            return BaseDal.Insert(entities);
        }
        #endregion
    }
}
