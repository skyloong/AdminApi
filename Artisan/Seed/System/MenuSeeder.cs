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
                menus.Add(new Menu
                {
                    Id = "7B81DCC5-0320-4FB0-8F5D-F5DBB1F9FBCE",
                    Name = "首页",
                    Icon = "",
                    Url = "",
                });
                menus.Add(new Menu
                {
                    Id = "0109046E-BC29-4CCB-B972-DF51A6F85D39",
                    Name = "用户",
                    Icon = "",
                    Url = "/test/index",
                });
                menus.Add(new Menu
                {
                    Id = "09CC2309-85AC-4D33-9A65-54DAC82C1384",
                    Name = "班级",
                    Icon = "",
                    Url = "",
                });
                menus.Add(new Menu
                {
                    Id = "5E7242E6-C75E-4D05-B31D-800692B0C9BE",
                    Name = "按钮列表",
                    Icon = "",
                    Url = "/home/getbuttons",
                });
                context.AddRange(menus);
                context.SaveChanges();
            }
        }
    }
}
