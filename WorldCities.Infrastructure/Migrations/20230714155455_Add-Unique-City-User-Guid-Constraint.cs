using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldCities.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueCityUserGuidConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Likes_CityGuid",
                table: "Likes");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_CityGuid_UserGuid",
                table: "Likes",
                columns: new[] { "CityGuid", "UserGuid" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Likes_CityGuid_UserGuid",
                table: "Likes");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_CityGuid",
                table: "Likes",
                column: "CityGuid");
        }
    }
}
