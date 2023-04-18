using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaborProtection.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddedDateProperies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Lamps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Lamps",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Bulbs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Bulbs",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Lamps");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Lamps");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Bulbs");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Bulbs");
        }
    }
}
