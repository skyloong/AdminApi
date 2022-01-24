using Microsoft.EntityFrameworkCore.Migrations;

namespace Artisan.Migrations
{
    public partial class AddIsAuthorizeForButton : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "IsGroup",
                table: "sys_menus",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0,
                comment: "是否是父节点，前端显示菜单判断用",
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldDefaultValue: (byte)0,
                oldComment: "是否是父节点");

            migrationBuilder.AddColumn<byte>(
                name: "IsAuthorize",
                table: "sys_buttons",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)1,
                comment: "是否需要授权");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAuthorize",
                table: "sys_buttons");

            migrationBuilder.AlterColumn<byte>(
                name: "IsGroup",
                table: "sys_menus",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0,
                comment: "是否是父节点",
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldDefaultValue: (byte)0,
                oldComment: "是否是父节点，前端显示菜单判断用");
        }
    }
}
