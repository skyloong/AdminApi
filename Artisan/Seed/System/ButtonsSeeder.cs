using Model.Models.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artisan.Seed.System
{
    public class ButtonsSeeder
    {
        public void Run()
        {
            using (var context = new ApplicationDbContext())
            {
                var buttons = new List<MenuButton>();
                buttons.Add(new MenuButton
                {
                    Id = "8DD5C0BE-3913-42CF-8992-119358B40885",
                    Name = "新增",
                    Url = "/test/add",
                    MenuId = "0109046E-BC29-4CCB-B972-DF51A6F85D39"
                });
                buttons.Add(new MenuButton
                {
                    Id = "DEB403F5-FBED-4026-920D-ED45F3CFEA2B",
                    Name = "修改",
                    Url = "/test/edit",
                    MenuId = "0109046E-BC29-4CCB-B972-DF51A6F85D39"
                });
                buttons.Add(new MenuButton
                {
                    Id = "5366A9FD-7D0D-49E4-A00C-F394215768AE",
                    Name = "删除",
                    Url = "/test/delete",
                    MenuId = "0109046E-BC29-4CCB-B972-DF51A6F85D39"
                });
                buttons.Add(new MenuButton
                {
                    Id = "3E968DFB-928E-4F7E-A8AE-267E2417AF38",
                    Name = "导出",
                    Url = "/test/export",
                    MenuId = "0109046E-BC29-4CCB-B972-DF51A6F85D39"
                });
                context.Buttons.AddRange(buttons);
                context.SaveChanges();
            }
        }
    }
}
