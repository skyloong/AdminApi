using Model.Models.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artisan.Seed.System
{
    public class MenuSeeder
    {
        public void Run()
        {
            using(var context = new ApplicationDbContext())
            {
                var menus = new List<Menu>();
                var groupId = Guid.NewGuid().ToString();
                menus.Add(new Menu
                {
                    Id = groupId,
                    Name = "系统设置",
                    Icon = "cog",
                    Url = "",
                    Path = "",
                    IsGroup = true
                });
                menus.Add(new Menu
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "菜单设置",
                    Icon = "",
                    Url = "/Menus/Index",
                    Path = "/system/menu",
                    ParentId = groupId
                });
                menus.Add(new Menu
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "按钮设置",
                    Icon = "",
                    Url = "/Buttons/Index",
                    Path = "/system/button",
                    ParentId = groupId
                });
                context.AddRange(menus);
                context.SaveChanges();
            }
        }
    }
}
