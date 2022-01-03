using Common.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Artisan.Seed
{
    public class PermissionSeeder
    {
        public void Run()
        {
            var connection = "Data Source=127.0.0.1;Initial Catalog=Test;User ID=sa;Password=123456;Trusted_Connection=false;";
            var confPath = Path.Combine(AppContext.BaseDirectory, $"config{Path.DirectorySeparatorChar}rbac_model.conf");
            var helper = new CasbinHelper(connection, confPath);

            helper.AddRoleForUser("C11DA582-3824-4992-A036-5C021DB833E4", "C4589779-AE52-4A27-9A9B-795501C13FFD");//sky 超管
            helper.AddRoleForUser("E6070FD3-8973-446F-AF2D-CFF1DB3035DD", "C4589779-AE52-4A27-9A9B-795501C13FFD");//loong 超管
            helper.AddRoleForUser("C11DA582-3824-4992-A036-5C021DB833E4", "10CF3A92-9227-421D-A2EB-4946E25CC6ED");//sky 县级管理员
            helper.AddRoleForUser("E6070FD3-8973-446F-AF2D-CFF1DB3035DD", "2A40A0A0-6E77-4D11-8EB8-6B9CEA5BF2CD");//loong 超管
            helper.AddButtonForRole("C4589779-AE52-4A27-9A9B-795501C13FFD", "8DD5C0BE-3913-42CF-8992-119358B40885");//超管 新增
            helper.AddButtonForRole("C4589779-AE52-4A27-9A9B-795501C13FFD", "DEB403F5-FBED-4026-920D-ED45F3CFEA2B");//超管 修改
            helper.AddButtonForRole("C4589779-AE52-4A27-9A9B-795501C13FFD", "5366A9FD-7D0D-49E4-A00C-F394215768AE");//超管 删除
            helper.AddButtonForRole("10CF3A92-9227-421D-A2EB-4946E25CC6ED", "DEB403F5-FBED-4026-920D-ED45F3CFEA2B");//管理员 删除
            helper.AddMenuForRole("10CF3A92-9227-421D-A2EB-4946E25CC6ED", "0109046E-BC29-4CCB-B972-DF51A6F85D39");//管理员 删除
        }
    }
}
