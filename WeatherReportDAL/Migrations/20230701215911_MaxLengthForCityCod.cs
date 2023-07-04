using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherReportDAL.Migrations
{
    /// <inheritdoc />
    public partial class MaxLengthForCityCod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitiesReports_WeatherReport_WeatherReportsId",
                table: "CitiesReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeatherReport",
                table: "WeatherReport");

            migrationBuilder.RenameTable(
                name: "WeatherReport",
                newName: "WeatherReports");

            migrationBuilder.AlterColumn<string>(
                name: "Cod",
                table: "Cities",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeatherReports",
                table: "WeatherReports",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CitiesReports_WeatherReports_WeatherReportsId",
                table: "CitiesReports",
                column: "WeatherReportsId",
                principalTable: "WeatherReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitiesReports_WeatherReports_WeatherReportsId",
                table: "CitiesReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeatherReports",
                table: "WeatherReports");

            migrationBuilder.RenameTable(
                name: "WeatherReports",
                newName: "WeatherReport");

            migrationBuilder.AlterColumn<string>(
                name: "Cod",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeatherReport",
                table: "WeatherReport",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CitiesReports_WeatherReport_WeatherReportsId",
                table: "CitiesReports",
                column: "WeatherReportsId",
                principalTable: "WeatherReport",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
