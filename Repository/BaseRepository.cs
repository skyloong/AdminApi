using IRepository;
using IRepository.UnitOfWork;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ISqlSugarClient _db;

        internal ISqlSugarClient Db
        {
            get { return _db; }
        }

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _db = unitOfWork.GetDbClient();
        }

        public bool Insert(IEnumerable<TEntity> entities)
        {
            return _db.Insertable<TEntity>(entities).ExecuteCommand() > 0;
        }

        public TEntity Find(Expression<Func<TEntity, bool>> where)
        {
            return _db.Queryable<TEntity>()
                .Where(where)
                .First();
        }
    }
}
