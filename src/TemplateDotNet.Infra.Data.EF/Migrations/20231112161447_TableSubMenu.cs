using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TemplateDotNet.Infra.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class TableSubMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sub_menus",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    idmenu = table.Column<Guid>(name: "id_menu", type: "uuid", nullable: false),
                    icon = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sub_menus", x => x.id);
                    table.ForeignKey(
                        name: "FK_sub_menus_menus_id_menu",
                        column: x => x.idmenu,
                        principalTable: "menus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sub_menus_id_menu",
                table: "sub_menus",
                column: "id_menu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sub_menus");
        }
    }
}
