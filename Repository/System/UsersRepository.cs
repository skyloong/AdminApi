using IRepository.System;
using IRepository.UnitOfWork;
using Model.Models.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.System
{
    public class UsersRepository : BaseRepository<AdminUser>, IUsersRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsersRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
