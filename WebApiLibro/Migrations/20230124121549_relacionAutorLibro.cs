using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiLibro.Migrations
{
    public partial class relacionAutorLibro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AutorIdAutor",
                table: "Libro",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Libro_AutorIdAutor",
                table: "Libro",
                column: "AutorIdAutor");

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Autor_AutorIdAutor",
                table: "Libro",
                column: "AutorIdAutor",
                principalTable: "Autor",
                principalColumn: "IdAutor",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Autor_AutorIdAutor",
                table: "Libro");

            migrationBuilder.DropIndex(
                name: "IX_Libro_AutorIdAutor",
                table: "Libro");

            migrationBuilder.DropColumn(
                name: "AutorIdAutor",
                table: "Libro");
        }
    }
}
