using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldCities.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameGuidToId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserCountry_Countries_CountriesGuid",
                table: "ApplicationUserCountry");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_CitiesImages_CityImageGuid",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryGuid",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_CitiesImages_Cities_CityGuid",
                table: "CitiesImages");

            migrationBuilder.DropTable(
                name: "ApplicationUserCity");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CityImageGuid",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "Likes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "Countries",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CityGuid",
                table: "CitiesImages",
                newName: "CityId");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "CitiesImages",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_CitiesImages_CityGuid",
                table: "CitiesImages",
                newName: "IX_CitiesImages_CityId");

            migrationBuilder.RenameColumn(
                name: "CountryGuid",
                table: "Cities",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "CityImageGuid",
                table: "Cities",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "Cities",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_CountryGuid",
                table: "Cities",
                newName: "IX_Cities_CountryId");

            migrationBuilder.RenameColumn(
                name: "CountriesGuid",
                table: "ApplicationUserCountry",
                newName: "CountriesId");

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                table: "Cities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CityImageId",
                table: "Cities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ApplicationUserId",
                table: "Cities",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CityImageId",
                table: "Cities",
                column: "CityImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserCountry_Countries_CountriesId",
                table: "ApplicationUserCountry",
                column: "CountriesId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_AspNetUsers_ApplicationUserId",
                table: "Cities",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_CitiesImages_CityImageId",
                table: "Cities",
                column: "CityImageId",
                principalTable: "CitiesImages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CitiesImages_Cities_CityId",
                table: "CitiesImages",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserCountry_Countries_CountriesId",
                table: "ApplicationUserCountry");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_AspNetUsers_ApplicationUserId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_CitiesImages_CityImageId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_CitiesImages_Cities_CityId",
                table: "CitiesImages");

            migrationBuilder.DropIndex(
                name: "IX_Cities_ApplicationUserId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CityImageId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CityImageId",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Likes",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Countries",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "CitiesImages",
                newName: "CityGuid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CitiesImages",
                newName: "Guid");

            migrationBuilder.RenameIndex(
                name: "IX_CitiesImages_CityId",
                table: "CitiesImages",
                newName: "IX_CitiesImages_CityGuid");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Cities",
                newName: "CityImageGuid");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Cities",
                newName: "CountryGuid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cities",
                newName: "Guid");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                newName: "IX_Cities_CountryGuid");

            migrationBuilder.RenameColumn(
                name: "CountriesId",
                table: "ApplicationUserCountry",
                newName: "CountriesGuid");

            migrationBuilder.CreateTable(
                name: "ApplicationUserCity",
                columns: table => new
                {
                    CitiesGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserCity", x => new { x.CitiesGuid, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserCity_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserCity_Cities_CitiesGuid",
                        column: x => x.CitiesGuid,
                        principalTable: "Cities",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CityImageGuid",
                table: "Cities",
                column: "CityImageGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserCity_UsersId",
                table: "ApplicationUserCity",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserCountry_Countries_CountriesGuid",
                table: "ApplicationUserCountry",
                column: "CountriesGuid",
                principalTable: "Countries",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_CitiesImages_CityImageGuid",
                table: "Cities",
                column: "CityImageGuid",
                principalTable: "CitiesImages",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryGuid",
                table: "Cities",
                column: "CountryGuid",
                principalTable: "Countries",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CitiesImages_Cities_CityGuid",
                table: "CitiesImages",
                column: "CityGuid",
                principalTable: "Cities",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
