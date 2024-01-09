using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TOMSU.Emailova_schranka.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FinalMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Messages");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Odeslani",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Spam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Uzivatel = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Blokovany_Uzivatel = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spam", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Odeslani",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: "Send");

            migrationBuilder.InsertData(
                table: "Spam",
                columns: new[] { "Id", "Blokovany_Uzivatel", "Uzivatel" },
                values: new object[] { 1, "Title", "Blakijdhalhfssjfah" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spam");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Odeslani");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Messages",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: "Send");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: "Send");
        }
    }
}
