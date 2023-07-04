using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherReportDAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebId = table.Column<int>(type: "int", nullable: false),
                    Timezone = table.Column<int>(type: "int", nullable: false),
                    Cod = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeatherReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Coordinates = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeatherData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeatherDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Visibility = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherReport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CitiesReports",
                columns: table => new
                {
                    CitiesId = table.Column<int>(type: "int", nullable: false),
                    WeatherReportsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitiesReports", x => new { x.CitiesId, x.WeatherReportsId });
                    table.ForeignKey(
                        name: "FK_CitiesReports_Cities_CitiesId",
                        column: x => x.CitiesId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CitiesReports_WeatherReport_WeatherReportsId",
                        column: x => x.WeatherReportsId,
                        principalTable: "WeatherReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CitiesReports_WeatherReportsId",
                table: "CitiesReports",
                column: "WeatherReportsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CitiesReports");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "WeatherReport");
        }
    }
}
