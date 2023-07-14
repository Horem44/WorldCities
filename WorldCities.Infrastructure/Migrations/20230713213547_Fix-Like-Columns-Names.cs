using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldCities.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixLikeColumnsNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_AspNetUsers_UserId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Cities_CityId",
                table: "Likes");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Likes",
                newName: "UserGuid");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Likes",
                newName: "CityGuid");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                newName: "IX_Likes_UserGuid");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_CityId",
                table: "Likes",
                newName: "IX_Likes_CityGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_AspNetUsers_UserGuid",
                table: "Likes",
                column: "UserGuid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Cities_CityGuid",
                table: "Likes",
                column: "CityGuid",
                principalTable: "Cities",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_AspNetUsers_UserGuid",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Cities_CityGuid",
                table: "Likes");

            migrationBuilder.RenameColumn(
                name: "UserGuid",
                table: "Likes",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "CityGuid",
                table: "Likes",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_UserGuid",
                table: "Likes",
                newName: "IX_Likes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_CityGuid",
                table: "Likes",
                newName: "IX_Likes_CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_AspNetUsers_UserId",
                table: "Likes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Cities_CityId",
                table: "Likes",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
