using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaborProtection.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDefaultData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 20, 18, 49, 232, DateTimeKind.Local).AddTicks(3697));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 20, 18, 49, 232, DateTimeKind.Local).AddTicks(3719));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 20, 18, 49, 232, DateTimeKind.Local).AddTicks(3722));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 20, 18, 49, 232, DateTimeKind.Local).AddTicks(3726));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 20, 18, 49, 232, DateTimeKind.Local).AddTicks(3729));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 20, 18, 49, 232, DateTimeKind.Local).AddTicks(3732));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 20, 18, 49, 232, DateTimeKind.Local).AddTicks(3735));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 20, 18, 49, 232, DateTimeKind.Local).AddTicks(3738));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 20, 18, 49, 232, DateTimeKind.Local).AddTicks(3742));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 20, 18, 49, 232, DateTimeKind.Local).AddTicks(3745));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 20, 18, 49, 232, DateTimeKind.Local).AddTicks(3748));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 20, 18, 49, 232, DateTimeKind.Local).AddTicks(3751));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 20, 18, 49, 232, DateTimeKind.Local).AddTicks(3754));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 20, 18, 49, 232, DateTimeKind.Local).AddTicks(3757));

            migrationBuilder.UpdateData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 20, 18, 49, 232, DateTimeKind.Local).AddTicks(2361));

            migrationBuilder.UpdateData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 20, 18, 49, 232, DateTimeKind.Local).AddTicks(2415));

            migrationBuilder.UpdateData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 20, 18, 49, 232, DateTimeKind.Local).AddTicks(2420));

            migrationBuilder.UpdateData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 20, 18, 49, 232, DateTimeKind.Local).AddTicks(2423));

            migrationBuilder.UpdateData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 20, 18, 49, 232, DateTimeKind.Local).AddTicks(2426));

            migrationBuilder.UpdateData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedOn", "ImagePath" },
                values: new object[] { new DateTime(2023, 5, 10, 20, 18, 49, 232, DateTimeKind.Local).AddTicks(2429), "Images/Brille BS-02.jpg" });

            migrationBuilder.UpdateData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedOn", "ImagePath" },
                values: new object[] { new DateTime(2023, 5, 10, 20, 18, 49, 232, DateTimeKind.Local).AddTicks(2432), "Images/MAGNUM PLF 30.jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 14, 35, 21, 807, DateTimeKind.Local).AddTicks(4463));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 14, 35, 21, 807, DateTimeKind.Local).AddTicks(4480));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 14, 35, 21, 807, DateTimeKind.Local).AddTicks(4484));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 14, 35, 21, 807, DateTimeKind.Local).AddTicks(4487));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 14, 35, 21, 807, DateTimeKind.Local).AddTicks(4490));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 14, 35, 21, 807, DateTimeKind.Local).AddTicks(4493));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 14, 35, 21, 807, DateTimeKind.Local).AddTicks(4496));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 14, 35, 21, 807, DateTimeKind.Local).AddTicks(4499));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 14, 35, 21, 807, DateTimeKind.Local).AddTicks(4502));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 14, 35, 21, 807, DateTimeKind.Local).AddTicks(4505));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 14, 35, 21, 807, DateTimeKind.Local).AddTicks(4508));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 14, 35, 21, 807, DateTimeKind.Local).AddTicks(4510));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 14, 35, 21, 807, DateTimeKind.Local).AddTicks(4513));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 14, 35, 21, 807, DateTimeKind.Local).AddTicks(4516));

            migrationBuilder.UpdateData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 14, 35, 21, 807, DateTimeKind.Local).AddTicks(3384));

            migrationBuilder.UpdateData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 14, 35, 21, 807, DateTimeKind.Local).AddTicks(3439));

            migrationBuilder.UpdateData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 14, 35, 21, 807, DateTimeKind.Local).AddTicks(3442));

            migrationBuilder.UpdateData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 14, 35, 21, 807, DateTimeKind.Local).AddTicks(3445));

            migrationBuilder.UpdateData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 14, 35, 21, 807, DateTimeKind.Local).AddTicks(3448));

            migrationBuilder.UpdateData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedOn", "ImagePath" },
                values: new object[] { new DateTime(2023, 5, 10, 14, 35, 21, 807, DateTimeKind.Local).AddTicks(3451), "Images/Brille BS-02.png" });

            migrationBuilder.UpdateData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedOn", "ImagePath" },
                values: new object[] { new DateTime(2023, 5, 10, 14, 35, 21, 807, DateTimeKind.Local).AddTicks(3454), "Images/MAGNUM PLF 30.png" });
        }
    }
}
