using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiLibro.Migrations
{
    public partial class RelacionLibroEditorialFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Libro_EditorialId",
                table: "Libro",
                column: "EditorialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Editorial_EditorialId",
                table: "Libro",
                column: "EditorialId",
                principalTable: "Editorial",
                principalColumn: "IdEditorial",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Editorial_EditorialId",
                table: "Libro");

            migrationBuilder.DropIndex(
                name: "IX_Libro_EditorialId",
                table: "Libro");
        }
    }
}
