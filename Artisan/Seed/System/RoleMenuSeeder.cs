using Model.Models.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artisan.Seed.System
{
    public class RoleMenuSeeder
    {
        public void Run()
        {
            using (var context = new ApplicationDbContext())
            {
                var menus = new List<RoleMenu>();
                menus.Add(new RoleMenu
                {
                   RoleId = context.Roles.Single(a => a.Name == "管理员").Id,
                   MenuId = context.Menus.Where(a => a.Name == "系统设置").Select(a => a.Id).Single(),
                   CreatedBy = "sysmanager"
                });
                menus.Add(new RoleMenu
                {
                    RoleId = context.Roles.Single(a => a.Name == "管理员").Id,
                    MenuId = context.Menus.Where(a => a.Name == "菜单设置").Select(a => a.Id).Single(),
                    CreatedBy = "sysmanager"
                });
                menus.Add(new RoleMenu
                {
                    RoleId = context.Roles.Single(a => a.Name == "管理员").Id,
                    MenuId = context.Menus.Where(a => a.Name == "按钮设置").Select(a => a.Id).Single(),
                    CreatedBy = "sysmanager"
                });
                context.RoleMenus.AddRange(menus);
                context.SaveChanges();
            }
        }
    }
}
