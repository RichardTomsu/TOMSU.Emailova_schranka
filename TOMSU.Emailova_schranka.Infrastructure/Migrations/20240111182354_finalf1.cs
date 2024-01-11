using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TOMSU.Emailova_schranka.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class finalf1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cil_adresa",
                table: "Messages",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Cil_adresa",
                value: "dads");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Cil_adresa",
                value: "dadsadsad");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cil_adresa",
                table: "Messages");
        }
    }
}
