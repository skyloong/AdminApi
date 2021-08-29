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
    }
}
