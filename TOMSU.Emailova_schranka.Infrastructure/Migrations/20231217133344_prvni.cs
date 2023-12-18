using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TOMSU.Emailova_schranka.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class prvni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserName",
                value: "admin@emailik.cz");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserName",
                value: "admin");
        }
    }
}
