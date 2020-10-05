using Microsoft.EntityFrameworkCore.Migrations;

namespace Lekker.Kort.Repository.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Lekker");

            migrationBuilder.CreateTable(
                name: "ShortenedUrls",
                schema: "Lekker",
                columns: table => new
                {
                    Key = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortenedUrls", x => x.Key);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShortenedUrls",
                schema: "Lekker");
        }
    }
}
