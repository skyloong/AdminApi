using Common.Helper;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Casbin.Adapter.EFCore;
using Microsoft.EntityFrameworkCore;
using NetCasbin;

namespace Artisan.Seed
{
    public class PermissionSeeder
    {
        private string _connection = "Data Source=127.0.0.1;Initial Catalog=Test;User ID=sa;Password=123456;Trusted_Connection=false;";
        private string _confPath = Path.Combine(AppContext.BaseDirectory, $"config{Path.DirectorySeparatorChar}rbac_model.conf");
        public void Run()
        {
            var helper = new CasbinHelper(_connection, _confPath);

            using (var context = new ApplicationDbContext())
            {
                helper.AddRoleForUser(context.AdminUsers.Single(a => a.Account == "sysmanager").Id, context.Roles.Single(a => a.Name == "超级管理员").Id);
                helper.AddRoleForUser(context.AdminUsers.Single(a => a.Account == "user1").Id, context.Roles.Single(a => a.Name == "管理员").Id);
                helper.AddRoleForUser(context.AdminUsers.Single(a => a.Account == "user2").Id, context.Roles.Single(a => a.Name == "普通用户").Id);
                helper.AddButtonForRole(context.Roles.Single(a => a.Name == "管理员").Id, context.Buttons.Single(a => a.Url == "/Menus/Create").Id);
                helper.AddButtonForRole(context.Roles.Single(a => a.Name == "管理员").Id, context.Buttons.Single(a => a.Url == "/Menus/Edit").Id);
                helper.AddButtonForRole(context.Roles.Single(a => a.Name == "管理员").Id, context.Buttons.Single(a => a.Url == "/Menus/Delete").Id);
                helper.AddButtonForRole(context.Roles.Single(a => a.Name == "管理员").Id, context.Buttons.Single(a => a.Url == "/Menus/Search").Id);
                helper.AddMenuForRole(context.Roles.Single(a => a.Name == "管理员").Id, context.Menus.Where(a => a.Name == "菜单设置").Select(a => a.Id).Single());

                helper.AddButtonForRole(context.Roles.Single(a => a.Name == "管理员").Id, context.Buttons.Single(a => a.Url == "/Buttons/Create").Id);
                helper.AddButtonForRole(context.Roles.Single(a => a.Name == "管理员").Id, context.Buttons.Single(a => a.Url == "/Buttons/Edit").Id);
                helper.AddButtonForRole(context.Roles.Single(a => a.Name == "管理员").Id, context.Buttons.Single(a => a.Url == "/Buttons/Delete").Id);
                helper.AddButtonForRole(context.Roles.Single(a => a.Name == "管理员").Id, context.Buttons.Single(a => a.Url == "/Buttons/Search").Id);
                helper.AddMenuForRole(context.Roles.Single(a => a.Name == "管理员").Id, context.Menus.Where(a => a.Name == "按钮设置").Select(a => a.Id).Single());
                helper.AddMenuForRole(context.Roles.Single(a => a.Name == "管理员").Id, context.Menus.Where(a => a.Name == "系统设置").Select(a => a.Id).Single());
            }
        }

        public void Test()
        {
            var helper = new CasbinHelper(_connection, _confPath);

            using (var context = new ApplicationDbContext())
            {
                var options = new DbContextOptionsBuilder<CasbinDbContext<int>>()
               .UseSqlServer(_connection)
               .Options;
                using (var casbinContext = new CasbinDbContext<int>(options))
                {
                    var efCoreAdapter = new EFCoreAdapter<int>(casbinContext);
                    var e = new Enforcer(_confPath, efCoreAdapter);
                    Console.WriteLine(e.Enforce(context.AdminUsers.Single(a => a.Account == "user1").Id, context.Buttons.Single(a => a.Url == "/Menus/Search").Id));
                    Console.WriteLine(e.HasPermissionForUser(context.Roles.Single(a => a.Name == "管理员").Id, context.Buttons.Single(a => a.Url == "/Menus/Search").Id));
                    var fuck = e.GetPermissionsForUser(context.Roles.Single(a => a.Name == "管理员").Id).Aggregate((curr, next) =>
                    {
                        curr.Add(next[1]);
                        return curr;
                    });
                    context.Menus.Where(a => fuck.Contains(a.Id)).ToList().ForEach(item =>
                    {
                        Console.WriteLine(item.Name);
                    });
                    Console.WriteLine(e.GetPermissionsForUser(context.Roles.Single(a => a.Name == "管理员").Id).Count);
                }
                
            }
        }
    }
}
