using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRepository.UnitOfWork
{
    public interface IUnitOfWork
    {
        SqlSugarClient GetDbClient();

        void BeginTran();

        void CommitTran();
        void RollbackTran();
    }
}
