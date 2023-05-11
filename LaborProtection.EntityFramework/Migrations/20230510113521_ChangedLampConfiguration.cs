using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaborProtection.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class ChangedLampConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "CreatedOn", "ImagePath" },
                values: new object[] { new DateTime(2023, 5, 10, 14, 35, 21, 807, DateTimeKind.Local).AddTicks(3384), "Images/EGLO 31756.png" });

            migrationBuilder.UpdateData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedOn", "ImagePath" },
                values: new object[] { new DateTime(2023, 5, 10, 14, 35, 21, 807, DateTimeKind.Local).AddTicks(3439), "Images/Laguna Lightning.png" });

            migrationBuilder.UpdateData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedOn", "ImagePath" },
                values: new object[] { new DateTime(2023, 5, 10, 14, 35, 21, 807, DateTimeKind.Local).AddTicks(3442), "Images/BS-24.png" });

            migrationBuilder.UpdateData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedOn", "ImagePath" },
                values: new object[] { new DateTime(2023, 5, 10, 14, 35, 21, 807, DateTimeKind.Local).AddTicks(3445), "Images/Sign 48.png" });

            migrationBuilder.UpdateData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedOn", "ImagePath" },
                values: new object[] { new DateTime(2023, 5, 10, 14, 35, 21, 807, DateTimeKind.Local).AddTicks(3448), "Images/EuroLight.png" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(3827));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(3848));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(3852));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(3855));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(3861));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(3864));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(3867));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(3869));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(3872));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(3875));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(3877));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(3880));

            migrationBuilder.UpdateData(
                table: "Bulbs",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedOn",
                value: new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(3883));

            migrationBuilder.UpdateData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "ImagePath" },
                values: new object[] { new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(2616), "Images//Image/EGLO 31756.png" });

            migrationBuilder.UpdateData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedOn", "ImagePath" },
                values: new object[] { new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(2681), "Images//Image/Laguna Lightning.png" });

            migrationBuilder.UpdateData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedOn", "ImagePath" },
                values: new object[] { new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(2688), "Images//Image/BS-24.png" });

            migrationBuilder.UpdateData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedOn", "ImagePath" },
                values: new object[] { new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(2693), "Images//Image/Sign 48.png" });

            migrationBuilder.UpdateData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedOn", "ImagePath" },
                values: new object[] { new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(2698), "Images//Image/EuroLight.png" });

            migrationBuilder.UpdateData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedOn", "ImagePath" },
                values: new object[] { new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(2702), "Images//Image/Brille BS-02.png" });

            migrationBuilder.UpdateData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedOn", "ImagePath" },
                values: new object[] { new DateTime(2023, 5, 10, 14, 31, 24, 176, DateTimeKind.Local).AddTicks(2706), "Images//Image/MAGNUM PLF 30.png" });
        }
    }
}
