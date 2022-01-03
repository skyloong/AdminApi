using IRepository.System;
using IServices.System;
using Model.Models.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.System
{
    public class UsersService : BaseService<AdminUser>, IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
            base.BaseDal = usersRepository;
        }

        public AdminUser Find(string usercode)
        {
            return BaseDal.Find(user => user.Account == usercode);
        }
    }
}
