using Model.Models.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artisan.Seed.System
{
    public class AdminUserSeeder
    {
        public void Run()
        {
            using (var context = new ApplicationDbContext())
            {
                var users = new List<AdminUser>();
                users.Add(new AdminUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Account = "sysmanager",
                    Name = "管理员",
                    Password = "123456",
                });
                users.Add(new AdminUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Account = "user1",
                    Name = "派大星",
                    Password = "123456",
                });
                users.Add(new AdminUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Account = "user2",
                    Name = "海绵宝宝",
                    Password = "123456",
                });
                context.AdminUsers.AddRange(users);
                context.SaveChanges();
            }
        }
    }
}
