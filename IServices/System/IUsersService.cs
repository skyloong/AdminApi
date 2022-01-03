using Model.Models.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace IServices.System
{
    public interface IUsersService : IBaseService<AdminUser>
    {
        AdminUser Find(string usercode);
    }
}
