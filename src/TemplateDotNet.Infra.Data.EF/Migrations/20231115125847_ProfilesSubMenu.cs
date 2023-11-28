using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TemplateDotNet.Infra.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class ProfilesSubMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "profiles_sub_menus",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    idprofile = table.Column<Guid>(name: "id_profile", type: "uuid", nullable: false),
                    idsubmenu = table.Column<Guid>(name: "id_sub_menu", type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profiles_sub_menus", x => x.id);
                    table.ForeignKey(
                        name: "FK_profiles_sub_menus_profiles_id_profile",
                        column: x => x.idprofile,
                        principalTable: "profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_profiles_sub_menus_sub_menus_id_sub_menu",
                        column: x => x.idsubmenu,
                        principalTable: "sub_menus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_profiles_sub_menus_id_profile",
                table: "profiles_sub_menus",
                column: "id_profile");

            migrationBuilder.CreateIndex(
                name: "IX_profiles_sub_menus_id_sub_menu",
                table: "profiles_sub_menus",
                column: "id_sub_menu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "profiles_sub_menus");
        }
    }
}
