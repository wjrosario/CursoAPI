using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiLibro.Migrations
{
    public partial class relacionLibroFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "AutorId",
                table: "Libro",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Libro_AutorId",
                table: "Libro",
                column: "AutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Autor_AutorId",
                table: "Libro",
                column: "AutorId",
                principalTable: "Autor",
                principalColumn: "IdAutor",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Autor_AutorId",
                table: "Libro");

            migrationBuilder.DropIndex(
                name: "IX_Libro_AutorId",
                table: "Libro");

            migrationBuilder.DropColumn(
                name: "AutorId",
                table: "Libro");

            migrationBuilder.AddColumn<int>(
                name: "AutorIdAutor",
                table: "Libro",
                type: "int",
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
    }
}
