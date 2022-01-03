using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Models.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artisan.Configuration
{
    public class RoleEntityTypeConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("sys_roles");
            builder.Property(a => a.Id)
                .HasMaxLength(36)
                .IsRequired()
                .HasDefaultValueSql("newid()");
            builder.Property(a => a.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("getdate()");
            builder.Property(a => a.UpdatedAt)
                .IsRequired()
                .HasDefaultValueSql("getdate()");
            builder.Property(a => a.Name)
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(a => a.Description)
                .HasMaxLength(255)
                .IsRequired()
                .HasDefaultValue("");
            builder.Property(a => a.IsUse)
                .HasColumnType("tinyint")
                .IsRequired()
                .HasComment("1启用，0停用")
                .HasDefaultValue(1);
            builder.Property(a => a.Sort)
                .HasComment("排序");

            builder.HasKey(a => a.Id);
        }
    }
}
