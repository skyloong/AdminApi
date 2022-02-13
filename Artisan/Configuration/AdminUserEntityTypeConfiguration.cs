using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Models.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artisan.Configuration
{
    public class AdminUserEntityTypeConfiguration : IEntityTypeConfiguration<AdminUser>
    {
        public void Configure(EntityTypeBuilder<AdminUser> builder)
        {
            builder.ToTable("sys_users");
            builder.Property(s => s.Id)
                .HasMaxLength(36)
                .HasDefaultValueSql("newid()")
                .IsRequired();
            builder.Property(s => s.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("getdate()");
            builder.Property(s => s.UpdatedAt)
                .IsRequired()
                .HasDefaultValueSql("getdate()");
            builder.Property(a => a.CreatedBy)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(a => a.UpdatedBy)
                .IsRequired()
                .HasMaxLength(50)
                .HasDefaultValue("");

            builder.Property(s => s.Account)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(s => s.Name)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(s => s.Password)
                .HasMaxLength(300)
                .IsRequired();
            builder.Property(s => s.Email)
                .HasMaxLength(300)
                .IsRequired()
                .HasDefaultValue("");
            builder.Property(s => s.MobilePhone)
                .HasMaxLength(20)
                .IsRequired()
                .HasDefaultValue("");
            builder.Property(s => s.Remark)
                .HasMaxLength(300)
                .IsRequired()
                .HasDefaultValue("");
            builder.Property(s => s.LocalCityId)
                .HasMaxLength(36)
                .IsRequired()
                .HasDefaultValue("");
            builder.Property(s => s.DeptId)
                .HasMaxLength(36)
                .IsRequired()
                .HasDefaultValue("");
            builder.Property(s => s.ModifyPwdDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
            builder.Property(s => s.LastLoginDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
            builder.Property(s => s.IsUse)
                .HasColumnType("tinyint")
                .IsRequired()
                .HasDefaultValue(1);

            builder.HasKey(a => a.Id);
        }
    }
}
