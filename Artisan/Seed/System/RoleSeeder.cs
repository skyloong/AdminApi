using Model.Models.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artisan.Seed.System
{
    public class RoleSeeder
    {
        public void Run()
        {
            using (var context = new ApplicationDbContext())
            {
                var roles = new List<Role>();
                roles.Add(new Role
                {
                    Id = "C4589779-AE52-4A27-9A9B-795501C13FFD",
                    Name = "超级管理员"
                });
                roles.Add(new Role
                {
                    Id = "10CF3A92-9227-421D-A2EB-4946E25CC6ED",
                    Name = "管理员"
                });
                roles.Add(new Role
                {
                    Id = "2A40A0A0-6E77-4D11-8EB8-6B9CEA5BF2CD",
                    Name = "县级管理员"
                });
                context.Roles.AddRange(roles);
                context.SaveChanges();
            }
        }
    }
}
