using Artisan.Configuration;
using Microsoft.EntityFrameworkCore;
using Model.Models.System;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Artisan
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuButton> Buttons { get; set; }
        public DbSet<RoleMenu> RoleMenus { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=127.0.0.1;Initial Catalog=Test;User ID=sa;Password=123456;Trusted_Connection=false;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdminUserEntityTypeConfiguration).Assembly);
        }
    }
}
