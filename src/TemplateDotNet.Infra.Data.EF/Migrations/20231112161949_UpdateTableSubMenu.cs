using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TemplateDotNet.Infra.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableSubMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "path",
                table: "sub_menus",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "path",
                table: "sub_menus");
        }
    }
}
