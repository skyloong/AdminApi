using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Artisan.Migrations
{
    public partial class InitTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sys_buttons",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false, defaultValueSql: "newid()"),
                    MenuId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FrontUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    Action = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: ""),
                    Icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, defaultValue: ""),
                    IsUse = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    IsAuthorize = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1, comment: "是否需要授权"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_buttons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sys_menus",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false, defaultValueSql: "newid()"),
                    ParentId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false, defaultValue: ""),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Path = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    IsAuthorize = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1, comment: "是否需要授权"),
                    IsUse = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    IsGroup = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)0, comment: "是否是父节点，前端显示菜单判断用"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    MenuId = table.Column<string>(type: "nvarchar(36)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sys_menus_sys_menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "sys_menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sys_role_menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    MenuId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_role_menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sys_roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, defaultValue: ""),
                    IsUse = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1, comment: "1启用，0停用"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sys_users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false, defaultValueSql: "newid()"),
                    Account = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, defaultValue: ""),
                    MobilePhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: ""),
                    Remark = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, defaultValue: ""),
                    LocalCityId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false, defaultValue: ""),
                    DeptId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false, defaultValue: ""),
                    ModifyPwdDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    IsUse = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sys_menus_MenuId",
                table: "sys_menus",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_sys_role_menu_RoleId",
                table: "sys_role_menu",
                column: "RoleId")
                .Annotation("SqlServer:Include", new[] { "MenuId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sys_buttons");

            migrationBuilder.DropTable(
                name: "sys_menus");

            migrationBuilder.DropTable(
                name: "sys_role_menu");

            migrationBuilder.DropTable(
                name: "sys_roles");

            migrationBuilder.DropTable(
                name: "sys_users");
        }
    }
}
