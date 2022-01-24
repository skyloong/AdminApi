using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace IRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        bool Insert(IEnumerable<TEntity> entities);
        TEntity Find(Expression<Func<TEntity, bool>> where);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
    }
}
