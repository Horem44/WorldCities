using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldCities.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyCitiesUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUserCity",
                columns: table =>
                    new
                    {
                        CitiesGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "PK_ApplicationUserCity",
                        x => new { x.CitiesGuid, x.UsersId }
                    );
                    table.ForeignKey(
                        name: "FK_ApplicationUserCity_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_ApplicationUserCity_Cities_CitiesGuid",
                        column: x => x.CitiesGuid,
                        principalTable: "Cities",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserCity_UsersId",
                table: "ApplicationUserCity",
                column: "UsersId"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "ApplicationUserCity");
        }
    }
}
