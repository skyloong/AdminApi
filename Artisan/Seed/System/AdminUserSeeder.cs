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
                    Id = "C11DA582-3824-4992-A036-5C021DB833E4",
                    Account = "sky",
                    Name = "sky",
                    Password = "1233",
                });
                users.Add(new AdminUser
                {
                    Id = "E6070FD3-8973-446F-AF2D-CFF1DB3035DD",
                    Account = "loong",
                    Name = "loong",
                    Password = "1233",
                });
                users.Add(new AdminUser
                {
                    Id = "20E7F7A0-2118-4EAF-8696-B957211A89F3",
                    Account = "skyloong",
                    Name = "skyloong",
                    Password = "1233",
                });
                users.Add(new AdminUser
                {
                    Id = "AFBF0322-A354-4F16-8E4E-5490380AC0D0",
                    Account = "ltl",
                    Name = "ltl",
                    Password = "1233",
                });
                users.Add(new AdminUser
                {
                    Id = "94096D52-13B4-44EC-8C64-01CB5BA94341",
                    Account = "lil",
                    Name = "lil",
                    Password = "1233",
                });
                context.AdminUsers.AddRange(users);
                context.SaveChanges();
            }
        }
    }
}
