using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaDbContext2.Migrations
{
    /// <inheritdoc />
    public partial class AddAgeAndDateMiseEnService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateMiseEnService",
                table: "Salles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "AgeMinimum",
                table: "Films",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateMiseEnService",
                table: "Salles");

            migrationBuilder.DropColumn(
                name: "AgeMinimum",
                table: "Films");
        }
    }
}
