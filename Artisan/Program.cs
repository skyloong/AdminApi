using Artisan.Seed;
using Artisan.Seed.System;
using Microsoft.EntityFrameworkCore;
using Model.Models.System;
using System;
using System.Collections.Generic;

namespace Artisan
{
    class Program
    {
        static void Main(string[] args)
        {
            new MenuSeeder().Run();
            new ButtonsSeeder().Run();
            new RoleSeeder().Run();
            new AdminUserSeeder().Run();
            new PermissionSeeder().Run();
            new RoleMenuSeeder().Run();
        }
    }
}
