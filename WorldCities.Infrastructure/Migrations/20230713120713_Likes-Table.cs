using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldCities.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LikesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table =>
                    new
                    {
                        Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Likes_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(name: "IX_Likes_CityId", table: "Likes", column: "CityId");

            migrationBuilder.CreateIndex(name: "IX_Likes_UserId", table: "Likes", column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Likes");
        }
    }
}
