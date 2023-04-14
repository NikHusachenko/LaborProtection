using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaborProtection.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddImagePathToLampEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Lamps",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Lamps");
        }
    }
}
