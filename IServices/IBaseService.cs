using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace IServices
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> ExcelToEntity<T>(string filePath);

        bool ImportExcel<T>(string filePath);

        #region 数据库插入操作
        bool Insert(IEnumerable<TEntity> entities);
        #endregion

        #region 数据库查询
        TEntity Find(Expression<Func<TEntity, bool>> where);
        #endregion
    }
}
