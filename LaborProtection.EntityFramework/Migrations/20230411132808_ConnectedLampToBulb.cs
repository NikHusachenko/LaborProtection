using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaborProtection.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class ConnectedLampToBulb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LambBulb",
                columns: table => new
                {
                    LampFK = table.Column<long>(type: "bigint", nullable: false),
                    BulbFK = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LambBulb", x => new { x.LampFK, x.BulbFK });
                    table.ForeignKey(
                        name: "FK_LambBulb_Bulbs_BulbFK",
                        column: x => x.BulbFK,
                        principalTable: "Bulbs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LambBulb_Lamps_LampFK",
                        column: x => x.LampFK,
                        principalTable: "Lamps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LambBulb_BulbFK",
                table: "LambBulb",
                column: "BulbFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LambBulb");
        }
    }
}
