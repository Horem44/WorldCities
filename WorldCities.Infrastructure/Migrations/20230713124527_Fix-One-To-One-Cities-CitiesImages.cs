using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldCities.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixOneToOneCitiesCitiesImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "CityGuid",
                table: "CitiesImages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_CitiesImages_CityGuid",
                table: "CitiesImages",
                column: "CityGuid"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CityImageGuid",
                table: "Cities",
                column: "CityImageGuid"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_CitiesImages_CityImageGuid",
                table: "Cities",
                column: "CityImageGuid",
                principalTable: "CitiesImages",
                principalColumn: "Guid"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_CitiesImages_Cities_CityGuid",
                table: "CitiesImages",
                column: "CityGuid",
                principalTable: "Cities",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_CitiesImages_CityImageGuid",
                table: "Cities"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_CitiesImages_Cities_CityGuid",
                table: "CitiesImages"
            );

            migrationBuilder.DropIndex(name: "IX_CitiesImages_CityGuid", table: "CitiesImages");

            migrationBuilder.DropIndex(name: "IX_Cities_CityImageGuid", table: "Cities");

            migrationBuilder.AlterColumn<Guid>(
                name: "CityGuid",
                table: "CitiesImages",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier"
            );
        }
    }
}
