using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Models.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artisan.Configuration
{
    public class MenuEntityTypeConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("sys_menus");
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
            builder.Property(a => a.CreatedBy)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(a => a.UpdatedBy)
                .IsRequired()
                .HasMaxLength(50)
                .HasDefaultValue("");

            builder.Property(a => a.ParentId)
                .HasMaxLength(36)
                .IsRequired()
                .HasDefaultValue("");
            builder.Property(a => a.Name)
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(a => a.Icon)
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(a => a.Url)
                .HasMaxLength(300)
                .IsRequired();
            builder.Property(a => a.Path)
                .HasMaxLength(300)
                .IsRequired();
            builder.Property(a => a.Sort);
            builder.Property(a => a.IsAuthorize)
                .HasColumnType("tinyint")
                .IsRequired()
                .HasDefaultValue(1)
                .HasComment("是否需要授权");
            builder.Property(a => a.IsGroup)
                .HasColumnType("tinyint")
                .IsRequired()
                .HasDefaultValue(0)
                .HasComment("是否是父节点，前端显示菜单判断用");
            builder.Property(a => a.IsUse)
                .HasColumnType("tinyint")
                .IsRequired()
                .HasDefaultValue(1);
            builder.Property(a => a.Description)
                .IsRequired()
                .HasDefaultValue("");

            builder.HasKey(a => a.Id);
        }
    }
}
