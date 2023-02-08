using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiLibro.Migrations
{
    public partial class addColumAutor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TarjetaCredito",
                table: "Autor",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TarjetaCredito",
                table: "Autor");
        }
    }
}
