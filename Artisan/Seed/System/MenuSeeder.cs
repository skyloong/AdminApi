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
                    Icon = "mdi-cog",
                    Url = "",
                    Path = "/system",//vuetify展开对应菜单所需
                    IsGroup = true,
                    CreatedBy = "sysmanager"
                });
                menus.Add(new Menu
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "菜单设置",
                    Icon = "mdi-menu",
                    Url = "/Menus/Index",
                    Path = "/system/menu",
                    ParentId = groupId,
                    CreatedBy = "sysmanager"
                });
                menus.Add(new Menu
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "按钮设置",
                    Icon = "mdi-gesture-tap-button",
                    Url = "/Buttons/Index",
                    Path = "/system/button",
                    ParentId = groupId,
                    CreatedBy = "sysmanager"
                });
                context.AddRange(menus);
                context.SaveChanges();
            }
        }
    }
}
