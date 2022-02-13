using Model.Models.System;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Artisan.Seed.System
{
    public class ButtonsSeeder
    {
        public void Run()
        {
            using (var context = new ApplicationDbContext())
            {
                var menu = context.Menus.Single(a => a.Name == "菜单设置");
                var buttons = new List<MenuButton>();
                buttons.Add(new MenuButton
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "新增",
                    Url = "/Menus/Create",
                    FrontUrl = "",
                    Action = "post",
                    Icon = "plus-thick",
                    MenuId = menu.Id,
                    CreatedBy = "sysmanager"
                });
                buttons.Add(new MenuButton
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "修改",
                    Url = "/Menus/Edit",
                    Action = "put",
                    Icon = "pencil",
                    MenuId = menu.Id,
                    CreatedBy = "sysmanager"
                });
                buttons.Add(new MenuButton
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "删除",
                    Url = "/Menus/Delete",
                    Action = "delete",
                    Icon = "delete",
                    MenuId = menu.Id,
                    CreatedBy = "sysmanager"
                });
                buttons.Add(new MenuButton
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "查询",
                    Url = "/Menus/Search",
                    Action = "get",
                    Icon = "magnify",
                    MenuId = menu.Id,
                    CreatedBy = "sysmanager"
                });
                var button = context.Menus.Single(a => a.Name == "按钮设置");
                buttons.Add(new MenuButton
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "新增",
                    Url = "/Buttons/Create",
                    FrontUrl = "",
                    Action = "post",
                    Icon = "plus-thick",
                    MenuId = button.Id,
                    CreatedBy = "sysmanager"
                });
                buttons.Add(new MenuButton
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "修改",
                    Url = "/Buttons/Edit",
                    Action = "put",
                    Icon = "pencil",
                    MenuId = button.Id,
                    CreatedBy = "sysmanager"
                });
                buttons.Add(new MenuButton
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "删除",
                    Url = "/Buttons/Delete",
                    Action = "delete",
                    Icon = "delete",
                    MenuId = button.Id,
                    CreatedBy = "sysmanager"
                });
                buttons.Add(new MenuButton
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "查询",
                    Url = "/Buttons/Search",
                    Action = "get",
                    Icon = "magnify",
                    MenuId = button.Id,
                    CreatedBy = "sysmanager"
                });
                context.Buttons.AddRange(buttons);
                context.SaveChanges();
            }
        }
    }
}
