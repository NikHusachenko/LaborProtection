using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LaborProtection.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultLampAndBulbsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bulbs",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "LightFlux", "Name", "Power", "Price", "Type", "Voltage" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(3827), null, 1060, "ЛБ18", (short)18, 18f, 1, (short)57 },
                    { 2L, new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(3848), null, 880, "ЛД18", (short)18, 13f, 2, (short)57 },
                    { 3L, new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(3852), null, 1060, "ЛБ20", (short)20, 20f, 1, (short)57 },
                    { 4L, new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(3855), null, 1060, "ЛБ20-2", (short)20, 22f, 1, (short)65 },
                    { 5L, new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(3858), null, 880, "ЛД20-2", (short)20, 12f, 2, (short)65 },
                    { 6L, new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(3861), null, 2020, "ЛБ30", (short)30, 26f, 1, (short)106 },
                    { 7L, new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(3864), null, 1980, "ЛБУ30", (short)30, 25f, 3, (short)104 },
                    { 8L, new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(3867), null, 2800, "ЛБ36", (short)36, 28f, 1, (short)103 },
                    { 9L, new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(3869), null, 2800, "ЛБ40", (short)40, 42f, 1, (short)103 },
                    { 10L, new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(3872), null, 3000, "ЛБ40-2", (short)40, 40f, 1, (short)110 },
                    { 11L, new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(3875), null, 2300, "ЛД40-2", (short)40, 40f, 2, (short)110 },
                    { 12L, new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(3877), null, 4600, "ЛБ65", (short)65, 45f, 1, (short)110 },
                    { 13L, new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(3880), null, 5200, "ЛБ80", (short)80, 45f, 1, (short)99 },
                    { 14L, new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(3883), null, 4250, "ЛД80", (short)80, 42f, 2, (short)105 }
                });

            migrationBuilder.InsertData(
                table: "Lamps",
                columns: new[] { "Id", "BulbCount", "CreatedOn", "DeletedOn", "Height", "ImagePath", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { 1L, 4, new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(2616), null, 300f, "Images//Image/EGLO 31756.png", "EGLO 31756", 1928f, 3 },
                    { 2L, 2, new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(2681), null, 650f, "Images//Image/Laguna Lightning.png", "Laguna Lightning", 1800f, 4 },
                    { 3L, 4, new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(2688), null, 350f, "Images//Image/BS-24.png", "BS-24", 479f, 3 },
                    { 4L, 3, new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(2693), null, 700f, "Images//Image/Sign 48.png", "Sign 48", 1169f, 4 },
                    { 5L, 3, new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(2698), null, 150f, "Images//Image/EuroLight.png", "EuroLight", 653f, 2 },
                    { 6L, 2, new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(2702), null, 200f, "Images//Image/Brille BS-02.png", "Brille BS-02", 419f, 1 },
                    { 7L, 2, new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(2706), null, 180f, "Images//Image/MAGNUM PLF 30.png", "MAGNUM PLF 30", 267f, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: 7L);
        }
    }
}
