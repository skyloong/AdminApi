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
                    Id = Guid.NewGuid().ToString(),
                    Name = "超级管理员",
                    CreatedBy = "sysmanager"
                });
                roles.Add(new Role
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "管理员",
                    CreatedBy = "sysmanager"
                });
                roles.Add(new Role
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "普通用户",
                    CreatedBy = "sysmanager"
                });
                context.Roles.AddRange(roles);
                context.SaveChanges();
            }
        }
    }
}
