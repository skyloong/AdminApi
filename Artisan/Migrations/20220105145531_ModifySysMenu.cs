using Microsoft.EntityFrameworkCore.Migrations;

namespace Artisan.Migrations
{
    public partial class ModifySysMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Action",
                table: "sys_button",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FrontUrl",
                table: "sys_button",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "sys_button",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Action",
                table: "sys_button");

            migrationBuilder.DropColumn(
                name: "FrontUrl",
                table: "sys_button");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "sys_button");
        }
    }
}
