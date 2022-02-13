using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Models.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artisan.Configuration
{
    public class ButtonEntityTypeConfiguration : IEntityTypeConfiguration<MenuButton>
    {
        public void Configure(EntityTypeBuilder<MenuButton> builder)
        {
            builder.ToTable("sys_buttons");
            builder.Property(a => a.Id)
                .HasMaxLength(36)
                .HasDefaultValueSql("newid()")
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

            builder.Property(a => a.MenuId)
                .IsRequired()
                .HasMaxLength(36);
            builder.Property(a => a.Name)
                .HasMaxLength(300)
                .IsRequired();
            builder.Property(a => a.Url)
                .HasMaxLength(500)
                .IsRequired();
            builder.Property(a => a.FrontUrl)
                .HasMaxLength(500)
                .IsRequired()
                .HasDefaultValue("");
            builder.Property(a => a.Action)
                .HasMaxLength(20)
                .IsRequired()
                .HasDefaultValue("");
            builder.Property(a => a.Icon)
                .HasMaxLength(50)
                .IsRequired()
                .HasDefaultValue("");
            builder.Property(a => a.Sort);
            builder.Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(300)
                .HasDefaultValue("");
            builder.Property(a => a.IsUse)
                .HasColumnType("tinyint")
                .IsRequired()
                .HasDefaultValue(1);
            builder.Property(a => a.IsAuthorize)
                .HasColumnType("tinyint")
                .IsRequired()
                .HasDefaultValue(1)
                .HasComment("是否需要授权");

            builder.HasKey(a => a.Id);
        }
    }
}
