using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Models.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artisan.Configuration
{
    class RoleMenuEntityTypeConfiguration : IEntityTypeConfiguration<RoleMenu>
    {
        public void Configure(EntityTypeBuilder<RoleMenu> builder)
        {
            builder.ToTable("sys_role_menu");
            builder.Property(a => a.Id)
                .IsRequired();
            builder.Property(a => a.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("getdate()");
            builder.Property(a => a.UpdatedAt)
                .IsRequired()
                .HasDefaultValueSql("getdate()");
            builder.Property(a => a.CreatedBy)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(a => a.UpdatedBy)
                .IsRequired()
                .HasMaxLength(50)
                .HasDefaultValue("");

            builder.Property(a => a.RoleId)
                .HasMaxLength(36)
                .IsRequired();
            builder.Property(a => a.MenuId)
                .HasMaxLength(36)
                .IsRequired();

            builder.HasKey(a => a.Id);
            builder.HasIndex(a => a.RoleId)
                .IncludeProperties(a => a.MenuId);
        }
    }
}
