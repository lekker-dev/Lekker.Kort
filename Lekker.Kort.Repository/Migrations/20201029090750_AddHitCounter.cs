using Microsoft.EntityFrameworkCore.Migrations;

namespace Lekker.Kort.Repository.Migrations
{
    public partial class AddHitCounter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hits",
                schema: "Lekker",
                columns: table => new
                {
                    Key = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    ShortenedUrlKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hits", x => x.Key);
                    table.ForeignKey(
                        name: "FK_Hits_ShortenedUrls_ShortenedUrlKey",
                        column: x => x.ShortenedUrlKey,
                        principalSchema: "Lekker",
                        principalTable: "ShortenedUrls",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hits_ShortenedUrlKey",
                schema: "Lekker",
                table: "Hits",
                column: "ShortenedUrlKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hits",
                schema: "Lekker");
        }
    }
}
